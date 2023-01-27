namespace MVCDemo.Models
{
    public class UserProfileModel
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public string Occupation;

        public string Description
        {
            get
            {
                return $"{FirstName}/{LastName}, {Age}. {Occupation}.";
            }
        }

        public string EstimatedBirthYear
        {
            get
            {
                int currentYear = DateTime.Now.Year;
                return $"If already had your birthday this year, then you were born in {currentYear-Age}, " +
                    $"otherwise you were born in {currentYear-Age-1}";
            }
        }
    }
}
