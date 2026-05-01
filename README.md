# Playwright Assessment

Automated test for the Snipe-IT demo using .NET 10 and Playwright (xUnit).

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [PowerShell 7+ (pwsh)](https://aka.ms/powershell) — required to run the Playwright installer script

## Setup

1. Clone the repo and navigate into it:

```
git clone <repo-url>
cd playwright-assessment
```

2. Copy the example env file:

**Windows (PowerShell):**
```
Copy-Item .env.example .env
```

**macOS / Linux:**
```
cp .env.example .env
```

The default credentials are already filled in and match the public demo site — no changes needed.

3. Build and install Playwright browsers:

```
dotnet build playwright-assessment.sln
pwsh bin/Debug/net10.0/playwright.ps1 install chromium
```

> If you have Windows PowerShell 5.1 instead of PowerShell 7, replace `pwsh` with `powershell`.

## Running the tests

```
dotnet test playwright-assessment.sln
```

The browser will open visually (headless is off). The single test creates a new Macbook Pro 13" asset, assigns it to a random user, finds it in the asset list, verifies the detail page, and checks the History tab for the expected actions.

> The tests run against the public Snipe-IT demo at [https://snipeitapp.com/demo](https://snipeitapp.com/demo). Make sure it is reachable before running.
