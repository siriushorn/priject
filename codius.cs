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

   if (environmentName == Environments.Development)
        return true;

    if (System.Diagnostics.Debugger.IsAttached)
        return true;
