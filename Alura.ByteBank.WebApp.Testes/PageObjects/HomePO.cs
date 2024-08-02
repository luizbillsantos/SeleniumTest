using OpenQA.Selenium;

namespace Alura.ByteBank.WebApp.Testes.PageObjects
{
    public class HomePO : PageRaiz
    {
        private IWebDriver driver;
        private By linkHome;
        private By linkContaCorrentes;
        private By linkClientes;
        private By linkAgencias;

        public HomePO(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.linkHome = By.Id("home");
            this.linkContaCorrentes = By.Id("contacorrente");
            this.linkClientes = By.Id("clientes");
            this.linkAgencias = By.Id("agencia");
        }

        public void LinkHomeClick()
            => driver.FindElement(linkHome).Click();

        public void LinkContaCorrenteClick()
            => driver.FindElement(linkContaCorrentes).Click();

        public void LinkClientesClick()
            => driver.FindElement(linkClientes).Click();

        public void LinkAgenciasClick()
            => driver.FindElement(linkAgencias).Click();
    }
}
