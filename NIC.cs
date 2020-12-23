using System;
using System.Collections.Generic;
using System.Text;

namespace TAMIU_Final_Project
{
    
    public class NIC
    {
        Monitor screen = new Monitor();
        Keyboard keyboard = new Keyboard();
        TAMIUDatabase maindatabase;

        public TAMIUDatabase GetTAMIUDatabase() {
            maindatabase = new TAMIUDatabase();
            return maindatabase;
        }
        public double recieveNum() {
            return keyboard.getNumpad();
            
        }
        public string recieveString() {
            return keyboard.getKeyboard();
        }
        public void exportOnput(string input)
        {
            screen.monitorMessageLine(input);
        }
    }
}
