using CTIN.Domain.Models;
using static CTIN.DataAccess.Models.TermsOfPayment;

namespace CTIN.WebApi.Modules.General.Models
{
    public class TermsOfPaymentModel
    {
    }

    public class Search_TermsOfPaymentModel : Search_TermsOfPaymentServiceModel
    {
    }

    public class Add_TermsOfPaymentModel
    {
        public Add_TermsOfPaymentModel_DataJson data { get; set; }
        public Add_TermsOfPaymentModel_DataDbJson dataDb { get; set; }

        public class Add_TermsOfPaymentModel_DataJson : TermsOfPaymentDataJson
        {

        }

        public class Add_TermsOfPaymentModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_TermsOfPaymentModel : Add_TermsOfPaymentModel
    {


    }

    public class FindOne_TermsOfPaymentModel : FindOne_TermsOfPaymentServiceModel
    {

    }

    public class Count_TermsOfPaymentModel : Count_TermsOfPaymentServiceModel
    {

    }
}
