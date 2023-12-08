using System.ComponentModel.DataAnnotations;

namespace Mango.Services.Identity.Pages.Account.Register
{
    public class InputModel
    {
        [Required, EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = default!;

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required, StringLength(100, MinimumLength = 6), DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Required, StringLength(100, MinimumLength = 6), DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; } = default!;

        public string? Button { get; set; }
    }
}
