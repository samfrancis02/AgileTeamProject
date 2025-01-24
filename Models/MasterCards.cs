using System.ComponentModel.DataAnnotations;

namespace atmapp.Models

{
    public class MasterCard
    {
        public string CardNumber { get; set; } // Primary Key
        public string CardHolderName { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public string HashedPIN { get; set; }
        public string IssuerBank { get; set; }

        public double Balance { get; set; }
    }

}
