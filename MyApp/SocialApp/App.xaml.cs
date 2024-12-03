namespace SocialApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Đặt NavigationPage cho trang chính
        MainPage = new NavigationPage(new MainPage());
    }
}
