namespace PayUnicard.Registration.Iframe.Client.Models;

public class CitizenshipCountry
{
    public int CountryID { get; set; }
    public string CountryName { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
}

public class CitizenshipCountriesResponse
{
    public List<CitizenshipCountry> Countries { get; set; } = [];
}

public class Country
{
    public string CountryCode { get; set; } = string.Empty;
    public string CountryName { get; set; } = string.Empty;
    public string DialCode { get; set; } = string.Empty;
    public int MinDIG { get; set; }
    public int MaxDIG { get; set; }
}

public class CountriesResponse
{
    public List<Country> Countries { get; set; } = [];
}

public class EmploymentStatusType
{
    public string EmploymentStatusCode { get; set; } = string.Empty;
    public string EmploymentStatus { get; set; } = string.Empty;
}

public class EmploymentStatusResponse
{
    public List<EmploymentStatusType> Statuses { get; set; } = [];
}

public class WorkType
{
    public string CustomerEmploymentTypeCode { get; set; } = string.Empty;
    public string CustomerEmploymentType { get; set; } = string.Empty;
}

public class WorkTypesResponse
{
    public List<WorkType> Types { get; set; } = [];
}

public class ExpectedTurnoverType
{
    public string ExpectedTurnoverCode { get; set; } = string.Empty;
    public string ExpectedTurnover { get; set; } = string.Empty;
}

public class ExpectedTransactionType
{
    public string ExpectedTransactionsCode { get; set; } = string.Empty;
    public int ExpectedTransactionsID { get; set; }
}

public class ExpectedTransactionTypesResponse
{
    public List<ExpectedTurnoverType> ExpectedTurnoverTypes { get; set; } = [];
    public List<ExpectedTransactionType> ExpectedTransactionTypes { get; set; } = [];
}

public class AnnualIncomeType
{
    public int ExpectedAnnualIncomeId { get; set; }
    public string ExpectedAnnualIncomeCode { get; set; } = string.Empty;
}

public class AnnualIncomeResponse
{
    public List<AnnualIncomeType> ExpectedAnnualIncomes { get; set; } = [];
}

public class UsagePurpose
{
    public int UsageID { get; set; }
    public string UsagePurposeText { get; set; } = string.Empty;
}

public class UsagePurposeResponse
{
    public List<UsagePurpose> CustomerUsagePurposes { get; set; } = [];
}

public class OtpSource
{
    public int Id { get; set; }
    public string OtpSourceName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
}

public class OtpSourcesResponse
{
    public List<OtpSource> Sources { get; set; } = [];
}
