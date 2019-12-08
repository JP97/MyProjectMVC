using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectMVC.Models.ViewModels
{
    public class Teamwithplayer
    {
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Player> Players { get; set; }
    }
}
