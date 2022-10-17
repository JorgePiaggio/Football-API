using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Models
{
    public class Player : Person
    {
        public string Position { get; set; }
        public short ShirtNumber { get; set; }
        public Team Team { get; set; }
    }
}