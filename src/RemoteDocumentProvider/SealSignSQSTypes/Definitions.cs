using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteDocumentProvider.SealSignSQSTypes
{
    public class SignatureClientBehaviour
    {
        public string uri;
        public string signatureId;
        public string signatureAccount;
        public string providerParameter;
        public string signatureWindowTitle;
        public STUConfiguration stuConfiguration;
    }

    public class STUConfiguration
    {
        public byte[] Image;
        public STUButtonDefinition OKButton;
        public STUButtonDefinition CancelButton;
    }

    public class STUButtonDefinition
    {        
        public int x1;        
        public int y1;        
        public int x2;        
        public int y2;
    }
}
