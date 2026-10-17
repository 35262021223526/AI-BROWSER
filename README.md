# Nova AI Browser

A Windows browser starter with a branded search page, web search, a matching logo, and Microsoft Copilot as an optional AI companion.

## Try it

On Windows with Microsoft Edge installed, double-click **Nova AI Browser.exe**. Keep the executable next to `AI-Browser.html`, `AI-Browser-Logo.svg`, and `AI-Browser.ico`.

You can also open `AI-Browser.html` directly in a modern browser. Searches open in a new tab, and **Ask AI** opens Microsoft Copilot.

## Windows desktop source

`WindowsApp/` contains a WPF desktop browser project using WebView2. To run it, install the .NET 8 SDK and Microsoft Edge WebView2 Runtime, then run:

```powershell
dotnet run --project WindowsApp\NovaBrowser.csproj
```

The desktop app starts at Bing and can open Copilot in the system browser.

## Project files

- `AI-Browser.html` — standalone responsive browser start page.
- `AI-Browser-Logo.svg` — scalable logo used in the page.
- `AI-Browser.ico` — Windows application icon.
- `Nova AI Browser.exe` — small Windows launcher for the HTML page.
- `WindowsApp/` — WPF/WebView2 desktop application source.
- `Nova-AI-Browser-Windows.zip` — packaged project files.

## Scope

This is a browser starter, not a standalone browser engine or an embedded AI model. The launcher requires Microsoft Edge; the desktop source requires WebView2. Copilot availability may depend on region, account, and Microsoft service requirements.
