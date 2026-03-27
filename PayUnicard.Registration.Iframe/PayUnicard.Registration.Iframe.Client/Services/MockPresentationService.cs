using PayUnicard.Registration.Iframe.Client.Models;

namespace PayUnicard.Registration.Iframe.Client.Services;

public class MockPresentationService : IPresentationService
{
    public Task<CitizenshipCountriesResponse?> GetCitizenshipCountriesAsync()
    {
        return Task.FromResult<CitizenshipCountriesResponse?>(new CitizenshipCountriesResponse 
        { 
            Countries = new List<CitizenshipCountry> 
            { 
                new CitizenshipCountry { CountryID = 1, CountryName = "Georgia", CountryCode = "GE" },
                new CitizenshipCountry { CountryID = 2, CountryName = "United States", CountryCode = "US" }
            } 
        });
    }

    public Task<WorkTypesResponse?> GetCustomerWorkTypesAsync()
    {
        return Task.FromResult<WorkTypesResponse?>(new WorkTypesResponse 
        { 
            Types = new List<WorkType> 
            { 
                new WorkType { CustomerEmploymentTypeCode = "W1", CustomerEmploymentType = "Full Time" },
                new WorkType { CustomerEmploymentTypeCode = "W2", CustomerEmploymentType = "Part Time" }
            } 
        });
    }

    public Task<EmploymentStatusResponse?> GetCustomerEmploymentStatusTypesAsync()
    {
        return Task.FromResult<EmploymentStatusResponse?>(new EmploymentStatusResponse 
        { 
            Statuses = new List<EmploymentStatusType> 
            { 
                new EmploymentStatusType { EmploymentStatusCode = "S1", EmploymentStatus = "Employed" },
                new EmploymentStatusType { EmploymentStatusCode = "S2", EmploymentStatus = "Self-Employed" }
            } 
        });
    }

    public Task<ExpectedTransactionTypesResponse?> GetExpectedTransactionTypesAsync()
    {
        return Task.FromResult<ExpectedTransactionTypesResponse?>(new ExpectedTransactionTypesResponse 
        { 
            ExpectedTurnoverTypes = new List<ExpectedTurnoverType> 
            { 
                new ExpectedTurnoverType { ExpectedTurnoverCode = "T1", ExpectedTurnover = "0 - 10,000" },
                new ExpectedTurnoverType { ExpectedTurnoverCode = "T2", ExpectedTurnover = "10,001 - 50,000" }
            },
            ExpectedTransactionTypes = new List<ExpectedTransactionType> 
            { 
                new ExpectedTransactionType { ExpectedTransactionsCode = "TR1", ExpectedTransactionsID = 1 },
                new ExpectedTransactionType { ExpectedTransactionsCode = "TR2", ExpectedTransactionsID = 2 }
            }
        });
    }

    public Task<AnnualIncomeResponse?> GetCustomerAnnualIncomeTypesAsync()
    {
        return Task.FromResult<AnnualIncomeResponse?>(new AnnualIncomeResponse 
        { 
            ExpectedAnnualIncomes = new List<AnnualIncomeType> 
            { 
                new AnnualIncomeType { ExpectedAnnualIncomeId = 1, ExpectedAnnualIncomeCode = "I1" },
                new AnnualIncomeType { ExpectedAnnualIncomeId = 2, ExpectedAnnualIncomeCode = "I2" }
            } 
        });
    }

    public Task<UsagePurposeResponse?> GetCustomerUsagePurposeAsync()
    {
        return Task.FromResult<UsagePurposeResponse?>(new UsagePurposeResponse 
        { 
            CustomerUsagePurposes = new List<UsagePurpose> 
            { 
                new UsagePurpose { UsageID = 1, UsagePurposeText = "Personal" },
                new UsagePurpose { UsageID = 2, UsagePurposeText = "Business" }
            } 
        });
    }

    public Task<OtpSourcesResponse?> GetOtpSourcesAsync()
    {
        return Task.FromResult<OtpSourcesResponse?>(new OtpSourcesResponse 
        { 
            Sources = new List<OtpSource> 
            { 
                new OtpSource { Id = 1, Name = "SMS", IsDefault = true }
            } 
        });
    }
}
