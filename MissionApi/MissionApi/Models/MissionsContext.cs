using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionApi.Models
{
    public class MissionsContext : DbContext
    {
        public DbSet<Mission> Missions { get; set; }
        public MissionsContext(DbContextOptions<MissionsContext> options)
            : base(options)
        { }
    }
}
