using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using CustomerApp.Infrastructure.Static.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BildeConsole
{
    public class Printer:IPrinter
    {
        private ICustomerService _customerService;
        public Printer(ICustomerService customerService)
        {
            _customerService = customerService;
            // TEST
            DataInit();
        }

        #region UI
        public void StartUI()
        {
            string[] menuItems = {
                "List All Customers",
                "Add Customer",
                "Delete Customer",
                "Edit Customer",
                "Exit"
            };

            //Show Menu
            //Wait for Selection
            // - Show selection or
            // - Warning and go back to menu

            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        var customers = _customerService.GetAllCustomers();
                        ListCustomers(customers);
                        break;
                    case 2:
                        var firstName = AskQuestion("Firstname: ");
                        var lastName = AskQuestion("Lastname: ");
                        var address = AskQuestion("Address: ");
                        var customer = _customerService.NewCustomer(firstName, lastName, address);
                        _customerService.CreateCustomer(customer);
                        break;
                    case 3:
                        var idForDelete = PrintFindCustomerById();

                        _customerService.DeleteCustomer(idForDelete);
                        break;
                    case 4:
                        var idForEdit = PrintFindCustomerById();
                        var customerToEdit = _customerService.FindCustomerById(idForEdit);
                        Console.WriteLine("Updating " + customerToEdit.FirstName);
                        var newFirstName = AskQuestion("Firstname: ");
                        var newLastName = AskQuestion("Lastname: ");
                        var newAddress = AskQuestion("Address: ");
                        _customerService.UpdateCustomer(new Customer()
                        {
                            Address =newAddress,
                            FirstName = newFirstName,
                            Id = idForEdit,
                            LastName = newLastName,
                            
                        });


                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye bye!");

            Console.ReadLine();
        }
        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();

        }
        int PrintFindCustomerById()
        {

            Console.WriteLine("Insert Customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }

            return id;

        }
        private void ListCustomers(List<Customer> customers)
        {
            Console.WriteLine("\nList of Customers");

            foreach (var customer in customers)
            {
                Console.WriteLine($"Id: {customer.Id} Name: {customer.FirstName} " +
                                $"{customer.LastName} " +
                                $"Adress: {customer.Address}");
            }
            Console.WriteLine("\n");

        }
        private int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select What you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 5)
            {
                Console.WriteLine("Please select a number between 1-5");
            }

            return selection;
        }
        #endregion










        #region Infrastructure
        void DataInit()
        {
            var cust1 = new Customer()
            {
                FirstName = "Bob",
                LastName = "Dylan",
                Address = "BongoStreet 202"
            };
            _customerService.CreateCustomer(cust1);

            var cust2 = new Customer()
            {
                FirstName = "Lars",
                LastName = "Bilde",
                Address = "Ostestrasse 202"
            };
            _customerService.CreateCustomer(cust2);
        }
        #endregion










    }
}
