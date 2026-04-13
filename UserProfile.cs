namespace CybersecurityChatbot
{
    // Stores information about the current user session.
    // Uses automatic properties as required by the assignment brief.
    
    public class UserProfile
    {
        // ── Automatic Properties ─────────────────────────────────────────

        //The user's name entered at startup.
        public string Name { get; set; }

        //Tracks how many messages the user has sent.
        public int MessageCount { get; set; }

        //The last topic the user asked about.  
        public string LastTopic { get; set; }

        // ── Constructor ──────────────────────────────────────────────────
        public UserProfile(string name)
        {
            Name         = name;
            MessageCount = 0;
            LastTopic    = string.Empty;
        }

        //Increments the message counter each time the user sends input.
        public void IncrementMessages()
        {
            MessageCount++;
        }
    }
}
