namespace TransportCompany.Shared.Application.Dto
{
    public sealed class DriverDetailsDto
    {
        public int DriverId { get; set; }
        public string Name { get; set;  }
        public decimal Surname { get; set;  }
        public byte[] Photo { get; set;  }
        public string CarModel { get; set; }
    }
}
