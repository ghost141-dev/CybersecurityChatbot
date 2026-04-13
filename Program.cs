using System;
using System.Text;

namespace CybersecurityChatbot
{
    // Entry point for the Cybersecurity Awareness Chatbot.
    // Sets up the console for UTF-8 and emoji rendering, then launches the engine.
    
    class Program
    {
        static void Main(string[] args)
        {
            // ── Console encoding setup ────────────────────────────────────
            // MUST come before any Console.Write calls.
            // Tells Windows to use UTF-8 so box-drawing characters
            // and emojis render correctly in the console.
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding  = Encoding.UTF8;

            Console.Title = "Cybersecurity Awareness Bot";

            // Launch the chatbot
            ChatbotEngine engine = new ChatbotEngine();
            engine.Run();
        }
    }
}
