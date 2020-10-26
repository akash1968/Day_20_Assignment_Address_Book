// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contact.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akash Kumar Singh"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Day_20_Assignment_Address_Book
{
    class Contact
    {
        private string name;
        private string address;
        private string city;
        private string state;
        private string zip;
        private string phoneNo;
        private string email;



        //creating a constructor
        public Contact(string name, string address, string city, string state, string zip, string phoneNo, string email)
        {
            this.name = name;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNo = phoneNo;
            this.email = email;
        }
        //getters and setters for the data entered by the user
        public string GetName()
        {
            return name;
        }
        public string GetAddress()
        {
            return address;
        }
        public string GetCity()
        {
            return city;
        }
        public string GetState()
        {
            return state;
        }
        public string GetZip()
        {
            return zip;
        }
        public string GetPhoneNo()
        {
            return phoneNo;
        }
        public void SetPhoneNo(string phoneNo)
        {
            this.phoneNo = phoneNo;
        }
        public string GetEmail()
        {
            return email;
        }
        public bool Count { get; internal set; }
    }
}
