using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Cadastro_de_Usuarios.elementMapper
{
    class CadastroDeUsuariosElementMapper
    {
        [FindsBy(How = How.CssSelector, Using = "#name")]
        public IWebElement CampoNome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#email")]
        public IWebElement CampoEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#password")]
        public IWebElement CampoSenha { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#register")]
        public IWebElement BotaoCadastrar { get; set; }

    }
}
