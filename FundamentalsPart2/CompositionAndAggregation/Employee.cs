using System;

namespace CompositionAndAggregation
{
    public class Employee : Object// Is a Relationship
    {
        public Employee(string name, string street, string city, string state, string pincode)
        {
            Name = name;
            Address = new AddressInfo { Street = street, City = city, State = state, PinCode = pincode };
        }
        public string Name { get; set; }
        public AddressInfo Address { get; set; }// life time of this depend on Employee and equal to employee and it mandatory to have it. This is called Composition. //has a realtionship
        public InsuranceInfo Insurance { get; set; }// life time of this not depend on Employee. Can be created after employee creation or can be destroyed before employee destroyed. This is call aggregation. //has a realtionship
    }

    public class InsuranceInfo
    {
        public string PolicyName { get; set; }
        public string PolicyId { get; set; }
    }

    public class AddressInfo : object
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        ~AddressInfo()
        {

        }
    }
}
