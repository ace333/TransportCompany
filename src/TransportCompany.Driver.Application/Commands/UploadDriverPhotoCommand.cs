using Microsoft.AspNetCore.Http;
using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Driver.Application.Commands
{
    public sealed class UploadDriverPhotoCommand : IdCommand, ICommand
    {
        public IFormFile Photo { get; set; }
    }
}
