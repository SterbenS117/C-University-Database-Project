using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TAMIU_Final_Project
{
    class UserActions
    {
        char typeUser;
        Account User;
        int choice;
        NIC network = new NIC();
        TAMIUDatabase database;
        TamiuSystem tamiu;
        
        public UserActions(char type, Account current, TAMIUDatabase data, TamiuSystem system) {
            tamiu = system;
            typeUser = type;
            User = current;
            database = data;
        }
        public int Choice {
            get {
                return choice;
            }
            set {
                choice = value;
            }
        
        }
        public void action() {

            if (typeUser == 'S') { 
                studentActions(); 
            }
            if (typeUser == 'F') { 
                facultyActions(); 
            }
            if (typeUser == 'A') { 
                adminAction(); 
            }

        }

        void facultyActions() {
            if (choice == 1) {
                ((Faculty)User).showSectionRoster();
            }
            if (choice == 2)
            {
                ((Faculty)User).gradeStudent();
            }
            if (choice == 3)
            {
                ((Faculty)User).showClassroster();
            }
            if (choice == 4)
            {
                User.exitSystem();
            }
            if (choice == 5)
            {
                User.updatePassword();
            }
            if (choice == 6)
            {
                tamiu.run();
            }
        }

        void adminAction() {
            if (choice == 1)
            {
                ((Faculty)User).showSectionRoster();
            }
            if (choice == 2)
            {
                ((Faculty)User).gradeStudent();
            }
            if (choice == 3)
            {
                ((Faculty)User).showClassroster();
            }
            if (choice == 4)
            {
                ((Admin)User).manageCourse();
            }
            if (choice == 5)
            {
                ((Admin)User).assignFaculty();
            }
            if (choice == 6)
            {
                ((Admin)User).changeDeptChair();
            }
            if (choice == 7)
            {
                ((Admin)User).withdrawStudent();
            }
            if (choice == 8) {
                User.exitSystem();
            }
            if (choice == 9) {
                
                User.updatePassword();
                
            }
            if (choice == 10)
            {
                tamiu.run();
            }
        }
        void studentActions() {
            if (choice == 1)
            {
                network.exportOnput("\nPrinting your class schedule:");
                ((Student)User).showSchedule();
            }
            if (choice == 2)
            {
                ((Student)User).showTranscript();
            }
            if (choice == 3)
            {
                ((Student)User).enrollCourse(database);
            }
            if (choice == 4)
            {
                ((Student)User).withdrawCourse(database);
            }
            if (choice == 5)
            {
                User.exitSystem();
            }
            if (choice == 6)
            {
                User.updatePassword();
            }
            if (choice == 7) 
            {
                tamiu.run();
            }
            
        }
    }
}
