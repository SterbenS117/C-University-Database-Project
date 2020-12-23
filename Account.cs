using System;
using System.Collections.Generic;
using System.Text;

namespace TAMIU_Final_Project
{
    public class Account
    {
        int accountNumber;
        string password;
        string firstName;
        string lastName;
        string username;
        string userDepart;
        NIC network = new NIC();
        
        public Account(int accNum, string pass, string last, string first, string user, string depart)
        {
            accountNumber = accNum;
            password = pass;
            lastName = last;
            firstName = first;
            username = user;
            userDepart = depart;
        }

        public string printUserinfo()
        {
            string printInfo = username + ": " + lastName + "_" + firstName + " " + accountNumber + "\n";
            return (printInfo);
        }
        public void updatePassword() {
            string input;
            bool isupper = false;
            bool islower = false;
            network.exportOnput("\nPasswords must contain at least 8 characters, one lowercase letter, and one uppercase letter. Special characters and numbers are allowed.");
            network.exportOnput("\nPlease input your new password.");
            input = network.recieveString();
            char checking;
            if (input.Length > 7) {
                for (int i = 0; i < input.Length; i++)
                {
                    checking = input[i];
                    if (Char.IsUpper(checking)) {
                        isupper = true;
                    }
                    if (Char.IsLower(checking)) {
                        islower = true;
                    }
                }
            }
            if (islower && isupper)
            {
                password = input;
                network.exportOnput("\nYour password has been updated.");
            }
            else {
                network.exportOnput("\nYour new password is invalid");
                this.updatePassword();
            }
            
        }
        public string getUser() {
            return username;

        }

        public bool PINValidation(string pass)
        {
            if (string.Equals(pass, password))
            {
                return true;
            }
            else {
                return false;
            }
        }
        public void exitSystem() {
           System.Environment.Exit(1);
        }
        public string UserDepart
        {
            get {return userDepart; }
            set { userDepart = value;}
        }
        public int AccountNumber {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
    }
}
