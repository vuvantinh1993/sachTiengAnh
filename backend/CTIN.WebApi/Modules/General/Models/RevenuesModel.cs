using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CTIN.DataAccess.Models.Revenues;

namespace CTIN.WebApi.Modules.General.Models
{
    public class Search_RevenuesModel : Search_RevenuesServiceModel
    {
        public Search_RevenuesModel()
        {
            order = "[{\"vouchersNumber\": false}]";
        }
        public override string order { get => base.order; set => base.order = value; }
    }

    public class Add_RevenuesModel
    {
        [Required]
        public string vouchersNumber { get; set; }
        public Add_RevenuesModel_DataJson data { get; set; }
        public Add_RevenuesModel_DataDbJson dataDb { get; set; }

        public class Add_RevenuesModel_DataJson
        {
            public DateTime? datePosted { get; set; }
            public DateTime? vouchersDate { get; set; }
            public int status { get; set; }
            public string currency { get; set; }
            public decimal? exchangeRate { get; set; }
            public string classification { get; set; }
            public string content { get; set; }
            public int? expItenId { get; set; }
            public int? accountant { get; set; }
            public int projectId { get; set; }
            public int? contractId { get; set; }
            public string frameContract { get; set; }
            public int? bidId { get; set; }
            public decimal? payments { get; set; }
            public string implementationSchedule { get; set; }
            public decimal? amountOfMoney { get; set; }
            public decimal? taxpay { get; set; }
            public decimal? amountReceived { get; set; }
            public int paymentType { get; set; }
            public int? partId { get; set; }
            public List<int> coordinationList { get; set; }
            public int? empId { get; set; }
            public int? index { get; set; }
            public string note { get; set; }
        }

        public class Add_RevenuesModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_RevenuesModel : Add_RevenuesModel
    {


    }

    public class FindOne_RevenuesModel : FindOne_RevenuesServiceModel
    {

    }

    public class Count_RevenuesModel : Count_RevenuesServiceModel
    {

    }
}
