using System;
using System.Collections.Generic;
using System.Text;

namespace Wata.InvoiceApp.Domain.Common
{
    public class AuditEntity
    {
        public string CreateBy { get; set; }
        public DateTime Created { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? Updated { get; set; }
    }
}
