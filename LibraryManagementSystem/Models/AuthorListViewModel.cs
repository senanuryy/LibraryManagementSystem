using System.Security.Principal;

namespace LibraryManagementSystem.Models
{
    public class AuthorListViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
