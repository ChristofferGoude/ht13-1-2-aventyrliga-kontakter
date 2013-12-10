using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models
{
    [MetadataType(typeof(Contact_MetaData))]
    public partial class Contact
    {

    }

    public class Contact_MetaData
    {
        public int ContactID { get; set; }

        [Required(ErrorMessage = "Du måste ange ett förnamn!")]
        [MaxLength(50, ErrorMessage = "Förnamnet får max vara 50 tecken!")]
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Du måste ange ett efternamn!")]
        [MaxLength(50, ErrorMessage = "Efternamnet får max vara 50 tecken!")]
        [DisplayName("Efternamn")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Du måste ange en mailadress!")]
        [MaxLength(50, ErrorMessage = "Mailadressen får max vara 50 tecken!")]
        [DisplayName("Mailadress")]
        [EmailAddress(ErrorMessage = "Detta är ingen giltig mailadress!")]
        public string EmailAddress { get; set; }
    }
}