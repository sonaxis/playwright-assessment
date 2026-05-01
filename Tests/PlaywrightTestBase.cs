using PlaywrightTests.Fixtures;
using PlaywrightTests.Pages;

namespace PlaywrightTests.Tests;

[Collection("Playwright")]
public abstract class PlaywrightTestBase
{
    protected readonly LoginPage _loginPage;
    protected readonly CreateAssetPage _createAssetPage;
    protected readonly AssetListPage _assetListPage;
    protected readonly AssetDetailPage _assetDetailPage;

    protected PlaywrightTestBase(BrowserFixture fixture)
    {
        _loginPage = new LoginPage(fixture.Page);
        _createAssetPage = new CreateAssetPage(fixture.Page);
        _assetListPage = new AssetListPage(fixture.Page);
        _assetDetailPage = new AssetDetailPage(fixture.Page);
    }
}
