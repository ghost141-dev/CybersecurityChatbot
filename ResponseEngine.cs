using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    
    // Handles all keyword matching and response generation for the chatbot.
    //Contains a dictionary of cybersecurity topics, each with multiple
    // possible responses that are selected randomly to keep interactions varied.
   
    public class ResponseEngine
    {
        // ── Random number generator ───────────────────────────────────────
        private readonly Random _random = new Random();

        // ── Responses dictionary ──────────────────────────────────────────
        // Key   = keyword to look for in user input (case-insensitive)
        // Value = list of possible responses (one picked at random)
        private readonly Dictionary<string, List<string>> _responses;

        // ── Constructor ───────────────────────────────────────────────────
        public ResponseEngine()
        {
            _responses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                // ── Greetings ─────────────────────────────────────────────
                ["how are you"] = new List<string>
                {
                    "I am running at 100% and all security checks are green! How can I help you?",
                    "All systems secure and ready! What cybersecurity topic can I help with?",
                    "Fully operational and threat-free! Let's talk about keeping you safe online."
                },

                // ── Purpose ───────────────────────────────────────────────
                ["purpose"] = new List<string>
                {
                    "My purpose is to educate South African citizens about cybersecurity threats\n" +
                    "   like phishing, malware, and social engineering -- and help you stay safe.",
                    "I am a Cybersecurity Awareness Bot! I help users identify online threats,\n" +
                    "   practise safe browsing, and protect their personal information."
                },

                // ── Help / Topic list ─────────────────────────────────────
                ["what can you do"] = new List<string>
                {
                    "You can ask me about any of these topics:\n\n" +
                    "   [KEY]    password  -- Strong password practices\n" +
                    "   [HOOK]   phishing  -- Spotting phishing scams\n" +
                    "   [GLOBE]  browsing  -- Safe browsing habits\n" +
                    "   [LOCK]   privacy   -- Protecting your data\n" +
                    "   [BUG]    malware   -- Avoiding malicious software\n" +
                    "   [SHIELD] 2fa       -- Two-factor authentication\n" +
                    "   [WARN]   social    -- Social engineering awareness\n\n" +
                    "   Type 'help' to see this list again at any time."
                },

                ["help"] = new List<string>
                {
                    "Here are all the topics I can help you with:\n\n" +
                    "   * password  -- Tips for creating strong passwords\n" +
                    "   * phishing  -- Recognising phishing emails and links\n" +
                    "   * browsing  -- Safe browsing habits\n" +
                    "   * privacy   -- Protecting your personal data\n" +
                    "   * malware   -- Understanding and avoiding malware\n" +
                    "   * social    -- Social engineering awareness\n" +
                    "   * 2fa       -- Two-factor authentication\n" +
                    "   * exit      -- Exit the chatbot\n\n" +
                    "   Just type any keyword above and I will help!"
                },

                // ── Password Safety ───────────────────────────────────────
                ["password"] = new List<string>
                {
                    "<<< PASSWORD SAFETY TIP >>>\n\n" +
                    "   * Use at least 12 characters mixing UPPERCASE, lowercase,\n" +
                    "     numbers, and symbols (e.g. C0ff33!Sunrise#SA).\n" +
                    "   * Never reuse the same password across multiple accounts.\n" +
                    "   * Consider using a reputable password manager like Bitwarden.",

                    "<<< STRONG PASSWORD ADVICE >>>\n\n" +
                    "   * Avoid using personal details like your name, birthday, or ID number.\n" +
                    "   * A passphrase such as 'Coffee!Sunrise#2024' is long and memorable.\n" +
                    "   * Change passwords immediately if you suspect a breach.",

                    "<<< DID YOU KNOW? >>>\n\n" +
                    "   * 81% of data breaches are caused by weak or stolen passwords.\n" +
                    "   * Enable multi-factor authentication (MFA) wherever possible.\n" +
                    "   * Never share your password -- not even with IT support staff."
                },

                // ── Phishing ──────────────────────────────────────────────
                ["phishing"] = new List<string>
                {
                    "<<< PHISHING ALERT >>>\n\n" +
                    "   * Phishing emails pretend to be from banks, SARS, or trusted brands.\n" +
                    "   * Look for spelling mistakes, urgency, and suspicious sender addresses.\n" +
                    "   * Never click links in unexpected emails -- go directly to the website.",

                    "<<< SPOTTING PHISHING >>>\n\n" +
                    "   * Hover over any link before clicking to reveal the real URL.\n" +
                    "   * Legitimate organisations will NEVER ask for your password via email.\n" +
                    "   * Report suspicious emails to your email provider immediately.",

                    "<<< PHISHING IN SOUTH AFRICA >>>\n\n" +
                    "   * SARS, Nedbank, and FNB are commonly impersonated in SA phishing scams.\n" +
                    "   * If you receive a suspicious SMS or email -- verify via the official site.\n" +
                    "   * SABRIC (SA Banking Risk Information Centre) has resources to help you."
                },

                // ── Safe Browsing ─────────────────────────────────────────
                ["browsing"] = new List<string>
                {
                    "<<< SAFE BROWSING TIPS >>>\n\n" +
                    "   * Always check for HTTPS (the padlock icon) in the address bar.\n" +
                    "   * Avoid using public Wi-Fi for banking or sensitive logins.\n" +
                    "   * Keep your browser and operating system updated at all times.",

                    "<<< BROWSING SAFETY >>>\n\n" +
                    "   * Use a reputable VPN when connecting on public networks.\n" +
                    "   * Install a browser extension like uBlock Origin to block malicious ads.\n" +
                    "   * Regularly clear your browser cookies and cache for privacy."
                },

                // ── Privacy ───────────────────────────────────────────────
                ["privacy"] = new List<string>
                {
                    "<<< PRIVACY TIPS >>>\n\n" +
                    "   * Review app permissions regularly -- does a torch app need your contacts?\n" +
                    "   * Use privacy settings on social media to limit who sees your posts.\n" +
                    "   * Be cautious about what personal information you share publicly online.",

                    "<<< PROTECTING YOUR PRIVACY >>>\n\n" +
                    "   * South Africa's POPIA law gives you rights over your personal data.\n" +
                    "   * Opt out of marketing lists and unnecessary data collection schemes.\n" +
                    "   * Use a private/incognito browser window for sensitive searches."
                },

                // ── Malware ───────────────────────────────────────────────
                ["malware"] = new List<string>
                {
                    "<<< MALWARE AWARENESS >>>\n\n" +
                    "   * Malware includes viruses, ransomware, spyware, and trojans.\n" +
                    "   * Only download software from official and trusted sources.\n" +
                    "   * Keep your antivirus software updated and run regular scans.",

                    "<<< STAYING MALWARE-FREE >>>\n\n" +
                    "   * Be wary of USB drives from unknown sources -- they can carry malware.\n" +
                    "   * Ransomware locks your files and demands payment -- back up your data!\n" +
                    "   * Never disable Windows Defender or your antivirus software."
                },

                // ── Social Engineering ────────────────────────────────────
                ["social"] = new List<string>
                {
                    "<<< SOCIAL ENGINEERING >>>\n\n" +
                    "   * Scammers psychologically manipulate people to reveal info or grant access.\n" +
                    "   * Common tactics: impersonating IT support, creating urgency, offering prizes.\n" +
                    "   * Always verify the identity of anyone asking for sensitive information.",

                    "<<< PROTECTING YOURSELF >>>\n\n" +
                    "   * No legitimate company will ever ask for your password over the phone.\n" +
                    "   * If something feels wrong, trust your instincts and verify independently.\n" +
                    "   * Educate family members -- elderly people are often targeted by scammers."
                },

                // ── Two-Factor Authentication ─────────────────────────────
                ["2fa"] = new List<string>
                {
                    "<<< TWO-FACTOR AUTHENTICATION (2FA) >>>\n\n" +
                    "   * 2FA adds a second layer of security beyond just your password.\n" +
                    "   * Even if your password is stolen, 2FA blocks unauthorised access.\n" +
                    "   * Enable it on your email, banking apps, and social media right now!"
                },

                // ── Exit ──────────────────────────────────────────────────
                ["exit"] = new List<string> { "QUIT_SIGNAL" },
                ["quit"] = new List<string> { "QUIT_SIGNAL" },
                ["bye"]  = new List<string> { "QUIT_SIGNAL" }
            };
        }

        // ── Public Method ─────────────────────────────────────────────────

        // Matches the user's input against known keywords and returns
        // a response string. Returns "QUIT_SIGNAL" for exit commands.
        // Returns a fallback message if no keyword is matched.
        public string GetResponse(string userInput, UserProfile user)
        {
            // Empty input check — caller handles the UI message
            if (string.IsNullOrWhiteSpace(userInput))
                return null;

            string input = userInput.Trim().ToLower();

            // Check every keyword against the user's input
            foreach (var entry in _responses)
            {
                if (input.Contains(entry.Key))
                {
                    user.LastTopic = entry.Key;

                    // Randomly pick one of the available responses for variety
                    List<string> options = entry.Value;
                    return options[_random.Next(options.Count)];
                }
            }

            // No keyword matched — return a helpful fallback
            return GetFallbackResponse(user.Name);
        }

        // ── Private Helper ────────────────────────────────────────────────

        
        //Returns one of several fallback messages when no keyword is recognised.
      
        private string GetFallbackResponse(string userName)
        {
            string[] fallbacks =
            {
                $"I did not quite understand that, {userName}. Could you rephrase?",
                $"Hmm, I am not sure about that one, {userName}.\n" +
                "   Try asking about: password, phishing, browsing, privacy, or type 'help'.",
                $"That is outside my current knowledge base, {userName}.\n" +
                "   Type 'help' to see all the topics I can assist with."
            };

            return fallbacks[_random.Next(fallbacks.Length)];
        }
    }
}
