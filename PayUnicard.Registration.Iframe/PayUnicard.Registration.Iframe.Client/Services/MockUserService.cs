using PayUnicard.Registration.Iframe.Client.Models;

namespace PayUnicard.Registration.Iframe.Client.Services;

public class MockUserService : IUserService
{
    public Task<CheckUserResponse?> CheckUserPreRegistrationAsync(CheckUserRequest request)
    {
        // Mock: always available, matches legacy MSW where no duplicates are returned.
        return Task.FromResult<CheckUserResponse?>(new CheckUserResponse
        {
            UserNameExists = false,
            PhoneExists = false,
            PersonalIDExists = false
        });
    }

    public Task<UserPreRegistrationResponse?> UserPreRegistrationAsync(UserPreRegistrationRequest request)
    {
        return Task.FromResult<UserPreRegistrationResponse?>(new UserPreRegistrationResponse { Success = true });
    }

    public Task<CustomerRegistrationResponse?> CustomerRegistrationAsync(CustomerRegistrationRequest request)
    {
        return Task.FromResult<CustomerRegistrationResponse?>(new CustomerRegistrationResponse { Success = true });
    }

    public Task<FinishCustomerRegistrationResponse?> FinishCustomerRegistrationAsync(FinishCustomerRegistrationRequest request)
    {
        return Task.FromResult<FinishCustomerRegistrationResponse?>(new FinishCustomerRegistrationResponse { Success = true });
    }

    public Task<ChangeCustomerResponse?> ChangeCustomerAsync(ChangeCustomerRequest request)
    {
        return Task.FromResult<ChangeCustomerResponse?>(new ChangeCustomerResponse { Success = true });
    }
}
