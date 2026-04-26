using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MFBlog.Data
{
    public class MFBlogContextFactory : IDesignTimeDbContextFactory<MFBlogContext>
    {
        public MFBlogContext CreateDbContext(string[] args)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "..", "MFBlog.Data");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.Exists(path) ? path : Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            var builder = new DbContextOptionsBuilder<MFBlogContext>();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new MFBlogContext(builder.Options);
        }
    }
}
