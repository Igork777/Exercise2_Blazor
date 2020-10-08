﻿using System.ComponentModel.DataAnnotations;

namespace Exercise1.Models
{
    public class Todo
    {
        [Required, MinLength(3)]
        public string AssigneeUserName { get; set; }

        public int AssigneeId { get; set; }
        
        public string AssigneeRole { get; set; }
        
        public int TodoId { get; set; }
        [Required, MinLength(3)]
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public string AsignorUserName { get; set; }
        public string AssignorRole { get; set; }
    }
}