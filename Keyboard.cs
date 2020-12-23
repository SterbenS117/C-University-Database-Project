using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TAMIU_Final_Project
{
    class Keyboard
    {
        
        public string getKeyboard()
        {
            string inputKeyboard = Console.ReadLine();
            return inputKeyboard;
        }
        public int getNumpad()
        {
            bool isInt;
            int inputNumpad;
            do
            {
                var input = Console.ReadLine();
                isInt = int.TryParse(input.ToString(), out inputNumpad);
                if (isInt == false)
                {
                    Console.WriteLine("Please enter a valid integer");
                }
            } while (isInt == false);

            return inputNumpad;
        }
    }
}
