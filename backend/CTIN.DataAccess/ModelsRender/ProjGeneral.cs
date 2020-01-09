using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class ProjGeneral
    {
        public int Id { get; set; }
        public int ProjTypeId { get; set; }
        public string ProjCode { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int StatusId { get; set; }
        public int? ProjPercent { get; set; }
        public int? PmName { get; set; }
        public bool? AllowEmail { get; set; }
        public string Content { get; set; }
        public int PartnerId { get; set; }
        public int ProjgroupId { get; set; }
        public string ProjPriority { get; set; }
        public string LearderName { get; set; }
        public int? TargetId { get; set; }
        public int? MntFormId { get; set; }
        public int? InvestsId { get; set; }
        public int? BiddingId { get; set; }
        public int ProdId { get; set; }
        public int? EmpId { get; set; }
        public int? DepId { get; set; }
        public int? BudgetId { get; set; }
        public string Currency { get; set; }
        public decimal? ExchangeRate { get; set; }
        public decimal? EstimatedBudget { get; set; }
        public decimal? ProposedBudget { get; set; }
        public decimal? PlanBudget { get; set; }
        public decimal? Crbudget { get; set; }
        public decimal? FeasibilityStadyBudget { get; set; }
        public decimal? FeasibilityCrbudget { get; set; }
        public decimal? TotalCostContract { get; set; }
        public decimal? TotalContractExpenses { get; set; }
        public decimal? BudgetRemaining { get; set; }
        public decimal? TotalContractAmount { get; set; }
        public decimal? TotalContractPayment { get; set; }
        public decimal? TotalContractRemaining { get; set; }
        public decimal? TotalOperatingExpenses { get; set; }
        public decimal? CostBooks { get; set; }
        public decimal? SalesPlan { get; set; }
        public string Note { get; set; }
        public string Memory { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? PartGroupId { get; set; }
        public int? DirectorProject { get; set; }
        public int? Cmo { get; set; }
        public int? AmProject { get; set; }
        public int? CoordinatorProject { get; set; }
        public string ProjectMembers { get; set; }
        public string CoordinatorDep { get; set; }
        public string ProjName { get; set; }
        public int BizModId { get; set; }
        public int ServId { get; set; }
        public int? Delete { get; set; }
        public int? CustomerGroupId { get; set; }
        public int? CustomerId { get; set; }
    }
}
