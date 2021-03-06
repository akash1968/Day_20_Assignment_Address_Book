// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBook.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akash Kumar Singh"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Xml.Serialization;

namespace Day_20_Assignment_Address_Book
{
    class AddressBook
    { //creating a new list to store contact details entered by the user
        private List<Contact> list = new List<Contact>();
        //create a dictionary(generic collection) to store keyvalue pair
        private Dictionary<string, Contact> dict = new Dictionary<string, Contact>();
        //create a city dictionary to store city details
        public static Dictionary<string, Contact> cityDictionary = new Dictionary<string, Contact>();
        //create a state dictionary to store state details
        public static Dictionary<string, Contact> stateDictionary = new Dictionary<string, Contact>();
        public List<Contact> GetList()
        {
            return list;
        }
        public Dictionary<string, Contact> GetDictionary()
        {
            return dict;
        }
        //method to add address to the list
        public void AddAddress(string kname, Contact c)
        {
            list.Add(c);
            dict.Add(kname, c);
        }
        //method to view contact details using key name
        public Contact ViewByKeyName(string kname)
        {
            //iterating the keyvalue pair using for each loop
            foreach (KeyValuePair<string, Contact> kvp in dict)
            {
                if (kvp.Key == kname)
                    return kvp.Value;
            }
            return null;
        }
        public List<Contact> ViewAddressBook(int input)
        {
            // Sorting by name
            if (input == 1)
            {
                list = list.OrderBy(c => c.GetName()).ToList();
            }
            // Sorting by City
            else if (input == 2)
            {

                list = list.OrderBy(c => c.GetCity()).ToList();
            }
            // Sorting by State
            else if (input == 3)
            {
                list = list.OrderBy(c => c.GetState()).ToList();
            }
            // Sorting by Zip
            else
            {
                list = list.OrderBy(c => c.GetZip()).ToList();
            }
            // Returning the sorted list
            return list;
        }
        //method to edit the contact details
        public void EditNumber(string ename, string newnumber)
        {
            Boolean flag = false;
            // Iterating along the contact list to get each value
            foreach (Contact cc in list)
            {
                // Checking if the entered name matches the name in the record
                if (cc.GetName().Equals(ename))
                {
                    flag = true;
                    // updating the new number
                    cc.SetPhoneNo(newnumber);
                    Console.WriteLine("Number edited successfully");
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("No such name found!!!");
            }
       }
        //method to delete the contact from the phonebook
        public void RemoveContact(string rname)
        {
            Boolean flag = false;
            // Iterating along the contact list to get each value
            foreach (Contact cc in list)
            {
                // Checking if the entered name matches the name in the record
                if (cc.GetName().Equals(rname))
                {
                    flag = true;
                    // Removing the contact from the list
                    list.Remove(cc);
                    Console.WriteLine("Number removed successfully");
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("No such name found!!!");
            }
        }
        //method to check for any duplicate entry 
        public bool UC7_CheckForDuplicateEntry(string name)
        {
            foreach (Contact c in list)
            {
                if (c.GetName().Equals(name))
                {
                    return true;
                }
            }
            return false;
        }
        //UC8-Ability to search Person in a City or State across the multiple address book
        public List<Contact> UC8_SearchPeopleByCityOrState(string location)
        {
            //using foreach loop to add city name entered by the user into the city dictionary
            foreach (Contact c in list)
            {
                cityDictionary.Add(c.GetCity(), c);
            }
            //using foreach loop to add state name entered by the user into the state dictionary
            foreach (Contact c in list)
            {
                stateDictionary.Add(c.GetState(), c);
            }
            //creating a new list as list of people to store the people of similar city together
            List<Contact> listofpeople = new List<Contact>();
            //iterating the key value pair in the city dictionary using foreach loop
            foreach (KeyValuePair<string, Contact> kvp in cityDictionary)
            {
                // adding the key value pair into the list
                if (kvp.Key.Equals(location))
                {
                    listofpeople.Add(kvp.Value);
                }
            }
            //iterating the key value pair in the state dictionary using foreach loop
            foreach (KeyValuePair<string, Contact> kvp in stateDictionary)
            {
                // adding the key value pair into the list
                if (kvp.Key.Equals(location))
                {
                    listofpeople.Add(kvp.Value);
                }
            }
            return listofpeople;
        }
        //method to view address by city name
        public void AddressByCity()
        {
            //creating hashset with name cityset
            HashSet<string> citySet = new HashSet<string>();
            //using for each loop to iterate the list and add city into hashset
            foreach (Contact c in list)
            {
               citySet.Add(c.GetCity());
            }
            //iterating the hashset to display contact details with city name
            foreach (string city in citySet)
            {
                int count = 0;
                foreach (Contact cc in list)
                {
                    // If the entered city matches the city present in address book then increasing the count
                    if (cc.GetCity().Equals(city))
                    {
                        count++;
                    }
               }
                // Displaying the count of contacts with similar city
                Console.WriteLine("There are " + count + " contacts with city " + city);
                Console.WriteLine();
                foreach(Contact cc in list)
                {
                    if (cc.GetCity().Equals(city))
                        Console.WriteLine("Name : " + cc.GetName() + "  Address : " + cc.GetAddress() + "  ZIP : " + cc.GetZip() + "  Contact No : " + cc.GetPhoneNo() + "  EmailID : " + cc.GetEmail());
                }
                Console.WriteLine();
            }
        }
        //method to view address by state name
        public void AddressByState()
        {
            //creating hashset with name stateset
            HashSet<string> stateSet = new HashSet<string>();
            //using for each loop to iterate the list and add state into hashset
            foreach (Contact c in list)
            {
               stateSet.Add(c.GetState());
            }
            //iterating the hashset to display contact details with state name
            foreach (string state in stateSet)
            {
                int count = 0;
                foreach (Contact cc in list)
                {
                    // If the entered state matches the state present in address book then increasing the count
                    if (cc.GetState().Equals(state))
                    {
                        count++;
                    }
                }
                // Displaying the count of contacts with similar state
                Console.WriteLine("There are " + count + " contacts with state " + state);
                Console.WriteLine();
                foreach (Contact cc in list)
                {
                    if (cc.GetState().Equals(state))
                        Console.WriteLine("Name : " + cc.GetName() + "  Address : " + cc.GetAddress() + "  ZIP : " + cc.GetZip() + "  Contact No : " + cc.GetPhoneNo() + "  EmailID : " + cc.GetEmail());
               }
                Console.WriteLine();
            }
        }
        // Method to Read All Text from the file
       internal void ReadAllText()
        {
            string path = @"C:\Users\Lenovo\source\repos\Day_20_Assignment_Address_Book\Hello.txt";
             // Reading all lines from the file
           string lines = File.ReadAllText(path);
            Console.WriteLine(lines);
      
        }  
    }
}
