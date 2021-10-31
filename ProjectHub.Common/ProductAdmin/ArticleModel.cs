using ProjectHub.CommonModel.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHub.Common.ProductAdmin
{
   public class ArticleModel : BaseClass
    {
        public int ID { get; set; }
        public string Topic { get; set; }
        public string SubTopic { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
