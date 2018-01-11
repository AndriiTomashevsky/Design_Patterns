using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxCalculator
{
    public interface ISalesTaxRate { decimal SalesTaxRate { get; } }

    public abstract class SalesTax
    {
        public ISalesTaxRate iSalesTaxRate;
        public string name;
        public decimal itemCost;
        public decimal TotalSalesTax() { return itemCost * (iSalesTaxRate.SalesTaxRate/100); }
    }
    public class Alabama : ISalesTaxRate { decimal salesTaxRate = 6.0m; public decimal SalesTaxRate { get { return salesTaxRate; } } }
    public class Massachusetts : ISalesTaxRate { decimal salesTaxRate = 6.25m; public decimal SalesTaxRate { get { return salesTaxRate; } } }
    public class Alaska : ISalesTaxRate { decimal salesTaxRate = 0m; public decimal SalesTaxRate { get { return salesTaxRate; } } }

    public class AlabamaSalesTax : SalesTax
    {
        public AlabamaSalesTax() { name = "Alabama"; iSalesTaxRate = new Alabama(); }
    }
    public class MassachusettsSalesTax : SalesTax
    {
        public MassachusettsSalesTax() { name = "Massachusetts"; iSalesTaxRate = new Massachusetts();}
    }
    public class AlaskaSalesTax : SalesTax
    {
        public AlaskaSalesTax() { name = "Alaska"; iSalesTaxRate = new Alaska();}
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<SalesTax> states = new List<SalesTax> { new AlabamaSalesTax(), new MassachusettsSalesTax(), new AlaskaSalesTax() };

            foreach (SalesTax item in states)
            {
                item.itemCost = 60;
                Console.WriteLine(item.name);
                Console.WriteLine($"${item.TotalSalesTax()}");
               
            }

            Console.ReadKey();
        }
    }
}
