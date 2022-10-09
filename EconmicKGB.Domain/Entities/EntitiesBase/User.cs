using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartSolution.Domain.Entities.EntitiesBase
{
    public partial class User
    {
        public User()
        {
            Conversions = new HashSet<Conversion>();
            Solutions = new HashSet<Solution>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string? PhoneNumber { get; set; }
        public string? Dni { get; set; }
        public byte[]? Password { get; set; }
        public DateTime Creation { get; set; }
        public bool State { get; set; }


        public virtual ICollection<Conversion> Conversions { get; set; }
        public virtual ICollection<Solution> Solutions { get; set; }
    }
}
