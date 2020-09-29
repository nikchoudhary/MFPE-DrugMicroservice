using MailOrderPharmacyDrugService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOrderPharmacyDrugService.Repository
{
    public interface IDrugRepository
    {
        DrugDetails searchDrugsByID(int DrugId);
        DrugDetails searchDrugsByName(string Name);

        IEnumerable<DrugLocation> GetDispatchableDrugStock(int DrugId, string Location);
    }
}
