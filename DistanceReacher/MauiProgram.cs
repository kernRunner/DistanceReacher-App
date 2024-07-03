using Microsoft.Extensions.Logging;

namespace DistanceReacher;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                fonts.AddFont("BubblerOne-Regular.ttf", "BubblerOne");

                fonts.AddFont("SourceSans3-Regular.ttf", "SourceSans3Regular");
                fonts.AddFont("SourceSans3-Bold.ttf", "SourceSans3Bold");

                fonts.AddFont("Oswald-Bold.ttf", "OswaldBold");
                fonts.AddFont("Oswald-ExtraLight.ttf", "OswaldExtraLight");
                fonts.AddFont("Oswald-Light.ttf", "OswaldLight");
                fonts.AddFont("Oswald-Medium.ttf", "OswaldMedium");
                fonts.AddFont("Oswald-Regular.ttf", "OswaldRegular");
                fonts.AddFont("Oswald-SemiBold.ttf", "OswaldSemiBold");
            })
            .UseMauiMaps()
            .ConfigureMauiHandlers(handlers =>
            {
#if ANDROID
                handlers.AddHandler<Microsoft.Maui.Controls.Maps.Map, DistanceReacher.Platforms.Android.CustomMapHandler>();
#endif
            }); ;

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
