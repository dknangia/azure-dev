using ContactManager.V1.Models;
using ContactManager.V1.Models.Tax_Calculator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Completion;

namespace ContactManager.V1.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string criteria, string searchBy)
        {
            var data = await GetData(criteria, searchBy);
            ViewBag.Criteria = criteria; 
            ViewBag.SearchBy = searchBy;
            return View(data);
        }

        public async Task<List<Customer>> GetData(string criteria, string searchBy)
        {
            var data = searchBy.ToLower() switch
            {
                "companyname" => await CustomerSearch.SearchByCompanyName(criteria),
                "contactname" => await CustomerSearch.SearchByContactName(criteria),
                "country" => await CustomerSearch.SearchByCountry(criteria),
                _ => new List<Customer>()
            };

            return data;
        }

        [HttpPost]
        public async Task<FileResult> Export(string criteria, string searchBy)
        {
            List<Customer> data = await GetData(criteria, searchBy);
            string exportData = CustomerExport.ExportToExcel(data).ToString();
            return File(System.Text.Encoding.ASCII.GetBytes(exportData),
                "application/Excel");
        }

        [HttpGet]
        public IActionResult CalculateTax()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateTax(DtoIncomeDetails income)
        {
            if (ModelState.IsValid)
            {
                ICountryTaxCalculator tc = null;

                switch (income.Country)
                {
                    case "US":
                    tc = new TaxCalculateForUs();
                    break;

                    case "UK":
                        tc = new TaxCalculateForSpain();
                        break;

                    case "IN":
                        tc = new TaxCalculateForIndia();
                        break;
                    default:
                        throw new Exception("Country not recognized");
                }


            }
            return View();
        }
    }

   
}
