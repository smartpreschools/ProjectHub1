using ProjectHub.Common.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHub.IDLL
{
    public interface IMasterDLL
    {
        #region dropdown Binding
        List<MasterDataModel> GetDropDownData(string drpName, string inputText);
        #endregion
    }
}
