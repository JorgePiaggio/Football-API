using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FootballAPI.Models
{
    public class Competition
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Emblem { get; set; }
        public string Plan { get; set; }
        public int? SeasonId { get; set; }
        public int AreaId { get; set; }
        public short NumberOfAvailableSeasons { get; set; }
        public Area Area { get; set; }
        [JsonProperty("CurrentSeason")]
        public Season Season { get; set; }

    }
}