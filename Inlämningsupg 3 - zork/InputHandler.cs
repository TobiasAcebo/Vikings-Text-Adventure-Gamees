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
            if (command.ToLower().Contains("excuse me"))
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
        }

        private static bool IsValidTheDocksCommand(Character character, string command)
        {
            List<string> validCommands = new List<string>
            {
                "go east",
                "go west",
                "go north",
                "go south",
                "go to fisherman",
                "open gate",
                "jump in water",
                "jump into the water",
                "climb up",
                "climb back up",
                "go back",
                "go to end of docks",
                "go to gate",
                "look",
                "go on the boat",
                "go on boat",
                "hi",
                "hi there",
                "hello",
                "hello there", 
                "talk to fisherman",
                "buy fishing line",
                "buy knife",
                "buy fishing line and knife",
                "buy knife and fishing line",
                "go to starting point",
                "enter muddy road",
                "go to muddy road"
            };

            

            if (character.ItemList != null)
            {
                var itemTitles = character.ItemList.Select(i => i.Title).ToList();
                if (itemTitles.Contains("fishing line") && itemTitles.Contains("knife"))
                {
                    validCommands.Add("use knife on fishing line");
                }
            }
            return validCommands.Contains(command);
        }

        private static List<string> GetTheDocksInputWordsExceptionsList(Character character, string command)
        {
            string[] theDocksStandardWords = { "fisherman", "end", "of", "docks", "gate", "boat", "buy", "hi", "hello", "there", "use", "on", "jump", "in", "water", "into", "the", "talk", "and", "starting", "point", "enter", "muddy", "road", "climb", "up"};

            var validWordsList = new List<string>();
            var inputWordsExceptionsList = new List<string>();

            var uniqueItemTitles = GetUniqueItemTitlesFromInventoryAndCurrentLocation(character);
            
            validWordsList.AddRange(_standardWords);
            validWordsList.AddRange(theDocksStandardWords);
            validWordsList.AddRange(uniqueItemTitles);

            string[] commandWordsArr = command.Split(' ');
            foreach (var commandWord in commandWordsArr)
            {
                if(!validWordsList.Contains(commandWord.ToLower()))
                    inputWordsExceptionsList.Add(commandWord);
            }
            return inputWordsExceptionsList;
        }

        private static List<string> GetUniqueItemTitlesFromInventoryAndCurrentLocation(Character character)
        {
            var uniqueItemTitles = new List<string>();
            if (character.CurrentLocation.ItemList != null)
            {
                var itemTitlesInCurrentLocation = character.CurrentLocation.ItemList.Select(i => i.Title).ToArray();
                foreach (var itemTitle in itemTitlesInCurrentLocation)
                {
                    uniqueItemTitles.AddRange(itemTitle.Split(' '));
                }
            }

            if (character.ItemList != null)
            {
                 var itemTitlesInInventory = character.ItemList.Select(i => i.Title).ToArray();
                 foreach (var itemTitle in itemTitlesInInventory)
                 {
                     uniqueItemTitles.AddRange(itemTitle.Split(' '));
                 }
            }
            

            return uniqueItemTitles.Distinct().ToList();
        }
    }
}
