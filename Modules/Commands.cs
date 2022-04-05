using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Kuzu.Modules
{


    class Commands
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fWinIni);
        public string Command;
        public bool AllowedToRun = false;
       
        public Commands()
        {
            AllowedToRun = true;
        }


        public void setCommand(string cmd)
        {
            Command = cmd;
        }

        public void Write()
        {
            Console.Write("Kuzu>");
            setCommand(Console.ReadLine());
        }

        void SetBackground(string path)
        {
            SystemParametersInfo(0x14, 0, path, 0x01);

        }

        public void RunCommand()
        {
            if (Command.Contains("bg"))
            {
                if(Command.Contains("Black"))
                {
                    SetBackground("C:/Users/abdul/source/repos/Kuzu/Modules/Backgrounds/Black.jpg");
                }else if (Command.Contains("Mizuhara"))
                {
                    SetBackground("C:/Users/abdul/source/repos/Kuzu/Modules/Backgrounds/Mizuhara3.png");

                }
            }
            else
            {
                Console.WriteLine("Commad not found");
              //  Write();
            }
        }
        public void AutomaticRun()
        {
            while(AllowedToRun == true)
            {
                Write();
                RunCommand();
            }
        }
    }
}
