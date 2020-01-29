using System;
using System.Collections.Generic;

namespace HostBooks.Data.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
    }
}
