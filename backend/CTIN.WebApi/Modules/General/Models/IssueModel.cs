using CTIN.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_IssueModel : Search_IssueServiceModel
    {
        //public Search_IssueModel()
        //{
        //    order = "[{\"issue.id\": false}]";
        //}
        //public override string order { get => base.order; set => base.order = value; }
    }

    public class Add_IssueModel
    {
        [Required(ErrorMessage = "Required issueName")]
        public string issueName { get; set; }
        public int issueTypeId { get; set; }

        [Required(ErrorMessage = "Required statusId")]
        public int statusId { get; set; }
        public int percentCompleted { get; set; }
        public DateTime completedDate { get; set; }


        public int priority { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public int timePlan { get; set; }
        public int timeReality { get; set; }


        public int empId { get; set; }
        public string content { get; set; }
        public object coordinationList { get; set; }

        [Required(ErrorMessage = "Required projId")]
        public int projId { get; set; }
        [MaxLength(500, ErrorMessage = "Vượt quá 500 kí tự")]
        public string contactList { get; set; }
        public string note { get; set; }
        public int levelIssue { get; set; }
        public string solusion { get; set; }
        public int? issueCausesId { get; set; }
        public int flag { get; set; }
    }

    public class Edit_IssueModel : Add_IssueModel
    {
    }

    public class FindOne_IssueModel : FindOne_IssueServiceModel
    {

    }

    public class Count_IssueModel : Count_IssueServiceModel
    {

    }
}
