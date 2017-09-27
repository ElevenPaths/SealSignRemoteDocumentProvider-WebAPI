using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteDocumentProvider.Models
{
    public class DocumentModel
    {
        public string Document { get; set; } 
    }

    public class GetBehaviorModel
    {
        public string Metadata { get; set; }
        public string Document { get; set; }
    }

    public class GetSignatureParameterModel
    {
        public string Uri { get; set; }
        public string ProviderParameter { get; set; }
        public string JobMetadata { get; set; }
        public string Document { get; set; }
    }    
}
