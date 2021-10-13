using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBS.CSharp.Snippets.DTO
{
    public class BaseCreateInvoiceObject
    {
        public bool Error { get; set; }
        public string ErrorCode { get; set; }
    }

    public class CreateInvoiceErrorResponseObject
    {
        public string ErrorMessage { get; set; }
        public string FieldName { get; set; }
    }

    public class CreateInvoiceErrorRootObject : BaseCreateInvoiceObject
    {
        public List<CreateInvoiceErrorResponseObject> ResponseObject { get; set; }
    }

    public class CreateInvoiceSuccessResponseObject
    {
        public int AmountDue { get; set; }
        public int CustomerId { get; set; }
        public int CustomerPrimaryContactId { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public object ExternalRefNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoicePreviewUrl { get; set; }
        public string MDAName { get; set; }
        public string PayerId { get; set; }
        public string PaymentURL { get; set; }
        public string PhoneNumber { get; set; }
        public string Recipient { get; set; }
        public string RevenueHeadName { get; set; }
        public string TIN { get; set; }
    }
    public class CreateInvoiceSuccessRootObject : BaseCreateInvoiceObject
    {
        public CreateInvoiceSuccessResponseObject ResponseObject { get; set; }
    }
}
