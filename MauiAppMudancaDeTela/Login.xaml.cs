namespace MauiAppMudancaDeTela;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		try
		{
			List<DadosUsuario> lista_usuarios = new List<DadosUsuario>()
			{
				new DadosUsuario()
				{
					Usuario = "jose",
					Senha = "123"
				},

				new DadosUsuario()
				{

					Usuario = "Nicolas",
					Senha = "Barros"
				},

				new DadosUsuario()
				{
					Usuario = "Maria",
					Senha= "Luiza"
				}

			};

			DadosUsuario dados_digitados = new DadosUsuario()
			{
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text
			};

			//LINQ
			if (lista_usuarios.Any(i => (dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha)))
			{
				await SecureStorage.Default.SetAsync("Usuario Logado", dados_digitados.Usuario);

				App.Current.MainPage = new Protegida();
			}
			else
			{
                throw new Exception("Usuario ou senha incorretos");
            }
        }

		catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "Fechar");
		}
	}
	
}

