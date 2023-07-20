using System.ComponentModel.DataAnnotations;

namespace RapidAPIConsume_WEBUI.DTOs.ServiceDtos
{
    public class AddServiceDto
    {
        [Required(ErrorMessage = "Lütfen ikon giriniz")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Lütfen başlık giriniz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen açıklama giriniz")]
        public string Description { get; set; }
    }
}
