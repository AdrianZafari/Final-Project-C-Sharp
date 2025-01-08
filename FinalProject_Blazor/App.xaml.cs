namespace FinalProject_Blazor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = new Window(new MainPage()) { Title = "FinalProject_Blazor" };
            window.MinimumWidth = 800;
            window.MinimumHeight = 850;

            return window;
        }
    }
}
