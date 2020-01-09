using Microsoft.EntityFrameworkCore.Query;
using System;

namespace CTIN.DataAccess.Bases
{
    public static class DbFunction
    {     
        public static object JsonValue(object column,[NotParameterized] string path)
        {
            
            throw new NotSupportedException();
        }
    }
}
