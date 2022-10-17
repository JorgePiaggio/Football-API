using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FootballAPI.Models
{
    public class Team
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Tla { get; set; }
        public string Crest { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public int? Founded { get; set; }
        public string ClubColours { get; set; }
        public string Venue { get; set; }
        public int MarketValue { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public Competition[] RunningCompetitions { get; set; }
        public Player[] Squad { get; set; }
    }
}