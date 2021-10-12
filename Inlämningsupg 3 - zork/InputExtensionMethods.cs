using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork
{
    static class InputExtensionMethods
    {
        public static bool IsAGreeting(this string input)
        {
            var greetingPhrasesArr = new []
            {
                "hi",
                "hi there",
                "hello",
                "hello there"
            };

            return greetingPhrasesArr.Contains(input);
        }
        public static bool IsEnterBoat(this string input)
        {
            var boatPhrasesArr = new []
            {
                "go on the boat",
                "go on boat",
                "go on the ship",
                "go on ship"
            };

            return boatPhrasesArr.Contains(input);
        }
        public static bool IsClimbUp(this string input)
        {
            var climbingPhrasesArr = new []
            {
                "climb up",
                "climb back up"
            };

            return climbingPhrasesArr.Contains(input);
        }
        public static bool IsMoveToEndOfDocks(this string input)
        {
            var endOfDocksPhrasesArr = new []
            {
                "go to fisherman",
                "go to the fisherman",
                "go to end of docks",
                "go to the end of docks",
                "move to fisherman",
                "move to the fisherman",
                "move to end of docks",
                "move to the end of docks"
            };

            return endOfDocksPhrasesArr.Contains(input);
        }
        public static bool IsJumpInWater(this string input)
        {
            var jumpInWaterPhrasesArr = new []
            {
                "jump in water",
                "jump into the water"
            };

            return jumpInWaterPhrasesArr.Contains(input);
        }
        public static bool IsEnterMuddyRoad(this string input)
        {
            var enterMuddyRoadPhrasesArr = new []
            {
                "enter muddy road",
                "enter the muddy road",
                "go to muddy road",
                "go to the muddy road",
                "move to muddy road",
                "move to the muddy road"
            };

            return enterMuddyRoadPhrasesArr.Contains(input);
        }
        public static bool IsOpenGate(this string input)
        {
            var openGatePhrasesArr = new[]
            {
                "open gate",
                "open the gate",
                "use key on gate",
                "use the key on the gate",
                "use key on the gate",
                "use the key on gate"
            };

            return openGatePhrasesArr.Contains(input);
        }
        public static bool IsMoveToStartingPoint(this string input)
        {
            var goToStartingPointPhrasesArr = new[]
            {
                "go to starting point",
                "go to the starting point",
                "go back to starting point",
                "go back to the starting point",
                "move to starting point",
                "move to the starting point",
                "move back to starting point",
                "move back to the starting point",
            };

            return goToStartingPointPhrasesArr.Contains(input);
        }
        public static bool IsMoveToGate(this string input)
        {
            var goToGatePhrasesArr = new[]
            {
                "go to gate",
                "go to the gate",
                "move to gate",
                "move to the gate"
            };

            return goToGatePhrasesArr.Contains(input);
        }




        public static bool IsDirectionEast(this string input)
        {
            var goEastPhrasesArr = new[]
            {
                "go east",
                "move east" //lägg till i inputhandler
            };

            return goEastPhrasesArr.Contains(input);
        }
        public static bool IsDirectionWest(this string input)
        {
            var goWestPhrasesArr = new[]
            {
                "go west",
                "move west" //lägg till i inputhandler
            };

            return goWestPhrasesArr.Contains(input);
        }
        public static bool IsDirectionNorth(this string input)
        {
            var goNorthPhrasesArr = new[]
            {
                "go north",
                "move north"//lägg till i inputhandler
            };

            return goNorthPhrasesArr.Contains(input);
        }
        public static bool IsDirectionSouth(this string input)
        {
            var goSouthPhrasesArr = new[]
            {
                "go south",
                "move south"//lägg till i inputhandler
            };

            return goSouthPhrasesArr.Contains(input);
        }
        public static bool IsGoBack(this string input)
        {
            var goGoBackPhrasesArr = new[]
            {
                "go back",
                "move back"//lägg till i inputhandler
            };

            return goGoBackPhrasesArr.Contains(input);
        }
        public static bool ContainsKeyWord(this string input)
        {
            if (input.Contains("erhild") ||
                input.Contains("thor") ||
                input.Contains("good work") ||
                input.Contains("long sword") ||
                input.Contains("excuse me") ||
                input.Contains("great halls") ||
                input.Contains("gate") ||
                input.Contains("key") ||
                input.Contains("coin"))
            {
                return true;
            }

            return false;
        }

    }
}
