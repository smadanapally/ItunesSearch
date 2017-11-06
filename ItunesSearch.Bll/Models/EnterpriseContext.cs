using ItunesSearch.Bll.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItunesSearch.Bll.Models
{
    public class EnterpriseContext : DbContext 
    {
        public EnterpriseContext()
            : base("name=EnterpriseContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

        public virtual DbSet<SearchResultDTO> SearchResultCounters { get; set; }
    }
}
