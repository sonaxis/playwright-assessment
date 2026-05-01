# Playwright Assessment

Automated test for the Snipe-IT demo using .NET 10 and Playwright (xUnit).

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Setup

1. Clone the repo and navigate into it:

```
git clone <repo-url>
cd playwright-assessment
```

2. Copy the example env file:

```
cp .env.example .env
```

The default credentials are already filled in and match the public demo site — no changes needed.

3. Install Playwright browsers:

```
dotnet build
pwsh bin/Debug/net10.0/playwright.ps1 install chromium
```

## Running the tests

```
dotnet test
```

The browser will open visually (headless is off). The single test creates a new Macbook Pro 13" asset, assigns it to a random user, finds it in the asset list, verifies the detail page, and checks the History tab for the expected actions.
