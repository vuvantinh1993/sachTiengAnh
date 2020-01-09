using CTIN.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CTIN.WebApi.Modules.General.Models
{
    public class Search_ProjectResourcesModel : Search_ProjectResourcesServiceModel
    {
    }

    public class Add_ProjectResourcesModel
    {
        [Required(ErrorMessage = "empId không được để trống")]
        public int empId { get; set; }
        public int? posId { get; set; }

        [Required(ErrorMessage = "projId không được để trống")]
        public int projId { get; set; }
        public int? roleName { get; set; }
        public int? percentResource { get; set; }
        public object relatedList { get; set; }

        [Required(ErrorMessage = "beginDate không được để trống")]
        public DateTime? beginDate { get; set; }

        [Required(ErrorMessage = "endDate không được để trống")]
        public DateTime? endDate { get; set; }
        public bool? allowDisplay { get; set; }

        [MaxLength(250, ErrorMessage = "Không được nhập quá 500 kí tự")]
        public string note { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public string modifiedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
    }

    public class Edit_ProjectResourcesModel : Add_ProjectResourcesModel
    {
    }

    public class FindOne_ProjectResourcesModel : FindOne_ProjectResourcesServiceModel
    {

    }

    public class Count_ProjectResourcesModel : Count_ProjectResourcesServiceModel
    {

    }
}
