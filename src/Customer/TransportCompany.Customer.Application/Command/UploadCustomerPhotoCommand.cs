using Microsoft.AspNetCore.Http;
using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Customer.Application.Command
{
    public sealed class UploadCustomerPhotoCommand : IdCommand, ICommand
    {
        public IFormFile Photo { get; set; }
    }
}
