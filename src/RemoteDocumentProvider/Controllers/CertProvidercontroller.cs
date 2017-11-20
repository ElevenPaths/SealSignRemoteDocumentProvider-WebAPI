using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RemoteDocumentProvider.SealSignSQSTypes;
using Newtonsoft.Json;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using RemoteDocumentProvider.SealSignDSSTypes;
using RemoteDocumentProvider.SealSignBSSTypes;
using RemoteDocumentProvider.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RemoteDocumentProvider.Controllers
{   
    //[Authorize]
    public class CertProviderController : Controller
    {        
        [Route("api/[controller]/behavior/{jobId}/{jobTitle}")]
        [HttpPost]
        public string GetBehavior(int jobId, string jobTitle, [FromBody] GetBehaviorModel bodyData)
        {
            var jobTitleDecoded = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(jobTitle));            
            var documentBytes = WebEncoders.Base64UrlDecode(bodyData.Document);

            SignatureClientBehaviour[] signatureClientBehaviour = new SignatureClientBehaviour[1];

            signatureClientBehaviour[0] = new SignatureClientBehaviour();

            signatureClientBehaviour[0].signatureId = "";
            signatureClientBehaviour[0].signatureAccount = "";
            signatureClientBehaviour[0].providerParameter = "";
            signatureClientBehaviour[0].signatureWindowTitle = "Firme Aquí . . .";

            return JsonConvert.SerializeObject(signatureClientBehaviour);
        }

        [Route("api/[controller]/parameters/{signatureIndex}/{originalJobId}/{jobTitle}")]
        [HttpPost]
        public IActionResult GetSignatureParameters(int signatureIndex, int originalJobId, string jobTitle, [FromBody] GetSignatureParameterModel bodyData)
        {            
            var jobTitleDecoded = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(jobTitle));

            return Ok(new GetSignatureParametersResponse()
            {
                SignatureProfile = SignatureProfile.PDF,
                BiometricSignatureType = BiometricSignatureType.Default,
                BiometricOptions = BiometricSignatureFlags.Default,
                BiometricParameters = null,
                Options = SignatureFlags.Default,
                Parameters = null,
                DetachedSignature = null
            });           
        }

        private class GetSignatureParametersResponse
        {
            public BiometricSignatureFlags BiometricOptions { get; set; }
            public BiometricImageParameters BiometricParameters { get; set; }
            public BiometricSignatureType BiometricSignatureType { get; set; }
            public byte[] DetachedSignature { get; set; }
            public SignatureFlags Options { get; set; }
            public SignatureParameters Parameters { get; set; }
            public SignatureProfile SignatureProfile { get; set; }
        }

        [Route("api/[controller]/document/{signatureIndex}/{originalJobId}/{jobTitle}")]
        [HttpPost]
        public void SetSignedDocument(int signatureIndex,                        
            int originalJobId, 
            string jobTitle,             
            [FromBody]GetSignatureParameterModel bodyData)
        {            
            var jobTitleDecoded = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(jobTitle));

            var documentBytes = Convert.FromBase64String(bodyData.Document);
        }        
    }
}
