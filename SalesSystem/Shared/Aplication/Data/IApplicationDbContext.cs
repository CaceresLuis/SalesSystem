using Microsoft.EntityFrameworkCore;
using SalesSystem.Categories.Domain;

namespace SalesSystem.Shared.Aplication.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
