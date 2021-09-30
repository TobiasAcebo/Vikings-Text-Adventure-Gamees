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
        private static readonly string[] _standardWords = { "go", "east", "west", "north", "back", "south", "to", "look" };
        private static readonly string _standardExceptionMessage = "The command is not valid";
        public static string GetInputExceptionMessage(Character character, string command)
        {


            if (character.CurrentScenario.Id == 1)
                return GetTheDocksInputExceptionsMessage(character, command);
            
            
            return null;
        }

        private static string GetTheDocksInputExceptionsMessage(Character character, string command)
        {
            if (character.CurrentLocation.Title == "end of docks" && command.ToLower().Contains("excuse me"))
                return null;
            
            
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
            var validWordsList = new List<string>();
            var inputWordsExceptionsList = new List<string>();
            string[] theDocksStandardWords = { "fisherman", "end", "of", "docks", "gate", "boat", "gate", "buy", "hi", "hello", "there", "use", "on" };
            var itemTitlesInCurrentLocation = character.CurrentLocation.ItemList.Select(i => i.Title).ToArray();
            var itemTitlesInInventory = character.ItemList.Select(i => i.Title).ToArray();
            string[] commandWordsArr = command.Split(' ');

            validWordsList.AddRange(_standardWords);
            validWordsList.AddRange(theDocksStandardWords);
            validWordsList.AddRange(itemTitlesInCurrentLocation);
            validWordsList.AddRange(itemTitlesInInventory);

            if (character.CurrentLocation.Title == "starting point")
            {

            }
            
            foreach (var commandWord in commandWordsArr)
            {
                if(!validWordsList.Contains(commandWord))
                    inputWordsExceptionsList.Add(commandWord);
            }
            return inputWordsExceptionsList;
        }
    }
}
