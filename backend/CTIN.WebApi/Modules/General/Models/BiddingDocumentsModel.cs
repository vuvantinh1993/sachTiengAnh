using CTIN.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_BiddingDocumentsModel : Search_BiddingDocumentsServiceModel
    {
    }

    public class Add_BiddingDocumentsModel
    {
        [Required(ErrorMessage = "Required projId")]
        public int projId { get; set; } //mã dự án

        [Required(ErrorMessage = "Required packageBidsId")]
        public int packageBidsId { get; set; } //mã gói thầu
        public DateTime? dateOfBidSubmission { get; set; } //ngày nộp hồ sơ mời thầu
        public DateTime? submissionDate { get; set; } //ngày trình
        public DateTime? dateOfVerification { get; set; } //ngày thẩm tra
        public DateTime? datePassed { get; set; } //ngày thông qua
        public DateTime? dateOfApproval { get; set; } //ngày duyệt
        public string decisionNumber { get; set; } //số quyết định
        public DateTime? releaseDate { get; set; } //ngày phát hành
        public DateTime? adjustmentDate { get; set; } //ngày điều chỉnh nộp hồ sơ mời thầu
        public DateTime? signedOn { get; set; } //ngày kí
        public object[] listEmpId { get; set; } //người liên quan
        public bool? allowDisplay { get; set; }
        public string note { get; set; }
        public int? index { get; set; }
    }


    public class Edit_BiddingDocumentsModel : Add_BiddingDocumentsModel
    {

    }

    public class FindOne_BiddingDocumentsModel : FindOne_BiddingDocumentsServiceModel
    {

    }

    public class Count_BiddingDocumentsModel : Count_BiddingDocumentsServiceModel
    {

    }
}
