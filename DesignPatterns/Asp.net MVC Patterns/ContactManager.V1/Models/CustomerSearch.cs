using Microsoft.EntityFrameworkCore;

namespace ContactManager.V1.Models
{
    public class CustomerSearch
    {
        public static async Task<List<Customer>> SearchByCountry(string country)
        {
            await using var context = new AppDbContext();
            return await context
                .Customers.Where(x => x.Country == country).ToListAsync();
        }

        public static async Task<List<Customer>> SearchByCompanyName(string companyName)
        {
            await using var context = new AppDbContext();
            return await context
                .Customers.Where(x => x.CompanyName == companyName).ToListAsync();
        }


        public static async Task<List<Customer>> SearchByContactName(string contactName)
        {
            await using var context = new AppDbContext();
            return await context
                .Customers.Where(x => x.ContactName== contactName).ToListAsync();
        }



    }
}
