using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppTeste.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AppTeste.ViewModels
{
    public partial class CoinViewModel : ObservableObject
    {
        public CoinViewModel()
        {
             Application.Current.MainPage
                   .DisplayAlert("Mensagem", "Bem-vindo(a) ao jogo", "OK");
            FlipCommand = new Command(Flip);
        }
        public ICommand FlipCommand { get; set; }

        [ObservableProperty]
        public string _ladoEscolhido = string.Empty;
        
        [ObservableProperty]
        public string _imagem = string.Empty;
        
        [ObservableProperty] 
        public string _resultado = string.Empty;

        public async void Flip()
        {
            try
            {
                await Application.Current.MainPage
                   .DisplayAlert("Mensagem","Bem-vindo(a) ao jogo","OK");

                if (string.IsNullOrEmpty(_ladoEscolhido))
                {
                    throw new Exception("Selecione o lado da moeda");
                }
                string nome = await Application.Current.MainPage
                .DisplayPromptAsync("Indentificação", "Digite seu nome");

                string diaSemana = 
                await Application.Current.MainPage
                    .DisplayActionSheet("Dia da semana",
                    "Cancelar", 
                    "ok",
                    "Domingo",
                    "Segunda",
                    "Terça",
                    "Quarta",
                    "Quinta",
                    "Sexta",
                    "Sábado");

                Coin coin = new Coin();
                _resultado = coin.Jogar(_ladoEscolhido);
                _imagem = $"{coin.Lado}.png";

                _resultado = $"{nome}, Hoje é {diaSemana},{_resultado}";

                OnPropertyChanged(nameof(Resultado));
                OnPropertyChanged(nameof(Imagem));

                bool retorno = await Application.Current.MainPage
                    .DisplayAlert("Pergunta", "Deseja reiniciar o jogo", "sim","não");
                if (retorno)
                {
                    _resultado = string.Empty;
                    _imagem = string.Empty;

                    OnPropertyChanged(nameof(Resultado));
                    OnPropertyChanged(nameof(Imagem));
                }
            }
            catch (Exception ex)
            {
                 await Application.Current.MainPage
                    .DisplayAlert("Mensagem", ex.Message, "OK");
                
            }
            
        }



    }
}
