using System;
using System.ComponentModel.DataAnnotations;


    public class MyTask
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } 

        public string Description { get; set; } 

        [Required]
        public string Assignee { get; set; } 

        public bool IsOpen { get; set; } = true; 

        public DateTime CreatedAt { get; set; } = DateTime.Now; 

        public DateTime? ClosedAt { get; set; } 

        [Required]
        public PriorityLevel Priority { get; set; } 
    }

    public enum PriorityLevel
    {
        Высокий,
        Средний,
        Низкий
    }
