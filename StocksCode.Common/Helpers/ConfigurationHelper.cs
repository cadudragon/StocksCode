using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace StocksCode.Common.Helpers
{
    /// <summary>
    /// Helper to get configurations from Presentation within other assemblies
    /// </summary>
    public static class ConfigurationHelper
    {

        /// <summary>
        /// Helper to get json configuration from diferent projects
        /// </summary>
        /// <returns>The json configuration by relative path.</returns>
        /// <param name="nameSpace">Name space.</param>
        /// <param name="environmentName">Environment name.</param>
        public static IConfigurationRoot GetJsonConfigurationByRelativePath(string nameSpace, string environmentName) {

            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}{1}", Path.DirectorySeparatorChar, nameSpace);

            var configuration = new ConfigurationBuilder()
                   .SetBasePath(basePath)
                   .AddJsonFile("appsettings.json")
                   .AddJsonFile($"appsettings.Local.json", optional: true)
                   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable(environmentName)}.json", optional: true)
                   .AddEnvironmentVariables()
                   .Build();

            return configuration;
        }
    }
}
