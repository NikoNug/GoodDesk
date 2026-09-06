using Microsoft.EntityFrameworkCore;

namespace GoodDesk.DataModel
{
    public class GoodDeskContext : DbContext
    {
        public GoodDeskContext() { }
        public GoodDeskContext(DbContextOptions<GoodDeskContext> options) : base(options) { }

        //public virtual DbSet<xxx> xxx { get; set; } = null!;
    }
}
