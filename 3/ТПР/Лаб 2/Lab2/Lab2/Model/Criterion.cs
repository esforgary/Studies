using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Model
{
    public class Criterion
    {
        private List<string> criteriaScale = new List<string>();

        public List<string> CriteriaScale
        {
            get { return criteriaScale; }
            set { criteriaScale = value; }
        }
    }
}
