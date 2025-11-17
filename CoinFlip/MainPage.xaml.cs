using System.Threading.Tasks;

namespace CoinFlip
{
    public partial class MainPage : ContentPage
    {
        int i, sorteado, itemIndex= -1, tentativas = 0, sm = 0;
        string face = "cara.pgn";

        Game jogo = new Game();

        public MainPage()
        {
            InitializeComponent();
            
        }

        private async void FlipButton_Clicked(object sender, EventArgs e)
        {
            //Verificar qual opção está selecionada?
            itemIndex = FacePicker.SelectedIndex;

            if (itemIndex == -1)
            {
                await DisplayAlert("Moeda", "Escolha a Face da Moeda!", "OK");
            }
            else
            {
                //Fazer o sorteio do lado da moeda.
                //Classe ... Variável... Uso do Construtor;
                
                Coin moeda = new Coin();
                face = moeda.Flip();

                await Animate(face);

                sorteado = moeda.LadoSorteado == "cara" ? 0 : 1; 

                //Comparar com a opção selecionada
                //Informar se o usuário ganho ou perdeu em um alert.
                if (jogo.CheckWinner(sorteado,itemIndex))
                {
                    await DisplayAlert("Sorteio", $"PARABÉNS!!! \nDeu {face}! \nVocê GANHOU!", "OK");
                }
                else
                {
                    await DisplayAlert("Sorteio", $"Que PENA!!!\nDeu {face}! \nVocê PERDEU!", "OK");
                }

                Total.Text = $"Total de vitórias: {jogo.Total}";
                Sequencia.Text = $"Sequencia de vitorias: {jogo.Sequencia}";
                tentativas += 1;
                Tentativas.Text = $"Tentativas: {tentativas}";
                if (jogo.Sequencia > sm)
                {
                    sm = jogo.Sequencia;
                }
                Sm.Text = $"Sequência máxima de vitórias: {sm}";

            }
        }

        public void Resetar(object sender, EventArgs e)
        {
            jogo.Total = 0 ;
            jogo.Sequencia = 0 ;
            tentativas = 0 ;
            sm = 0 ;

            Total.Text = $"Total de vitórias: {jogo.Total}";
            Sequencia.Text = $"Sequencia de vitorias: {jogo.Sequencia}";
            Tentativas.Text = $"Tentativas: {tentativas}";
            Sm.Text = $"Sequência máxima de vitórias: {sm}";
        }
        
        private async Task Animate(string face)
        {
            Random giros = new Random();
            for (i = 0; i < giros.Next(1,10); i++)
            {

                if (face == "cara")
                {
                    await Task.Delay(50);
                    FaceImage.Source = "cc.png";
                    await Task.Delay(50);
                    FaceImage.Source = "coroa.png";
                }
                else
                {
                    await Task.Delay(50);
                    FaceImage.Source = "cc.png";
                    await Task.Delay(50);
                    FaceImage.Source = "cara.png";
                }

                await Task.Delay(50);
                FaceImage.Source = "cc.png";
                await Task.Delay(50);
                FaceImage.Source = $"{face}.png";
            }
        }
    }

}
