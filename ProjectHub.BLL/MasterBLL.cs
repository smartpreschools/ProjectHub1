using ProjectHub.Common.CommonModel;
using ProjectHub.DLL;
using ProjectHub.IDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHub.BLL
{
    public class MasterBLL 
    {
        private readonly IMasterDLL masterDLLObj;
        public MasterBLL()
        {
            masterDLLObj = new MasterDLL();
        }

        public List<MasterDataModel> GetDropDownData(string dropName, string inputText)
        {
            return masterDLLObj.GetDropDownData(dropName, inputText);
        }
    }
}
