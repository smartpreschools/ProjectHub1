using ProjectHub.Common.CommonModel;
using ProjectHub.Common.Constants;
using ProjectHub.IDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHub.DLL
{
    public class MasterDLL : IMasterDLL
    {
        #region DropDownBinding
        public List<MasterDataModel> GetDropDownData(string drpName, string inputText)
        {
            SqlDataReader dr = null;
            List<MasterDataModel> masterDataModelList = new List<MasterDataModel>();
            SqlParameter[] param = null;
            try
            {
                string key = string.Empty, value = string.Empty, procname = string.Empty;
                if (drpName.ToUpper() == "ArticleTopic".ToUpper())
                {
                    key = "ID";
                    value = "Topic";
                    procname = SPName.GetActiveArticleTopic;

                    param = new SqlParameter[]
                    {

                    };
                }
                if (drpName.ToUpper() == "ArticleSubTopic".ToUpper())
                {
                    key = "ID";
                    value = "SubTopic";
                    procname = SPName.GetActiveArticleSubTopic;

                    param = new SqlParameter[]
                    {
                         new SqlParameter("V_Topic",inputText),
                    };
                }
                dr = SqlHelper.ExcuteDataReader(procname, param);
                if (dr != null)
                {
                    while (dr.HasRows && dr.Read())
                    {
                        var genericList = new MasterDataModel
                        {
                            DataId = Convert.ToString(dr["DataID"]),
                            DataName = Convert.ToString(dr["DataName"]),
                        };
                        masterDataModelList.Add(genericList);
                    }
                }
                return masterDataModelList;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (dr != null && !dr.IsClosed)
                {
                    dr.Close();
                }
            }
        }
        #endregion
    }
}
