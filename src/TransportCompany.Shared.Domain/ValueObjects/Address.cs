﻿using System.Collections.Generic;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Shared.Domain.ValueObjects
{
    public class Address: ValueObject
    {
        public Address(string street,
            string houseNumber,
            string zipCode,
            string city,
            string state,
            string country)
        {
            Street = street;
            HouseNumber = houseNumber;
            ZipCode = zipCode;
            City = city;
            State = state;
            Country = country;
        }

        protected Address() { }

        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return HouseNumber;
            yield return ZipCode;
            yield return City;
            yield return State;
            yield return Country;
        }
    }
}
