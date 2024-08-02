using Alura.ByteBank.WebApp.Testes.Utilitarios;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Reflection;

namespace Alura.ByteBank.WebApp.Testes
{
    public class NavegandoNaPaginaHome : IDisposable
    {
        private readonly IWebDriver _driver;
        public NavegandoNaPaginaHome()
        {
            _driver = new EdgeDriver(Util.CaminhoNavegador());
        }

        [Fact]
        public void CarregaPaginaHomeEVerificaTituloDaPagina()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001/");
            Assert.Contains("WebApp", _driver.Title);
        }

        [Fact]
        public void CarregaPaginaHomeVerificaExistenciaLinkLoginEHome()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001/");
            Assert.Contains("Login", _driver.PageSource);
            Assert.Contains("Home", _driver.PageSource);
        }

        [Fact]
        public void LogandoNoSistema()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001/");
            _driver.Manage().Window.Size = new System.Drawing.Size(1732, 1032);
            _driver.FindElement(By.LinkText("Login")).Click();
            _driver.FindElement(By.Id("Email")).SendKeys("andre@email.com");
            _driver.FindElement(By.Id("Senha")).SendKeys("senha01");
            _driver.FindElement(By.CssSelector(".row")).Click();
            _driver.FindElement(By.CssSelector(".row")).Click();
            _driver.FindElement(By.CssSelector(".row")).Click();
            _driver.FindElement(By.Id("btn-logar")).Click();
            _driver.FindElement(By.CssSelector("html")).Click();
        }

        [Fact]
        public void ValidaLinkDeLoginNaHome()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001/");
            var linkLogin = _driver.FindElement(By.LinkText("Login"));

            //Act
            linkLogin.Click();

            //Assert
            Assert.Contains("img", _driver.PageSource);
        }

        [Fact]
        public void TentaAcessarPaginaSemEstarLogado()
        {

            //Act
            _driver.Navigate().GoToUrl("https://localhost:5001/Agencia/Index");

            //Assert
            Assert.Contains("401", _driver.PageSource);
        }

        [Fact]
        public void AcessaPaginaSemEstarLogadoVerificaUrl()
        {
            //Act
            _driver.Navigate().GoToUrl("https://localhost:5001/Agencia/Index");

            //Assert
            Assert.Contains("https://localhost:5001/Agencia/Index", _driver.Url);
            Assert.Contains("401", _driver.PageSource);
        }

        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
