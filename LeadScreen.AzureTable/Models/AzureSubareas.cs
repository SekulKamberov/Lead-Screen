namespace LeadScreen.AzureTable.Models 
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.Azure.CosmosDB.Table;
    using System.Text;

    public class AzureSubAreas : AzureTableEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{6}$")] 
        public int PinCode { get; set; }
    }
}