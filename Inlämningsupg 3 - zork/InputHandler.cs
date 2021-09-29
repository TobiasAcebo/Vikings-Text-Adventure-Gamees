using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork
{
    static class InputHandler
    {
        private static readonly string[] _standardWords = { "go", "east", "west", "forward", "back", "to" };
        private static readonly string _standardExceptionMessage = "The command is not valid";
        public static string GetInputExceptionMessage(Character character, string command)
        {

            if (character.CurrentScenario.Id == 1)
                return GetTheDocksInputExceptionsMessage(character, command);
            
            
            return null;
        }

        private static string GetTheDocksInputExceptionsMessage(Character character, string command)
        {
            List<string> inputWordsExceptionsList = GetTheDocksInputWordsExceptionsList(character, command);
            if (inputWordsExceptionsList.Count > 0)
            {
                string result = "";
                foreach (var inputWordException in inputWordsExceptionsList)
                {
                    result += $"'{inputWordException}', ";
                }

                return result.Substring(0, result.Length - 2) + " Isn't in our vocabulary";
            }

            if (IsValidTheDocksCommand(character, command))
                return null;

            return _standardExceptionMessage;

            var itemTitlesInCurrentLocation = character.CurrentLocation.ItemList.Select(i => i.Title);

            var currentLocation = character.CurrentLocation;

            return null;
        }

        private static bool IsValidTheDocksCommand(Character character, string command)
        {
            List<string> validCommands = new List<string>
            {
                "go east",
                "go west",
                "go forward",
                "go back",
                "go to fisherman",
                "open door",
                "use knife on fishing line",

            };
            if (character.CurrentLocation.Title != "end of docks")
                validCommands.Add("go to fisherman");

            return true;
        }

        private static List<string> GetTheDocksInputWordsExceptionsList(Character character, string command)
        {
            string[] theDocksStandardWords = { "talk", "fisherman" };
            return null;
        }
    }
}
