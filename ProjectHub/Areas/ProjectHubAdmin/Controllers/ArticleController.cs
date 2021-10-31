using ProjectHub.BLL;
using ProjectHub.Common.ProductAdmin;
using ProjectHub.DataSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHub.Areas.ProjectHubAdmin.Controllers
{
    public class ArticleController : Controller
    {

        #region Constructor and varibale declaration
        private readonly ArticleBLL articleBLLobj;
        private readonly CrossSiteScripting crossSiteScripting;
        public ArticleController()
        {
            articleBLLobj = new ArticleBLL();
            crossSiteScripting = new CrossSiteScripting();
        }

        #endregion
        #region Topic Master 
        /// <summary>
        /// Method: Category
        /// Description:To view category page
        /// Created By :Sourabh Raut
        /// Created On : 03-03-2021
        /// </summary>
        /// <returns>Category View</returns>
        public ActionResult Topic()
        {
            return View();
        }

        /// <summary>
        /// Method: Category
        /// Description:To adding new category
        /// Created By :Someshwar Wagh
        /// Created On : 03-05-2021
        /// </summary>
        /// <returns>Category View</returns>

        [HttpPost]
        public ActionResult Topic(ArticleTopicModel articleTopicModel)
        {
            //Check Cross Site Scripting attack
            articleTopicModel = crossSiteScripting.SafeContentCheckOnModel<ArticleTopicModel>(articleTopicModel);

            //Login
            string UserID = Convert.ToString(Session["UserID"]);
            if (ModelState.IsValid && UserID!="")
            {
                articleTopicModel.CreatedBy = UserID;
                int value = articleBLLobj.AddTopic(articleTopicModel);
                return Json(value);
            }
            return Json("100");
        }
        /// <summary>
        /// Method: Category
        /// Description:To updating new category
        /// Created By :Someshwar Wagh
        /// Created On : 13-04-2021
        /// </summary>
        /// <returns>Category View</returns>

        [HttpPost]
        public ActionResult UpdateTopic(ArticleTopicModel articleTopicModel)
        {
            //Check Cross Site Scripting attack
            articleTopicModel = crossSiteScripting.SafeContentCheckOnModel<ArticleTopicModel>(articleTopicModel);
            //Login
            string UserID = Convert.ToString(Session["UserID"]);
            if (ModelState.IsValid)
            {
                articleTopicModel.ModifiedBy = UserID;

                int value = articleBLLobj.UpdateTopic(articleTopicModel);
                return Json(value);
            }
            return Json("");
        }
        /// <summary>
        /// Method: GetCategoryList
        /// Description:fetching all category list
        /// Created By :Sourabh Raut
        /// Created On : 06-03-2021
        /// </summary>
        /// <returns>GetCategoryList</returns>

        [HttpPost]
        public ActionResult GetTopicList()
        {
            var categoryList = articleBLLobj.GetTopicList();
            return Json(categoryList, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Method: GetCategoryList
        /// Description:fetching all category list
        /// Created By :Sourabh Raut
        /// Created On : 06-03-2021
        /// </summary>
        /// <returns>GetCategoryList</returns>

        [HttpPost]
        public ActionResult DeleteTopic(string TopicID)
        {
            //Check Cross Site Scripting attack
            TopicID = crossSiteScripting.SafeContentCheckOnParameter(TopicID);
            var Status = articleBLLobj.DeleteTopic(TopicID);
            return Json(Status, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Method: GetTopicByID
        /// Description:fetching single category based on GetTopicByID ID
        /// Created By :Sourabh Raut
        /// Created On : 10-04-2021
        /// </summary>
        /// <returns>return single GetTopicByID</returns>

        [HttpGet]
        public ActionResult GetTopicByID(string TopicID)
        {
            //Check Cross Site Scripting attack
            TopicID = crossSiteScripting.SafeContentCheckOnParameter(TopicID);

            var category = articleBLLobj.GetTopicByID(TopicID);
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region SubTopic Master 
        /// <summary>
        /// Method: Category
        /// Description:To view category page
        /// Created By :Sourabh Raut
        /// Created On : 03-03-2021
        /// </summary>
        /// <returns>Category View</returns>
        public ActionResult SubTopic()
        {
            return View();
        }

        /// <summary>
        /// Method: Category
        /// Description:To adding new category
        /// Created By :Sayali
        /// Created On : 03-05-2021
        /// </summary>
        /// <returns>Category View</returns>

        [HttpPost]
        public ActionResult SubTopic(ArticleTopicModel articleTopicModel)
        {
            //Check Cross Site Scripting attack
            articleTopicModel = crossSiteScripting.SafeContentCheckOnModel<ArticleTopicModel>(articleTopicModel);

            //Login
            string UserID = Convert.ToString(Session["UserID"]);
            if (ModelState.IsValid && UserID != "")
            {
                articleTopicModel.CreatedBy = UserID;
                int value = articleBLLobj.AddSubTopic(articleTopicModel);
                return Json(value);
            }
            return Json("100");
        }
        /// <summary>
        /// Method: Category
        /// Description:To updating new category
        /// Created By :Sayali
        /// Created On : 13-04-2021
        /// </summary>
        /// <returns>Category View</returns>

        [HttpPost]
        public ActionResult UpdateSubTopic(ArticleTopicModel articleTopicModel)
        {
            //Check Cross Site Scripting attack
            articleTopicModel = crossSiteScripting.SafeContentCheckOnModel<ArticleTopicModel>(articleTopicModel);
            //Login
            string UserID = Convert.ToString(Session["UserID"]);
            if (ModelState.IsValid)
            {
                articleTopicModel.ModifiedBy = UserID;

                int value = articleBLLobj.UpdateSubTopic(articleTopicModel);
                return Json(value);
            }
            return Json("");
        }
        /// <summary>
        /// Method: GetCategoryList
        /// Description:fetching all category list
        /// Created By :Sourabh Raut
        /// Created On : 06-03-2021
        /// </summary>
        /// <returns>GetCategoryList</returns>

        [HttpPost]
        public ActionResult GetSubTopicList()
        {
            var categoryList = articleBLLobj.GetSubTopicList();
            return Json(categoryList, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Method: GetCategoryList
        /// Description:fetching all category list
        /// Created By :Sourabh Raut
        /// Created On : 06-03-2021
        /// </summary>
        /// <returns>GetCategoryList</returns>

        [HttpPost]
        public ActionResult DeleteSubTopic(string SubTopicID)
        {
            //Check Cross Site Scripting attack
            SubTopicID = crossSiteScripting.SafeContentCheckOnParameter(SubTopicID);
            var Status = articleBLLobj.DeleteSubTopic(SubTopicID);
            return Json(Status, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Method: GetTopicByID
        /// Description:fetching single category based on GetTopicByID ID
        /// Created By :Sourabh Raut
        /// Created On : 10-04-2021
        /// </summary>
        /// <returns>return single GetTopicByID</returns>

        [HttpGet]
        public ActionResult GetSubTopicByID(string SubTopicID)
        {
            //Check Cross Site Scripting attack
            SubTopicID = crossSiteScripting.SafeContentCheckOnParameter(SubTopicID);

            var category = articleBLLobj.GetSubTopicByID(SubTopicID);
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Article 
        /// <summary>
        /// Method: Content
        /// Description:To view Content page
        /// Created By :Sourabh Raut
        /// Created On : 03-03-2021
        /// </summary>
        /// <returns>Content View</returns>
        public ActionResult Content()
        {
            return View();
        }

        /// <summary>
        /// Method: Content
        /// Description:Content
        /// Created By :Sayali
        /// Created On : 03-05-2021
        /// </summary>
        /// <returns>Category View</returns>

        [HttpPost]
        public ActionResult Content(ArticleModel articleModel)
        {
            //Check Cross Site Scripting attack
            articleModel = crossSiteScripting.SafeContentCheckOnModel<ArticleModel>(articleModel);

            //Login
            string UserID = Convert.ToString(Session["UserID"]);
            if (ModelState.IsValid && UserID != "")
            {
                articleModel.CreatedBy = UserID;
                int value = articleBLLobj.AddArticle(articleModel);
                return Json(value);
            }
            return Json("100");
        }
        /// <summary>
        /// Method: UpdateArticle
        /// Description:UpdateArticle
        /// Created By :Sayali
        /// Created On : 13-04-2021
        /// </summary>
        /// <returns>Category View</returns>

        [HttpPost]
        public ActionResult UpdateArticle(ArticleModel articleModel)
        {
            //Check Cross Site Scripting attack
            articleModel = crossSiteScripting.SafeContentCheckOnModel<ArticleModel>(articleModel);
            //Login
            string UserID = Convert.ToString(Session["UserID"]);
            if (ModelState.IsValid)
            {
                articleModel.ModifiedBy = UserID;

                int value = articleBLLobj.UpdateArticle(articleModel);
                return Json(value);
            }
            return Json("");
        }
        /// <summary>
        /// Method: GetArticleList
        /// Description:GetArticleList
        /// Created By :Sourabh Raut
        /// Created On : 06-03-2021
        /// </summary>
        /// <returns>GetArticleList</returns>

        [HttpPost]
        public ActionResult GetArticleList(string mode)
        {
            string UserID = Convert.ToString(Session["UserID"]);
            var articleList = articleBLLobj.GetArticleList(mode, UserID);
            return Json(articleList, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Method: GetPendingArticleList
        /// Description:GetPendingArticleList
        /// Created By :Sourabh Raut
        /// Created On : 06-03-2021
        /// </summary>
        /// <returns>GetCategoryList</returns>

        [HttpPost]
        public ActionResult GetPendingArticleList()
        {
            var articleList = articleBLLobj.GetPendingArticleList();
            return Json(articleList, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Method: DeleteArticle
        /// Description:DeleteArticles
        /// Created By :Sourabh Raut
        /// Created On : 06-03-2021
        /// </summary>
        /// <returns>GetCategoryList</returns>

        [HttpPost]
        public ActionResult DeleteArticle(string ArticleID)
        {
            //Check Cross Site Scripting attack
            ArticleID = crossSiteScripting.SafeContentCheckOnParameter(ArticleID);
            var Status = articleBLLobj.DeleteArticle(ArticleID);
            return Json(Status, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Method: ApproveArticle
        /// Description:ApproveArticle
        /// Created By :Sourabh Raut
        /// Created On : 06-03-2021
        /// </summary>
        /// <returns>GetCategoryList</returns>

        [HttpPost]
        public ActionResult ApproveArticle(string ArticleID)
        {
            //Check Cross Site Scripting attack
            ArticleID = crossSiteScripting.SafeContentCheckOnParameter(ArticleID);
            var Status = articleBLLobj.ApproveArticle(ArticleID);
            return Json(Status, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Method: GetArticleByID
        /// Description:fetching single GetArticleByID based on GetArticleByID
        /// Created By :Sourabh Raut
        /// Created On : 10-04-2021
        /// </summary>
        /// <returns>return single GetTopicByID</returns>

        [HttpGet]
        public ActionResult GetArticleByID(string ArticleID)
        {
            //Check Cross Site Scripting attack
            ArticleID = crossSiteScripting.SafeContentCheckOnParameter(ArticleID);

            var article = articleBLLobj.GetArticleByID(ArticleID);
            return Json(article, JsonRequestBehavior.AllowGet);
        }

        #endregion
        public ActionResult ArticleList()
        {
            return View();
        }
        public ActionResult PendingArticle()
        {
            return View();
        }
       
    }
}