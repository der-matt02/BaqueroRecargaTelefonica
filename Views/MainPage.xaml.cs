namespace BaqueroRecargaTelefonica.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        radio3.CheckedChanged += MA_OnMontoChanged;
        radio5.CheckedChanged += MA_OnMontoChanged;
        radio10.CheckedChanged += MA_OnMontoChanged;
    }

    private void MA_OnMontoChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            var radioButton = (RadioButton)sender;
            DisplayAlert("Monto Seleccionado", $"Has seleccionado {radioButton.Content}", "OK");
        }
    }

    private async void MA_btnRecargar_Clicked(object sender, EventArgs e)
    {
        string telefono = inputTelefono.Text;
        string operador = pickerOperador.SelectedItem?.ToString();
        string monto = null;

        if (radio3.IsChecked)
            monto = "3 d�lares";
        else if (radio5.IsChecked)
            monto = "5 d�lares";
        else if (radio10.IsChecked)
            monto = "10 d�lares";

        if (string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(operador) || string.IsNullOrEmpty(monto))
        {
            await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
            return;
        }

        await MA_RealizarRecargaAsync(telefono, operador, monto);
    }

    private async Task MA_RealizarRecargaAsync(string telefono, string operador, string monto)
    {
        // Simulaci�n de una operaci�n asincr�nica (ej. llamada a una API)
        await Task.Delay(2000);

        string mensaje = $"Se hizo una recarga de {monto} en la siguiente fecha: {DateTime.Now:dd/MM/yyyy}";
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{telefono}.txt");

        // Guardar la informaci�n en un archivo
        File.WriteAllText(filePath, mensaje);

        // Mostrar mensaje de confirmaci�n
        lblMensaje.Text = "Recarga realizada con �xito";
        lblMensaje.IsVisible = true;

        await DisplayAlert("Confirmaci�n", "Su recarga se ha realizado con �xito.", "OK");
    }
}
