namespace HBS.Service.Configuration;

public static class AppConfigurationConfig
{
    public static void Configure(
        IConfigurationBuilder builder,
        IHostEnvironment environment)
    {
        builder.SetBasePath(environment.ContentRootPath);

        builder.AddYamlFile(
            path: "appsettings.yaml",
            optional: false,
            reloadOnChange: true);

        builder.AddYamlFile(
            path: $"appsettings.{environment.EnvironmentName}.yaml",
            optional: true,
            reloadOnChange: false
        );

        if (environment.IsDevelopment())
        {
            builder.AddUserSecrets<Program>();
        }

        builder.AddEnvironmentVariables();
    }
}