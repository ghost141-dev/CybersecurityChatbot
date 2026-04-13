using System;
using System.Threading;

namespace CybersecurityChatbot
{
   
    //Handles all console display formatting, colours, borders,
    //ASCII art, typing effects, and emoji labels for the chatbot UI.
    // "Lucida Console" AND Console.OutputEncoding = Encoding.UTF8 must be
    // called in Program.cs before any output is written.
    // In Visual Studio: Debug -> [Project] Properties -> set "Use UTF-8 encoding"
    // or run via Windows Terminal for best emoji support.
    public static class DisplayHelper
    {
        // ── Colour scheme ─────────────────────────────────────────────────
        public static readonly ConsoleColor PrimaryColour = ConsoleColor.Cyan;
        public static readonly ConsoleColor BotColour     = ConsoleColor.Green;
        public static readonly ConsoleColor UserColour    = ConsoleColor.Yellow;
        public static readonly ConsoleColor ErrorColour   = ConsoleColor.Red;
        public static readonly ConsoleColor BorderColour  = ConsoleColor.DarkCyan;

        // ── ASCII Art Logo ────────────────────────────────────────────────
        
        public static void ShowAsciiLogo()
{
    Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"  _____ __   __ ____  ______ _____ ");
            Console.WriteLine(@" / ____|\ \ / /|  _ \|  ____|  __ \");
            Console.WriteLine(@"| |      \ V / | |_) | |__  | |__) |");
            Console.WriteLine(@"| |       > <  |  _ <|  __| |  _  /");
            Console.WriteLine(@"| |____  / . \ | |_) | |____| | \ \");
            Console.WriteLine(@" \_____|/_/ \_\|____/|______|_|  \_\");
            Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.DarkCyan;

    Console.WriteLine(@"   _____                      _ _         ");
    Console.WriteLine(@"  / ____|                    (_) |        ");
    Console.WriteLine(@" | (___   ___  ___ _   _ _ __ _| |_ _   _ ");
    Console.WriteLine(@"  \___ \ / _ \/ __| | | | '__| | __| | | |");
    Console.WriteLine(@"  ____) |  __/ (__| |_| | |  | | |_| |_| |");
    Console.WriteLine(@" |_____/ \___|\___|\__,_|_|  |_|\__|\__, |");
    Console.WriteLine(@"                                     __/ |");
    Console.WriteLine(@"                                    |___/  ");
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Green;

    Console.WriteLine(@"   _____ _           _   ____        _   ");
    Console.WriteLine(@"  / ____| |         | | |  _ \      | |  ");
    Console.WriteLine(@" | |    | |__   __ _| |_| |_) | ___ | |_ ");
    Console.WriteLine(@" | |    | '_ \ / _` | __|  _ < / _ \| __|");
    Console.WriteLine(@" | |____| | | | (_| | |_| |_) | (_) | |_ ");
    Console.WriteLine(@"  \_____|_| |_|\__,_|\__|____/ \___/ \__|");
    Console.WriteLine();

    Console.ResetColor();


            // ── Shield graphic ────────────────────────────────────────────
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("              .------.");
            Console.WriteLine("             /  SA    \\");
            Console.WriteLine("            |  ( ** )  |");
            Console.WriteLine("            |   \\  /   |");
            Console.WriteLine("             \\   \\/   /");
            Console.WriteLine("              '------'");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("         [ Cybersecurity Bot ]");
            Console.ResetColor();
            Console.WriteLine();
        }

        // ── Borders & Dividers ────────────────────────────────────────────

        /// <summary>Prints a full-width double-line border using = signs.</summary>
        public static void ShowDoubleBorder()
        {
            Console.ForegroundColor = BorderColour;
            Console.WriteLine(new string('=', 68));
            Console.ResetColor();
        }

        /// <summary>Prints a full-width single-line divider using - signs.</summary>
        public static void ShowDivider()
        {
            Console.ForegroundColor = BorderColour;
            Console.WriteLine(new string('-', 68));
            Console.ResetColor();
        }

        // ── Section Headers ───────────────────────────────────────────────

        /// <summary>Prints a styled section header between two borders.</summary>
        public static void ShowSectionHeader(string title)
        {
            Console.WriteLine();
            ShowDoubleBorder();
            Console.ForegroundColor = PrimaryColour;
            Console.WriteLine($"  >> {title.ToUpper()}");
            ShowDoubleBorder();
            Console.ResetColor();
        }

        // ── Bot / User Messages ───────────────────────────────────────────

    
        // Prints a bot message in green with a typing animation.
        //Uses a robot label prefix.
        
        public static void BotMessage(string message, bool typeEffect = true)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("  [BOT] >> ");
            Console.ForegroundColor = BotColour;

            if (typeEffect)
                TypeWrite(message);
            else
                Console.WriteLine(message);

            Console.ResetColor();
        }

        // Prints the user input prompt in yellow.
        public static void UserPrompt(string name = "You")
        {
            Console.WriteLine();
            Console.ForegroundColor = UserColour;
            Console.Write($"  [YOU] {name} >> ");
            Console.ResetColor();
        }

        // Prints an error message in red.
        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ErrorColour;
            Console.WriteLine($"  [!] {message}");
            Console.ResetColor();
        }

        // Prints an informational message in white.
        public static void InfoMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"  [i] {message}");
            Console.ResetColor();
        }

        // ── Welcome Banner ────────────────────────────────────────────────

        // Displays the styled welcome banner after the logo.
        public static void ShowWelcomeBanner()
        {
            ShowDoubleBorder();
            Console.ForegroundColor = PrimaryColour;
            Console.WriteLine("  Welcome to the Cybersecurity Awareness Bot");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  Protecting South African citizens -- one tip at a time.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  Powered by The IIE  |  PROG6221  |  2026");
            ShowDoubleBorder();
            Console.ResetColor();
            Console.WriteLine();
        }

        // ── Typing Effect ─────────────────────────────────────────────────

        // Prints text one character at a time with a small delay
        // to simulate a natural conversational typing feel.
        private static void TypeWrite(string text, int delayMs = 15)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        // ── Utilities ─────────────────────────────────────────────────────

        // Clears the console screen with a black background.
        public static void ClearScreen()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        // Shows a pause message and waits for the user to press Enter.
        public static void PausePrompt()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n  Press ENTER to exit...");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
