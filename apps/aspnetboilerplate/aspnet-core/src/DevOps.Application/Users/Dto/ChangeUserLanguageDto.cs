using System.ComponentModel.DataAnnotations;

namespace DevOps.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}