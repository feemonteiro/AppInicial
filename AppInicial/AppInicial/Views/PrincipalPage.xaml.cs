using AppInicial.Models;
using AppInicial.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppInicial.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PrincipalPage : ContentPage
	{
        PrincipalPageViewModel _viewModel;
		public PrincipalPage ()
		{
			InitializeComponent ();
            _viewModel = new PrincipalPageViewModel();
            //ligar view com viewmodel
            BindingContext = _viewModel;
            listagem.ItemSelected += Listagem_ItemSelected;
            //+= tab -> cria o evento
            btnAdicionar.Clicked += BtnAdicionar_Clicked;
		}
        //Evento de seleção do item da lista
        private void Listagem_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelecionado = (Pessoa) e.SelectedItem;
            //salvar o item selecionado de forma global
            Helpers.GlobalHelper.PessoaSelecionada = itemSelecionado;

            Navigation.PushAsync(new Views.DetalhePage());
          
        }

        private void BtnAdicionar_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(nomePessoa.Text) || 
               string.IsNullOrEmpty(cpfPessoa.Text))
            {
                DisplayAlert("Aviso", "Preencha todos os dados", "OK");
                return;
            }
            var lastItem = _viewModel.ListaPessoas.Last();
            Pessoa p = new Pessoa()
            {
                Id = lastItem.Id+1,
                Nome = nomePessoa.Text,
                CPF = cpfPessoa.Text
            };

            _viewModel.ListaPessoas.Add(p);

            nomePessoa.Text = string.Empty;
            cpfPessoa.Text = string.Empty;
        }
    }
}