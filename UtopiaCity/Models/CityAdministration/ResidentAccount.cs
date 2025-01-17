﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Models.CityAdministration
{
    public class ResidentAccount
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string FamilyName { get; set; }

        [Column(TypeName = "date"), Required]
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public Gender Gender { get; set; }

        [ScaffoldColumn(false)]
        public string MarriageId { get; set; }
        public Marriage Marriage { get; set; }
        public string RegistrationAddress { get; set; }
        public string Property { get; set; }
        public string MotorTransport { get; set; }
        public string MedicalRecords { get; set; }
        public string Phone { get; set; }

        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter а valid email address")]
        public string Email { get; set; }
    }
}
