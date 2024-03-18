namespace Trial.Models
{
    using System.ComponentModel.DataAnnotations;
    public class SignInModel
    {
        [EmailAddress]
        [Required, Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}