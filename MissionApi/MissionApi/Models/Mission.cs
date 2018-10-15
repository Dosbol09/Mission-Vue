using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionApi.Models
{
    public class Mission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tegs { get; set; }
        public string Description { get; set; }
        public bool IsComplate { get; set; }
    }
}
