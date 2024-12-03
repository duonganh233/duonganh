namespace SocialApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Lỗi", "Vui lòng nhập đầy đủ thông tin.", "OK");
            return;
        }

        if (!IsValidEmail(email))
        {
            await DisplayAlert("Lỗi", "Email không hợp lệ.", "OK");
            return;
        }

        if (!IsValidPassword(password))
        {
            await DisplayAlert("Lỗi", "Mật khẩu không hợp lệ. Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt.", "OK");
            return;
        }

        // Thực hiện logic đăng nhập tại đây
        if (email == "test@example.com" && password == "Password@123")
        {
            await DisplayAlert("Thành công", "Đăng nhập thành công!", "OK");
            // Chuyển sang trang chính
        }
        else
        {
            await DisplayAlert("Lỗi", "Email hoặc mật khẩu không đúng.", "OK");
        }
    }

    private bool IsValidEmail(string email)
    {
        // Kiểm tra định dạng email
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private bool IsValidPassword(string password)
    {
        // Kiểm tra mật khẩu có đáp ứng tiêu chuẩn bảo mật
        if (password.Length < 8)
            return false;

        bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;

        foreach (var c in password)
        {
            if (char.IsUpper(c)) hasUpper = true;
            else if (char.IsLower(c)) hasLower = true;
            else if (char.IsDigit(c)) hasDigit = true;
            else if (!char.IsLetterOrDigit(c)) hasSpecial = true;

            if (hasUpper && hasLower && hasDigit && hasSpecial)
                return true;
        }

        return false;
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        // Điều hướng sang trang đăng ký
        await DisplayAlert("Thông báo", "Chuyển sang trang đăng ký.", "OK");
        Navigation.PushAsync(new RegisterPage());
    }

    private async void OnForgotPasswordButtonClicked(object sender, EventArgs e)
    {
        // Điều hướng sang trang quên mật khẩu
        await DisplayAlert("Thông báo", "Chuyển sang trang quên mật khẩu.", "OK");
    }

}
