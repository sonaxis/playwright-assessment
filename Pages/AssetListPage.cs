using Microsoft.Playwright;
namespace PlaywrightTests.Pages;

public class AssetListPage
{
    private readonly IPage _page;

    public AssetListPage(IPage page)
    {
        _page=page;
    }
    
    public async Task<string> GetSuccessMessageAsync()
    {
        await _page.Locator(".alert-success").WaitForAsync();
        return await _page.Locator(".alert-success").InnerTextAsync();
    }

    public async Task SearchAssetAsync(string assetTag)
    {
        await _page.Locator(".search-input").FillAsync(assetTag);
        await _page.Locator(".search-input").PressAsync("Enter");
        await _page.Locator("#assetsListingTable").Locator($"td a:has-text('{assetTag}')").First.WaitForAsync();
    }

    public async Task OpenAssetAsync(string assetTag)
    {
        await _page.Locator("#assetsListingTable").Locator($"td a:has-text('{assetTag}')").First.ClickAsync();
        await _page.WaitForURLAsync(url=> url.Contains("/hardware/"));
    }
}