using System.ComponentModel.DataAnnotations;

namespace DummyDataMaker.ViewModels
{
    public class RegisterViewModel:LoginViewModel
    {
        [Required(ErrorMessage = "Please enter First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please enter field")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

    }
}
