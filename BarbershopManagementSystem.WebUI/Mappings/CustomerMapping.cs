using BarbershopManagementSystem.WebUI.Models.Entity;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Mappings
{
    public static class CustomerMapping
    {
        public static CustomerViewModel ToViewModel(this Customer customer)
        {
            return new CustomerViewModel
            {
                Id = customer.Id,
                FullName = customer.FirstName + " " + customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email
            };
        }
        public static Customer ToEntity(this CustomerViewModel customerViewModel)
        {
            return new Customer
            {
                Id = customerViewModel.Id,
                FirstName = customerViewModel.FullName.Split(' ')[0],
                LastName = customerViewModel.FullName.Split(' ')[1],
                PhoneNumber = customerViewModel.PhoneNumber,
                Email = customerViewModel.Email ?? ""
            };
        }
    }
}
