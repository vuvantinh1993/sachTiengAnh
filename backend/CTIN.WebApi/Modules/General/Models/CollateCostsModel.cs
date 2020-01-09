using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CTIN.DataAccess.Models.CollateCosts;

namespace CTIN.WebApi.Modules.General.Models
{
    public class Search_CollateCostsModel : Search_CollateCostsServiceModel
    {
        public Search_CollateCostsModel()
        {
            order = "[{\"vouchersNumber\": false}]";
        }
        public override string order { get => base.order; set => base.order = value; }
    }

    public class Add_CollateCostsModel
    {
        [Required]
        public string vouchersNumber { get; set; }
        public Add_CollateCostsModel_DataJson data { get; set; }
        public Add_CollateCostsModel_DataDbJson dataDb { get; set; }

        public class Add_CollateCostsModel_DataJson
        {
            public DateTime? datePosted { get; set; }
            public DateTime? vouchersDate { get; set; }
            public int? statusId { get; set; }
            public string currency { get; set; }
            public decimal? exchangeRate { get; set; }
            public string classification { get; set; }
            public string content { get; set; }
            public int? accountant { get; set; }
            public int? accountant2 { get; set; }
            public int? projectId { get; set; }
            public int? contractId { get; set; }
            public string frameContract { get; set; }
            public int? bidId { get; set; }
            public int? payments { get; set; }
            public string implementationSchedule { get; set; }
            public decimal? amountOfMoney { get; set; }
            public string accountantName { get; set; }
            public int paymentType { get; set; }
            public int? expItenId { get; set; }
            public int? partId { get; set; }
            public List<int> coordinationList { get; set; }
            public int? index { get; set; }
            public int? empId { get; set; }
            public string note { get; set; }
        }

        public class Add_CollateCostsModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_CollateCostsModel : Add_CollateCostsModel
    {


    }

    public class FindOne_CollateCostsModel : FindOne_CollateCostsServiceModel
    {

    }

    public class Count_CollateCostsModel : Count_CollateCostsServiceModel
    {

    }
}
