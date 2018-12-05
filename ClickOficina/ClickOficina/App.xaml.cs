using ClickOficina.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ClickOficina
{
    public partial class App : Application
    {

        public static UsuarioVM usuarioVM { get; set; }

        public App()
        {
            InitializeApplication();

            MainPage = new NavigationPage(new Views.Login() { BindingContext = App.usuarioVM });
        }

        private void InitializeApplication()
        {
            if (usuarioVM == null) usuarioVM = new UsuarioVM();
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
