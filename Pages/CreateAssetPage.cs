using Microsoft.Playwright;
namespace PlaywrightTests.Pages;

public class CreateAssetPage
{
    private readonly IPage _page;
    private readonly string _baseUrl;
    public CreateAssetPage(IPage page)
    {
        _page=page;
        _baseUrl=Environment.GetEnvironmentVariable("SNIPEIT_URL") ?? throw new Exception("SNIPEIT_URL not set in .env file");
    }
    
    public async Task NavigateAsync()
    {
        await _page.GotoAsync($"{_baseUrl}/hardware/create");
    }
    public async Task<(string assignedUser, string assetTag)> CreateAssetAsync(string modelname, string status)
    {
        //Select Model 
        await _page.Locator("#select2-model_select_id-container").ClickAsync();
        await _page.Locator(".select2-search__field").FillAsync(modelname);
        await _page.Locator(".select2-results__option").First.ClickAsync();
        
        //Select Status 
        await _page.Locator("#select2-status_select_id-container").ClickAsync();
        await _page.GetByRole(AriaRole.Option, new() {Name = status}).ClickAsync();
        
        //Select assigned user - dropdown loads via AJAX, wait for options then pick randomly
        await _page.Locator("#select2-assigned_user_select-container").ClickAsync();
        await _page.Locator(".select2-results__option").First.WaitForAsync();
        var options = _page.Locator(".select2-results__option");
        var count = await options.CountAsync();
        var randomIndex = Random.Shared.Next(count);
        await options.Nth(randomIndex).ClickAsync();
        var rawText = await _page.Locator("#select2-assigned_user_select-container").InnerTextAsync();
        var assignedUser = rawText.Replace("×", "").Split('(')[0].Trim();
        //Read Asset Tag before Submission
        var assetTag = await _page.Locator("#asset_tag").InputValueAsync();
        
        //Save
        await _page.Locator("#submit_button").ClickAsync();
        await _page.WaitForURLAsync($"{_baseUrl}/hardware");
        
        return (assignedUser,assetTag);
    }

}