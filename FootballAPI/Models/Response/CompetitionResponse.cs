using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Models.Response
{
    public class CompetitionResponse
    {
        public int Count { get; set; }
        public Filter filter{ get; set; }
        public Competition[] Competitions { get; set; }
    }
}