using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOrderPharmacyDrugService.Models
{
    public class DrugLocation
    {
        public int Drug_Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Available_Stock { get; set; }
        public string Location { get; set; }
    }
}
