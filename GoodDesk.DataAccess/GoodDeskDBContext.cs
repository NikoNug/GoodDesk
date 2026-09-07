using GoodDesk.DataModel;
using Microsoft.EntityFrameworkCore;

namespace GoodDesk.DataAccess
{
    public class GoodDeskDBContext : DbContext
    {
        public GoodDeskDBContext(
            DbContextOptions<GoodDeskDBContext> options) 
            : base(options) 
        { 
        }

        public virtual DbSet<TblMCategory> TblMCategories { get; set; } = null!;
    }
}
