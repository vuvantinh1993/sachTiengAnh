using CTIN.Common.Models;
using CTIN.DataAccess.Models;
namespace CTIN.Domain.Models
{
    public class Search_ProjGeneralServiceModel : SearchModel
    {

    }

    public class Add_ProjGeneralServiceModel : ProjGeneral
    {

    }

    public class Edit_ProjGeneralServiceModel : ProjGeneral
    {

    }

    public class Delete_ProjGeneralServiceModel
    {
        public virtual int id { get; set; }

    }

    public class FindOne_ProjGeneralServiceModel : WhereModel
    {
    }

    public class Count_ProjGeneralServiceModel : WhereModel
    {
    }

}
