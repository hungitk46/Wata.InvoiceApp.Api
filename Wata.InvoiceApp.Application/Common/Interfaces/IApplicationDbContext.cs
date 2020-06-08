using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Wata.InvoiceApp.Domain.Entities;

namespace Wata.InvoiceApp.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Invoice> Invoices { get; set; }
        DbSet<InvoiceItem> InvoiceItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
