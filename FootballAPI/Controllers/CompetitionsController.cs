using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FootballAPI.Data;
using FootballAPI.Models;
using FootballAPI.Services;

namespace FootballAPI.Controllers
{
    public class CompetitionsController : ApiController
    {
        private FootballDbContext db = new FootballDbContext();

        // GET: api/Competitions
        public IQueryable<Competition> GetCompetitions()
        {
            return db.Competitions;
        }

        // GET: api/Competitions/5
        [ResponseType(typeof(Competition))]
        public async Task<IHttpActionResult> GetCompetition(int id)
        {
            Competition competition = await db.Competitions.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }

            return Ok(competition);
        }

        // PUT: api/Competitions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCompetition(int id, Competition competition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != competition.Id)
            {
                return BadRequest();
            }

            db.Entry(competition).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Competitions
        [ResponseType(typeof(Competition))]
        public async Task<IHttpActionResult> PostCompetition(Competition competition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // detach area if exists in db
            var area = db.Areas.Find(competition.Area.Id);
            if (area != null)
            {
                competition.AreaId = area.Id;
                db.Entry(area).State = EntityState.Detached;
                competition.Area = null;
            }

            // add currentSeason
            var season = db.Seasons.Add(competition.Season);
            competition.SeasonId = season.Id;

            // add competition
            db.Competitions.Add(competition);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = competition.Id }, competition);
        }

        // DELETE: api/Competitions/5
        [ResponseType(typeof(Competition))]
        public async Task<IHttpActionResult> DeleteCompetition(int id)
        {
            Competition competition = await db.Competitions.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }

            db.Competitions.Remove(competition);
            await db.SaveChangesAsync();

            return Ok(competition);
        }

        [Route("api/competitions/getapi")]
        public async Task<IHttpActionResult> GetApiCompetitions()
        {
            if (db.Competitions.Count() == 0)
            {
                var service = new ApiService();
                var competitions = service.FetchCompetitions();
                foreach (var item in competitions)
                {
                    await PostCompetition(item);
                }
            }
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompetitionExists(int id)
        {
            return db.Competitions.Count(e => e.Id == id) > 0;
        }

    }
}