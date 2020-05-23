namespace TransportCompany.Customer.Application.Dto
{
    public sealed class CustomerPhotoQueryDto
    {
        public CustomerPhotoQueryDto(byte[] photo)
        {
            Photo = photo;
        }

        public byte[] Photo { get; }
    }
}
