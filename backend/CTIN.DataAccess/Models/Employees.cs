using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.Models
{
    public partial class Employees
    {
        public Employees()
        {
        }

        public long id { get; set; }

        [JsonData]
        public Employees_BasicJson basic { get; set; }
        public class Employees_BasicJson
        {
            public virtual FileJson avatar { get; set; }

            public virtual Guid? accountId { get; set; }
            public virtual string empCode { get; set; }

            public virtual string empCardNo { get; set; }

            public virtual string fullName { get; set; }

            public virtual string otherName { get; set; }

            public virtual string profileNo { get; set; }

            public virtual int profileLevel { get; set; }

            public virtual int genderId { get; set; }

            public virtual int? maritalId { get; set; }

            public virtual int? ethnicId { get; set; }

            public virtual int? religionId { get; set; }

            public virtual int? originateId { get; set; }

            public virtual string note { get; set; }

        }

        public Employees_StoryJson story { get; set; }
        public class Employees_StoryJson
        {
            public virtual DateTime? birthDay { get; set; }

            public virtual string placeOfBirth { get; set; }

            public virtual string originalAddress { get; set; }

            public virtual string permanentAddress { get; set; }

            public virtual int? countryId { get; set; }

            public virtual int? provinceId { get; set; }

            public virtual int? district { get; set; }

            public virtual int? wards { get; set; }
        }

        public virtual Employees_ContactJson contact { get; set; }
        public class Employees_ContactJson
        {
            public virtual string currentAddress { get; set; }

            public virtual string householdNo { get; set; }

            public virtual string phone { get; set; }

            public virtual string email { get; set; }

            public virtual string skype { get; set; }

            public virtual string facebook { get; set; }
        }

        public virtual List<Employees_AccuracyJson> accuracy { get; set; }
        public class Employees_AccuracyJson
        {
            public virtual int type { get; set; }

            public virtual string code { get; set; }

            public virtual DateTime? dateOfIssue { get; set; }

            public virtual DateTime? expirationDate { get; set; }

            public virtual string placeOfIssue { get; set; }
        }

        public virtual Employees_HealthJson health { get; set; }
        public class Employees_HealthJson
        {
            public virtual string bloodGroup { get; set; }

            public virtual string healthStatus { get; set; }

            public virtual float? height { get; set; }

            public virtual float? weight { get; set; }

            public virtual string note { get; set; }

            public virtual List<HealthCareHistory> healthCareHistory { get; set; }
            public class HealthCareHistory
            {
                public virtual string type { get; set; }

                public virtual string result { get; set; }

                public virtual DateTime? dateTime { get; set; }

                public virtual string place { get; set; }
            }
        }

        public virtual List<RelationshipJson> relationships { get; set; }
        public class RelationshipJson
        {
            public virtual string name { get; set; }

            public virtual string type { get; set; }

            public virtual DateTime? birthDay { get; set; }

            public virtual string job { get; set; }
            public virtual string address { get; set; }
            public virtual string dependent { get; set; }

        }

        public virtual List<FileJson> files { get; set; }

        public virtual Employees_FinanceJson finance { get; set; }
        public class Employees_FinanceJson
        {
            public virtual string bankId { get; set; }

            public virtual string bankName { get; set; }

            public virtual string taxCode { get; set; }

            public virtual string socialSecurityCode { get; set; }
        }

        public virtual Employees_PartyDelegationJson partyDelegation { get; set; }
        public class Employees_PartyDelegationJson
        {
            public virtual string dateInUnion { get; set; }

            public virtual string unionCardCode { get; set; }

            public virtual string unionPosition { get; set; }

            public virtual string placeOfUnion { get; set; }

            public virtual string dateInParty { get; set; }

            public virtual string partyCardCode { get; set; }

            public virtual string partyPosition { get; set; }

            public virtual string placeOfParty { get; set; }
        }

        public virtual Employees_FederationJson federation { get; set; }
        public class Employees_FederationJson
        {
            public virtual DateTime? dateIn { get; set; }

            public virtual string code { get; set; }

            public virtual string job { get; set; }

            public virtual string place { get; set; }
        }

        public virtual Employees_ArmyJson army { get; set; }
        public class Employees_ArmyJson
        {
            public virtual string dateInEnlistment { get; set; }

            public virtual string dateOutEnlistment { get; set; }

            public virtual string militaryPosition { get; set; }

            public virtual string rank { get; set; }

            public virtual string office { get; set; }
        }

        public List<Employees_RevolutionaryHistoryJson> revolutionaryHistory { get; set; }
        public class Employees_RevolutionaryHistoryJson
        {
            public virtual DateTime? dateJoining { get; set; }

            public virtual DateTime? dateOfOrganization { get; set; }

            public virtual string OldCharacteristics { get; set; }

            public virtual string newCharacteristics { get; set; }
        }

        public virtual List<Employees_JobJson> jobs { get; set; }
        public class Employees_JobJson
        {
            public virtual string decisionName { get; set; }

            public virtual string decisionId { get; set; }

            public virtual DateTime? effectiveDate { get; set; }

            public virtual FileJson decisionFile { get; set; }

            public virtual string reason { get; set; }

            public virtual int? officeId { get; set; }

            public virtual int? companyId { get; set; }

            public virtual int? nature { get; set; }

            public virtual Employees_JobDropdownJson job { get; set; }

            public virtual int? typeId { get; set; }

            public virtual string manager { get; set; }

            public virtual int? titleId { get; set; }

            public virtual int? position { get; set; }

            public class Employees_JobDropdownJson
            {
                public virtual int? id { get; set; }

                public virtual string name { get; set; }
            }

            public virtual List<Employees_BindingContractJson> bindingContract { get; set; }

            public class Employees_BindingContractJson
            {
                public virtual Guid? id { get; set; }
                public virtual string code { get; set; }

                public virtual string name { get; set; }

                public virtual DateTime? expiryDate { get; set; }
            }

            public virtual List<Employees_SubtaskJson> subtasks { get; set; }
            public class Employees_SubtaskJson
            {
                public virtual Guid? id { get; set; }
                public virtual DateTime? startDate { get; set; }

                public virtual DateTime? endDate { get; set; }

                public virtual int? office { get; set; }

                public virtual string name { get; set; }

                public virtual string description { get; set; }
            }
        }

        public DataDbJson dataDb { get; set; }

        public virtual List<EmployeesContract> contracts { get; set; }

        public class EmployeesContract
        {
            public virtual Guid? id { get; set; }

            public virtual string code { get; set; }

            public virtual string name { get; set; }

            public virtual int typeId { get; set; }

            public virtual DateTime? signDate { get; set; }

            public virtual DateTime? effectiveDate { get; set; }
        }

        public virtual EmployeesCapacityProfile capacityProfile { get; set; }
        public class EmployeesCapacityProfile
        {
            public List<EmployeesCapacity> capacity { get; set; }
            public class EmployeesCapacity
            {
                public virtual Guid id { get; set; }
                public virtual string name { get; set; }

                public virtual string evaluate { get; set; }

                public virtual string graded { get; set; }
            }

            public List<EmployeesSkill> skills { get; set; }
            public class EmployeesSkill
            {
                public virtual Guid id { get; set; }

                public virtual string name { get; set; }

                public virtual int? level { get; set; }

                public virtual string exper { get; set; }
            }

            public List<EmployeesDiploma> diploma { get; set; }
            public class EmployeesDiploma
            {
                public virtual Guid id { get; set; }

                public virtual string name { get; set; }

                public virtual string specialized { get; set; }

                public virtual string graded { get; set; }

                public virtual string issuedBy { get; set; }
            }

            public virtual List<EmployeesCertificate> certificate { get; set; }
            public class EmployeesCertificate
            {

                public virtual string name { get; set; }

                public virtual string specialized { get; set; }

                public virtual string graded { get; set; }

                public virtual string issuedBy { get; set; }

                public virtual DateTime? dateOfIssue { get; set; }

                public virtual DateTime? expirationDate { get; set; }
            }

            public virtual List<EmployeesWorkExperience> workExperience { get; set; }
            public class EmployeesWorkExperience
            {
                public virtual DateTime? startDate { get; set; }

                public virtual DateTime? endDate { get; set; }

                public virtual string issuedBy { get; set; }

                public virtual string job { get; set; }

                public virtual string description { get; set; }
            }

            public virtual List<EmployeesCommendation> commendation { get; set; }
            public class EmployeesCommendation
            {
                public virtual DateTime? startDate { get; set; }

                public virtual DateTime? endDate { get; set; }

                public virtual int? typeId { get; set; }

                public virtual string wonTheTitle { get; set; }

                public virtual string reward { get; set; }

                public virtual string note { get; set; }
            }

            public virtual List<EmployeesDiscipline> discipline { get; set; }
            public class EmployeesDiscipline
            {
                public virtual DateTime? startDate { get; set; }

                public virtual DateTime? endDate { get; set; }

                public virtual int? typeId { get; set; }

                public virtual string name { get; set; }

                public virtual string value { get; set; }

                public virtual string note { get; set; }
            }
        }
    }
}
