// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

namespace Mango.Services.Identity.Pages.Ciba
{
    public class ViewModel
    {
        public ViewModel()
        {
            IdentityScopes = new List<ScopeViewModel>();
            ApiScopes = new List<ScopeViewModel>();
        }

        public string? ClientName { get; set; }
        public string? ClientUrl { get; set; }
        public string? ClientLogoUrl { get; set; }
        
        public string? BindingMessage { get; set; }

        public IEnumerable<ScopeViewModel> IdentityScopes { get; set; }
        public IEnumerable<ScopeViewModel> ApiScopes { get; set; }
    }

    public class ScopeViewModel
    {
        public ScopeViewModel()
        {
            Resources = new List<ResourceViewModel>();
        }

        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public bool Emphasize { get; set; }
        public bool Required { get; set; }
        public bool Checked { get; set; }
        public IEnumerable<ResourceViewModel> Resources { get; set; }
    }

    public class ResourceViewModel
    {
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
    }
}