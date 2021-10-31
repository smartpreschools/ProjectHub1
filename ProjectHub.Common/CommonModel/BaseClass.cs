using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHub.CommonModel.CommonModel
{
    [DataContract]
    [Serializable]
    public class BaseClass
    {
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string Status { get; set; }

        public string InsertMode { get; set; }
    }
}
