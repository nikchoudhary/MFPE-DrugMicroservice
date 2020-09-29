using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailOrderPharmacyDrugService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MailOrderPharmacyDrugService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DrugsController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        IDrugRepository _drug;
        public  DrugsController(IDrugRepository drug)
        {
            _drug = drug;
            _log4net = log4net.LogManager.GetLogger(typeof(DrugsController));
        }
        /// <summary>
        /// This method responsible for returing the Drug Details searched by Drug ID
        /// </summary>
        /// <param name="drug_id"></param>
        /// <returns></returns>
        
        [HttpGet("GetDrugDetails/{drug_id}")]
        public IActionResult GetDrugDetails(int drug_id)
        {
            _log4net.Info(" Http Get Drug Details request");

            try
            {
                var obj = _drug.searchDrugsByID(drug_id);
                if (obj == null)
                {
                    return NotFound();
                }

                return Ok(obj);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        /// <summary>
        /// This method responsible for returing the Drug Details searched by Drug Name
        /// </summary>
        /// <param name="drug_name"></param>
        /// <returns></returns>
        
        [HttpGet("GetDrugDetailByName/{drug_name}")]
        public IActionResult GetDrugDetailByName(string drug_name)
        {
            _log4net.Info(" Http GET Request for Drug Details By Name");
            try
            {
                var obj = _drug.searchDrugsByName(drug_name);
                if (obj == null)
                {
                    return NotFound();
                }

                return Ok(obj);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        /// <summary>
        /// This method responsible for returing the Drug Details searched by Drug ID and Location
        /// </summary>
        /// <param name="drug_id"></param>
        /// <param name="drug_loc"></param>
        /// <returns></returns>

        [HttpGet("{id}/{loc}")]
        public IActionResult getDispatchableDrugStock(int drug_id, string drug_loc)
        {
            _log4net.Info(" Http Get Request for Drug Details by Location and ID");
            var drug = _drug.GetDispatchableDrugStock(drug_id, drug_loc);
            if (drug == null)
                return null;
            return Ok(drug);
        }

        
    }
}
