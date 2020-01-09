using CTIN.Common.Models;
using CTIN.DataAccess.Models;
namespace CTIN.Domain.Models
{
    public class Search_ProjectResourcesServiceModel : SearchModel
    {

    }

    public class Add_ProjectResourcesServiceModel : ProjectResources
    {

    }

    public class Edit_ProjectResourcesServiceModel : ProjectResources
    {

    }

    public class Delete_ProjectResourcesServiceModel
    {
        public virtual int id { get; set; }
        public virtual int? delete { get; set; }

    }

    public class FindOne_ProjectResourcesServiceModel : WhereModel
    {
    }

    public class Count_ProjectResourcesServiceModel : WhereModel
    {
    }

}
