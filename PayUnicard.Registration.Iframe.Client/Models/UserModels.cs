namespace PayUnicard.Registration.Iframe.Client.Models
{
    public class CheckUserRequest
    {
        public string? Phone { get; set; }
        public string? UserName { get; set; }
        public string? PersonalID { get; set; }
    }

    public class CheckUserResponse
    {
        public bool UserNameExists { get; set; }
        public bool PhoneExists { get; set; }
        public bool PersonalIDExists { get; set; }
    }

    public class UserPreRegistrationRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string OtpGuid { get; set; } = string.Empty;
        public string IsApplyTerms { get; set; } = "1";
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string PersonalId { get; set; } = string.Empty;
        public int CitizenshipCountryID { get; set; }
        public string PhoneCountryCode { get; set; } = string.Empty;
        public string? RefId { get; set; }
        public string? RefName { get; set; }
    }

    public class UserPreRegistrationResponse
    {
        public bool Success { get; set; }
    }

    public class CustomerRegistrationRequest
    {
        public int TermID { get; set; } = 1;
        public bool IsRepresentative { get; set; } = false;
        public string? Employer { get; set; }
        public string? EmploymentStatusCode { get; set; }
        public string? EmploymentTypeCode { get; set; }
        public string? WorkPosition { get; set; }
        public string? ExpectedTurnoverCode { get; set; }
        public int[] ExpectedTransactionTypes { get; set; } = [];
        public string? OtherDesctiption { get; set; }
        public int? FactCountryID { get; set; }
        public int FactCityID { get; set; } = 0;
        public string? FactCity { get; set; }
        public string? FactAddress { get; set; }
        public string? FactPostalCode { get; set; }
        public int? LegalCountryID { get; set; }
        public int LegalCityID { get; set; } = 0;
        public string? LegalCity { get; set; }
        public string? LegalAddress { get; set; }
        public string? LegalPostalCode { get; set; }
        public int? DocumentRegisterCountryId { get; set; }
        public string? ExpectedAnualIncomeCode { get; set; }
        public bool? IsTransitUsagePlanned { get; set; }
        public bool IsPartnerSelected { get; set; }
        public bool IsGeorgiaSelected { get; set; }
        public bool IsNoLocalAlternative { get; set; }
        public bool IsPayUnicardUsagePlanned { get; set; }
    }

    public class CustomerRegistrationResponse
    {
        public bool Success { get; set; }
    }

    public class FinishCustomerRegistrationRequest
    {
        public string DocumentType { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PersonalID { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public string DocumentFrontSide { get; set; } = string.Empty;
        public string DocumentFrontSideContent { get; set; } = "Front";
        public string DocumentFrontSideName { get; set; } = string.Empty;
        public string DocumentBackSide { get; set; } = string.Empty;
        public string DocumentBackSideContent { get; set; } = "Back";
        public string DocumentBackSideName { get; set; } = string.Empty;
        public string CustomerSelf { get; set; } = string.Empty;
        public string CustomerSelfContent { get; set; } = "Selfie";
        public string CustomerSelfName { get; set; } = string.Empty;
        public int Sex { get; set; }
        public string BirthDate { get; set; } = string.Empty;
        public string IssueDate { get; set; } = string.Empty;
        public string ValidTo { get; set; } = string.Empty;
        public int CitizenshipCountryID { get; set; }
        public string BirthCity { get; set; } = string.Empty;
        public int BirthCountryId { get; set; }
        public int DualCitizen { get; set; }
        public int SecondaryCitizenshipCountryID { get; set; }
    }

    public class FinishCustomerRegistrationResponse
    {
        public bool Success { get; set; }
    }

    public class ChangeCustomerRequest
    {
        public int? DocumentRegisterCountryId { get; set; }
        public string? ExpectedAnualIncomeCode { get; set; }
        public bool? IsTransitUsagePlanned { get; set; }
        public bool IsPartnerSelected { get; set; }
        public bool IsGeorgiaSelected { get; set; }
        public bool IsNoLocalAlternative { get; set; }
        public bool IsPayUnicardUsagePlanned { get; set; }
    }

    public class ChangeCustomerResponse
    {
        public bool Success { get; set; }
    }
}
