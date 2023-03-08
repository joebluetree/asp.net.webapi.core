# Data Access Layer 

## DotNet Standard Libraray for Database Access

#### Add Below Domain Models

<p> Create the folder Models inside the project 
then add below class
</p>

```
using System.ComponentModel.DataAnnotations;
namespace Database.models
{
    public class userm
    {
        [Key]
        public int user_id = 0;
        public string user_code = "";
        public string user_name ="";
        public string user_password = "";
        public string user_email = "";
        public string user_is_locked = "N";
        public string user_is_admin = "N";
    }
}
```
#### Add Below DTO models
<p>Create the folder DTO inside the project 
then add below class
</p>

```
namespace Database.DTO
{
    public class Page
    {
        public int pageSize = 0;
        public int pages = 0;
        public int currentPageNo = 0;
        public int rows = 0;
        public string action = "";
    }
}
```

#### Add Entity Framework DBContext Class
<p>Create a class and give the name AppDbContext
inside the project, then add below code
</p>


```
using Microsoft.EntityFrameworkCore;
using Database.models;
namespace Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<userm> Userm { get; set; }
    }
}
```

#### Setting Up DBContext in program.cs file
<p>Now add below code in program.cs to setup DbContext
</p>

```
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
```