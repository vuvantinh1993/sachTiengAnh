using CTIN.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_TimeSheetModel : Search_TimeSheetServiceModel
    {
    }

    public class Add_TimeSheetModel
    {
        [Required(ErrorMessage = "projworkId không được trống")]
        public int projworkId { get; set; }
        public string topic { get; set; }
        public int? dateNumber { get; set; }
        public DateTime? startDay { get; set; }
        public DateTime? endDate { get; set; }
        public decimal? t2 { get; set; }
        public decimal? t3 { get; set; }
        public decimal? t4 { get; set; }
        public decimal? t5 { get; set; }
        public decimal? t6 { get; set; }
        public decimal? t7 { get; set; }
        public decimal? cn { get; set; }
    }


    public class Edit_TimeSheetModel : Add_TimeSheetModel
    {

    }

    public class FindOne_TimeSheetModel : FindOne_TimeSheetServiceModel
    {

    }

    public class Count_TimeSheetModel : Count_TimeSheetServiceModel
    {

    }
}
