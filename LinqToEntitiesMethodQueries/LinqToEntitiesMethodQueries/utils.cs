using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToEntitiesMethodQueries
{
    class utils
    {
        
    }

    public class bookComparer : IEqualityComparer<title>
    {
        public bool Equals(title x, title y)
        {
            return x.title_id == y.title_id;
        }

        public int GetHashCode(title obj)
        {
            return obj.GetHashCode();
        }
    }
}
