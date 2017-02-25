using System;

class PrintCompanyInformation
{
    static void Main()
    {       
        Console.WriteLine("Please fill the form:");

        Console.Write("Company name: ");
        string companyName = Console.ReadLine();
        if (companyName == "")
        {
            companyName = "(no name)";
        }

        Console.Write("Company address: ");
        string companyAddress = Console.ReadLine();
        if (companyAddress == "")
        {
            companyAddress = "(no address)";
        }

        Console.Write("Phone number: ");
        string phoneNumber = Console.ReadLine();
        if (phoneNumber == "")
        {
            phoneNumber = "(no phone)";
        }

        Console.Write("Fax number: ");
        string faxNumber = Console.ReadLine();
        if (faxNumber == "")
        {
            faxNumber = "(no fax)";
        }

        Console.Write("Web site: ");
        string webSite = Console.ReadLine();
        if (webSite == "")
        {
            webSite = "(no web site)";
        }

        Console.Write("Manager first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Manager last name: ");
        string managerLastName = Console.ReadLine();
        if (managerFirstName == "" && managerLastName == "")
        {
            managerFirstName = "(no data)";
        }

        Console.Write("Manager age: ");
        string managerAge = Console.ReadLine();
        if (managerAge == "")
	    {
            managerAge = "(no data)";
	    }

        Console.Write("Manager phone: ");
        string managerPhone = Console.ReadLine();
        if (managerPhone == "")
        {
            managerPhone = "(no data)";
        }

        Console.WriteLine("{0, -20} {1}","Company name:", companyName);
        Console.WriteLine("{0, -20} {1}", "Company address:", companyAddress);
        Console.WriteLine("{0, -20} {1}", "Phone number:", phoneNumber);
        Console.WriteLine("{0, -20} {1}", "Fax number:", faxNumber);
        Console.WriteLine("{0, -20} {1}", "Web site:", webSite);
        Console.WriteLine("{0, -20} {1} {2} (age: {3}, tel. {4})", "Manager:", managerFirstName, managerLastName, managerAge, managerPhone);
    }
}