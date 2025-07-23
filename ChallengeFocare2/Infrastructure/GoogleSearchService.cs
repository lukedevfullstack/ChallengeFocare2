using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace ChallengeFocare2.Infrastructure
{
    public class GoogleSearchService : IDisposable
    {
        private readonly IWebDriver _webDriver;

        public GoogleSearchService()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            _webDriver = new ChromeDriver(options);
        }

        public void OpenGoogleAndFilterTopResults(int maxResults = 2)
        {
            _webDriver.Navigate().GoToUrl("https://www.google.com");

            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(120));
            wait.Until(driver =>
            {
                var h3s = driver.FindElements(By.CssSelector("h3"));
                return h3s.Count > 0 && !string.IsNullOrWhiteSpace(h3s[0].Text);
            });

            string jsScript = $@"(function(){{const allBlocks=Array.from(document.querySelectorAll('div.g, div.MjjYud'));let count=0;allBlocks.forEach(el=>{{const hasTitle=el.querySelector('h3');const isAd=el.innerText.toLowerCase().includes('anúncio');const isPeopleAlsoAsk=el.innerText.toLowerCase().includes('outras pessoas também perguntaram');const isImageBlock=el.innerHTML.includes('aria-label=\""Imagens\""');const isRelatedSearch=el.innerText.toLowerCase().includes('pesquisas relacionadas');if(hasTitle&&!isAd&&!isPeopleAlsoAsk&&!isImageBlock&&!isRelatedSearch&&count<{maxResults}){{count++;}}else{{el.style.display='none';}}}});}})();";

            ((IJavaScriptExecutor)_webDriver).ExecuteScript(jsScript);
        }

        public void Dispose()
        {
        }
    }
}
