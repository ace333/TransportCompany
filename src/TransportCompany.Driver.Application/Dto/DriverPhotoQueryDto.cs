namespace TransportCompany.Driver.Application.Dto
{
    public sealed class DriverPhotoQueryDto
    {
        public DriverPhotoQueryDto(byte[] photo)
        {
            Photo = photo;
        }

        public byte[] Photo { get; }
    }
}
