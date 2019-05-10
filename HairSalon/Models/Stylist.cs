namespace HairSalon
{
    public class Stylist
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}

        public Stylist(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}