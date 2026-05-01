using Microsoft.Playwright;

namespace PlaywrightTests.Fixtures;
public class BrowserFixture : IAsyncLifetime
{
    public IPage Page { get; private set; } = null!;
    private IBrowser _browser = null!;
    private IPlaywright _playwright = null!;

    public async Task InitializeAsync()
    {
        DotNetEnv.Env.Load();
        _playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new()
        {
            Headless = false
        });
        Page = await _browser.NewPageAsync();
    }
    public async Task DisposeAsync()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
}