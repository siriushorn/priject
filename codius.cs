   if (appContext.IsInstalled)
    {
        var scopeAccessor = appContext.Services.Resolve<ILifetimeScopeAccessor>();
        using (scopeAccessor.BeginContextAwareScope(out var scope))
        {
            var initializer = scope.ResolveOptional<IDatabaseInitializer>();
            if (initializer != null)
            {
                var appLifetime = scope.ResolveOptional<IHostApplicationLifetime>();
                await initializer.InitializeDatabasesAsync(appLifetime?.ApplicationStopping ?? CancellationToken.None);
            }
        }
    }
//yes

   if (environmentName == Environments.Development)
        return true;

    if (System.Diagnostics.Debugger.IsAttached)
        return true;
  if (value.IsEmpty() || !value.Contains(path))
    {
        value = value.EmptyNull().Trim(';') + ';' + path;
        Environment.SetEnvironmentVariable(name, value, EnvironmentVariableTarget.Process);
    }
}

void SetupLogging(ILoggingBuilder loggingBuilder)
{
    loggingBuilder.ClearProviders();
    loggingBuilder.AddSerilog();
}
