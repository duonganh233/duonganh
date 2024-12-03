namespace SocialApp;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            DisplayAlert("Lỗi", "Vui lòng điền đầy đủ thông tin!", "OK");
            return;
        }

        if (password.Length < 8)
        {
            DisplayAlert("Lỗi", "Mật khẩu phải có ít nhất 8 ký tự!", "OK");
            return;
        }

        DisplayAlert("Thành công", "Đăng ký thành công!", "OK");
        // Điều hướng về trang đăng nhập
        Navigation.PopAsync();
    }
}
