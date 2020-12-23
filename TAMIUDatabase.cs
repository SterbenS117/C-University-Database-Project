using System;
using System.Collections.Generic;
using System.Text;

namespace TAMIU_Final_Project
{

    public class TAMIUDatabase
    {
        List<Account> accounts = new List<Account>();
        List<Department> departments = new List<Department>();
        
        Account currentUser = new Account(0000, " ", " ", " ", " ", " ");
        //int accNum, string pass, string last, string first, string user
        public TAMIUDatabase()
        {
            Account primaryadmin = new Admin(0001, "P@55w0rd", "Sanchez", "A", "ASanchez", "College Of Arts and Science");
            Account secondaryadmin = new Admin(0002, "P@66w0rd", "Sanchez", "Aaron", "AaronSanchez", "College Of Business");

            //Student(string major, double gpa, int accNum, string pass, string last, string first, string user, string depart)
            Account student1 = new Student(false, "Mathematics", 3.5, 020, "0987yes", "Jason", "David", "DJason", "College Of Arts and Science");
            Account student2 = new Student(true, "Physic", 3.0, 021, "0987no", "Jacob", "Gamez", "GJacob", "College Of Arts and Science");
            Account student3 = new Student(false, "Bussiness", 2.9, 022, "6543yes", "Alex", "David", "DAlex", "College Of Business");
            Account student4 = new Student(true, "Economics", 3.1, 023, "12345no", "David", "Alex", "ADavid", "College Of Business");
            ((Student)student2).Advisor = "JMendez";
            ((Student)student2).ThesisTitle = "Why yes";
            ((Student)student4).Advisor = "JMaze";
            ((Student)student4).ThesisTitle = "Why no";

            Account faculty1 = new Faculty(0201, "12345No", "Mendez", "Jose", "JMendez", "College Of Arts and Science");
            Account faculty2 = new Faculty(0201, "No12345", "Maze", "Jose", "JMaze", "College Of Business");

            //Department(int num,string name, string loc)
            Department Business = new Department(342, "College Of Business", "Wesertn Hemisphere Building");
            Department ArtScience = new Department(234, "College Of Arts and Science", "LBV Building");
            
            //Section(string name, int secNum, int credit, string location)
            Section Calculus = new Section("Calculus1 2401", 102, 4, "LBV 110", "College Of Arts and Science");
            Section Physics = new Section("College Physics 2306", 105, 3, "LBV 205", "College Of Arts and Science");
            Section Chemistry = new Section("Chemistry 3340", 117, 3, "LBV 210", "College Of Arts and Science");
            Calculus.AssignedFaculty = ((Faculty)faculty1);
            Physics.AssignedFaculty = ((Faculty)faculty1);
            Chemistry.AssignedFaculty = ((Faculty)faculty1);
            ArtScience.OffedCourse.Add(Chemistry);
            ArtScience.OffedCourse.Add(Calculus);
            ArtScience.OffedCourse.Add(Physics);

            Section Bussiness1 = new Section("Bussiness1 1320", 107, 3, "WH 114", "College Of Business");
            Section Economics = new Section("Economics 2410", 130, 4, "WH 208", "College Of Business");
            Section Bussiness2 = new Section("Bussiness1 1330", 120, 3, "WH 116", "College Of Business");
            Bussiness1.AssignedFaculty = ((Faculty)faculty2);
            Economics.AssignedFaculty = ((Faculty)faculty2);
            Bussiness2.AssignedFaculty = ((Faculty)faculty2);
            Business.OffedCourse.Add(Bussiness2);
            Business.OffedCourse.Add(Bussiness1);
            Business.OffedCourse.Add(Economics);

            ((Faculty)faculty1).addCourse(Calculus);
            ((Faculty)faculty1).addCourse(Physics);
            

            ((Faculty)faculty2).addCourse(Bussiness1);
            ((Faculty)faculty2).addCourse(Economics);

            ((Student)student1).addCourse(Calculus);
            Calculus.addStudent(((Student)student1));
            ((Student)student1).addCourse(Physics);
            Physics.addStudent(((Student)student1));
            
            ((Student)student2).addCourse(Calculus);
            Calculus.addStudent(((Student)student2));
            ((Student)student2).addCourse(Physics);
            Physics.addStudent(((Student)student2));

            ((Student)student3).addCourse(Bussiness1);
            Bussiness1.addStudent(((Student)student3));
            ((Student)student3).addCourse(Economics);
            Economics.addStudent(((Student)student3));

            ((Student)student4).addCourse(Bussiness1);
            Bussiness1.addStudent(((Student)student4));
            ((Student)student4).addCourse(Economics);
            Economics.addStudent(((Student)student4));

            ((Student)student1).addGrade(new Grade("English 1301", 104, 3, 0.75));
            ((Student)student2).addGrade(new Grade("English 1301", 104, 3, 0.90));
            ((Student)student3).addGrade(new Grade("English 1301", 106, 3, 0.86));
            ((Student)student4).addGrade(new Grade("English 1301", 106, 3, 0.81));

            ((Student)student1).addGrade(new Grade("Art 1333", 102, 3, 0.75));
            ((Student)student2).addGrade(new Grade("Art 1333", 102, 3, 0.90));
            ((Student)student3).addGrade(new Grade("Music 1320", 105, 3, 0.8));
            ((Student)student4).addGrade(new Grade("Music 1320", 105, 3, 0.65));

            ((Student)student1).generateGrades();
            ((Student)student2).generateGrades();
            ((Student)student3).generateGrades();
            ((Student)student4).generateGrades();

            this.departments.Add(Business);
            this.departments.Add(ArtScience);
            
            this.accounts.Add(primaryadmin);
            this.accounts.Add(secondaryadmin);
            this.accounts.Add(student1);
            this.accounts.Add(student2);
            this.accounts.Add(student3);
            this.accounts.Add(student4);
            this.accounts.Add(faculty1);
            this.accounts.Add(faculty2);

        }

        
        public bool userAuthenticate(string username, string pass)
        {
            //Account currentUser;
            Account refAccount = getUser(username);
            if (refAccount != null)
            {
                currentUser = refAccount;
                return (refAccount.PINValidation(pass));
            }
            else {
                return false;
            }

        }

        public Account CurrentUser {
            get {
                return currentUser;
            }
            set {
                currentUser = value;
            }
        
        }

        Account getUser(string username)
        {
            foreach(var account in accounts)
            {
                if (string.Equals(account.getUser(), username))
                {
                    return account;
                }
                
            }
            return null;

        }
        public List<Account> Accounts
        {
            get
            {
                return accounts;
            }
            set {
                accounts = value;
            }

        }
        public List<Department> Departments
        {
            get
            {
                return departments;
            }
            set {
                departments = value;
            }
        }
    }
}
