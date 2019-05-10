namespace HairSalon.Models
{
    public class Stylist
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        int _id;

        public int Id {get=> _id;}

        public Stylist(string firstName = "default", string lastName = "default", int id = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            _id = id;
        }
    }
}