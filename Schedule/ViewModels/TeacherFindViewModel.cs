﻿using System.ComponentModel.DataAnnotations;

namespace Schedule.ViewModels
{
    public class TeacherFindViewModel
    {
        [Required(ErrorMessage = "Будь ласка виберіть викладача зі списку або введіть повне ПІБ")]
        public string SelectedTeacher { get; set; }
    }
}
