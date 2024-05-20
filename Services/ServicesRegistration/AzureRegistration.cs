
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using CSharp_FinalExam.Models.Azure.KeyVault;
using Microsoft.Extensions.Azure;

namespace CSharp_FinalExam.Services.ServicesRegistration;

public static class AzureRegistration
{
     public static IServiceCollection AddAzureServices(this IServiceCollection services)
     {
          services.AddAzureClients(x =>
          {
               x.AddBlobServiceClient(new Uri("https://csharpfinalexam.blob.core.windows.net"));
               x.UseCredential(new ClientSecretCredential(
                    Environment.GetEnvironmentVariable("DirectoryId", EnvironmentVariableTarget.User),
                    Environment.GetEnvironmentVariable("ClientId", EnvironmentVariableTarget.User),
                    Environment.GetEnvironmentVariable("ClientSecret", EnvironmentVariableTarget.User)
                    ));
          });
          return services;
     }
     
     public static SecretClient AddKeyVault(this WebApplicationBuilder builder)
     {
          var keyVault = new KeyVault()
          {
               KeyVaultURL = Environment.GetEnvironmentVariable("KeyVaultURL", EnvironmentVariableTarget.User),
               ClientId = Environment.GetEnvironmentVariable("ClientId", EnvironmentVariableTarget.User),
               ClientSecret = Environment.GetEnvironmentVariable("ClientSecret", EnvironmentVariableTarget.User),
               DirectoryId = Environment.GetEnvironmentVariable("DirectoryId", EnvironmentVariableTarget.User)
          };
          
          var credential = new ClientSecretCredential(keyVault.DirectoryId, keyVault.ClientId, keyVault.ClientSecret);
          builder.Configuration.AddAzureKeyVault(new Uri(keyVault.KeyVaultURL), credential);
          var secretClient = new SecretClient(new Uri(keyVault.KeyVaultURL), credential);
          
          builder.Services.AddSingleton(secretClient);

          return secretClient;
     }
}