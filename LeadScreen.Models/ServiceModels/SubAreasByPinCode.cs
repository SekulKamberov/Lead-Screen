namespace LeadScreen.Models.ServiceModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using LeadScreen.Common.AutoMapper;
    using LeadScreen.Models.EntityModels;

    public class SubAreasByPinCode : IMapFrom<SubArea>
    {
        //public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{6}$")]
        public int PinCode { get; set; }
    }
}