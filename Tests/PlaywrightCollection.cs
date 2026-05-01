using PlaywrightTests.Fixtures;

namespace PlaywrightTests.Tests;

[CollectionDefinition("Playwright")]
public class PlaywrightCollection : ICollectionFixture<BrowserFixture> { }