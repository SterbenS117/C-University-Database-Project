using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace TAMIU_Final_Project
{
    public class Faculty : Account
    {
        List<Student> gradstudentAssigned = new List<Student>();
        List<Section> sectionsAssigned = new List<Section>();
        
        NIC network = new NIC();
        public Faculty(int accNum, string pass, string last, string first, string user, string depart):base(accNum, pass, last, first, user, depart)
        {
            
        }

        public void addCourse(Section course)
        {
            sectionsAssigned.Add(course);

        }
        public void removeCourse(Section course)
        {
            sectionsAssigned.Remove(course);
        }

        public void addGrade(string course, Student stud, double grade)
        {
            stud.updategrade(grade, course);
        }
        public void showClassroster()
        {
            network.exportOnput("Printing your current teaching Schedule");
            string roster = "";
            bool checking = checkingSections();
            if (!checking)
            {
                network.exportOnput("\n Your are not assigned to any sections");
            }
            else {
                for (int i = 0; i < sectionsAssigned.Count; i++)
                {
                    roster = roster + sectionsAssigned[i].printInfo();
                }
                network.exportOnput(roster);
            }
            
        }
        public void showSectionRoster() {
            showClassroster();
            bool valid = !checkingSections();
            int input;
            
            while (!valid) {
                network.exportOnput("\nPlease enter the section number of the section you wish to see the roster of.\n");
                input = Convert.ToInt32(network.recieveNum());
                for (int i = 0; i < sectionsAssigned.Count; i++) {
                    if (input == sectionsAssigned[i].SectionNm)  {
                        for (int j = 0; j < sectionsAssigned[i].StudentAssigned.Count; j++)
                        {
                            network.exportOnput("Major: " + sectionsAssigned[i].StudentAssigned[j].Degreemajor + " " + sectionsAssigned[i].StudentAssigned[j].printUserinfo());
                        }
                        valid = true;
                    }
                    
                }
                if (valid == false) {
                    network.exportOnput("\n The section number your inputed is invalid.");
                }
            }
        }
        bool checkingSections() {
            if (sectionsAssigned.Count == 0)
            {
                return false;
            }
            else {
                return true;
            }
        
        }
        public void gradeStudent() {
            showClassroster();
            int input;
            int student;
            double grade;
            bool valid = !checkingSections();
            while (!valid) {
                network.exportOnput("\nPlease enter the section number of the section you wish to see the roster of.\n");
                input = Convert.ToInt32(network.recieveNum());
                for (int i = 0; i < sectionsAssigned.Count; i++) {
                    if (input == sectionsAssigned[i].SectionNm)
                    {
                        for (int j = 0; j < sectionsAssigned[i].StudentAssigned.Count; j++)
                        {
                            network.exportOnput("Major: " + sectionsAssigned[i].StudentAssigned[j].Degreemajor + " " + sectionsAssigned[i].StudentAssigned[j].printUserinfo());
                        }
                        network.exportOnput("\nPlease enter the student number of the student you wish to grade.\n");
                        student = Convert.ToInt32(network.recieveNum());
                        for (int j = 0; j < sectionsAssigned[i].StudentAssigned.Count; j++)
                        {
                            if (student == sectionsAssigned[i].StudentAssigned[j].AccountNumber) {
                                network.exportOnput("\nPlease enter the percent grade for student.\n");
                                grade = network.recieveNum();
                                grade = grade / 100;
                                sectionsAssigned[i].StudentAssigned[j].CurrentGrades[j].GradePercent = grade;
                                valid = true;
                            }
                        }
                        
                    }
                    if (valid == false)
                    {
                        network.exportOnput("\n The section number your inputed is invalid.");
                    }
                }
            }
        }
        
    }
}
