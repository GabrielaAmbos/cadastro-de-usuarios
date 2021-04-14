using Cadastro_de_Usuarios.elementMapper;
using Cadastro_de_Usuarios.utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Cadastro_de_Usuarios.pageObjects
{
    class CadastroDeUsuariosPageObjects : CadastroDeUsuariosElementMapper
    {
        public CadastroDeUsuariosPageObjects()
        {
            PageFactory.InitElements(Browser.GetCurrentDriver(), this);
        }

        public void PreencherCampoNome(string nome)
        {
            CampoNome.SendKeys(nome);
        }

        public void PreencherCampoEmail(string email)
        {
            CampoEmail.SendKeys(email);
        }

        public void PreencherCampoSenha(string senha)
        {
            CampoSenha.SendKeys(senha);
        }

        public void ClicarBotaoCadastrar()
        {
            BotaoCadastrar.Click();
        }

        public string GetTextMensagemErro(string campo)
        {
            int opcao;
            switch(campo)
            {
                case "Nome":
                    opcao = 1;
                    break;
                case "E-mail":
                    opcao = 2;
                    break;
                case "Senha":
                    opcao = 3;
                    break;
                default:
                    opcao = 0;
                    break;
            }
            return Browser.GetCurrentDriver().FindElement(By.CssSelector($"div.register-form div:nth-child({opcao}) > p")).Text;
        }

        public string GetTextId(string idUser)
        {
            return Browser.GetCurrentDriver().FindElement(By.CssSelector($"#tdUserId{idUser}")).Text;
        }

        public string GetTextNome(string idUser)
        {
            return Browser.GetCurrentDriver().FindElement(By.CssSelector($"#tdUserName{idUser}")).Text;
        }

        public string GetTextEmail(string idUser)
        {
            return Browser.GetCurrentDriver().FindElement(By.CssSelector($"#tdUserEmail{idUser}")).Text;
        }

        public void ClicarBotaoExcluirUsuario(string idUser)
        {
            Browser.GetCurrentDriver().FindElement(By.CssSelector($"#removeUser{idUser}")).Click();
        }
    }
}
