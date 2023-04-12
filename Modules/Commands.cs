using OpenAI;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

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

        public async void RunCommand()
        {
            string[] commandParts = Command.Split(' ');

            switch (commandParts[0])
            {
                case "bg":
                    if (commandParts.Length < 2)
                    {
                        Console.WriteLine("Invalid command syntax: bg [background]");
                    }
                    else if (commandParts[1].Equals("Black", StringComparison.OrdinalIgnoreCase))
                    {
                        SetBackground("C:/Users/abdul/source/repos/Kuzu/Modules/Backgrounds/Black.jpg");
                    }
                    else if (commandParts[1].Equals("Mizuhara", StringComparison.OrdinalIgnoreCase))
                    {
                        SetBackground("C:/Users/abdul/source/repos/Kuzu/Modules/Backgrounds/Mizuhara3.png");
                    }
                    else
                    {
                        Console.WriteLine("Invalid background: " + commandParts[1]);
                    }
                    break;
                case "chatgpt":
                    if (commandParts.Length < 2)
                    {
                        Console.WriteLine("Invalid command syntax: chatgpt [message]");
                    }
                    else
                    {
                        string message = string.Join(" ", commandParts.Skip(1));
                        string response = await GetGPTResponseAsync(message);
                        Console.WriteLine("ChatGPT: " + response);
                    }
                    break;
                default:
                    Console.WriteLine("Command not found");
                    break;
            }
        }

        private async Task<string> GetGPTResponseAsync(string message)
        {
            string apiKey = "YOUR_API_KEY_HERE";
            string modelId = "gpt-3.5-turbo";
            string prompt = "Conversation with ChatGPT:\n\nUser: " + message + "\nChatGPT:";

            OpenAIRequest request = new OpenAIRequest(prompt, modelId, 1, 50, apiKey);
            OpenAIResponse response = await OpenAICompletion.CreateCompletionAsync(request);

            if (response != null && response.choices != null && response.choices.Count > 0)
            {
                return response.choices[0].text.Trim();
            }
            else
            {
                return "Sorry, I could not generate a response.";
            }
        }

        public void AutomaticRun()
        {
            while (AllowedToRun)
            {
                Write();
                RunCommand();
            }
        }
    }
}
