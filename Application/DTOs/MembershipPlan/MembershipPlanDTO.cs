using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class MembershipPlanDTO
    {

         public int Id { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public int? Amount { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public int? ValidityMonth { get; set; }
        public int? IsRenewal { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }
        public int? MembershipTypeId {  get; set; }


    }
}
