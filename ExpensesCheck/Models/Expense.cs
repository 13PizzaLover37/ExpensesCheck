﻿using System.ComponentModel.DataAnnotations;

namespace ExpensesCheck.Models
{
    public class Expense
    {
        public int Id { get; set; }

        public double Value { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
