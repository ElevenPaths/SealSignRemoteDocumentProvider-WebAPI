using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteDocumentProvider.SealSignDSSTypes
{
    public class GetSigningDocumentResponse
    {
        public SignatureProfile SignatureProfile { get; set; }
        public SignatureType SignatureType { get; set; }
        public HashAlgorithm HashAlgorithm { get; set; }
        public SignatureFlags Options { get; set; }
        public SignatureParameters Parameters { get; set; }
        public byte[] DettachedSignature { get; set; }
        public byte[] Document { get; set; }
    }

    public enum SignatureType
    {
        Default = 0,
        Enveloped,
        Enveloping,
        Detached,
        DetachedInternal
    }

    public enum HashAlgorithm
    {
        Default = 0,
        RIPEMD160,
        MD5,
        SHA1,
        SHA256,
        SHA384,
        SHA512,
        SSL3
    }

    public enum SignatureProfile
    {
        Default = 0,
        CMS,
        CAdESBES,
        CAdEST,
        CAdESC,
        CAdESX,
        CAdESXL,
        CAdESA,
        XMLDigSig,
        XAdESBES,
        XAdEST,
        XAdESC,
        XAdESX,
        XAdESXL,
        XAdESA,
        PDF,
        PAdESBasic,
        PAdESBES,
        PAdESLTV,
        PAdESXML,
        Office
    }

    [Flags]
    public enum SignatureFlags
    {
        None = 0,
        Default = 1,
        ValidateChain = 2,
        CheckRevocationStatus = 4,
        XMLAddXPathRemoveSignatureTransform = 8,
        XMLAdESIncludeSignerRole = 16,
        XMLAdESExplicitPolicy = 32,
        XMLAdESXType2 = 64,
        CMSAdESExplicitPolicy = 128,
        CMSAdESXType2 = 256,
        PDFAdESIncludeTimestamp = 512,
        PDFAdESIncludeRevocationInfo = 1024,
        PDFAdESExplicitPolicy = 2048,
        IncludeLocation = 4096,
        XMLAdESVersion122 = 8192,
        XMLAdESIncludeKeyValue = 16384,
        XMLAdESVersion132 = 32768,
        PDFAdESUseParametersInWidget = 65536,
        XMLAdESPrettySignature = 131072,
        PDFAdESHideTimestampInWidget = 262144,
        XMLAdExcludeCertFromSignedProperties = 524288,
        PDFAdESIncludeFontInWidget = 1048576
    }

    public class SignatureParameters
    {
        public string reason { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string signerRole { get; set; }
        public string policyIdentifier { get; set; }
        public string policyDigest { get; set; }
        public string policyCMSQualifierURI { get; set; }
        public string reference { get; set; }
        public PDFSignatureParameters pdfParameters { get; set; }
        public int timestampServerId { get; set; }
        public int timestampBackupServerId { get; set; }
        public string header { get; set; }
        public string signerCaption { get; set; }
        public string signerInfo { get; set; }
        public string algorithmCaption { get; set; }
        public string algorithmInfo { get; set; }
        public string documentPassword { get; set; }
    }

    public class PDFSignatureParameters
    {
        public string PDFPassword { get; set; }
        public string PDFSignatureFieldName { get; set; }
        public bool PDFSignatureVisible { get; set; }
        public byte[] PDFSignatureBackground { get; set; }
        public bool PDFSignatureBackgroundStretch { get; set; }
        public int PDFSignatureBackgroundWidth { get; set; }
        public int PDFSignatureBackgroundHeight { get; set; }
        public bool PDFSignatureWidgetAutoPos { get; set; }
        public int PDFSignatureWidgetOffsetX { get; set; }
        public int PDFSignatureWidgetOffsetY { get; set; }
        public bool PDFSignatureWidgetAutoSize { get; set; }
        public int PDFSignatureWidgetHeight { get; set; }
        public int PDFSignatureWidgetWidth { get; set; }
        public int PDFSignatureWidgetRotate { get; set; }
        public bool PDFSignatureWidgetOnAllPages { get; set; }
        public int PDFSignatureWidgetOnPage { get; set; }
        public bool PDFSignatureFilterOnlyDocSignatures { get; set; }
        public bool PDFSignatureWidgetHideText { get; set; }
        public bool PDFSignatureWidgetOnLastPage { get; set; }
        public int PDFSignatureWidgetPageOffset { get; set; }
        public string PDFSignatureWidgetImageTokenText { get; set; }
        public string PDFSignatureWidgetDateCaptionFormat { get; set; }
        public int PDFSignatureWidgetDateOffsetX { get; set; }
        public int PDFSignatureWidgetDateOffsetY { get; set; }
    }
}
