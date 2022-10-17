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
    public class TeamsController : ApiController
    {
        private FootballDbContext db = new FootballDbContext();

        // GET: api/Teams
        public IQueryable<Team> GetTeams()
        {
            return db.Teams;
        }

        // GET: api/Teams/5
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> GetTeam(int id)
        {
            Team team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        // PUT: api/Teams/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTeam(int id, Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.Id)
            {
                return BadRequest();
            }

            db.Entry(team).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/Teams
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> PostTeam(Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var area = db.Areas.Find(team.Area.Id);
            if (area != null)
            {
                team.AreaId = area.Id;
                db.Entry(area).State = EntityState.Detached;
                team.Area = null;
            }
            db.Teams.Add(team);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = team.Id }, team);
        }

        // DELETE: api/Teams/5
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> DeleteTeam(int id)
        {
            Team team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            db.Teams.Remove(team);
            await db.SaveChangesAsync();

            return Ok(team);
        }

        [Route("api/teams/getRandomTeams")]
        public async Task<IHttpActionResult> GetRandomTeams()
        {
            if (db.Teams.Count() == 0)
            {
                var service = new ApiService();
                var teams = service.FetchTeams();
                var teamIds = new List<int>();
                
                // select 10 random teams
                foreach (var item in teams)
                {
                    teamIds.Add(item.Id);
                }

                teamIds = teamIds.OrderBy(r => Guid.NewGuid()).Take(10).ToList();

                // save teams and players
                foreach (var item in teams)
                {
                    if (teamIds.Contains(item.Id))
                    {
                        await PostTeam(item);

                        foreach (var player in item.Squad)
                        {
                            // add first & last name
                            var splitName = player.Name.Split(' ');
                            player.FirstName = splitName[0];
                            player.LastName = splitName.Count() > 1 ? splitName[1] : "";

                            // add team to player
                            player.Team = item;

                            db.Players.Add(player);
                        }
                        await db.SaveChangesAsync();
                    }
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

        private bool TeamExists(int id)
        {
            return db.Teams.Count(e => e.Id == id) > 0;
        }
    }
}