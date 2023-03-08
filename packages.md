
## Install Below Packages

```
Microsoft.Entityframeworkcore.SqlServer
Microsoft.Entityframeworkcore.Tools
```

## Add Sql server connection string and Jwt Settings to appsettings.json

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "server=HQSERVER;database=demodb;User Id=sa;password=sa123#;Trusted_Connection=false;TrustServerCertificate=True"
  },
  "Jwt": {
    "Key": "dwc8aqu8ExmFfJzKLudJ4DpefeE7dDAMBhSXexM",
    "Issuer": "https://localhost:5153/",
    "Audience": "https://localhost:5153/"
  }
}

```
