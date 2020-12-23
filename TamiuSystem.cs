using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Text;

namespace TAMIU_Final_Project
{
    class TamiuSystem
    {
        
        UserActions actions;
        bool userAuthenticate;
        string currentAccount;
        char usertype;
        TAMIUDatabase database;
        Account current = new Account(0000, "", "", "", "", "");
        NIC network = new NIC();

        public TamiuSystem() {
            database = network.GetTAMIUDatabase();
            this.userAuthenticate = false;
            this.currentAccount = "";
        }
        public void run()
        {
            userAuthenticate = false;
            network.exportOnput("\nWelcome!");
            accountType();
            while (!userAuthenticate)
            {
                userAuthenticate = authenticateUser();
                //network.exportOnput("\nWelcome!");
            }
            while (userAuthenticate)
            {
                performAction();
                actions.action();
                //userAuthenticate = false;
                //currentAccountNumber = 0;
                network.exportOnput("\nPress any key to continue..........");
                Console.ReadKey();

            }
        }


        private void accountType() {
            network.exportOnput("\nPlease specify your account type, by entering 1 for student, 2 for faculty, and 3 for admin");
            int answer;
            answer = Convert.ToInt32(network.recieveNum());
            bool valid = false;
            while (!valid) {
                if (answer == 1){
                    //student type
                    usertype = 'S';
                    valid = true;
                }
                if (answer == 2) {
                    //faculty type
                    usertype = 'F';
                    valid = true;
                }
                if (answer == 3) {
                    //admin type
                    usertype = 'A';
                    valid = true;
                }
                if (valid == false) {
                    network.exportOnput("\nYou did not enter a valid selection. Try again");
                }
            }
        }

        void performAction()
        {
            int input;
            actions = new UserActions(usertype, database.CurrentUser, database, this);
            //network.exportOnput("\nTEST");
            input = displayMenu();
            actions.Choice = input;

        }
        private bool authenticateUser()
        {
            network.exportOnput("\nPlease enter your account username: ");
            string accountuser = network.recieveString();
            network.exportOnput("\nPlease enter your password: ");
            string accountpassword = network.recieveString();
            userAuthenticate = database.userAuthenticate(accountuser, accountpassword);
            if (userAuthenticate)
            {
                currentAccount = accountuser;
                network.exportOnput("\nAccount found and verified");
                return true;
            }
            else {
                network.exportOnput("\nInvalid username or password. Please try again.");
                return false;
            }
        }
        private int displayMenu() {
            bool session = false;
            int input = 0;
            while (!session) {
                if (usertype == 'S') {
                    network.exportOnput("\n1-Show Schedule");
                    network.exportOnput("\n2-Show Transcript");
                    network.exportOnput("\n3-Enroll in course");
                    network.exportOnput("\n4-Withdraw from course");
                    network.exportOnput("\n5-exit system");
                    network.exportOnput("\n6-Update password");
                    network.exportOnput("\n7-Logout");
                    network.exportOnput("");
                    input = Convert.ToInt32(network.recieveNum());
                    
                    session = true;
                }
                if (usertype == 'F') {
                    network.exportOnput("\n1-Show Section Roster");
                    network.exportOnput("\n2-Grade Student");
                    network.exportOnput("\n3-Show Teaching Schedule");
                    network.exportOnput("\n4-exit system");
                    network.exportOnput("\n5-Update password");
                    network.exportOnput("\n6-Logout");
                    network.exportOnput("");
                    input = Convert.ToInt32(network.recieveNum());
                    
                    session = true;
                }
                if (usertype == 'A') {
                    network.exportOnput("\n1-Show Section Roster");
                    network.exportOnput("\n2-Grade Student");
                    network.exportOnput("\n3-Show Teaching Schedule");
                    network.exportOnput("\n4-Mange Courses");
                    network.exportOnput("\n5-Assign Faculty to Section");
                    network.exportOnput("\n6-Change Department Chair");
                    network.exportOnput("\n7-Withdraw Student from Section");
                    network.exportOnput("\n8-exit system");
                    network.exportOnput("\n9-Update password");
                    network.exportOnput("\n10-Logout");
                    network.exportOnput("");
                    input = Convert.ToInt32(network.recieveNum());
                    
                    session = true;
                }
                
            }
            if (session == true)
            {
                return input;
            }
            else {
                return 0;
            }
        }
    }
}
