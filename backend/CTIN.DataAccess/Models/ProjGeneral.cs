using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTIN.DataAccess.Models
{
    public partial class ProjGeneral
    {

        public virtual int id { get; set; }
        public virtual int? projTypeId { get; set; }
        public virtual string projCode { get; set; }
        public virtual string projName { get; set; }
        public virtual DateTime beginDate { get; set; }
        public virtual DateTime endDate { get; set; }
        public virtual DateTime? completedDate { get; set; }
        public virtual int? statusId { get; set; }
        public virtual int projPercent { get; set; }
        public virtual int? pmName { get; set; }
        public virtual bool? allowEmail { get; set; }
        public virtual string content { get; set; }
        public virtual int? partnerId { get; set; }
        public virtual int? projgroupId { get; set; }
        public virtual string projPriority { get; set; }
        public virtual string learderName { get; set; }
        public virtual int? targetId { get; set; }
        public virtual int? mntFormId { get; set; }
        public virtual int? investsId { get; set; }
        public virtual int? biddingId { get; set; }
        public virtual int? empId { get; set; } // đơn vị phối hợp
        public virtual int? depId { get; set; } // đơn vị triển khai
        public virtual int? budgetId { get; set; }
        public virtual string currency { get; set; }
        public virtual decimal exchangeRate { get; set; }
        public virtual decimal estimatedBudget { get; set; }
        public virtual decimal proposedBudget { get; set; }
        public virtual decimal planBudget { get; set; }
        public virtual decimal crbudget { get; set; }
        public virtual decimal feasibilityStadyBudget { get; set; }
        public virtual decimal feasibilityCrbudget { get; set; }
        public virtual decimal totalCostContract { get; set; }
        public virtual decimal totalContractExpenses { get; set; }
        public virtual decimal budgetRemaining { get; set; }
        public virtual decimal totalContractAmount { get; set; }
        public virtual decimal totalContractPayment { get; set; }
        public virtual decimal totalContractRemaining { get; set; }
        public virtual decimal totalOperatingExpenses { get; set; }
        public virtual decimal costBooks { get; set; }
        public virtual decimal salesPlan { get; set; }
        public virtual string note { get; set; }
        public virtual string memory { get; set; }
        public virtual string createdBy { get; set; }
        public virtual DateTime createdDate { get; set; }
        public virtual string modifiedBy { get; set; }
        public virtual DateTime modifiedDate { get; set; }
        public virtual int? partGroupId { get; set; }
        public virtual int directorProject { get; set; }
        public virtual int cmo { get; set; }
        public virtual int amProject { get; set; }
        public virtual int coordinatorProject { get; set; }  // điều phối dự án
        public object projectMembers { get; set; } // Thành viên dự án
        public object coordinatorDep { get; set; }  // đơn vị điều phối
        public virtual int? bizModId { get; set; } // loại hình kinh doanh
        public virtual int? servId { get; set; } //  dịch vụ
        public virtual int? prodId { get; set; } // sản phẩm
        public virtual int? customerGroupId { get; set; } // nhom khach hang
        public virtual int? customerId { get; set; } // khach hang
        public virtual int? delete { get; set; }

        public virtual Partner partner { get; private set; }
        public virtual ProjectGroup projgroup { get; private set; }
        public virtual Target target { get; private set; }
        public virtual ManagementForm mntForm { get; private set; }
        public virtual Invests invests { get; private set; }
        public virtual Bidding bidding { get; private set; }
        public virtual ProductServices serv { get; private set; }
        public virtual ProductServices prod { get; private set; }
        public virtual Status status { get; private set; }
        public virtual ProjectType projType { get; private set; }
        public virtual Partner pmNam { get; private set; }
        public virtual BizModel bizMod { get; private set; }

    }
}