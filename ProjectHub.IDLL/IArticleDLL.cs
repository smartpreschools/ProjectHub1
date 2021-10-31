using ProjectHub.Common.ProductAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHub.IDLL
{
    public interface IArticleDLL
    {
        #region Article Topic
        int AddTopic(ArticleTopicModel articleTopicModel);
        int UpdateTopic(ArticleTopicModel articleTopicModel);
        List<ArticleTopicModel> GetTopicList();

        int DeleteTopic(string TopicID);

        ArticleTopicModel GetTopicByID(string TopicID);
        #endregion

        #region Article Sub Topic
        int AddSubTopic(ArticleTopicModel articleTopicModel);
        int UpdateSubTopic(ArticleTopicModel articleTopicModel);
        List<ArticleTopicModel> GetSubTopicList();

        int DeleteSubTopic(string SubTopicID);

        ArticleTopicModel GetSubTopicByID(string SubTopicID);
        #endregion

        #region Article Sub Topic
        int AddArticle(ArticleModel articleModel);
        int UpdateArticle(ArticleModel articleModel);
        List<ArticleModel> GetArticleList(string mode,string userID);

        int DeleteArticle(string ArticleID);
        int ApproveArticle(string ArticleID);

        ArticleModel GetArticleByID(string ArticleID);
        List<ArticleModel> GetPendingArticleList();
        #endregion


    }
}
