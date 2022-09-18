﻿using ModelDB.Core.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ModelDB.Core
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(25)]
        public string Login { get; set; }

        [Required]
        [MaxLength(64)]
        public string Password { get; set; }

        [Required]
        public Role UserRole { get; set; }
    }
}