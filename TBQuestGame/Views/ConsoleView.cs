using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public class ConsoleView
    {
        #region FIELDS

        Player _myPlayer;
        Pass _pass;
        NPCList _NPCList;

        private const int WINDOW_WIDTH = Settings.WINDOW_WIDTH;
        private const int WINDOW_HEIGHT = Settings.WINDOW_HEIGHT;

        private const int DISPLAY_HORIZONTAL_MARGIN = Settings.DISPLAY_HORIZONTAL_MARGIN;
        private const int DISPLAY_VERITCAL_MARGIN = Settings.DISPLAY_VERITCAL_MARGIN;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        public ConsoleView(Player myplayer)
        {

        }

        public ConsoleView(Player myPlayer, Pass pass, NPCList NPCs)
        {
            _myPlayer = myPlayer;
            _pass = pass;
            _NPCList = NPCs;
            InitializeConsoleWindow();
        }

        #endregion

        #region METHODS

        public void InitializeConsoleWindow()
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);
        }

        public void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("Welcome to", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("The Traveler's Pass", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        public void DisplayPlayerInformation()
        {
            DisplayReset();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            DisplayMessage("Your player information:");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

            DisplayMessage("Name: " + _myPlayer.Name);
            DisplayMessage("Race: " + _myPlayer.Race);
            DisplayMessage("Gender: " + _myPlayer.Gender);

            DisplayContinuePrompt();
        }

        public void DisplayNPCInformation(int NPCNumber)
        {
            Console.WriteLine();

            DisplayMessage("Name: " + _NPCList.NPCs[NPCNumber].Name);
            DisplayMessage("Race: " + _NPCList.NPCs[NPCNumber].Race);
            DisplayMessage("Gender: " + _NPCList.NPCs[NPCNumber].Gender);
            //DisplayMessage("Appears Friendly: " + _NPCList.NPCs[NPCNumber].AppearsFriendly);
            //DisplayMessage("Greeting: " + _NPCList.NPCs[NPCNumber].InitialGreeting);
        }

        public void DisplayNPCListInformation()
        {
            DisplayReset();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            DisplayMessage("The game contains the following NPCs:");
            Console.ForegroundColor = ConsoleColor.White;

            for (int NPCNumber = 0; NPCNumber < NPCList.MAX_NUMBER_OF_NPCS; NPCNumber++)
            {
                if (_NPCList.NPCs[NPCNumber] != null)
                {
                    DisplayNPCInformation(NPCNumber);
                }

            }

            DisplayContinuePrompt();
        }

        public void DisplayHallInformation()
        {
            DisplayReset();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            DisplayMessage("The Traveler's Pass contains the following Caves:");
            Console.ForegroundColor = ConsoleColor.White;

            for (int caveNumber = 0; caveNumber < Pass.MAX_CAVES; caveNumber++)
            {
                DisplayCaveInformation(caveNumber);
            }

            DisplayContinuePrompt();
        }

        public void DisplayCaveInformation(int caveNumber)
        {
            Console.WriteLine();
            DisplayMessage("Name: " + _pass.Caves[caveNumber].Name);
            DisplayMessage("Description: " + _pass.Caves[caveNumber].Description);
            DisplayMessage("Lighted: " + _pass.Caves[caveNumber].IsLighted);
            DisplayMessage("Can Enter: " + _pass.Caves[caveNumber].CanEnter);
        }

        public void DisplayMessage(string message)
        {
            //
            // calculate the message area location on the console window
            //
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            //
            // create a list of strings to hold the wrapped text message
            //
            List<string> messageLines;

            //
            // call utility method to wrap text and loop through list of strings to display
            //
            messageLines = ConsoleUtil.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);
            foreach (var messageLine in messageLines)
            {
                Console.WriteLine(messageLine);
            }
        }
        
        public void DisplayExitPrompt()
        {
            Console.ResetColor();

            Console.CursorVisible = false;

            Console.WriteLine();
            DisplayMessage("Thank you for playing our game. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }

        public void DisplayReset()
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);

            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("Traveler's Pass Game", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            Console.WriteLine();
        }

        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            DisplayMessage("Press any key to continue or press the ESC key to quit.");
            Console.WriteLine();

            ConsoleKeyInfo response = Console.ReadKey();
            if (response.Key == ConsoleKey.Escape)
            {
                System.Environment.Exit(1);
            }

            Console.CursorVisible = true;
        }

        public void DisplayAllObjectInformation()
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                //
                // set a string variable with a length equal to the horizontal margin and filled with spaces
                //
                string leftTab = ConsoleUtil.FillStringWithSpaces(DISPLAY_HORIZONTAL_MARGIN);

                //
                // set up display area
                //
                DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                Console.WriteLine(
                    leftTab + "1. Player Information" + Environment.NewLine +
                    leftTab + "2. Traveler's Pass Information" + Environment.NewLine +
                    leftTab + "3. NPC List Information" + Environment.NewLine +
                    leftTab + "4. Exit" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case '1':
                        DisplayPlayerInformation();
                        break;
                    case '2':
                        DisplayHallInformation();
                        break;
                    case '3':
                        DisplayNPCListInformation();
                        break;
                    case '4':
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine(
                            "It appears you have selected an incorrect choice." + Environment.NewLine +
                            "Press any key to continue or the ESC key to exit.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }
                        break;
                }
            }
            Console.CursorVisible = true;
        }

        public Player.PlayerChoice GetPlayerAction()
        {
            string playerInput;
            Player.PlayerChoice playerChoice = Player.PlayerChoice.None;

            DisplayReset();

            ShowChoices();

            //DisplayPromptMessage("Enter the number for the action you would like to take: ");
            playerInput = Console.ReadLine();


            
        }

        public void ShowChoices()
        {
            Console.WriteLine("How would you like to proceed?");

            //Show choices here
            Console.WriteLine("1 - Continue Forward");
            Console.WriteLine("2 - Turn Around and Exit");
        }

        #endregion

    }
}
