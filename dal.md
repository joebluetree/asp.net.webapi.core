<h1> Data Access Layer </h1>

<h3>.Net Standard Libraray for Database Access</h3>

<h4> Add Below Domain Models </h4>

```
using System.ComponentModel.DataAnnotations;
namespace Database.domain.models
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

<h4> Add Below DTO models </h4>
```
namespace Database.dto
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

