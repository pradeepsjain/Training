using Microsoft.EntityFrameworkCore;
using Pradeep.MVVM.EntityLayer;

namespace Pradeep.MVVM.DataLayer
{
    public partial class AdvWorksDbContext : DbContext  
    {    
        public AdvWorksDbContext(DbContextOptions<AdvWorksDbContext> options) : base(options)
        {
        }
        
        public virtual DbSet<Product> Products { get; set; }  
    }
}
