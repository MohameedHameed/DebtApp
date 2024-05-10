using DebtApp.Model.DB;
using DebtApp.Pages;
using DebtApp.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UraniumUI;

namespace DebtApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            DBContext dbContext = new DBContext();
            dbContext.Database.EnsureCreated();
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseUraniumUI()
               .UseUraniumUIMaterial()

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<AddUser>();
            builder.Services.AddSingleton<AddUserViewModel>();
            builder.Services.AddSingleton<AddDebtProcessViewModel>();
            builder.Services.AddSingleton<AddUnDebtProcessViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
