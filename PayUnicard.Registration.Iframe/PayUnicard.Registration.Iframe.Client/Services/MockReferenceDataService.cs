using PayUnicard.Registration.Iframe.Client.Models;

namespace PayUnicard.Registration.Iframe.Client.Services;

public class MockReferenceDataService : IReferenceDataService
{
    public Task<CitizenshipCountriesResponse?> GetCitizenshipCountriesAsync()
    {
        return Task.FromResult<CitizenshipCountriesResponse?>(new CitizenshipCountriesResponse 
        { 
            Countries = new List<CitizenshipCountry> 
            { 
                new CitizenshipCountry { CountryID = 79, CountryName = "Georgia", CountryCode = "GE" },
                new CitizenshipCountry { CountryID = 840, CountryName = "United States", CountryCode = "US" },
                new CitizenshipCountry { CountryID = 826, CountryName = "United Kingdom", CountryCode = "GB" }
            } 
        });
    }

    public Task<WorkTypesResponse?> GetCustomerWorkTypesAsync()
    {
        return Task.FromResult<WorkTypesResponse?>(new WorkTypesResponse 
        { 
            Types = new List<WorkType> 
            { 
                new WorkType { CustomerEmploymentTypeCode = "FullTime", CustomerEmploymentType = "Full Time" },
                new WorkType { CustomerEmploymentTypeCode = "PartTime", CustomerEmploymentType = "Part Time" },
                new WorkType { CustomerEmploymentTypeCode = "SelfEmployed", CustomerEmploymentType = "Self Employed" }
            } 
        });
    }

    public Task<EmploymentStatusResponse?> GetCustomerEmploymentStatusTypesAsync()
    {
        return Task.FromResult<EmploymentStatusResponse?>(new EmploymentStatusResponse 
        { 
            Statuses = new List<EmploymentStatusType> 
            { 
                new EmploymentStatusType { EmploymentStatusCode = "Employed", EmploymentStatus = "Employed" },
                new EmploymentStatusType { EmploymentStatusCode = "UnEmployed", EmploymentStatus = "Unemployed" },
                new EmploymentStatusType { EmploymentStatusCode = "Student", EmploymentStatus = "Student" },
                new EmploymentStatusType { EmploymentStatusCode = "Retired", EmploymentStatus = "Retired" }
            } 
        });
    }

    public Task<ExpectedTransactionTypesResponse?> GetExpectedTransactionTypesAsync()
    {
        return Task.FromResult<ExpectedTransactionTypesResponse?>(new ExpectedTransactionTypesResponse 
        { 
            ExpectedTurnoverTypes = new List<ExpectedTurnoverType> 
            { 
                new ExpectedTurnoverType { ExpectedTurnoverCode = "Low", ExpectedTurnover = "Up to 10,000 GEL" },
                new ExpectedTurnoverType { ExpectedTurnoverCode = "Medium", ExpectedTurnover = "10,000 - 50,000 GEL" },
                new ExpectedTurnoverType { ExpectedTurnoverCode = "High", ExpectedTurnover = "Over 50,000 GEL" }
            },
            ExpectedTransactionTypes = new List<ExpectedTransactionType> 
            { 
                new ExpectedTransactionType { ExpectedTransactionsCode = "Salary", ExpectedTransactionsID = 1 },
                new ExpectedTransactionType { ExpectedTransactionsCode = "Freelance", ExpectedTransactionsID = 2 },
                new ExpectedTransactionType { ExpectedTransactionsCode = "Business", ExpectedTransactionsID = 3 },
                new ExpectedTransactionType { ExpectedTransactionsCode = "Investment", ExpectedTransactionsID = 4 },
            }
        });
    }

    public Task<AnnualIncomeResponse?> GetCustomerAnnualIncomeTypesAsync()
    {
        return Task.FromResult<AnnualIncomeResponse?>(new AnnualIncomeResponse 
        { 
            ExpectedAnnualIncomes = new List<AnnualIncomeType> 
            { 
                new AnnualIncomeType { ExpectedAnnualIncomeId = 1, ExpectedAnnualIncomeCode = "No income" },
                new AnnualIncomeType { ExpectedAnnualIncomeId = 2, ExpectedAnnualIncomeCode = "1 - 20,000 GEL" },
                new AnnualIncomeType { ExpectedAnnualIncomeId = 3, ExpectedAnnualIncomeCode = "20,000 - 50,000 GEL" },
                new AnnualIncomeType { ExpectedAnnualIncomeId = 4, ExpectedAnnualIncomeCode = "50,000 - 100,000 GEL" },
                new AnnualIncomeType { ExpectedAnnualIncomeId = 5, ExpectedAnnualIncomeCode = "100,000 - 500,000 GEL" },
                new AnnualIncomeType { ExpectedAnnualIncomeId = 6, ExpectedAnnualIncomeCode = "500,000 GEL and above" }
            } 
        });
    }

    public Task<UsagePurposeResponse?> GetCustomerUsagePurposeAsync()
    {
        return Task.FromResult<UsagePurposeResponse?>(new UsagePurposeResponse 
        { 
            CustomerUsagePurposes = new List<UsagePurpose> 
            { 
                new UsagePurpose
                {
                    UsageID = 1,
                    UsagePurposeText = "To perform transactions related to PayUnicard partner companies."
                },
                new UsagePurpose
                {
                    UsageID = 2,
                    UsagePurposeText = "To perform transactions related to Georgia."
                },
                new UsagePurpose
                {
                    UsageID = 3,
                    UsagePurposeText = "There is no similar product in the local jurisdiction."
                },
                new UsagePurpose
                {
                    UsageID = 4,
                    UsagePurposeText = "I want to use PayUnicard products and services."
                }
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
