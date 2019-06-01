using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenMercadolibreMutantes.Models
{
    public class MutantsDbContext : DbContext
    {
        public MutantsDbContext(DbContextOptions options) : base(options)
        {
        }

        public MutantsDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<MutantAnalysisLog>().Property(log => log.Dna)
                .HasConversion(v => JsonConvert.SerializeObject(v), v => JsonConvert.DeserializeObject<string[]>(v));

        }

        public virtual DbSet<MutantAnalysisLog> MutantAnalysisLogs { get; set; }
    }
}
