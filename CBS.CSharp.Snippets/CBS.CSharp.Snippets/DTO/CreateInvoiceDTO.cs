using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBS.CSharp.Snippets.DTO
{
    public class TaxEntity
    {
        public string Recipient { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxPayerIdentificationNumber { get; set; }
        public string RCNumber { get; set; }
        public string PayerId { get; set; }
    }

    public class TaxEntityInvoice
    {
        public TaxEntity TaxEntity { get; set; }
        public int Amount { get; set; }
        public string InvoiceDescription { get; set; }
        public int CategoryId { get; set; }
    }

    public class CreateInvoiceDTO
    {
        public int RevenueHeadId { get; set; }
        public TaxEntityInvoice TaxEntityInvoice { get; set; }
        public string ExternalRefNumber { get; set; }
        public string RequestReference { get; set; }
        public string CallBackURL { get; set; }
    }


}
