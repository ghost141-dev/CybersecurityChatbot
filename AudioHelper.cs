using System;
using System.Media;
using System.IO;

namespace CybersecurityChatbot
{
    // Handles audio playback for the chatbot's voice greeting.
    // Uses System.Media.SoundPlayer to play a WAV file on startup.
    public static class AudioHelper
    {
        // Path to the WAV greeting file (relative to the executable)
        private const string WavFileName = "greeting.wav";

        // Plays the voice greeting WAV file if it exists.
        // If the file is missing, a friendly notice is shown instead.
        public static void PlayGreeting()
        {
            try
            {
                // Build the full path relative to the running executable
                string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string wavPath = Path.Combine(exeDirectory, WavFileName);

                if (File.Exists(wavPath))
                {
                    using (SoundPlayer player = new SoundPlayer(wavPath))
                    {
                        // PlaySync blocks until the audio finishes
                        player.PlaySync();
                    }
                }
                else
                {
                    // Inform the user the WAV is not found but continue gracefully
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"  [Audio] Voice greeting file '{WavFileName}' not found.");
                    Console.WriteLine("  [Audio] Place a 'greeting.wav' file in the same folder as the .exe");
                    Console.WriteLine("  [Audio] to enable the voice greeting feature.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                // Non-fatal: audio failure should never crash the chatbot
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"  [Audio] Could not play greeting: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}
