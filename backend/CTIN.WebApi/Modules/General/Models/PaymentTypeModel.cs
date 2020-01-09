using CTIN.Domain.Models;
using static CTIN.DataAccess.Models.PaymentType;

namespace CTIN.WebApi.Modules.General.Models
{
    public class Search_PaymentTypeModel : Search_PaymentTypeServiceModel
    {
    }

    public class Add_PaymentTypeModel
    {
        public Add_PaymentTypeModel_DataJson data { get; set; }
        public Add_PaymentTypeModel_DataDbJson dataDb { get; set; }

        public class Add_PaymentTypeModel_DataJson : PaymentTypeDataJson
        {

        }

        public class Add_PaymentTypeModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_PaymentTypeModel : Add_PaymentTypeModel
    {


    }

    public class FindOne_PaymentTypeModel : FindOne_PaymentTypeServiceModel
    {

    }

    public class Count_PaymentTypeModel : Count_PaymentTypeServiceModel
    {

    }
}
