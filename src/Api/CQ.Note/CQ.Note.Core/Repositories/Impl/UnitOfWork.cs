using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQ.Note.Core.Repositories.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
       
        public UnitOfWork(NoteDbContext context)
        {
            DbContext = context;
        }


        public DbContext DbContext { get; private set; }


        public int Commit()
        {
            return DbContext.SaveChanges();
        }


        public async Task<int> CommitAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}
