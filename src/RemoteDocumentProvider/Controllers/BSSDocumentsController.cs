using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using RemoteDocumentProvider.SealSignBSSTypes;
using Newtonsoft.Json;
using RemoteDocumentProvider.SealSignDSSTypes;
using RemoteDocumentProvider.Models;
using Microsoft.AspNetCore.WebUtilities;

namespace RemoteDocumentProvider.Controllers
{
    //[Authorize]
    public class BSSDocumentsController : Controller
    {
        // GET api/BSSdocuments/qlkfjdksafjweoi=
        [Route("api/[controller]/{id}")]
        [HttpGet]
        public IActionResult Get(string id)
        {
            return Get(id, string.Empty);
        }

        // GET api/BSSdocuments/qlkfjdksafjweoi=/alkjdqkjweio=
        [Route("api/[controller]/{id}/{parameters}")]
        [HttpGet]
        public IActionResult Get(string id, string parameters)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("id");

#pragma warning disable CS1701 // Assuming assembly reference matches identity
            var documentUrl = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(id));
            var providerParameters = string.IsNullOrEmpty(parameters) ? string.Empty : Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(parameters));
            
            var documentBytes = System.IO.File.ReadAllBytes(@"d:\test\sample.pdf");
#pragma warning restore CS1701 // Assuming assembly reference matches identity

            SealSignBSSTypes.GetSigningDocumentResponse response = new SealSignBSSTypes.GetSigningDocumentResponse();

            response.BiometricOptions = BiometricSignatureFlags.Default;
            response.BiometricParameters = new BiometricSignatureParameters();
            response.BiometricSignatureType = BiometricSignatureType.Default;
            response.DettachedSignature = null;
            response.Document = documentBytes;
            response.Options = SignatureFlags.Default;
            response.Parameters = new SignatureParameters();
            response.SignatureProfile = SignatureProfile.PDF;

#pragma warning disable CS1701 // Assuming assembly reference matches identity
            return Ok(response);
#pragma warning restore CS1701 // Assuming assembly reference matches identity
        }

        // POST api/BSSDocuments/qlkfjdksafjweoi=
        [Route("api/[controller]/{id}")]
        [HttpPost]
        public IActionResult Post(string id, [FromBody]DocumentModel value)
        {
            return Post(id, string.Empty, value);
        }

        // POST api/BSSDocuments/qlkfjdksafjweoi=/alkjdqkjweio=
        [Route("api/[controller]/{id}/{parameters}")]
        [HttpPost]
        public IActionResult Post(string id, string parameters, [FromBody]DocumentModel value)
        {
#pragma warning disable CS1701 // Assuming assembly reference matches identity
            var documentUrl = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(id));
            var providerParameters = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(parameters));
#pragma warning restore CS1701 // Assuming assembly reference matches identity

            var documentBytes = Convert.FromBase64String(value.Document);

            System.IO.File.WriteAllBytes(@"d:\test\sample.signed.pdf", documentBytes);

            return NoContent();
        }

    }
}
