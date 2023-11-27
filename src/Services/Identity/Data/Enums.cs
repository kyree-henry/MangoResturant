using System.ComponentModel.DataAnnotations;

namespace Mango.Services.Identity.Data
{
    public enum UserTypes : ushort
    {
        [Display(Name = nameof(Customer), Description = "Regular restaurant customer")]
        Customer = 100,

        [Display(Name = nameof(Waiter), Description = "Staff member taking orders and serving customers")]
        Waiter = 200,

        [Display(Name = nameof(Chef), Description = "Staff member responsible for preparing and cooking food")]
        Chef = 300,

        [Display(Name = nameof(Manager), Description = "Staff member in charge of managing the restaurant")]
        Manager = 400,

        [Display(Name = nameof(Admin), Description = "Administrator with special privileges")]
        Admin = ushort.MaxValue
    }

    public enum RoleTypes : ushort
    {
        System,
        Regular,
        Developer
    }
}
