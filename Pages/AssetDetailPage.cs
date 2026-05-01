using Microsoft.Playwright;
using System.Linq;
namespace PlaywrightTests.Pages;

public class AssetDetailPage
{
    private readonly IPage _page;

    public AssetDetailPage(IPage page)
    {
        _page=page;
    }

    public async Task<string> GetAssetTagAsync()
    {
        return await _page.Locator(".js-copy-asset_tag").InnerTextAsync();
    }

    public async Task<string> GetModelAsync()
    {
        return await _page.Locator(".js-copy-asset_model").InnerTextAsync();
    }

    public async Task<string> GetAssignedUserAsync()
    {
        return await _page.Locator(".well:has(i.fa-circle) a[href*='/users/']").InnerTextAsync();
    }

    public async Task<string> GetStatusAsync()
    {
        var text= await _page.Locator(".well:has(i.fa-circle)").InnerTextAsync();
        return text.Split('\n').Select(l=>l.Trim()).First(l=>l.Length>0);
    }
    public async Task OpenHistoryTabAsync()
    {
        await _page.Locator("a[href='#history']").ClickAsync();
    }
    public async Task<IReadOnlyList<string>> GetHistoryActionsAsync()
    {
        await _page.Locator("#history table tbody td:nth-child(4)").First.WaitForAsync();
        return await _page.Locator("#history table td:nth-child(4)").AllInnerTextsAsync();
    }

}

