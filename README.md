# 🛡️ Cybersecurity Awareness Chatbot — Part 1

**Module:** Programming 2A (PROG6221)  
**Institution:** The Independent Institute of Education (IIE)  
**Assessment:** Portfolio of Evidence — Part 1

---

## 📋 Project Overview

A C# console application that acts as a **Cybersecurity Awareness Chatbot** for South African citizens. The bot educates users on topics such as phishing, password safety, safe browsing, privacy, malware, and social engineering.

---

## 🗂️ Project Structure

```
CybersecurityChatbot/
├── Program.cs              ← Entry point
├── ChatbotEngine.cs        ← Main controller / chat loop
├── ResponseEngine.cs       ← Keyword matching & response logic
├── DisplayHelper.cs        ← Console UI, ASCII art, colours, typing effect
├── AudioHelper.cs          ← WAV voice greeting playback
├── UserProfile.cs          ← User session data (automatic properties)
├── greeting.wav            ← Voice greeting audio file (add your own)
├── CybersecurityChatbot.csproj
└── .github/
    └── workflows/
        └── ci.yml          ← GitHub Actions CI workflow
```

---

## ✅ Features

| Feature | Description |
|---|---|
| 🔊 Voice Greeting | Plays `greeting.wav` on startup using `System.Media.SoundPlayer` |
| 🖼️ ASCII Art Logo | Cybersecurity Bot logo displayed as a header |
| 👤 Personalised Greeting | Asks for the user's name and uses it throughout |
| 💬 Response System | Responds to 8+ cybersecurity topics with varied answers |
| ✅ Input Validation | Handles empty input gracefully with helpful messages |
| 🎨 Enhanced Console UI | Coloured text, borders, dividers, and typing effect |
| 🏗️ Code Structure | Separated into classes and methods — no logic in `Program.cs` |
| 🔄 CI/CD | GitHub Actions workflow builds the project on every push |

---

## 🚀 How to Run

### Requirements
- Windows OS
- Visual Studio 2022 (or later) **or** .NET SDK 8.0+
- .NET Framework 4.8 (included with Windows)

### Steps

1. **Clone the repository**
   ```
   git clone https://github.com/YOUR_USERNAME/CybersecurityChatbot.git
   cd CybersecurityChatbot
   ```

2. **Add your voice greeting** *(optional but recommended)*  
   Place a file named `greeting.wav` in the `CybersecurityChatbot/` folder.  
   Record a short message such as:  
   *"Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online."*

3. **Build and run**
   ```
   dotnet build
   dotnet run --project CybersecurityChatbot
   ```
   Or open `CybersecurityChatbot.csproj` in Visual Studio and press **F5**.

---

## 💬 Supported Topics

Type any of these keywords to get a cybersecurity tip:

| Keyword | Topic |
|---|---|
| `password` | Strong password practices |
| `phishing` | Recognising phishing scams |
| `browsing` | Safe browsing habits |
| `privacy` | Protecting personal data |
| `malware` | Malware awareness |
| `social` | Social engineering |
| `2fa` | Two-factor authentication |
| `help` | Show the full topic list |
| `exit` / `quit` | Exit the chatbot |

---

## 🔄 GitHub Actions — CI Workflow

Every push to `main`/`master` automatically:
1. Checks out the code
2. Restores NuGet packages
3. Builds the project in Release mode
4. Reports success or failure

**CI Screenshot (green check mark):**  
> 📸 *Add a screenshot of your passing GitHub Actions workflow here*  
> Example: `![CI Badge](https://github.com/YOUR_USERNAME/CybersecurityChatbot/actions/workflows/ci.yml/badge.svg)`

---

## 🎬 Video Presentation

> 📹 [Watch the Part 1 Presentation on YouTube](https://www.youtube.com/@Amosghost)

---

## 📚 References

Pieterse, H. 2021. The Cyber Threat Landscape in South Africa: A 10-Year Review.  
*The African Journal of Information and Communication*, 28(28).  
doi: https://doi.org/10.23962/10539/32213
