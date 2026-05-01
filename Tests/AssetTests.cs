using PlaywrightTests.Fixtures;
namespace PlaywrightTests.Tests;

public class AssetTests : PlaywrightTestBase
{
    public AssetTests(BrowserFixture fixture) : base(fixture) { }

    [Fact]
    public async Task CreateAsset_ShouldBeCreatedAndVerified()
    {
        // Step 1 — Login
        await _loginPage.LoginAsync();

        // Step 2 — Create asset
        await _createAssetPage.NavigateAsync();
        var (assignedUser, assetTag) = await _createAssetPage.CreateAssetAsync("Macbook Pro 13\"", "Ready to Deploy");

        // Step 3 — Verify success message
        var message = await _assetListPage.GetSuccessMessageAsync();
        Assert.Contains(assetTag, message);

        // Step 4 — Search and open asset
        await _assetListPage.SearchAssetAsync(assetTag);
        await _assetListPage.OpenAssetAsync(assetTag);

        // Step 5 — Verify detail page
        Assert.Equal(assetTag, await _assetDetailPage.GetAssetTagAsync());
        Assert.Contains("Macbook Pro 13", await _assetDetailPage.GetModelAsync());
        Assert.Contains("Ready to Deploy", await _assetDetailPage.GetStatusAsync());
        Assert.Equal(assignedUser, await _assetDetailPage.GetAssignedUserAsync());

        // Step 6 — Verify history
        await _assetDetailPage.OpenHistoryTabAsync();
        var actions = await _assetDetailPage.GetHistoryActionsAsync();
        Assert.Contains("create new", actions);
        Assert.Contains("checkout", actions);
    }
}
