using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wata.InvoiceApp.Application.Common.Interfaces;
using Wata.InvoiceApp.Application.Invoices.Commands;
using Wata.InvoiceApp.Application.Invoices.Queries;
using Wata.InvoiceApp.Application.Invoices.ViewModels;

namespace Wata.InvoiceApp.Api.Controllers
{
    [Authorize]
    public class InvoiceController : ApiController
    {
        private readonly ICurrentUserService _currentUserService;
        public InvoiceController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateInvoiceCommand createInvoiceCommand)
        {
            return await Mediator.Send(createInvoiceCommand);
        }
        [HttpGet]
        public async Task<IList<InvoiceVm>> Get()
        {
            return await Mediator.Send(new GetUserIncoiceQuery
            {
                User = _currentUserService.UserId
            });
        }
    }
}
