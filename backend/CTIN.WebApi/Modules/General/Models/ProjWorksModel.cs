using CTIN.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_ProjWorksModel : Search_ProjWorksServiceModel
    {
    }

    public class Add_ProjWorksModel
    {
        [Required(ErrorMessage = "Required Idgeneral")]
        public int projGeneralId { get; set; }

        [Required(ErrorMessage = "Required Workname")]
        [MaxLength(500, ErrorMessage = "Chiều dài Classifyworks không được quá 500 kí tự")]
        public string workName { get; set; }

        [Required(ErrorMessage = "Required Idstatus")]
        public int statusId { get; set; }

        [Range(0, 100, ErrorMessage = "Giá trị được nhập Workcompleted từ 0 đến 100")]
        public int workCompleted { get; set; }

        public int? classifyWorks { get; set; }

        public DateTime beginDate { get; set; }

        public DateTime endDate { get; set; }

        public int timePlan { get; set; }

        public int timeReality { get; set; }

        public string content { get; set; }

        [Required(ErrorMessage = "Required empId")]
        public int empId { get; set; }
        public int targetId { get; set; }
        public int? perrentId { get; set; }
        public int? priority { get; set; }

        public string note { get; set; }

        [MaxLength(250, ErrorMessage = "contact không được quá 250")]
        public string contact { get; set; }

        [MaxLength(500, ErrorMessage = "coordinationList không quá 500")]
        public object coordinationList { get; set; }
        public DateTime? completeDate { get; set; } // ngay hoan thanh
    }


    public class Edit_ProjWorksModel : Add_ProjWorksModel
    {

    }

    public class FindOne_ProjWorksModel : FindOne_ProjWorksServiceModel
    {

    }

    public class Count_ProjWorksModel : Count_ProjWorksServiceModel
    {

    }
}
