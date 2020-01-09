using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CTIN.DataAccess.Models.ActualCosts;

namespace CTIN.WebApi.Modules.General.Models
{
    public class Search_ActualCostsModel : Search_ActualCostsServiceModel
    {
    }

    public class Add_ActualCostsModel
    {
        [Required(ErrorMessage = "vouchersNumber khong de trong")]
        public string vouchersNumber { get; set; }
        public Add_ActualCostsModel_DataJson data { get; set; }
        public Add_ActualCostsModel_DataDbJson dataDb { get; set; }

        public class Add_ActualCostsModel_DataJson
        {
            public DateTime? datePosted { get; set; }
            public DateTime? vouchersDate { get; set; }
            public int status { get; set; }
            public string currency { get; set; }
            public decimal? exchangeRate { get; set; }
            public int? expItenId { get; set; }
            public string costName { get; set; }
            public int accountant { get; set; }
            public int? projectId { get; set; }
            public int? contractId { get; set; }
            public string frameContract { get; set; }
            public int? bidId { get; set; }
            public decimal? payments { get; set; }
            public string implementationSchedule { get; set; }
            public decimal amountOfMoney { get; set; }
            public decimal taxpay { get; set; }
            public decimal amountReceived { get; set; }
            public int paymentType { get; set; }
            public int? partId { get; set; }
            public List<int> coordinationList { get; set; }
            public int? empId { get; set; }
            public string note { get; set; }
            public int allowDisplay { get; set; }
            public int? index { get; set; }
            public string classification { get; set; }
        }

        public class Add_ActualCostsModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_ActualCostsModel : Add_ActualCostsModel
    {


    }

    public class FindOne_ActualCostsModel : FindOne_ActualCostsServiceModel
    {

    }

    public class Count_ActualCostsModel : Count_ActualCostsServiceModel
    {

    }
}
