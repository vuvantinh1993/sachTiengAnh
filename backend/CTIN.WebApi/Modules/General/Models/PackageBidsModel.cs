using CTIN.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_PackageBidsModel : Search_PackageBidsServiceModel
    {
    }

    public class Add_PackageBidsModel
    {
        [Required(ErrorMessage = "Required packageBidName")]
        public string packageBidName { get; set; } // Tên gói  thầu

        [Required(ErrorMessage = "Required projId")]
        public int projId { get; set; } // Mã dự án

        [Required(ErrorMessage = "Required startDay")]
        public DateTime? startDay { get; set; } // Ngày bắt đầu

        [Required(ErrorMessage = "Required lastDay")]
        public DateTime? lastDay { get; set; } // Ngày kết thúc

        public int statusId { get; set; } // Trạng thái
        [MaxLength(5, ErrorMessage = "currency không quá 5 kí tự")]
        public string currency { get; set; } // Loại tiền
        public decimal? estimatedPrice { get; set; } // Giá dự toán
        public decimal? bidPrice { get; set; } // Giá gói thầu
        public decimal? bestBid { get; set; } // Giá trúng thầu
        public decimal? contractPrice { get; set; } // Giá hợp đồng
        public int bidModelId { get; set; } // Phương thức đấu thầu
        public int bidId { get; set; } // Lĩnh vực đấu thầu
        public string contractorId { get; set; } // hình thức lựa chọn
        public object listEmpId { get; set; }
        public int empId { get; set; }
        public int? partId { get; set; }
        public string note { get; set; }
        public int? index { get; set; }
        public bool? allowDisplay { get; set; }
        public decimal? exchangeRate { get; set; }
    }


    public class Edit_PackageBidsModel : Add_PackageBidsModel
    {

    }

    public class FindOne_PackageBidsModel : FindOne_PackageBidsServiceModel
    {

    }

    public class Count_PackageBidsModel : Count_PackageBidsServiceModel
    {

    }
}
