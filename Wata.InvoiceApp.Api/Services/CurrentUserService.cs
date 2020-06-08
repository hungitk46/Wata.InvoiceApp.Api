using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Wata.InvoiceApp.Application.Common.Interfaces;

namespace Wata.InvoiceApp.Api.Services
{
    public class CurrentUserService: ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public string UserId { get; }
    }
}
