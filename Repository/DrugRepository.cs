using MailOrderPharmacyDrugService.Controllers;
using MailOrderPharmacyDrugService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOrderPharmacyDrugService.Repository
{
    public class DrugRepository : IDrugRepository
    {

        public static List<DrugDetails> ls = new List<DrugDetails>
        {
            new DrugDetails
            {
                DrugId = 1,
                Name = "Paracetamol",
                Manufacturer = "Jonsons",
                ManufacturedDate = new DateTime(2020, 09, 21),
                ExpiryDate = new DateTime(2021, 07, 12),
                cost = 100.00,
                UnitPackage = 100,
                Quantity = 100,
                drugLocation=new DrugLocation
                {
                    Drug_Id = 1,
                    Name = "Paracetamol",
                    ExpiryDate = new DateTime(2022, 08, 10),
                    Location="Delhi",
                    Available_Stock =100
                }

            },
             new DrugDetails
            {
                DrugId = 2,
                Name = "Ativan",
                Manufacturer = "Sun",
                ManufacturedDate = new DateTime(2020, 09, 21),
                ExpiryDate = new DateTime(2021, 07, 12),
                cost = 100.00,
                UnitPackage = 100,
                Quantity = 100,
                drugLocation=new DrugLocation
                {
                    Drug_Id = 2,
                    Name = "Ativan",
                    ExpiryDate = new DateTime(2022, 08, 10),
                    Location="Mumbai",
                    Available_Stock =100
                }

            },
              new DrugDetails
            {
                DrugId = 3,
                Name = "Adderall",
                Manufacturer = "Acadia",
                ManufacturedDate = new DateTime(2020, 09, 21),
                ExpiryDate = new DateTime(2021, 07, 12),
                cost = 100.00,
                UnitPackage = 100,
                Quantity = 100,
                drugLocation=new DrugLocation
                {
                    Drug_Id = 3,
                    Name = "Adderall",
                    ExpiryDate = new DateTime(2022, 08, 10),
                    Location="Bangalore",
                    Available_Stock =100
                }

            }
            };
        public static List<DrugLocation> list = new List<DrugLocation>
        {
            new DrugLocation
            {
                Drug_Id = 1,
                Name = "Paracetamol",
                ExpiryDate = new DateTime(2022, 08, 10),
                Location="Delhi",
                Available_Stock =100
            },
            new DrugLocation
            {
                Drug_Id = 2,
                Name = "Ativan",
                ExpiryDate = new DateTime(2022, 08, 10),
                Location="Mumbai",
                Available_Stock =100
            },
            new DrugLocation
            {
                Drug_Id = 3,
                Name = "Adderall",
                ExpiryDate = new DateTime(2022, 08, 10),
                Location="Bangalore",
                Available_Stock =100
            }
        };
        /// <summary>
        /// This method responsible for returing the Drug Details searched by Drug ID
        /// </summary>
        /// <param name="drug_Id"></param>
        /// <returns></returns>
        public virtual DrugDetails searchDrugsByID(int drug_Id)
        {
            var item = ls.Where(x => x.DrugId == drug_Id).FirstOrDefault();
            if (item == null)
                return null;
            return item;
        }
        /// <summary>
        /// This method responsible for returing the Drug Details searched by Drug Name
        /// </summary>
        /// <param name="drug_name"></param>
        /// <returns></returns>
        public virtual DrugDetails searchDrugsByName(string drug_name)
        {
            var item = ls.Where(x => x.Name == drug_name).FirstOrDefault();
            if (item == null)
                return null;
            return item;
        }
        /// <summary>
        ///  This method responsible for returing the Drug Details searched by Drug ID and Location
        /// </summary>
        /// <param name="drugId"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public virtual IEnumerable<DrugLocation> GetDispatchableDrugStock(int drugId, string location)
        {
            
            List<DrugLocation> item = new List<DrugLocation>();
            DrugDetails drug = new DrugDetails();
            var obj1 = DrugRepository.ls;
          
            for(int i=0; i<ls.Count; i++)
            {
                if(list[i].Drug_Id ==drugId && list[i].Location ==location)
                {
                    item.Add(list[i]);
                }
            }

            return item;
        }
    }
}
