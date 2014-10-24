using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using neuchatService.Models;
using Microsoft.WindowsAzure.Mobile.Service.Config;

namespace neuchatService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Configure SignalR
            SignalRExtensionConfig.Initialize();

            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            Database.SetInitializer(new neuchatInitializer());
        }
    }

    public class neuchatInitializer : ClearDatabaseSchemaIfModelChanges<neuchatContext>
    {
        protected override void Seed(neuchatContext context)
        {
            base.Seed(context);
        }
    }
}

