using System.ComponentModel.DataAnnotations;
namespace Database.models
{ 
    public class modulem
    {
        [Key]
        public int module_id { get; set; }  = 0;
        public string module_name { get; set; } = "";
        public string module_is_installed { get; set; }  = "N";
        public int module_order { get; set; } = 0;

    }
}
