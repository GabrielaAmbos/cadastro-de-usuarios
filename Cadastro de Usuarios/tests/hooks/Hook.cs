using Cadastro_de_Usuarios.utils;
using TechTalk.SpecFlow;

namespace Cadastro_de_Usuarios.hooks
{
    [Binding]
    public sealed class Hook
    {
        [Before]
        public void Setup()
        {
            Browser.SetCurrentBrowser(Browser.Type.CHROME);
        }

        [After]
        public void TearDown()
        {
            Browser.QuitDriver();
        }
    }
}
