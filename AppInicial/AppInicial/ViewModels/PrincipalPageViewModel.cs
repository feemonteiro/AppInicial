using AppInicial.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppInicial.ViewModels
{
    public class PrincipalPageViewModel
    {
        public ObservableCollection<Pessoa> ListaPessoas { get; set; }

        public PrincipalPageViewModel()
        {
            ListaPessoas = new ObservableCollection<Pessoa>();
            ListaPessoas.Add(new Pessoa { Id = 1, Nome = "João", CPF = "123456" });
            ListaPessoas.Add(new Pessoa { Id = 2, Nome = "Pedro", CPF = "234567" });
            ListaPessoas.Add(new Pessoa { Id = 3, Nome = "Maria", CPF = "345679" });
        }
    }
}
