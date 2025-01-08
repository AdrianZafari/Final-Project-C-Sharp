using Microsoft.Extensions.Logging;
using Data.Interfaces;
using Social.Interfaces;
using Data.Services;
using Social.Services;

namespace FinalProject_Blazor
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IFileService>(new FileService(filePath: "userProfiles.json"));
            builder.Services.AddTransient<IUserService, UserService>();

            return builder.Build();
        }
    }
}
