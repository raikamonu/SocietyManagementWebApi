using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class PrizeMasterDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "AchievementTypeId is required")]
        public int? AchievementTypeId { get; set; }
        public string? AchievementTypeName { get; set; }


        [Required(ErrorMessage = "Level is required")]
        public int? Level { get; set; }
        public string? LevelName { get; set; }


        [Required(ErrorMessage = "MedalType is required")]
        public int? MedalType { get; set; }
        public string? MedalTypeName { get; set; }


        [Required(ErrorMessage = "SessionId is required")]
        public int? SessionId { get; set; }
        public string? SessionName { get; set; }


        [Required(ErrorMessage = "Prize is required")]
        public int? Prize { get; set; }

        public int? IsActive { get; set; }

        public int? IsDelete { get; set; }
    }
}
