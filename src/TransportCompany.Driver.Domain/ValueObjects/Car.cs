using System.Collections.Generic;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Driver.Domain.ValueObjects
{
    public class Car : ValueObject
    {
        public Car() { }

        public Car(string model, string registrationPlateNumber)
        {
            Model = model;
            RegistrationPlateNumber = registrationPlateNumber;
        }

        public string Model { get; set; }
        public string RegistrationPlateNumber { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Model.ToUpper();
            yield return RegistrationPlateNumber.ToUpper();
        }
    }
}
