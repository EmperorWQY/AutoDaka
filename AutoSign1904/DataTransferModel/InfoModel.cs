using System.ComponentModel.DataAnnotations;


namespace AutoSign1904.DataTransferModel
{
    public class InfoModel
    {
        [Required]
        public string Usr { get; set; }
        [Required]
        public string Pwd { get; set; }

        public string Type { set; get; }
    }
}
