using System;
using System.Collections.Generic;
using System.Text;

namespace TAMIU_Final_Project
{
    public class Admin : Faculty
    {
        NIC network = new NIC();
        string message = "This functionality of the system is currently under development. Please check with OIT formore information.To do that, please contact the OIT Help Desk at hotline@tamiu.edu or atext. 2310.Sorry for the inconvenience!";
        public Admin(int accNum, string pass, string last, string first, string user, string depart) : base(accNum, pass, last, first, user, depart)
        {
            
        }
        public void manageCourse() {
            network.exportOnput(message);
        }
        public void assignFaculty()
        {
            network.exportOnput(message);
        }
        public void changeDeptChair()
        {
            network.exportOnput(message);
        }
        public void withdrawStudent()
        {
            network.exportOnput(message);
        }
    }
}
