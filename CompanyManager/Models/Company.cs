namespace CompanyManager.Models
{
    public class Company
    {
        public Company(string name,string city, string state, string phone) 
        { 
            Name = name;
            City = city;
            State = state;
            Phone = phone;
        }

        public int Id { get; set; } = 1;

        public string Name { get; set; }
        public string Address { get; set; } = "702 SW 8th Street";
        public string City { get; set; }
        public string State { get; set; }        
        public string Phone { get; set; }
    }
}