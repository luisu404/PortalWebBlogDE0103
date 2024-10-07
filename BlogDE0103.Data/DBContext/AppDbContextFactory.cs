using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;


namespace BlogDE0103.Data.DBContext
{
    class AppDBContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var OptionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            OptionBuilder.UseSqlServer("Data Source=LUISURBAEZ\\ELISERVER; Initial Catalog=BlogDE0103DB; Integrated Security=True");
            return new AppDbContext(OptionBuilder.Options);
        }
    }
}
