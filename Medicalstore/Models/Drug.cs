using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicalstore.Models
{
    public class DrugDetails
    {
        public int Drug_id { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Drug_name { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Manufacturer_name { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Manufactured_date { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Expiration_date { get; set; }
    }
}