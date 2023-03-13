using System.ComponentModel.DataAnnotations;
namespace Database.models
{
    public class userm
    {
        [Key]
        public int user_id { get; set; }  = 0;
        public string user_code { get; set; } = "";
        public string user_name { get; set; } = "";
        public string user_password { get; set; }  = "";
        public string user_email { get; set; }  = "";
        public string user_is_locked { get; set; }  = "N";
        public string user_is_admin { get; set; }  = "N";
    }

}
