using OpenQA.Selenium;

namespace Alura.ByteBank.WebApp.Testes.PageObjects
{
    public class LoginPO : PageRaiz
    {
        private IWebDriver driver;
        private By campoEmail;
        private By campoSenha;
        private By btnLogar;

        public LoginPO(IWebDriver driver) : base(driver) 
        {
            this.driver = driver;
            this.campoEmail = By.Id("Email");
            this.campoSenha = By.Id("Senha");
            this.btnLogar = By.Id("btn-logar");
        }

        public void PreencherCampos(string email, string senha)
        {
            driver.FindElement(campoEmail).SendKeys(email);
            driver.FindElement(campoSenha).SendKeys(senha);
        }

        public void btnClick() 
            => driver.FindElement(btnLogar).Click();
    }
}
    
