using OpenQA.Selenium;

namespace Alura.ByteBank.WebApp.Testes.PageObjects
{

    public class PageRaiz : IPageRaiz
    {
        protected IWebDriver driver;

        public PageRaiz(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Navegar(string url)
            => driver.Navigate().GoToUrl(url);
    }
}
