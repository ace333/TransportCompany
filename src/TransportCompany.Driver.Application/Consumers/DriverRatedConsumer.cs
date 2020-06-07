using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Driver.Domain.Services;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Driver.Application.Consumers
{
    public class DriverRatedConsumer : IConsumer<IDriverRated>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IDriverService _driverService;

        public DriverRatedConsumer(IDriverUnitOfWork unitOfWork, IDriverService driverService)
        {
            _unitOfWork = unitOfWork;
            _driverService = driverService;
        }

        public async Task Consume(ConsumeContext<IDriverRated> context)
        {
            var message = context.Message;
            var driver = await _unitOfWork.DriverRepository.GetDriverWithRides(message.DriverId);

            _driverService.RecalculateDriversGrade(driver, message.Grade);
            await _unitOfWork.CommitAsync();
        }
    }
}
