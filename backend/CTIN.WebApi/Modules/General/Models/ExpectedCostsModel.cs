using CTIN.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;
using static CTIN.DataAccess.Models.ExpectedCosts;

namespace CTIN.WebApi.Modules.General.Models
{
    public class Search_ExpectedCostsModel : Search_ExpectedCostsServiceModel
    {
        public Search_ExpectedCostsModel()
        {
            order = "[{\"id\": false}]";
        }
        public override string order { get => base.order; set => base.order = value; }
    }

    public class Add_ExpectedCostsModel
    {
        public Add_ExpectedCostsModel_DataJson data { get; set; }
        public Add_ExpectedCostsModel_DataDbJson dataDb { get; set; }

        public class Add_ExpectedCostsModel_DataJson
        {
            public string currency { get; set; }
            public decimal exchangeRate { get; set; }

            [Required(ErrorMessage = "expItemId không được để trống")]
            public int expItemId { get; set; }

            [MaxLength(500, ErrorMessage = "costName không được quá 500 kí tự")]
            [Required(ErrorMessage = "costName không được để trống")]
            public string costName { get; set; }

            [Range(0, 100, ErrorMessage = "percentage giá trị nhận từ 0 đến 100")]
            public decimal percentage { get; set; }
            public decimal amountOfMoney { get; set; }
            public int projectId { get; set; }
            public string note { get; set; }
        }

        public class Add_ExpectedCostsModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_ExpectedCostsModel : Add_ExpectedCostsModel
    {


    }

    public class FindOne_ExpectedCostsModel : FindOne_ExpectedCostsServiceModel
    {

    }

    public class Count_ExpectedCostsModel : Count_ExpectedCostsServiceModel
    {

    }
}
