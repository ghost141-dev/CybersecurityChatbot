using System;

namespace CybersecurityChatbot
{
    //Main controller for the Cybersecurity Awareness Chatbot.
    // Coordinates startup (audio, logo, banner), user greeting, and the chat loop.
    public class ChatbotEngine
    {
        // ── Dependencies ──────────────────────────────────────────────────
        private readonly ResponseEngine _responseEngine;
        private UserProfile _currentUser;

        // ── Constructor ───────────────────────────────────────────────────
        public ChatbotEngine()
        {
            _responseEngine = new ResponseEngine();
        }

        // ── Public Entry Point ────────────────────────────────────────────

        // Runs the full chatbot lifecycle:
        // 1. Initialise console
        // 2. Play audio + show logo + banner
        // 3. Ask for name
        // 4. Show personalised welcome
        // 5. Run conversation loop
        // 6. Show goodbye
        public void Run()
        {
            InitialiseConsole();
            ShowStartupSequence();
            string userName = GetUserName();
            _currentUser = new UserProfile(userName);
            ShowPersonalisedWelcome(userName);
            RunChatLoop();
            ShowGoodbyeMessage();
        }

        // ── Startup ───────────────────────────────────────────────────────

        // Sets up the console window size and background colour.
        // Wrapped in try/catch because some terminals block window resizing.
        private void InitialiseConsole()
        {
            DisplayHelper.ClearScreen();
            try
            {
                Console.WindowWidth = Math.Max(Console.WindowWidth, 80);
                Console.BufferWidth = Math.Max(Console.BufferWidth, 120);
            }
            catch
            {
                // Silently ignore — not all terminals support resizing
            }
        }

        // Step 1: Plays the WAV voice greeting.
        // Step 2: Shows the ASCII logo.
        // Step 3: Shows the welcome banner.
        private void ShowStartupSequence()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n  >> Playing voice greeting...");
            Console.ResetColor();
            AudioHelper.PlayGreeting();

            DisplayHelper.ShowAsciiLogo();
            DisplayHelper.ShowWelcomeBanner();
        }

        // Prompts the user to enter their name.
        // Loops until a non-empty name is entered (input validation).
        private string GetUserName()
        {
            DisplayHelper.ShowSectionHeader("Getting Started");
            DisplayHelper.BotMessage("Hello! I'm your Cybersecurity Awareness Bot.");
            DisplayHelper.BotMessage("Before we begin — what is your name?");

            string name = string.Empty;

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  [YOU] Your name: ");
                Console.ResetColor();

                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    DisplayHelper.ErrorMessage("Name cannot be empty. Please try again.");
                }
            }

            return name.Trim();
        }

        // Displays a personalised multi-line welcome message using the user's name.
        private void ShowPersonalisedWelcome(string userName)
        {
            Console.WriteLine();
            DisplayHelper.ShowDoubleBorder();
            DisplayHelper.BotMessage($"Welcome, {userName}! Great to meet you  :-)");
            DisplayHelper.BotMessage("I am here to help you stay safe online.");
            DisplayHelper.BotMessage("Ask me about any of these topics:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("     password   |   phishing   |   browsing   |   privacy");
            Console.WriteLine("     malware    |    social    |     2fa      |    help");
            Console.WriteLine();
            Console.ResetColor();
            DisplayHelper.BotMessage("Type 'help' to see the full list, or 'exit' to quit.");
            DisplayHelper.ShowDoubleBorder();
            Console.WriteLine();
        }

        // ── Main Chat Loop ────────────────────────────────────────────────

    
        // Continuously reads user input, validates it, gets a response
        // from the ResponseEngine, and prints it — until the user exits.
        private void RunChatLoop()
        {
            bool isRunning = true;

            while (isRunning)
            {
                // Show the prompt with the user's name
                DisplayHelper.UserPrompt(_currentUser.Name);
                string userInput = Console.ReadLine();

                // Count every message attempt
                _currentUser.IncrementMessages();

                // ── Validate: empty input ─────────────────────────────────
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine();
                    DisplayHelper.ErrorMessage("You didn't type anything. Please enter a message.");
                    DisplayHelper.BotMessage("I didn't quite understand that. Could you rephrase?", false);
                    DisplayHelper.ShowDivider();
                    continue;
                }

                // ── Get response ──────────────────────────────────────────
                string response = _responseEngine.GetResponse(userInput, _currentUser);
                Console.WriteLine();

                // ── Check for exit signal ─────────────────────────────────
                if (response == "QUIT_SIGNAL")
                {
                    isRunning = false;
                    continue;
                }

                // ── Display the response ──────────────────────────────────
                DisplayHelper.BotMessage(response);
                DisplayHelper.ShowDivider();
            }
        }

        // ── Goodbye ───────────────────────────────────────────────────────

        // Shows a personalised farewell message with a session summary.
        private void ShowGoodbyeMessage()
        {
            Console.WriteLine();
            DisplayHelper.ShowDoubleBorder();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("   +-----------------------------------------+");
            Console.WriteLine("   |       STAY SAFE ONLINE!                  |");
            Console.WriteLine("   |       Think before you click.            |");
            Console.WriteLine("   +-----------------------------------------+");
            Console.WriteLine();
            Console.ResetColor();
            DisplayHelper.BotMessage($"Goodbye, {_currentUser.Name}! Take care.", false);
            DisplayHelper.BotMessage($"You sent {_currentUser.MessageCount} message(s) this session.", false);
            DisplayHelper.ShowDoubleBorder();
            Console.WriteLine();
            DisplayHelper.PausePrompt();
        }
    }
}
