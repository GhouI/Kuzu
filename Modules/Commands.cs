using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;

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
            if (Command.StartsWith("bg"))
            {
                string[] args = Command.Split(' ');

                if (args.Length < 2)
                {
                    Console.WriteLine("Error: Missing URL argument");
                    return;
                }

                string url = args[1];

                // Download the image from the URL
                WebClient webClient = new WebClient();
                byte[] data = webClient.DownloadData(url);

                // Save the image to a temporary file
                string tempFilePath = Path.Combine(Path.GetTempPath(), "bg.png");
                File.WriteAllBytes(tempFilePath, data);

                // Set the desktop background
                SetBackground(tempFilePath);

                Console.WriteLine("Background set successfully");
            }
            else if (Command.StartsWith("chatgpt"))
            {
                string prompt = Command.Substring("chatgpt".Length).Trim();

                if (prompt == "")
                {
                    Console.WriteLine("Error: Missing prompt argument");
                    return;
                }

                // Get OpenAI API key from environment variable
                string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
                if (apiKey == null || apiKey == "")
                {
                    Console.WriteLine("Error: Missing OPENAI_API_KEY environment variable");
                    return;
                }

                // Send request to OpenAI API
                OpenAI.API api = new OpenAI.API(apiKey, modelId: "text-davinci-002");
                string response = api.Completions.Create(engine: "davinci", prompt: prompt, maxTokens: 150).Choices[0].Text.TrimEnd();

                Console.WriteLine(response);
            }
            else
            {
                Console.WriteLine("Command not found");
            }
        }

        public void AutomaticRun()
        {
            while (AllowedToRun == true)
            {
                Write();
                RunCommand();
            }
        }
    }
}
