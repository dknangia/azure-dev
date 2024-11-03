using System.Text;

namespace ContactManager.V1.Models;

public class CustomerExport
{
    public static StringBuilder ExportToExcel(List<Customer> customers)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Customer customer in customers)
        {
            sb.AppendFormat("{0}, {1}, {2}, {3}",  //Notice the formatting of the data and usage of Append format
                customer.CustomerID, 
                customer.ContactName, 
                customer.CompanyName,
                customer.Country);

            sb.AppendLine(); // Blank line 
        }

        return sb;
    }
}