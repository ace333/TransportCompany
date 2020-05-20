using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Driver.Domain.Events.Consumed;
using TransportCompany.Driver.Infrastructure.Persistence;

namespace TransportCompany.Driver.Application.Consumers
{
    public class DriverRatedConsumer : IConsumer<DriverRated>
    {
        private readonly IDriverUnitOfWork _unitOfWork;

        public DriverRatedConsumer(IDriverUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<DriverRated> context)
        {
            var message = context.Message;
            var driver = await _unitOfWork.DriverRepository.FindAsync(message.DriverId);

            driver.UpdateGrade(message.Grade);
            await _unitOfWork.CommitAsync();
        }
    }
}
