using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuickType;

namespace SchoolHousing.Models
{
    public class SchoolHousingContext : DbContext
    {
        public SchoolHousingContext (DbContextOptions<SchoolHousingContext> options)
            : base(options)
        {
        }

        public DbSet<QuickType.AffordableHouse> AffordableHouse { get; set; }
    }
}
