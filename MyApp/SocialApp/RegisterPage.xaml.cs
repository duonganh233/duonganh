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

            // Kiểm tra mật khẩu và xác nhận mật khẩu có khớp không
            if (password != confirmPassword)
            {
                await DisplayAlert("Lỗi", "Mật khẩu và xác nhận mật khẩu không khớp!", "OK");
                return;
            }

            // Kiểm tra độ dài mật khẩu
            if (!IsValidPassword(password))
            {
                await DisplayAlert("Lỗi", "Mật khẩu không hợp lệ. Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt.", "OK");
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
    }
}
