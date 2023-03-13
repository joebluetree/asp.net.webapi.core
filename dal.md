# Data Access Layer 

## DotNet Standard Libraray for Database Access

#### Nuget Packages
###### Microsoft.EntityFrameworkCore


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




#### Add Below Class Lib
```


namespace Database
{
    public static class Lib
    {
        public static int getTotalPages(int Rows, int PageSize)
        {
            int Pages = (Rows / PageSize);
            if (Rows < PageSize)
                Pages = 1;
            else if ((Pages * PageSize) != Rows)
                Pages++;
            return Pages;
        }
        public static int getStartRow(int currentPageNo, int pageSize)
        {
            return (currentPageNo - 1) * pageSize + 1;
        }

        public static int getEndRow(int currentPageNo, int pageSize)
        {
            return currentPageNo * pageSize;
        }
        public static int FindPage(string Action, int CurrentPageNo, int Pages)
        {
            if (Action == "NEXT")
                CurrentPageNo++;
            if (Action == "PREV")
                CurrentPageNo--;
            if (Action == "FIRST")
                CurrentPageNo = 1;
            if (Action == "LAST")
                CurrentPageNo = Pages;
            if (CurrentPageNo < 1)
                CurrentPageNo = 1;
            if (CurrentPageNo > Pages)
                CurrentPageNo = Pages;
            return CurrentPageNo;
        }

    }
}

```
