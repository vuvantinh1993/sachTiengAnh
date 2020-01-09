using CTIN.Common.Models;


namespace CTIN.DataAccess.Models
{
    public partial class TermsOfPayment
    {
        public int id { get; set; }
        public TermsOfPaymentDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class TermsOfPaymentDataJson
        {
            public string termsOfPaymentName { get; set; }
            public virtual string note { get; set; }
        }
    }

}


