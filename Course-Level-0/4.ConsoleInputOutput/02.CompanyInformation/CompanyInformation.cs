using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CompanyInformation
{
    class CompanyInformation
    {
        static void Main(string[] args)
        {
            Console.Write("Company name: ");
            string companyName = Console.ReadLine();
            Console.Write("Company adress: ");
            string companyAdress = Console.ReadLine();
            Console.Write("Company phone: ");
            string companyPhone = Console.ReadLine();
            Console.Write("Company fax: ");
            string companyFax = Console.ReadLine();
            Console.Write("Company Site: ");
            string companySite = Console.ReadLine();
            Console.Write("Manager first name: ");
            string managerFirstNmae = Console.ReadLine();
            Console.Write("Manager last name: ");
            string managerLastName = Console.ReadLine();
            Console.Write("Age: ");
            int managerAge = int.Parse(Console.ReadLine());
            Console.Write("Phone: ");
            string managerPhone = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Name of the compnay: {0}", companyName);
            Console.WriteLine("Adress: {0}", companyAdress);
            Console.WriteLine("Phone: {0}", companyPhone);
            Console.WriteLine("Fax: {0}", companyFax);
            Console.WriteLine("Web site: {0}", companySite);
            Console.WriteLine("Manager: {0} {1}", managerFirstNmae, managerLastName);
            Console.WriteLine("Age: {0}", managerAge);
            Console.WriteLine("Phone: {0}", managerPhone);
        }
    }
}
