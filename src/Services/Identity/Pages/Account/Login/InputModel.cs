// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.ComponentModel.DataAnnotations;

namespace Mango.Services.Identity.Pages.Login
{
    public class InputModel
    {
        [Required]
        [Display(Name = "Email or Username")]
        public string? Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool RememberLogin { get; set; }

        public string? ReturnUrl { get; set; }

        public string? Button { get; set; }
    }
}
