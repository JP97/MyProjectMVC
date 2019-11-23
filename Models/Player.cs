using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectMVC.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public Team Team { get; set; }
    }
}
