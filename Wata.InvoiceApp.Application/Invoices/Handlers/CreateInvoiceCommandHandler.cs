using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wata.InvoiceApp.Application.Common.Interfaces;
using Wata.InvoiceApp.Application.Invoices.Commands;
using Wata.InvoiceApp.Domain.Entities;

namespace Wata.InvoiceApp.Application.Invoices.Handlers
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateInvoiceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Implement Handle method of IRequestHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var entity = new Invoice
            {
                AmountPaid = request.AmountPaid,
                Date = request.Date,
                DueDate = request.DueDate,
                Discount = request.Discount,
                DiscountType = request.DiscountType,
                From = request.From,
                InvoiceNumber = request.InvoiceNumber,
                Logo = request.Logo,
                PaymentTerms = request.PaymentTerms,
                Tax = request.Tax,
                TaxType = request.TaxType,
                To = request.To,
                InvoiceItems = request.InvoiceItems.Select(i => new InvoiceItem
                {
                    Item = i.Item,
                    Quantity = i.Quantity,
                    Rate = i.Rate
                }).ToList()
            };

            _context.Invoices.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
