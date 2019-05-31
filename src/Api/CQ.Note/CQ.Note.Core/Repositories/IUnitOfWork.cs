using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQ.Note.Core.Repositories
{
    public interface IUnitOfWork
    {

        DbContext DbContext { get; }

        int Commit();

        Task<int> CommitAsync();
    }
}
