

using Data.Interfaces;
using Data.Services;
using FinalProject.Dialogues;
using FinalProject.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Social.Interfaces;
using Social.Services;

var host = Host.CreateDefaultBuilder()
               .ConfigureServices(services =>
               {
                   services.AddSingleton<IFileService>(new FileService(filePath: "userProfiles.json"));
                   services.AddTransient<IUserService, UserService>();

                   services.AddTransient<IMainMenuDialogues, MainMenuDialogues>();
               })
               .Build();

using var scope = host.Services.CreateScope();

var mainMenu = scope.ServiceProvider.GetRequiredService<IMainMenuDialogues>();

mainMenu.ShowMenuOptions();