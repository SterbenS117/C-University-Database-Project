using System;
using System.Collections.Generic;
using System.Text;

namespace TAMIU_Final_Project
{
    public class Department
    {
        int departmentint;
        string departmentName;
        string location;
        List<Section> offedCourse = new List<Section>();

        

        public Department(int num,string name, string loc){
            departmentint = num;
            departmentName = name;
            location = loc;
        
        }

        
        public int Departmentint {
            get
            {
                return departmentint;
            }
        }
        public string Departmentname {
            get {
                return departmentName;
            }
            set {
                departmentName = value;
            }
        
        }
        public string Location
        {
            get {
                return location;
            }
            set {
                location = value;
            }
        }
        public List<Section> OffedCourse
        {
            get { return offedCourse; }
            set { offedCourse = value; }
        }

    }
}
