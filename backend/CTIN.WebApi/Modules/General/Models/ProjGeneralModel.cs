using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CTIN.WebApi.Modules.General.Models
{
    public class Search_ProjGeneralModel : Search_ProjGeneralServiceModel
    {
        //public Search_ProjGeneralModel()
        //{
        //    order = "[{\"projGeneral.id\": false}]";
        //}
        //public override string order { get => base.order; set => base.order = value; }
    }

    public class Add_ProjGeneralModel
    {
        [Required(ErrorMessage = "Required projTypeId")]
        public int projTypeId { get; set; }

        [Required(ErrorMessage = "Required projcode")]
        public string projCode { get; set; }

        [Required(ErrorMessage = "Required projName")]
        public string projName { get; set; }

        [Required(ErrorMessage = "Required beginDate")]
        public virtual DateTime beginDate { get; set; }

        [Required(ErrorMessage = "Required endDate")]
        public virtual DateTime endDate { get; set; }
        public virtual DateTime? completedDate { get; set; }

        [Required(ErrorMessage = "Required statusId")]
        public int statusId { get; set; }
        public int projPercent { get; set; }
        public int pmName { get; set; }
        public bool allowEmail { get; set; }
        public string content { get; set; }

        [Required(ErrorMessage = "Required partnetId")]
        public int partnerId { get; set; }

        [Required(ErrorMessage = "Required projgroupId")]
        public int projgroupId { get; set; }

        public string projPriority { get; set; }
        public string learderName { get; set; }
        public int targetId { get; set; }
        public int mntFormId { get; set; }
        public int investsId { get; set; }
        public int biddingId { get; set; }
        public int empId { get; set; }
        public int depId { get; set; }
        public int budgetId { get; set; }

        [MaxLength(10)]
        public string currency { get; set; }
        public decimal exchangeRate { get; set; }
        public decimal estimatedBudget { get; set; }
        public decimal proposedBudget { get; set; }
        public decimal planBudget { get; set; }
        public decimal crbudget { get; set; }
        public decimal feasibilityStadyBudget { get; set; }
        public decimal feasibilityCrbudget { get; set; }
        public decimal totalCostContract { get; set; }
        public decimal totalContractExpenses { get; set; }
        public decimal budgetRemaining { get; set; }
        public decimal totalContractAmount { get; set; }
        public decimal totalContractPayment { get; set; }
        public decimal totalContractRemaining { get; set; }
        public decimal totalOperatingExpenses { get; set; }
        public decimal costBooks { get; set; }
        public decimal salesPlan { get; set; }
        public string note { get; set; }
        public string memory { get; set; }
        public int partGroupId { get; set; }

        public virtual int directorProject { get; set; }
        public virtual int cmo { get; set; }
        public virtual int amProject { get; set; }
        public virtual int coordinatorProject { get; set; }  // điều phối dự án
        public virtual List<int> projectMembers { get; set; } // Thành viên dự án
        public virtual object coordinatorDep { get; set; }  // đơn vị điều phối
        [Required(ErrorMessage = "Required bizModId")]
        public virtual int bizModId { get; set; } // loại hình kinh doanh
        [Required(ErrorMessage = "Required servId")]
        public virtual int servId { get; set; } //  dịch vụ
        [Required(ErrorMessage = "Required prodId")]
        public virtual int prodId { get; set; } // sản phẩm
        public virtual int? customerGroupId { get; set; } // nhom khach hang
        public virtual int? customerId { get; set; } // khach hang
    }

    public class Edit_ProjGeneralModel : Add_ProjGeneralModel
    {
    }

    public class FindOne_ProjGeneralModel : FindOne_ProjGeneralServiceModel
    {

    }

    public class Count_ProjGeneralModel : Count_ProjGeneralServiceModel
    {

    }
}
