using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Models.Response
{
    public class TeamResponse
    {
        public int Count { get; set; }
        public Filter filter { get; set; }
        public Competition Competition { get; set; }
        public Season Season { get; set; }
        public Team[] Teams { get; set; }
    }
}