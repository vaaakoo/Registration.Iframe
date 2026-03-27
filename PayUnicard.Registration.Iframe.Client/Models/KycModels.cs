using System.Collections.Generic;

namespace PayUnicard.Registration.Iframe.Client.Models
{
    public class OpenSessionResponse
    {
        public string FrameUrl { get; set; } = string.Empty;
        public bool SkipKycSession { get; set; }
        public string SessionId { get; set; } = string.Empty;
    }

    public class GetSessionDataResponse
    {
        public List<KycData> Data { get; set; } = new();
    }

    public class KycData
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string ExpirationDate { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public string PersonalNumber { get; set; } = string.Empty;
        public string DocumentFrontSide { get; set; } = string.Empty;
        public string DocumentBackSide { get; set; } = string.Empty;
        public string DocumetType { get; set; } = string.Empty;
        public List<string> SelfImages { get; set; } = new();
        public bool Verified { get; set; }
        public string Status { get; set; } = string.Empty;
        public int CountryID { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public int? DocumentIssuingCountryID { get; set; }
    }

    public class CloseSessionResponse : KycData
    {
        public string IssueDate { get; set; } = string.Empty;
        public string IssueDateTime { get; set; } = string.Empty;
    }
}
