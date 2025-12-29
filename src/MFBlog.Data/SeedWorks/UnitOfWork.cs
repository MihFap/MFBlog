using MFBlog.Core.SeedWorks;

namespace MFBlog.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MFBlogContext _context;

        public UnitOfWork(MFBlogContext context)
        {
            _context = context;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
