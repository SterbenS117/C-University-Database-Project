using System;
using System.Collections.Generic;
using System.Text;

namespace TAMIU_Final_Project
{
    public class Grade
    {
        string sectionTitle;
        int numcredit;
        int sectionnum;
        double gradePercent;
        public Grade(string section, int numsection, int creditnum, double grade)
        {
            sectionTitle = section;
            gradePercent = grade;
            sectionnum = numsection;
            numcredit = creditnum;
        }

        public string printGrade() {
            string grade;
            grade = "\n" + sectionTitle + " " + sectionnum + ", number of credits was " + numcredit + " and final grade was: " + gradePercent * 100;
            return grade;
        
        }
        public string SectionTitle {
            get {
                return sectionTitle;
            }
            set {
                sectionTitle = value;
            }
        }

        public double GradePercent{
            get
            {
                return gradePercent;
            }
            set {
                gradePercent = value;
            }
        }
       
    }
}
