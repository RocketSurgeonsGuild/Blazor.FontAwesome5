//using Microsoft.Playwright;
//
//namespace Rocket.Surgery.Blazor.FontAwesome6.Tests;
//
//public class PlaywrightSampleTest : IClassFixture<PlaywrightFixture>
//{
//    [Fact(Skip = "ci issues")]
//    public async Task LetsGo()
//    {
//        var browser = _playwrightFixture.Browser;
//        var page = await browser.NewPageAsync();
//        await page.GotoAsync(_playwrightFixture.Uri);
//        await page.WaitForSelectorAsync(".loading-progress", new() { State = WaitForSelectorState.Detached, });
//        await Verify(page);
//    }
//
//    public PlaywrightSampleTest(PlaywrightFixture playwrightFixture)
//    {
//        _playwrightFixture = playwrightFixture;
//    }
//
//    private readonly PlaywrightFixture _playwrightFixture;
//}
