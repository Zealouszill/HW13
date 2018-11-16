

namespace HW11Types
{
    public class Potential
    {
        public Potential()
        {

        }

        public Potential(string firstName, string lastName, string additionalDetails, int age, int personalityRating, bool enjoysSports)
        {
            FirstName = firstName;
            LastName = lastName;
            AdditionalDetails = additionalDetails;
            Age = age;
            PersonalityRating = personalityRating;
            EnjoysSports = enjoysSports;

        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdditionalDetails { get; set; }
        public int Age { get; set; }
        public int PersonalityRating { get; set; }
        public bool EnjoysSports { get; set; }
        
    }
}
