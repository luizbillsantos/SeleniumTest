using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using Bogus;
using Bogus.Extensions.Brazil;
using Xunit.Abstractions;
using Alura.ByteBank.WebApp.Testes.PageObjects;
using Alura.ByteBank.WebApp.Testes.Utilitarios;

namespace Alura.ByteBank.WebApp.Testes
{
    public class AposRealizarLogin : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly Faker _faker;
        private readonly LoginPO _loginPO;
        private readonly HomePO _homePO;
        private ITestOutputHelper _saidaConsoleTest;

        public AposRealizarLogin(ITestOutputHelper saidaConsoleTest)
        {
            _driver = new EdgeDriver(Util.CaminhoNavegador());
            _faker = new Faker("pt_BR");
            _saidaConsoleTest = saidaConsoleTest;
            _loginPO = new LoginPO(_driver);
            _homePO = new HomePO(_driver);
        }

        [Fact]
        public void AposRealizarLoginVerificaSeExisteOpcaoAgenciaMenu() 
        {
            //Arrange
            _loginPO.Navegar("https://localhost:5001/UsuarioApps/Login");

            //Act
            _loginPO.PreencherCampos("andre@email.com", "senha01");
            _loginPO.btnClick();

            //Assert
            Assert.Contains("Agência", _driver.PageSource);
        }

        [Fact]
        public void TentaRealizarLoginSemPreencherCampos()
        {
            //Arrange
            _loginPO.Navegar("https://localhost:5001/UsuarioApps/Login");

            //Act
            _loginPO.btnClick();

            //Assert
            Assert.Contains("The Email field is required.", _driver.PageSource);
        }

        [Fact]
        public void TentaRealizarLoginComSenhaInvalida()
        {
            //Arrange
            _loginPO.Navegar("https://localhost:5001/UsuarioApps/Login");

            //Act
            _loginPO.PreencherCampos("andre@email.com", "senha010");
            _loginPO.btnClick();

            //Assert
            Assert.Contains("Login", _driver.PageSource);
        }

        [Fact]
        public void RealizarLoginAcessaMenuECadasdtraCliente()
        {
            //Arrange
            _loginPO.Navegar("https://localhost:5001/UsuarioApps/Login");
            _loginPO.PreencherCampos("andre@email.com", "senha01");
            _loginPO.btnClick();

            _driver.FindElement(By.LinkText("Cliente")).Click();
            _driver.FindElement(By.LinkText("Adicionar Cliente")).Click();

            _driver.FindElement(By.Name("Identificador")).Click();
            _driver.FindElement(By.Name("Identificador")).SendKeys(Guid.NewGuid().ToString());

            _driver.FindElement(By.Name("CPF")).Click();
            _driver.FindElement(By.Name("CPF")).SendKeys(_faker.Person.Cpf());

            _driver.FindElement(By.Name("Nome")).Click();
            _driver.FindElement(By.Name("Nome")).SendKeys(_faker.Name.FullName());

            _driver.FindElement(By.Name("Profissao")).Click();
            _driver.FindElement(By.Name("Profissao")).SendKeys(_faker.Lorem.Word());

            //Act
            _driver.FindElement(By.CssSelector(".btn-primary")).Click();
            _driver.FindElement(By.LinkText("Home")).Click();


            //Assert
            Assert.Contains("Logout", _driver.PageSource);
        }

        [Fact]
        public void RealizarLoginAcessarListagemDeContas()
        {
            //Arrange
            _loginPO.Navegar("https://localhost:5001/UsuarioApps/Login");
            _loginPO.PreencherCampos("andre@email.com", "senha01");
            _loginPO.btnClick();

            _driver.FindElement(By.Id("contacorrente")).Click();
            IReadOnlyCollection<IWebElement> elements = _driver.FindElements(By.TagName("a"));
            var elemento = elements.FirstOrDefault(e => e.Text.Contains("Detalhes"));

            //Act
            elemento.Click();

            //Assert
            Assert.True(elements.Count == 12);
        }

        [Fact]
        public void RealizarLoginAcessarListagemDeContasUsandoHomePO()
        {
            //Arrange
            _loginPO.Navegar("https://localhost:5001/UsuarioApps/Login");
            _loginPO.PreencherCampos("andre@email.com", "senha01");
            _loginPO.btnClick();

            _homePO.LinkContaCorrenteClick();
            IReadOnlyCollection<IWebElement> elements = _driver.FindElements(By.TagName("a"));
            var elemento = elements.FirstOrDefault(e => e.Text.Contains("Detalhes"));

            //Act
            elemento.Click();

            //Assert
            Assert.True(elements.Count == 12);
        }

        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
