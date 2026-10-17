NOVA AI BROWSER STARTER
=======================

Included
--------
AI-Browser.html       Standalone browser start-page prototype for Windows.
AI-Browser-Logo.svg   Matching vector logo.
AI-Browser.ico        Custom Windows app and executable icon.
WindowsApp\           WPF desktop browser source project for Windows.
Nova AI Browser.exe   Branded desktop launcher that opens the HTML app in Edge app mode.

Standalone HTML
---------------
Open AI-Browser.html in Microsoft Edge, Chrome, or another modern browser.
Searches and web addresses open in a new tab. The Ask AI button opens
Microsoft Copilot in a new tab.

Desktop launcher
----------------
Nova AI Browser.exe opens AI-Browser.html in an app-style Microsoft Edge
window. Keep the HTML file beside the EXE and make sure Microsoft Edge is
installed. The EXE is a launcher, not a self-contained browser engine.

Windows desktop app
-------------------
Requirements: Windows 10/11, .NET 8 SDK, and the Microsoft Edge WebView2
Runtime. Open WindowsApp\NovaBrowser.csproj in Visual Studio, or run:

  dotnet run --project WindowsApp\NovaBrowser.csproj

The desktop app uses Bing for web search and opens Copilot separately.
It does not include an AI model, provider credentials, or a Copilot integration
inside web pages. Copilot availability may depend on region, account, and
Microsoft service requirements.
