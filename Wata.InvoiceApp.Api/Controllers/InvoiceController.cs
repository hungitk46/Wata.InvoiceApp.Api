using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wata.InvoiceApp.Application.Invoices.Commands;

namespace Wata.InvoiceApp.Api.Controllers
{
    [Authorize]
    public class InvoiceController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateInvoiceCommand createInvoiceCommand)
        {
            return await Mediator.Send(createInvoiceCommand);
        }
    }
}
