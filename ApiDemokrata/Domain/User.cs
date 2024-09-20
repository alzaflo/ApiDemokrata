namespace ApiDemokrata.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } // Máx 50 caracteres, obligatorio
        public string? MiddleName { get; set; } // Opcional
        public string LastName { get; set; } // Máx 50 caracteres, obligatorio
        public string? SecondLastName { get; set; } // Opcional
        public DateTime DateOfBirth { get; set; } // Obligatorio
        public decimal Salary { get; set; } // Obligatorio, > 0
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
