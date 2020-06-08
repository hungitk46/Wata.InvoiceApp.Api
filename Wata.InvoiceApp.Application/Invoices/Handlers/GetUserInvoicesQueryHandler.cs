using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wata.InvoiceApp.Application.Common.Interfaces;
using Wata.InvoiceApp.Application.Invoices.Queries;
using Wata.InvoiceApp.Application.Invoices.ViewModels;

namespace Wata.InvoiceApp.Application.Invoices.Handlers
{
    public class GetUserInvoicesQueryHandler : IRequestHandler<GetUserIncoiceQuery, IList<InvoiceVm>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetUserInvoicesQueryHandler(IApplicationDbContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }
        public async  Task<IList<InvoiceVm>> Handle(GetUserIncoiceQuery request, CancellationToken cancellationToken)
        {
            var result = new List<InvoiceVm>();
            var invoices = await _context.Invoices.Include(i => i.InvoiceItems)
                .Where(i => i.CreatedBy == request.User).ToListAsync();
            if(invoices != null)
            {
                result = _mapper.Map<List<InvoiceVm>>(invoices);
            }
            return result;
            //var vm = invoices.Select(i => new InvoiceVm
            //{
            //    AmountPaid = i.AmountPaid,
            //    Discount = i.Discount,
            //    Date = i.Date,
            //    DiscountType = i.DiscountType,
            //    DueDate = i.DueDate,
            //    From = i.From,
            //    Id = i.Id,
            //    InvoiceNumber = i.InvoiceNumber,
            //    Logo = i.Logo,
            //    PaymentTerms = i.PaymentTerms,
            //    Tax = i.Tax,
            //    TaxType = i.TaxType,
            //    To = i.To,
            //    InvoiceItems = i.InvoiceItems.Select(it => new InvoiceItemVm
            //    {
            //        Id = it.Id,
            //        Item = it.Item,
            //        Quantity = it.Quantity,
            //        Rate = it.Rate
            //    }).ToList()
            //}).ToList();

            //return vm;
        }
    }
}
