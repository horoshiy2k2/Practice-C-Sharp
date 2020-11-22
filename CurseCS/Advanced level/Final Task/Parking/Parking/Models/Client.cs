namespace Parking.Models
{
    public class Client
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public PaymentInfo PaymentInfo { get; set; }
    }
}
