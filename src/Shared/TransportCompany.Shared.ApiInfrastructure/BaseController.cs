using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TransportCompany.Shared.ApiInfrastructure
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator Mediator;

        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
