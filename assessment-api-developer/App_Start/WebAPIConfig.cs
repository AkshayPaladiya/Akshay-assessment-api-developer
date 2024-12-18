﻿using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Http.Cors;

public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        // Use case-insensitive property names during JSON deserialization
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
            new CamelCasePropertyNamesContractResolver();

        // Web API routes
        config.MapHttpAttributeRoutes();

        // Remove XML Formatter (optional)
        config.Formatters.Remove(config.Formatters.XmlFormatter);

        // Add JSON Formatter
        config.Formatters.Add(config.Formatters.JsonFormatter);

        // Configure JSON Formatter to use Camel Case
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

        // Enable CORS globally for all controllers
        config.EnableCors(new EnableCorsAttribute("*", "*", "*"));


    }

    // Get the path to the XML comments file generated by build (if you use XML comments in your code)
    private static string GetXmlCommentsPath()
    {
        return System.String.Format(@"{0}\bin\assessment-platform-developer.xml", System.AppDomain.CurrentDomain.BaseDirectory);
    }
}
