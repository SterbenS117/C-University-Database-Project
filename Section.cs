using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace TAMIU_Final_Project
{
    public class Section
    {
        string courseName;
        int sectionNm;
        int numberCredit;
        string department;
        string classLocation;
        Faculty assignedFaculty;
        List<Student> studentAssigned = new List<Student>();
        public Section(string name, int secNum, int credit, string location, string depart) {
            courseName = name;
            sectionNm = secNum;
            numberCredit = credit;
            classLocation = location;
            department = depart;
            

        }
        public List<Student> StudentAssigned {
            get{ return studentAssigned; }
            set{ studentAssigned = value; }
        }
        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }
        public int NumberCredit {
            get { return numberCredit; }
            set { numberCredit = value; }
        }
        public int SectionNm {
            get { return sectionNm; }
        }
        
        public string printInfo() {
            string print = "";
            print = courseName + " " + sectionNm.ToString() + " number of credits " + numberCredit.ToString() + " which is located " + classLocation + " taught by " + assignedFaculty.Username + ", department: "+ department +"\n";
            return print;
        }

        public Faculty AssignedFaculty
        {
            get
            {
                return assignedFaculty;
            }
            set
            {
                assignedFaculty = value;
            }

        }

        public void addStudent(Student stud)
        {
            this.studentAssigned.Add(stud);
        }
        public void removeStudent(Student stud) {
            this.studentAssigned.Remove(stud);
        }
    }
}
