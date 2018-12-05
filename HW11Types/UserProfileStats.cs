


namespace HW11Types
{
    public class UserProfileStats
    {
        public UserProfileStats()
        {

        }

        public UserProfileStats(string firstName, string lastName, int age, int enjoysSportsRating, int frugalityRating, int physicallyActiveRating,
            int desireForKidsRating, int senseOfHumorRating, int drivenRating, string additionalDetails)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            EnjoysSportsRating = enjoysSportsRating;
            FrugalityRating = frugalityRating;
            PhysicallyActiveRating = physicallyActiveRating;
            DesireForKidsRating = desireForKidsRating;
            SenseOfHumorRating = senseOfHumorRating;
            DrivenRating = drivenRating;
            AdditionalDetails = additionalDetails;

            /* Religious vs Non-religious
         * Saver vs spender
         * active lifestlye vs non active
         * want to have kids vs not wanting kids
         * sense of humor
         * Go getter vs laid back
         */
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int EnjoysSportsRating { get; set; }
        public int PersonalityRating { get; set; }
        public int FrugalityRating { get; set; }
        public int PhysicallyActiveRating { get; set; }
        public int DesireForKidsRating { get; set; }
        public int SenseOfHumorRating { get; set; }
        public int DrivenRating { get; set; }
        public string AdditionalDetails { get; set; }
    }
}
