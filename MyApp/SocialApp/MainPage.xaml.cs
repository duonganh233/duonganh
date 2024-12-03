using Microsoft.Maui.Storage;  // Thêm namespace này để sử dụng Preferences

namespace SocialApp
{
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

            // Lấy thông tin đăng nhập đã lưu trong Preferences
            string savedEmail = Preferences.Get("Email", string.Empty); // Lấy email đã lưu
            string savedPassword = Preferences.Get("Password", string.Empty); // Lấy mật khẩu đã lưu

            // Kiểm tra thông tin email và mật khẩu
            if (email == savedEmail && password == savedPassword)
            {
                await DisplayAlert("Thành công", "Đăng nhập thành công!", "OK");
                // Chuyển sang trang chính (nếu có)
                //Navigation.PushAsync(new MainPage()); // Ví dụ, chuyển sang trang chính
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
            Navigation.PushAsync(new RegisterPage());
        }

        private async void OnForgotPasswordButtonClicked(object sender, EventArgs e)
        {
            // Điều hướng sang trang quên mật khẩu
            await DisplayAlert("Thông báo", "Chuyển sang trang quên mật khẩu.", "OK");
        }
    }
}
