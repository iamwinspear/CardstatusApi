using System;
using System.Collections.Generic;

namespace MessagingAPI.Models
{
    public partial class PersonView
    {
        public string Pin { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public string? StatusDescription { get; set; }
    }
}
