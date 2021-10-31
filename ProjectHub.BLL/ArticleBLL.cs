using ProjectHub.Common.ProductAdmin;
using ProjectHub.DLL;
using ProjectHub.IDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHub.BLL
{
   public class ArticleBLL
    {
        private readonly IArticleDLL articleDLLObj;
        public ArticleBLL()
        {
            articleDLLObj = new ArticleDLL();
        }

        #region Topic Master
        public int AddTopic(ArticleTopicModel articleTopicModel)
        {
            return articleDLLObj.AddTopic(articleTopicModel);
        }
        public int UpdateTopic(ArticleTopicModel articleTopicModel)
        {
            return articleDLLObj.UpdateTopic(articleTopicModel);
        }
        public List<ArticleTopicModel> GetTopicList()
        {
            return articleDLLObj.GetTopicList();
        }
        public int DeleteTopic(string TopicID)
        {
            return articleDLLObj.DeleteTopic(TopicID);
        }
        public ArticleTopicModel GetTopicByID(string TopicID)
        {
            return articleDLLObj.GetTopicByID(TopicID);
        }
        #endregion

        #region Sub Topic Master
        public int AddSubTopic(ArticleTopicModel articleTopicModel)
        {
            return articleDLLObj.AddSubTopic(articleTopicModel);
        }
        public int UpdateSubTopic(ArticleTopicModel articleTopicModel)
        {
            return articleDLLObj.UpdateSubTopic(articleTopicModel);
        }
        public List<ArticleTopicModel> GetSubTopicList()
        {
            return articleDLLObj.GetSubTopicList();
        }
        public int DeleteSubTopic(string SubTopicID)
        {
            return articleDLLObj.DeleteSubTopic(SubTopicID);
        }
        public ArticleTopicModel GetSubTopicByID(string SubTopicID)
        {
            return articleDLLObj.GetSubTopicByID(SubTopicID);
        }
        #endregion

        #region Article
        public int AddArticle(ArticleModel articleModel)
        {
            return articleDLLObj.AddArticle(articleModel);
        }
        public int UpdateArticle(ArticleModel articleModel)
        {
            return articleDLLObj.UpdateArticle  (articleModel);
        }
        public List<ArticleModel> GetArticleList(string mode,string userID)
        {
            return articleDLLObj.GetArticleList(mode, userID);
        }
        public int DeleteArticle(string ArticleID)
        {
            return articleDLLObj.DeleteArticle(ArticleID);
        }
        public ArticleModel GetArticleByID(string ArticleID)
        {
            return articleDLLObj.GetArticleByID(ArticleID);
        }
        public List<ArticleModel> GetPendingArticleList()
        {
            return articleDLLObj.GetPendingArticleList();
        }
        public int ApproveArticle(string ArticleID)
        {
            return articleDLLObj.ApproveArticle(ArticleID);
        }
        #endregion
    }
}
