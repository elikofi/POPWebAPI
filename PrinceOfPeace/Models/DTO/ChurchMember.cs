
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrinceOfPeace.Models.DTO
{
	public class ChurchMember
	{
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid HonorificId { get; set; }

        [Required(ErrorMessage = "Enter first name.")]
        [StringLength(15)]
        public string? Firstname { get; set; }

        public string? Middlename { get; set; }

        [Required(ErrorMessage = "Enter last name.")]
        [StringLength(15)]
        public string? Lastname { get; set; }

        //[Required(ErrorMessage = "Enter date of birth.")]
        //public DateOnly Birthday { get; set; }


        //starting test
        private DateOnly birthday;

        public DateOnly Birthday
        {
            get { return birthday; }
            set
            {
                if (value > DateOnly.MinValue && value <= DateOnly.FromDateTime(DateTime.UtcNow))
                {
                    birthday = value;
                }
                else
                {
                    throw new ArgumentException("Invalid date of birth.");
                }
            }
        }

        public int Age
        {
            get
            {
                DateOnly currentDate = DateOnly.FromDateTime(DateTime.UtcNow);
                int age = currentDate.Year - birthday.Year;
                if (currentDate.Month < birthday.Month || (currentDate.Month == birthday.Month && currentDate.Day < birthday.Day))
                {
                    age--;
                }
                return age;
            }
        }

        //ending test

        [Required(ErrorMessage = "Enter a mobile number.")]
        [Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string? Phone1 { get; set; }

        [Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string? Phone2 { get; set; }

        [Required]
        public Guid OccupationId { get; set; }

        public string? Email { get; set; }

        [Required]
        public Guid PositionId { get; set; }

        [Required]
        public Guid ServicetypeId { get; set; }

        public string? BoxAddress { get; set; }

        public string? Housenumber { get; set; }

        public string? GPSaddress { get; set; }

        [ValidateNever]
        [DisplayName("Upload picture")]
        public string? ImageUrl { get; set; }


        //Not mapped properties

        [NotMapped]
        public string? OccupationName { get; set; }
        [NotMapped]
        public string? PositionName { get; set; }
        [NotMapped]
        public string? HonorificName { get; set; }
        [NotMapped]
        public string? ServicetypeName { get; set; }

        [NotMapped]
        public List<SelectListItem>? OccupationList { get; set; }
        [NotMapped]
        public List<SelectListItem>? PositionList { get; set; }
        [NotMapped]
        public List<SelectListItem>? HonorificList { get; set; }
        [NotMapped]
        public List<SelectListItem>? ServicetypeList { get; set; }
    }
}

