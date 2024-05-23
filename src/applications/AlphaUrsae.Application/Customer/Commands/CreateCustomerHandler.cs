using AlphaUrsae.Abstractions;

namespace AlphaUrsae.Application.Customer.Commands;

public class CreateCustomerHandler
    (IApplicationWideService applicationWideService)
{
    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        // Do something 
        await applicationWideService.DoSomething();
    }
}
