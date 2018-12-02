namespace LeadScreen.Data.Seed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using LeadScreen.Models.EntityModels;

    public static class DatabaseSeeder
    {
        public static void InsertSeedData(LeadScreenDBContext context)
        {
            if (!context.SubAreas.Any())
            {
                context.SubAreas.AddRange(
                    new SubArea {Name = "Abhayapuri- Bongaigaon (Kokrajhar)", PinCode = 322191},
                    new SubArea { Name = "Abohar- Ferozepur", PinCode = 322191},
                    new SubArea { Name = "Abu Road- Sirohi (Abu Road)", PinCode = 322191},
                    new SubArea { Name = "Achalpur- Amravati", PinCode = 322191},
                    new SubArea { Name = "Achampet- Mahabubnagar", PinCode = 322192},
                    new SubArea { Name = "Achhnera- Agra", PinCode = 322192},
                    new SubArea { Name = "Adampur Mandi- Hissar", PinCode = 322192},
                    new SubArea { Name = "Adhaura- Sasaram", PinCode = 322193},
                    new SubArea { Name = "Adilabad- Adilabad", PinCode = 322193},
                    new SubArea { Name = "Adimaly- Ernakulam", PinCode = 322193},
                    new SubArea { Name = "Adoni- Kurnool", PinCode = 322194},
                    new SubArea { Name = "Adoor- Tiruvalla", PinCode = 322194},
                    new SubArea { Name = "Adra- Purulia", PinCode = 322194},
                    new SubArea { Name = "Afzalpur- Gulbarga", PinCode = 322195},
                    new SubArea { Name = "Agar- Shajapur", PinCode = 322195});

                context.SaveChanges();
            }
        }
    }
}
