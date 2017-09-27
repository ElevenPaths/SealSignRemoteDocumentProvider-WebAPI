using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using RemoteDocumentProvider.Models;
using RemoteDocumentProvider.SealSignDSSTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDocumentProvider.Controllers
{
    //[Authorize]
    public class DSSDocumentsController : Controller
    {
        // GET api/DSSdocuments/qlkfjdksafjweoi=
        [Route("api/[controller]/{id}")]
        [HttpGet]
        public string Get(string id)
        {
            return Get(id, string.Empty);
        }

        // GET api/DSSdocuments/qlkfjdksafjweoi=/alkjdqkjweio=
        [Route("api/[controller]/{id}/{parameters}")]
        [HttpGet]        
        public string Get(string id, string parameters)
        {            
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("id");

#pragma warning disable CS1701 // Assuming assembly reference matches identity
            var documentUrl = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(id));
            var providerParameters = string.IsNullOrEmpty(parameters) ? string.Empty : Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(parameters));

            var documentBytes = System.IO.File.ReadAllBytes(@"d:\test\sample.pdf");
#pragma warning restore CS1701 // Assuming assembly reference matches identity

            GetSigningDocumentResponse response = new GetSigningDocumentResponse();

            response.DettachedSignature = null;
            response.Document = documentBytes;
            response.HashAlgorithm = HashAlgorithm.Default;
            response.Options = SignatureFlags.PDFAdESUseParametersInWidget | SignatureFlags.PDFAdESIncludeFontInWidget;
            response.Parameters = new SignatureParameters();
            
            response.Parameters.header = "ÑEÉâññsE(E)EE";
            response.Parameters.signerCaption = "This \u03C0";
            response.Parameters.signerInfo = "ÑñÑñÑñÑñ";
            response.Parameters.algorithmCaption = "ÑñÑñÑñÑ";
            response.Parameters.algorithmInfo = "Ñañañañañañañ";

            response.SignatureProfile = SignatureProfile.PDF;
            response.SignatureType = SignatureType.Default;

#pragma warning disable CS1701 // Assuming assembly reference matches identity
            return JsonConvert.SerializeObject(response);
#pragma warning restore CS1701 // Assuming assembly reference matches identity
        }

        // POST api/DSSDocuments/qlkfjdksafjweoi=
        [Route("api/[controller]/{id}")]
        [HttpPost]        
        public void Post(string id, [FromBody]DocumentModel value)
        {
            Post(id, string.Empty, value);
        }

        // POST api/DSSDocuments/qlkfjdksafjweoi=/alkjdqkjweio=
        [Route("api/[controller]/{id}/{parameters}")]
        [HttpPost]
        public void Post(string id, string parameters, [FromBody]DocumentModel value)
        {
#pragma warning disable CS1701 // Assuming assembly reference matches identity
            var documentUrl = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(id));
            var providerParameters = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(parameters));

            var documentBytes = Convert.FromBase64String(value.Document);

            System.IO.File.WriteAllBytes(@"d:\test\sample.signed.pdf", documentBytes);
#pragma warning restore CS1701 // Assuming assembly reference matches identity
        }

    }
}
