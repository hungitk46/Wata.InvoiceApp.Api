using MediatR;
using System.Collections.Generic;
using Wata.InvoiceApp.Application.Invoices.ViewModels;

namespace Wata.InvoiceApp.Application.Invoices.Queries
{
    public class GetUserIncoiceQuery : IRequest<IList<InvoiceVm>>
    {
        public string User { get; set; }
    }
}
