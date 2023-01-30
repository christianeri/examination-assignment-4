using ConsoleContactsApp.Interfaces;
using ConsoleContactsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Channels;

namespace ConsoleContactsApp.Services
{
    internal class MenuService
    {
        //private List<IContact> contacts = new List<IContact>();
        private FileService fileService = new FileService();

        public string FilePath { get; set; } = null!;





        public void WelcomeMenu()
        {
            Console.WriteLine("Välkommen till Adressboken");
            Console.WriteLine();
            Console.WriteLine("1. Skapa en kontakt");
            Console.WriteLine("2. Visa alla kontakter");
            Console.WriteLine("3. Visa en specifik kontakt");
            Console.WriteLine("4. Ta bort en specifik kontakt");
            Console.WriteLine("5. Uppdatera en specifik kontakt");
            Console.WriteLine("6. Avsluta programmet");
            Console.WriteLine();
            Console.Write("Ange ditt val: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Option 1");
                    OptionOne();
                    break;

                case "2":
                    OptionTwo();
                    break;

                case "3":
                    OptionThree();
                    break;

                case "4":
                    OptionFour();
                    break;
                case "5":
                    OptionFive();
                    break;
            }
        }





        private void OptionOne()
        {
            Console.Clear();
            Console.WriteLine("Lägg till ny kontakt");
            Console.WriteLine();
            CreateContact();
        }

        private void CreateContact()
        {
            //IContact customer = new PrivateCustomer();

            Console.Write("Ange förnamn: ");
            string firstName = Console.ReadLine() ?? "";
            Console.Write("Ange efternamn: ");
            string lastName = Console.ReadLine() ?? "";
            Console.Write("Ange e-postadress: ");
            string email = Console.ReadLine() ?? "";
            Console.Write("Ange telefonnummer: ");
            string phone = Console.ReadLine() ?? "";
            Console.Write("Ange adress: ");
            string address = Console.ReadLine() ?? "";

            fileService.AddListItem(new ContactModel
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phone,
                Address = address
            });

        }





        private void OptionTwo()
        {
            ShowContacts();

        }

        private void ShowContacts() 
        {
            Console.Clear();
            Console.WriteLine("Visar alla kontakter");
            Console.WriteLine();

            var list = fileService.AllContacts();

            foreach (ContactModel contact in list)
                Console.WriteLine($"#{list.IndexOf(contact)+1}\n{contact.FirstName} {contact.LastName}\n{contact.Email}\n");

            Console.WriteLine("Tryck valfri tangent för att återvända till menyn");
            Console.ReadKey();
        }














        private void OptionThree()
        {

            Console.Clear();
            Console.WriteLine("Visa en specifik kontakt");
            Console.WriteLine();
            Console.Write("Ange kontaktens #-nummer: ");

            var option = Console.ReadLine();

            try
            {
                int index = Int32.Parse(option) - 1;
                ShowDetailedContact(index);
            }
            catch
            {
                Console.WriteLine("#-nummer måste vara ett heltal");
            }
        }

        private void ShowDetailedContact(int index)
        {
            var contact = fileService.SingleContact(index);

            Console.Clear();
            Console.WriteLine($"Visar kontakt #{index + 1}");
            Console.WriteLine();
            Console.WriteLine($"Förnamn: {contact.FirstName}\nEfternamn: {contact.LastName}\nE-postadress: {contact.Email}\nTelefonnummer: {contact.PhoneNumber}\nAdress: {contact.Address}\n");

            Console.WriteLine();
            Console.WriteLine("Tryck valfri tangent för att återvända till menyn");
            Console.ReadKey();
        }












        private void OptionFour()
        {
            Console.Clear();
            Console.WriteLine("Ta bort kontakt");
            Console.WriteLine();
            Console.Write("Ange kontaktens #-nummer: ");

            var option = Console.ReadLine();

            try
            {
                int index = Int32.Parse(option) - 1;
                RemoveContact(index);
            }
            catch
            {
                Console.WriteLine("#-nummer måste vara ett heltal");
            }
        }

        private void RemoveContact(int index)
        {
            var contact = fileService.SingleContact(index);

            Console.Clear();
            Console.WriteLine($"Visar kontakt #{index + 1}");
            Console.WriteLine();
            Console.WriteLine($"{contact.FirstName} {contact.LastName}\n{contact.Email}\n{contact.PhoneNumber}\n{contact.Address}\n");
            Console.Write("Är du säker på att du vill du ta bort kontakten?: (y/n) ");
            var option = Console.ReadLine();

            if (option == "y")
            {
                fileService.RemoveListItem(index);
            }
            else
            {
                Console.Clear();
                WelcomeMenu();
            }

        }









        private void OptionFive()
        {
            Console.Clear();
            Console.WriteLine("Uppdatera kontakt");
            Console.WriteLine();
            Console.Write("Ange kontaktens #-nummer: ");

            var option = Console.ReadLine();

            try
            {
                int index = Int32.Parse(option) - 1;
                UpdateContact(index);
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("#-nummer måste vara ett heltal");
            }
        }

        private void UpdateContact(int index)
        {
            var contact = fileService.SingleContact(index);

            Console.Clear();
            Console.WriteLine("Uppdatera kontakt");
            Console.WriteLine();
            Console.WriteLine($"Visar kontakt #{index + 1}");
            Console.WriteLine();
            Console.WriteLine($"{contact.FirstName} {contact.LastName}\n{contact.Email}\n{contact.PhoneNumber}\n{contact.Address}\n");
            Console.Write("Vill du uppdatera kontakten?: (y/n) ");
            var option = Console.ReadLine();

            if (option == "y")
            {
                Console.Clear();
                Console.WriteLine("Uppdatera kontakt");
                Console.WriteLine();
                Console.WriteLine($"Visar kontakt #{index + 1}");
                Console.WriteLine();
                Console.WriteLine("Ange nytt värde eller lämna fältet blankt och tryck ENTER för att behålla lagrat värde.\nLagrat värde visas inom parentes.");
                Console.WriteLine();

                Console.Write($"Förnamn ({contact.FirstName}): ");
                string firstName = Console.ReadLine() ?? "";
                if (firstName == "") {
                    firstName = contact.FirstName;
                }

                Console.Write($"Efternamn ({contact.LastName}): ");
                string lastName = Console.ReadLine() ?? "";
                if(lastName == "") {
                    lastName = contact.LastName;
                }

                Console.Write($"E-postadress ({contact.Email}): ");
                string email = Console.ReadLine() ?? "";
                if (email == "") {
                    email = contact.Email;
                }

                Console.Write($"Telefonnummer ({contact.PhoneNumber}): ");
                string phone = Console.ReadLine() ?? "";
                if (phone == "") {
                    phone = contact.PhoneNumber;
                }

                Console.Write($"Ange adress ({contact.Address}): ");
                string address = Console.ReadLine() ?? "";
                if (address == "") {
                    address = contact.Address;
                }

                fileService.UpdateListItem(index, new ContactModel
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phone,
                    Address = address
                });
            }
            else
            {
                Console.Clear();
                WelcomeMenu();
            }
        }
    }

}
