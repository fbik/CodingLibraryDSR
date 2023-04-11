namespace Identity.Properties.Configuration;

public abstract class Settings
{
    public static T Load<T>(string key, IConfiguration configuration = null)
    {
        var settings = (T)Activator.CreateInstance(typeof(T));

       //SettingsFactory.Greate(configuration).GetSection(key).Bing(settings, (x) =>
        //{
           // x.BindNonPublicProperties = true;
        //});

        return settings;
    }
    
}