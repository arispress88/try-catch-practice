using System;
using System.Collections.Generic;

public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}

public class AddressBook
{
    private Dictionary<string, Contact> _contactList { get; set; } = new Dictionary<string, Contact>();

    public void AddContact(Contact contact)
    {
        if (_contactList.ContainsKey(contact.Email))
        {
            throw new ArgumentException("Contact already exists in the address book.");
        }

        _contactList.Add(contact.Email, contact);
    }

    public Contact GetByEmail(string email)
    {

        if (!_contactList.ContainsKey(email))
        {
            throw new ArgumentException("Contact not found in the address book.");
        }
        return _contactList[email];
    }
}

class Program
{
    /*
        1. Add the required classes to make the following code compile.
        

        2. Run the program and observe the exception.

        3. Add try/catch blocks in the appropriate locations to prevent the program from crashing
            Print meaningful error messages in the catch blocks.
    */

    static void Main(string[] args)
    {
        try
        {
        // Create a few _contactList
            Contact bob = new Contact() {
            FirstName = "Bob", LastName = "Smith",
            Email = "bob.smith@email.com",
            Address = "100 Some Ln, Testville, TN 11111"
            };
            Contact sue = new Contact() {
            FirstName = "Sue", LastName = "Jones",
            Email = "sue.jones@email.com",
            Address = "322 Hard Way, Testville, TN 11111"
            };
            Contact juan = new Contact() {
            FirstName = "Juan", LastName = "Lopez",
            Email = "juan.lopez@email.com",
            Address = "888 Easy St, Testville, TN 11111"
            };


        // Create an AddressBook and add some _contactList to it
            AddressBook addressBook = new AddressBook();
            addressBook.AddContact(bob);
            addressBook.AddContact(sue);
            addressBook.AddContact(juan);

        // Try to addd a contact a second time
            addressBook.AddContact(sue);


        // Create a list of emails that match our _contactList
            List<string> emails = new List<string>() {
            "sue.jones@email.com",
            "juan.lopez@email.com",
            "bob.smith@email.com",
            };

        // Insert an email that does NOT match a Contact
            emails.Insert(1, "not.in.addressbook@email.com");


        //  Search the AddressBook by email and print the information about each Contact
            foreach (string email in emails)
            {
                try
                {
                Contact contact = addressBook.GetByEmail(email);
                Console.WriteLine("----------------------------");
                Console.WriteLine($"Name: {contact.FullName}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Address: {contact.Address}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured: {ex.Message}");
        }
    }
}