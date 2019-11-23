using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectMVC.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public String TeamName { get; set; }
        public List<Player> players { get; set; }
    }
}
