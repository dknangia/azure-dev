namespace ContactManager.V1.Models.Tax_Calculator
{
    public interface ICountryTaxCalculator
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalDeduction  { get; set; }

        decimal CalculateTax();
    }

    public class TaxCalculateForUs : ICountryTaxCalculator
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal CalculateTax()
        {
            decimal taxableIncome = TotalIncome - TotalDeduction;
            return taxableIncome * 30 / 100;
        }
    }

    public class TaxCalculateForIndia : ICountryTaxCalculator
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal CalculateTax()
        {
            decimal taxableIncome = TotalIncome - TotalDeduction;
            return taxableIncome * 35 / 100;
        }
    }

    public class TaxCalculateForSpain : ICountryTaxCalculator
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal CalculateTax()
        {
            decimal taxableIncome = TotalIncome - TotalDeduction;
            return taxableIncome * 20 / 100;
        }
    }

    public class TaxCalculator
    {
        public decimal CalculateTax(ICountryTaxCalculator obj)
        {
            return obj.CalculateTax();
        } 
    }

    public class DtoIncomeDetails
    {
        public decimal  TotalIncome { get; set; }
        public decimal  TotalTaxDeduction { get; set; }
        public string Country  { get; set; }
    }
}
