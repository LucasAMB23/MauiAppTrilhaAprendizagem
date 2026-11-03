namespace MauiAppTrilhaAprendizagem.Views;


    public partial class CriarConteudoPage : ContentPage
{
    private string caminhoImagemSelecionada = string.Empty;

    public CriarConteudoPage()
    {
        InitializeComponent();
    }

    // Simula a abertura da galeria de fotos do dispositivo
    private async void OnUploadImagemClicked(object sender, EventArgs e)
    {
        try
        {
            var resultado = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Selecione uma imagem pedagógica",
                FileTypes = FilePickerFileType.Images
            });

            if (resultado != null)
            {
                caminhoImagemSelecionada = resultado.FullPath;
                lblNomeImagem.Text = $"Selecionado: {resultado.FileName}";
            }

        }
        catch (Exception)
        {
            await DisplayAlert("Erro", "Não foi possível carregar a imagem.", "OK");
        }
    }

    // Valida as informações e publica na trilha
    private async void OnSalvarConteudoClicked(object sender, EventArgs e)
    {

        // Validação simples de campos vazios
        if (pickerTrilha.SelectedIndex == -1 ||
            string.IsNullOrWhiteSpace(entryPergunta.Text) ||
            string.IsNullOrWhiteSpace(entryAltA.Text) ||
            string.IsNullOrWhiteSpace(entryAltB.Text) ||
            string.IsNullOrWhiteSpace(entryAltC.Text) ||
            pickerCorreta.SelectedIndex == -1)
        {
            await DisplayAlert("Atenção", "Por favor, preencha todos os campos do formulário.", "OK");
            return;
        }

        // Captura os dados que seriam enviados ao banco
        string trilhaAlvo = pickerTrilha.SelectedItem.ToString();

        // Exibe o feedback de sucesso da publicação dinâmica
        await DisplayAlert("Sucesso!", $"A atividade foi publicada automaticamente na {trilhaAlvo}.", "OK");

        // Retorna o designer para a página inicial dele
        await Navigation.PopAsync();
    }
}
