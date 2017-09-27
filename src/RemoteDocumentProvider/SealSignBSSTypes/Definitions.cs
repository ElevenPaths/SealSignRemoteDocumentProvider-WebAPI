using RemoteDocumentProvider.SealSignDSSTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteDocumentProvider.SealSignBSSTypes
{
    class GetSigningDocumentResponse
    {
        public SignatureProfile SignatureProfile { get; set; }
        public BiometricSignatureType BiometricSignatureType { get; set; }
        public BiometricSignatureFlags BiometricOptions { get; set; }
        public BiometricSignatureParameters BiometricParameters { get; set; }
        public SignatureFlags Options { get; set; }
        public SignatureParameters Parameters { get; set; }
        public byte[] DettachedSignature { get; set; }
        public byte[] Document { get; set; }
    }

    public enum BiometricSignatureType
    {
        Default = 0,
        Signature = 1
    }

    [Flags]
    public enum BiometricSignatureFlags
    {
        None = 0,
        Default = 1,
        VerifyIdentity = 2,
        IncludeTimestamp = 4,
        BiometricImageAsWidgetBackground = 8,
        IncludeHashWatermark = 16,
        IncludeAttachments = 32,
        ExcludeDocumentMetadata = 64,
        IncludeIdWatermark = 128,
        IncludeAccountWatermark = 256,
        XMLBiometricSignatureDetached = 512
    }       

    public class BiometricSignatureParameters
    {
        public BiometricImageParameters imageParameters;
        public BiometricImageParameters[] advancedImageParameters;
        public string documentPassword;
    }

    public class BiometricImageParameters
    {
        public string attachmentName;
        public bool signatureVisible;
        public string imageTokenText;
        public int offsetX;
        public int offsetY;
        public bool autoSize;
        public int height;
        public int width;
        public int rotate;
        public bool onAllPages;
        public int onPage;
        public bool onLastPage;
        public int pageOffset;
    }
}
