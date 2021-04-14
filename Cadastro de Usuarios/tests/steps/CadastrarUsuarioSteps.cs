using Cadastro_de_Usuarios.pageObjects;
using Cadastro_de_Usuarios.utils;
using Cadastro_de_Usuarios.utils.providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Cadastro_de_Usuarios.steps
{
    [Binding]
    public class CadastrarUsuarioSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public CadastrarUsuarioSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        CadastroDeUsuariosPageObjects cadastroDeUsuariosPage = new CadastroDeUsuariosPageObjects();

        [Given(@"que eu acesse a página de cadastro")]
        public void DadoQueEuAcesseAPaginaDeCadastro()
        {
            Browser.LoadApplication(UrlProvider.BaseUrl());
        }
        
        [When(@"eu solicitar cadastrar um usuário")]
        public void QuandoEuSolicitarCadastrarUmUsuario()
        {
            cadastroDeUsuariosPage.ClicarBotaoCadastrar();
        }
        
        [Then(@"eu devo visualizar as mensagens de erro")]
        public void EntaoEuDevoVisualizarAsMensagensDeErro(Table mensagensDeErro)
        {
            foreach(var row in mensagensDeErro.Rows)
            {
                string campo = row["Campo"];
                string mensagem = row["Mensagem"];

                Assert.AreEqual(cadastroDeUsuariosPage.GetTextMensagemErro(campo), mensagem);
            }
        }
        [When(@"eu preencher o campo nome com ""(.*)""")]
        public void QuandoEuPreencherOCampoNomeCom(string nome)
        {
            cadastroDeUsuariosPage.PreencherCampoNome(nome);
        }

        [When(@"eu preencher o campo email com ""(.*)""")]
        public void QuandoEuPreencherOCampoEmailCom(string email)
        {
            cadastroDeUsuariosPage.PreencherCampoEmail(email);
        }

        [When(@"eu preencher o campo senha com ""(.*)""")]
        public void QuandoEuPreencherOCampoSenhaCom(string senha)
        {
            cadastroDeUsuariosPage.PreencherCampoSenha(senha);
        }

        [Then(@"eu devo visualizar a mensagem ""(.*)"" abaixo do campo ""(.*)""")]
        public void EntaoEuDevoVisualizarAMensagemAbaixoDoCampo(string mensagem, string campo)
        {
            Assert.AreEqual(cadastroDeUsuariosPage.GetTextMensagemErro(campo), mensagem);
        }

        [Then(@"eu devo visualizar os usuários cadastrados")]
        public void EntaoEuDevoVisualizarOsUsuariosCadastrados(Table informacoesDoUsuario)
        {
            foreach (var row in informacoesDoUsuario.Rows)
            {
                string id = row["Id"];
                string nome = row["Nome"];
                string email = row["E-mail"];

                Assert.AreEqual(cadastroDeUsuariosPage.GetTextId(id), id);
                Assert.AreEqual(cadastroDeUsuariosPage.GetTextNome(id), nome);
                Assert.AreEqual(cadastroDeUsuariosPage.GetTextEmail(id), email);
            }
        }

        [When(@"eu solicito excluir o usuário com o id ""(.*)""")]
        public void QuandoEuSolicitoExcluirOUsuarioComOId(string idUsuario)
        {
            cadastroDeUsuariosPage.ClicarBotaoExcluirUsuario(idUsuario);
        }


    }
}
