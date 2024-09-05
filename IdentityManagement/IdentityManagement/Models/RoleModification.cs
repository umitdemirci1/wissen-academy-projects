﻿using System.ComponentModel.DataAnnotations;

namespace IdentityManagement.Models
{
    public class RoleModification
    {
        [Required]
        public string RoleName { get; set; }

        public string RoleId { get; set; }

        public string[]? AddIds { get; set; }
        public string[]? DeletedIds { get; set; }
    }
}
