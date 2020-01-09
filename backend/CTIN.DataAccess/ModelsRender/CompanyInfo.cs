using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class CompanyInfo
    {
        public CompanyInfo()
        {
            Department = new HashSet<Department>();
            TrainningRequest = new HashSet<TrainningRequest>();
        }

        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string ShortName { get; set; }
        public string TradingName { get; set; }
        public int BusinessTypeId { get; set; }
        public int? ParentId { get; set; }
        public int? TypeId { get; set; }
        public string Data { get; set; }
        public string DataContact { get; set; }
        public string DataBank { get; set; }
        public string DataDb { get; set; }
        public string AffiliatedOrganization { get; set; }
        public int? Rank { get; set; }
        public string Director { get; set; }
        public string ChiefAccountant { get; set; }
        public string President { get; set; }
        public string PartyPresident { get; set; }
        public string UnionPresident { get; set; }
        public string YouthUnionPresident { get; set; }
        public string CertificateNo { get; set; }
        public DateTime? CertificateDate { get; set; }
        public string CertificatePlace { get; set; }
        public string TaxCode { get; set; }
        public string Representative { get; set; }
        public string Position { get; set; }
        public int? RegulationCapital { get; set; }
        public int? StockPrice { get; set; }
        public string Description { get; set; }
        public int? OrderIndex { get; set; }
        public bool? AllowDisplay { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public int? CountryId { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? CommuneId { get; set; }
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public string Branch { get; set; }
        public string BankAddress { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }

        public virtual TypeOfBusiness BusinessType { get; set; }
        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<TrainningRequest> TrainningRequest { get; set; }
    }
}
