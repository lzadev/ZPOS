namespace ZPOS.UI.Models
{
    using System;
    public class ClientVM
    {
        public int ID { get; set; }
        public string Document { get; set; }
        public string CompletedName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
