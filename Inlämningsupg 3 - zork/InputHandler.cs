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
        private static readonly string _standardExceptionMessage = "The input is not valid";
        public static string GetInputExceptionMessage(Character character, string input)
        {

            if (IsValidInput(input))
                return null;


            if (input == "go forward" && character.CurrentLocation.Title == "starting point")
                return "Try use: go north";

            List<string> inputWordsExceptionsList = GetInputWordsExceptionsList(input);
            if (inputWordsExceptionsList.Count > 0)
                return GetWordExceptionMessage(inputWordsExceptionsList);

            return _standardExceptionMessage;
        }

        private static string GetWordExceptionMessage(List<string> inputWordsExceptionsList)
        {
            string result = "";
            foreach (var inputWordException in inputWordsExceptionsList)
            {
                result += $"\"{inputWordException}\", ";
            }

            return result.Substring(0, result.Length - 2) + " is not in our vocabulary.";
        }

        private static bool IsValidInput(string input)
        {
            string [] validInputList = 
            {
                "look",
                "talk to fisherman",
                "buy fishing line",
                "buy knife",
                "buy fishing line and knife",
                "buy knife and fishing line",
                "use fishing line on knife",
                "use knife on fishing line",
                "drop knife",
                "drop fishing line",
                "pick up knife",
                "pick up fishing line",
                "use key on door",
                "go to house with a shield on the wall",
                "go to the house with a shield on the wall",
                "go to house with stack full of logs",
                "go to the house with stack full of logs",
                "go back to the docks",
                "enter the docks",
                "go to the docks",
                "enter town",
                "go to town",
                "go to house with a carpet made of fur",
                "go to the house with a carpet made of fur",
                "go to house next to a water well",
                "go to the house next to a water well",
                "valhalla",
                "pick up spear",
                "pick up book",
                "pick up candle",
                "pick up helmet",
                "drop spear",
                "drop book",
                "drop candle",
                "drop helmet",
                "use spear on book",
                "use book on spear",
                "pick up coin",
                "drop coin",
                "coin",
                "yes",
                "no",
                "good work"

            };

            if ((input.Contains("pick up") && input.Contains("and")) ||
                input.ContainsKeyWord() ||
                input.IsAGreeting() ||
                input.IsClimbUp() ||
                input.IsDirectionEast() ||
                input.IsDirectionNorth() ||
                input.IsDirectionSouth() ||
                input.IsDirectionWest() ||
                input.IsEnterBoat() ||
                input.IsEnterMuddyRoad() ||
                input.IsGoBack() ||
                input.IsJumpInWater() ||
                input.IsMoveToEndOfDocks() ||
                input.IsMoveToGate() ||
                input.IsMoveToStartingPoint() ||
                input.IsOpenGate() ||
                validInputList.Contains(input))
            {
                return true;
            }
                    
            return false;
        }

        private static List<string> GetInputWordsExceptionsList(string input)
        {
            var inputWordsExceptionsList = new List<string>();
            var validWordsArr = GetStandardWordsArr();

            string[] inputWordsArr = input.Split(' ');

            foreach (var inputWord in inputWordsArr)
            {
                if(!validWordsArr.Contains(inputWord))
                    inputWordsExceptionsList.Add(inputWord);
            }

            return inputWordsExceptionsList;
        }

        private static string[] GetStandardWordsArr()
        {
            return new []
            {
                "fisherman",
                "end",
                "of",
                "docks",
                "gate",
                "boat",
                "ship",
                "buy",
                "hi",
                "hello",
                "there",
                "use",
                "on",
                "jump",
                "in",
                "water",
                "into",
                "the",
                "talk",
                "and",
                "starting",
                "point",
                "enter",
                "muddy",
                "road",
                "climb",
                "up",
                "key",
                "fishing",
                "line",
                "knife",
                "door",
                "open",
                "drop",
                "pick",
                "go", 
                "east", 
                "west", 
                "north", 
                "back",
                "south", 
                "to", 
                "look",
                "house",
                "with",
                "shield",
                "a",
                "wall",
                "stack",
                "full",
                "of",
                "logs",
                "town",
                "carpet",
                "fur",
                "made",
                "well",
                "next",
                "valhalla",
                "helmet",
                "spear",
                "book",
                "candle",
                "coin",
                "sir",
                "how",
                "do",
                "i",
                "get",
                "yes",
                "no",
                "good",
                "work",
                "move",
                "pick",
                "up"
            };
        }
    }
}
