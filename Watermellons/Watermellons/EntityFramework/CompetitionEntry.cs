using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Watermellons.EntityFramework
{
    public class CompetitionEntry
    {
        [Key]
        [Required]
        public int CompetitionEntryId { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Index(IsUnique = true)]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Gender { get; set; }

        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string FavouriteWatermellonPlace { get; set; }

        [Required(ErrorMessage = "You must accept the T&Cs")]
        [DefaultValue(false)]
        public Boolean TermsAndConditionsAccepted  { get; set; }
    }
}