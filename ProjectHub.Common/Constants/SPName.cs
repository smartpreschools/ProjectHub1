using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHub.Common.Constants
{
   public static class SPName
    {
        #region Article

        #region Article Topic master
        public const string SaveArticleTopicMaster = "PH_ProcAddArticleTopic";
        public const string GetArticleTopicList = "PH_ProcGetArticleTopicList";
        public const string DeleteArticleTopic = "PH_ProcDeleteArticleTopic";
        public const string GetArticleTopicByID = "PH_ProcGetArticleTopicById";
        public const string UpdateArticleTopicMaster = "PH_ProcUpdateArticleTopic";
        #endregion

        #region Article SubTopic master
        public const string SaveArticleSubTopicMaster = "PH_ProcAddArticleSubTopic";
        public const string GetArticleSubTopicList = "PH_ProcGetArticleSubTopicList";
        public const string DeleteArticleSubTopic = "PH_ProcDeleteArticleSubTopic";
        public const string GetArticleSubTopicByID = "PH_ProcGetArticleSubTopicById";
        public const string UpdateArticleSubTopicMaster = "PH_ProcUpdateArticleSubTopic";
        #endregion


        #region Article 
        public const string SaveArticle = "PH_ProcAddArticle";
        public const string GetArticleList = "PH_ProcGetArticle";
        public const string DeleteArticle = "PH_ProcDeleteArticle";
        public const string GetArticleByID = "PH_ProcGetArticleById";
        public const string UpdateArticle = "PH_ProcUpdateArticle";
        public const string GetPendingArticleList = "PH_ProcGetPendingArticle";
        public const string ApproveArticle = "PH_ProcApproveArticle";
        #endregion
        #region Master DropDown
        public const string GetActiveArticleTopic = "PH_ProcGetActiveArticleTopic";
        public const string GetActiveArticleSubTopic = "PH_ProcGetActiveArticleSubTopic";

        #endregion

        #endregion
    }
}
