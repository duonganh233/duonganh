using Microsoft.Maui.Storage; // Đảm bảo đã thêm namespace này

namespace SocialApp
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;
            string confirmPassword = ConfirmPasswordEntry.Text;  // Lấy giá trị từ trường xác nhận mật khẩu

            // Kiểm tra các trường thông tin
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                await DisplayAlert("Lỗi", "Vui lòng điền đầy đủ thông tin!", "OK");
                return;
            }

            // Kiểm tra độ dài mật khẩu
            if (password.Length < 8)
            {
                await DisplayAlert("Lỗi", "Mật khẩu phải có ít nhất 8 ký tự!", "OK");
                return;
            }

            // Kiểm tra mật khẩu và xác nhận mật khẩu có khớp không
            if (password != confirmPassword)
            {
                await DisplayAlert("Lỗi", "Mật khẩu và xác nhận mật khẩu không khớp!", "OK");
                return;
            }

            // Lưu thông tin người đăng ký vào Preferences (lưu email và mật khẩu)
            Preferences.Set("Email", email);
            Preferences.Set("Password", password);

            // Hiển thị thông báo đăng ký thành công
            await DisplayAlert("Thành công", "Đăng ký thành công!", "OK");

            // Điều hướng về trang đăng nhập
            await Navigation.PopAsync();
        }
    }
}
