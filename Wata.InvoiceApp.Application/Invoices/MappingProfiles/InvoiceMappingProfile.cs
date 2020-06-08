using AutoMapper;
using Wata.InvoiceApp.Application.Invoices.Commands;
using Wata.InvoiceApp.Application.Invoices.ViewModels;
using Wata.InvoiceApp.Domain.Entities;

namespace Wata.InvoiceApp.Application.Invoices.MappingProfiles
{
    public class InvoiceMappingProfile: Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceVm>();
            CreateMap<InvoiceItem, InvoiceItemVm>().ConstructUsing(i => new InvoiceItemVm { 
                Id = i.Id,
                Item = i.Item,
                Quantity = i.Quantity,
                Rate = i.Rate,
            });

            CreateMap<InvoiceVm, Invoice>();
            CreateMap<InvoiceItemVm, InvoiceItem>();

            CreateMap<CreateInvoiceCommand, Invoice>();
        }

    }
}
