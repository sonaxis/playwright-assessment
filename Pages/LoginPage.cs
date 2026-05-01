using Microsoft.Playwright;
namespace PlaywrightTests.Pages;
public class LoginPage
{
    private readonly IPage _page;
    public LoginPage(IPage page)
    {
        _page = page;
    }
    public async Task LoginAsync()
    {
        var username = Environment.GetEnvironmentVariable("SNIPEIT_USERNAME") ?? throw new Exception("SNIPEIT_USERNAME not set in .env file");
        var password = Environment.GetEnvironmentVariable("SNIPEIT_PASSWORD") ?? throw new Exception("SNIPEIT_PASSWORD not set in .env file");
        var url = Environment.GetEnvironmentVariable("SNIPEIT_URL") ?? throw new Exception("SNIPEIT_URL not set in .env file");
        await _page.GotoAsync($"{url}/login");
        await _page.Locator("#username").FillAsync(username);
        await _page.Locator("#password-field").FillAsync(password);
        await _page.Locator("#submit").ClickAsync();
        await _page.WaitForURLAsync($"{url}");
    }
}