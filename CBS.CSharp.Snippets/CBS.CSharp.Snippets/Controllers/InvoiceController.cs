using CBS.CSharp.Snippets.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CBS.CSharp.Snippets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        /// <summary>
        /// Make a sample call to create invoice
        /// </summary>
        /// <returns></returns>
        [Route("create-invoice")]
        public async Task<IActionResult> CreateInvoiceAsync()
        {
            string invoiceCreationUrl = "https://URL/api/v1/invoice/create";

            var createInvoicePayload = GetSampleCreateInvoicePayload();

            UriBuilder uri = new(invoiceCreationUrl);

            // Create Http client 
            using var client = new HttpClient();
            HttpRequestMessage request = new(HttpMethod.Post, uri.ToString());
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Serialize request payload 
            // NOTE: Newtonsoft.Json package is required 

            request.Content = new StringContent(JsonConvert.SerializeObject(createInvoicePayload), Encoding.UTF8, "application/json");

            // Send Request
            var response = await client.SendAsync(request);

            // Read response as string
            string responseStringContent = await response.Content.ReadAsStringAsync();

            dynamic responeContentObj = JsonConvert.DeserializeObject(responseStringContent);

            // Check the error object
            if (responeContentObj.Error == true)
            {
                var createInvoiceErrorRootObject = JsonConvert.DeserializeObject<CreateInvoiceErrorRootObject>(responseStringContent);

                // Error logic
            }
            else if (responeContentObj.Error == false)
            {
                var createInvoiceSuccessRootObject = JsonConvert.DeserializeObject<CreateInvoiceSuccessRootObject>(responseStringContent);
                // Success logic 

            }

            return Ok();
        }

        private static CreateInvoiceDTO GetSampleCreateInvoicePayload()
        {
            return new CreateInvoiceDTO
            {
                RevenueHeadId = 16,
                TaxEntityInvoice = new TaxEntityInvoice
                {
                    TaxEntity = new TaxEntity
                    {
                        Recipient = "Tax Payer",
                        Email = "taxpayer@example.com",
                        Address = "API local",
                        PhoneNumber = "0804832361",
                        TaxPayerIdentificationNumber = "7777711",
                        RCNumber = "00329",
                        PayerId = "FG-00324"
                    },
                    Amount = 8903,
                    InvoiceDescription = "Invoice Description here",
                    CategoryId = 1
                },
                ExternalRefNumber = null,
                RequestReference = "Unique ref per request, must be deterministic",
                CallBackURL = "add a call back URL if payment notification is required"
            };
        }
    }
}
