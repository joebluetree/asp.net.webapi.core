# Data Access Layer 

## DotNet Standard Libraray for Database Access

#### Add Below Domain Models

<p> Create the Models inside the project 
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

