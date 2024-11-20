namespace BoxingAPI.Dtos
{
    public class BoxerDto
    {
        public Guid Id { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Wins { get; set; }

        public int Loses { get; set; }

        public Guid RegisteredGymId { get; set; }

        public string RegisteredGymName { get; set; }
    }
}
