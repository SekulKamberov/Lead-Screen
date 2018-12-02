namespace LeadScreen.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Lead 
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{6}$")]  
        public int PinCode { get; set; }

        [Required]
        public string SubArea { get; set; }

        [Required]
        [RegularExpression("[A-Za-z0-9].*")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}