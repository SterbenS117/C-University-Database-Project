using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TAMIU_Final_Project
{
    public class Student : Account
    {
        string degreeMajor;
        double gradepointaverage;
        string advisor;
        string thesisTitle;
        bool isGrad = false;
        List<Section> classSchedule = new List<Section>();
        List<Grade> studentGrades = new List<Grade>();
        List<Grade> currentGrades = new List<Grade>();
        NIC network = new NIC();
        
        public Student(bool grad, string major, double gpa, int accNum, string pass, string last, string first, string user, string depart) : base(accNum, pass, last, first, user, depart)
        {
            degreeMajor = major;
            gradepointaverage = gpa;
            isGrad = grad;
            
        }
        public void addGrade(Grade passclass) {
            studentGrades.Add(passclass);
        }
        public void addCourse(Section course) {
            classSchedule.Add(course);

        }
        public void removeCourse(Section course) {
            classSchedule.Remove(course);
        }

        public void showTranscript() {
            double totalgrades = 0;
            double totalaverage = 0;
            for (int i = 0; i < studentGrades.Count; i++) {
                network.exportOnput(studentGrades[i].printGrade());
                totalgrades = totalgrades + studentGrades[i].GradePercent;
            }
            totalaverage = totalgrades / studentGrades.Count;
            gradepointaverage = totalaverage * 4.0;
            network.exportOnput("\nYour grade point averges is " + gradepointaverage + "\n");
        }

        public void showSchedule() {
            //network.exportOnput("HOPe");
            string schedule = "";
            for (int i = 0; i < classSchedule.Count; i++) {
                schedule = schedule + classSchedule[i].printInfo();
            }
            network.exportOnput(schedule);
            
        }
        public void updategrade(double grade, string course)
        {
            for (int i = 0; i < studentGrades.Count; i++)
            {
                if (studentGrades[i].SectionTitle == course)
                {
                    studentGrades[i].GradePercent = grade;
                }
            }
        }

        public void viewOfferedCourses(TAMIUDatabase database) {
            int departcode;
            List<Department> departments = database.Departments;
            for (int i = 0; i < departments.Count; i++) {
                Convert.ToString(departments[i].Departmentint);
                network.exportOnput(departments[i].Departmentname + " "+ Convert.ToString(departments[i].Departmentint));
            }
            network.exportOnput("\nPlease enter the department code of the class you wish to be enrooled in.");
            departcode = Convert.ToInt32(network.recieveNum());
            network.exportOnput("\nThese are the offered courses from your department.\n");
            for (int i = 0; i < departments.Count ; i++)
            {
                if (departments[i].Departmentint == departcode) {
                    for (int j = 0; j < departments[i].OffedCourse.Count; j++) {
                        network.exportOnput(departments[i].OffedCourse[j].CourseName + " " + departments[i].OffedCourse[j].SectionNm + "\n");
                    }
                }
                
            }
        }

        public void enrollCourse(TAMIUDatabase database) {
            List<Department> departments = database.Departments;
            viewOfferedCourses(database);
            int userchoice;
            bool validEntry =false;
            
            network.exportOnput("\nPlease enter the section of the course you wish to enroll into\n");
            userchoice = Convert.ToInt32(network.recieveNum());
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Departmentname == UserDepart)
                {
                    for (int j = 0; j < departments[i].OffedCourse.Count; j++)
                    {
                        if (userchoice == departments[i].OffedCourse[j].SectionNm) {
                            //Add course to students course list or schedule
                            addCourse(departments[i].OffedCourse[j]);
                            addGrade(departments[i].OffedCourse[j]);
                            //Adds student to course student list
                            departments[i].OffedCourse[j].addStudent(this);
                            network.exportOnput("\nYou have been enrolled into " + departments[i].OffedCourse[j].CourseName + "\n");
                            validEntry = true;
                        }
                    }
                }
            }
            //is the user entry is not a valid section number calls method again
            if (validEntry == false) {
                enrollCourse(database);
            }
           
        }

        public void withdrawCourse(TAMIUDatabase database) {
            int courseNum;
            showSchedule();
            network.exportOnput("\nPlease enter the section number of the course you wish to withdraw from.\n");
            courseNum = Convert.ToInt32(network.recieveNum());
            List<Department> departments = database.Departments;
            bool validEntry = false;
            for (int i = 0; i < departments.Count; i++)
            {
                
                    for (int j = 0; j < departments[i].OffedCourse.Count; j++)
                    {
                        if (courseNum == departments[i].OffedCourse[j].SectionNm)
                        {
                            //Add course to students course list or schedule
                            removeCourse(departments[i].OffedCourse[j]);
                            removeGrade(departments[i].OffedCourse[j]);
                            //Adds student to course student list
                            departments[i].OffedCourse[j].removeStudent(this);
                            network.exportOnput("\nYou have been withdrawn from " + departments[i].OffedCourse[j].CourseName + "\n");
                            validEntry = true;
                        }
                    }
                
            }
            //is the user entry is not a valid section number calls method again
            if (validEntry == false)
            {
                enrollCourse(database);
            }

        }
        void removeGrade(Section newclass) {
            for (int i = 0; i < currentGrades.Count; i++) {
                if (currentGrades[i].SectionTitle == newclass.CourseName) {
                    currentGrades.Remove(currentGrades[i]);
                }
            }
        }
        void addGrade(Section newclass) { 
            Grade newgrade = new Grade(newclass.CourseName, newclass.SectionNm, newclass.NumberCredit, 0);
            currentGrades.Add(newgrade);
        }
        public void generateGrades() {
            for (int i = 0; i < classSchedule.Count; i++) {
                Grade grading = new Grade(classSchedule[i].CourseName, classSchedule[i].SectionNm, classSchedule[i].NumberCredit, 0);
                currentGrades.Add(grading);
            }
        }
        public List<Grade> CurrentGrades {
            get { return currentGrades; }
            set { currentGrades = value; }
        }
        public string Degreemajor {
            get { return degreeMajor; }
            set { degreeMajor = value; }
        }
        public string Advisor
        {
            get
            {
                if (isGrad)
                {
                    return advisor;
                }
                else {
                    network.exportOnput("studnet is not a graduate student");
                    return null;
                }
                    
            }
            set
            {
                if (isGrad)
                {
                    advisor = value;
                }
                else
                {
                    network.exportOnput("studnet is not a graduate student");
                    advisor = null;
                }
                
            }
        }

        public string ThesisTitle
        {
            get
            {
                if (isGrad)
                {
                    return thesisTitle;
                }
                else
                {
                    network.exportOnput("studnet is not a graduate student");
                    return null;
                }

            }
            set
            {
                if (isGrad)
                {
                    thesisTitle = value;
                }
                else
                {
                    network.exportOnput("studnet is not a graduate student");
                    thesisTitle = null;
                }

            }
        }
    }
}
