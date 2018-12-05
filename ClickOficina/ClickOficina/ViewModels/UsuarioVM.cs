using ClickOficina.Model;
using ClickOficina.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace ClickOficina.ViewModels
{
    public class UsuarioVM : INotifyPropertyChanged
    {
        public Usuario usuarioBinding { get; set; }


        public OnUsuarioAdd OnUsuarioAdd { get; }
        public OnUsuariologin OnUsuariologin { get; }
        public OnCadastrar OnCadastrar { get; }

        public UsuarioVM()
        {
            usuarioBinding = new Usuario();
            UsuarioRepository repository = UsuarioRepository.Instance;
            OnUsuariologin = new OnUsuariologin(this);
            OnUsuarioAdd = new OnUsuarioAdd(this);
            OnCadastrar = new OnCadastrar();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Salvar(Usuario userParam)
        {
            if (userParam != null)
            {
                UsuarioRepository.Salvar(userParam);
                App.Current.MainPage.Navigation.PushAsync(
                    new Views.Login()
                    {
                        BindingContext = App.usuarioVM
                    });
            }

            else
                App.Current.MainPage.DisplayAlert("Erro", "Erro ao salvar", "OK");
        }

        public void GetUsuario(Usuario userParam)
        {

            this.usuarioBinding = UsuarioRepository.GetUsuario(userParam.email);
            if (this.usuarioBinding != null)
                App.Current.MainPage.Navigation.PushAsync(
                        new Views.Home() { BindingContext = App.usuarioVM });
            else
                App.Current.MainPage.DisplayAlert("Erro", "Erro ao logar", "OK");

        }

    }

    public class OnUsuarioAdd : ICommand
    {
        private UsuarioVM usuarioVM;
        public OnUsuarioAdd(UsuarioVM usuariovm)
        {
            usuarioVM = usuariovm;
        }
        public event EventHandler CanExecuteChanged;
        public void AdicionarCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            usuarioVM.Salvar(parameter as Usuario);
        }
    }

    public class OnUsuariologin : ICommand
    {
        private UsuarioVM usuarioVM;
        public OnUsuariologin(UsuarioVM usuariovm)
        {
            usuarioVM = usuariovm;
        }
        public event EventHandler CanExecuteChanged;
        public void AdicionarCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            usuarioVM.GetUsuario(parameter as Usuario);
        }
    }


    public class OnCadastrar : ICommand
    {

        public event EventHandler CanExecuteChanged;
        public void AdicionarCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            App.Current.MainPage.Navigation.PushAsync(
                   new Views.Cadastro());
        }
    }

}
