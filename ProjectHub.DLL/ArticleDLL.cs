using ProjectHub.Common.Constants;
using ProjectHub.Common.ProductAdmin;
using ProjectHub.IDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHub.DLL
{
    public class ArticleDLL : IArticleDLL
    {
        #region Topic Master
        public int AddTopic(ArticleTopicModel articleTopicModel)
        {
            int statusID = 0;
            try
            {
                if (articleTopicModel != null)
                {
                    SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("V_Topic",articleTopicModel.Topic),
                        new SqlParameter("V_Desc",articleTopicModel.Description),
                        new SqlParameter("V_CreatedBy",articleTopicModel.CreatedBy),
                        new SqlParameter("V_Status",articleTopicModel.Status),
                    };
                    statusID = SqlHelper.ExcuteNonQuery(SPName.SaveArticleTopicMaster, param);
                }
                return statusID;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public int UpdateTopic(ArticleTopicModel articleTopicModel)
        {
            int statusID = 0;
            try
            {
                if (articleTopicModel != null)
                {
                    SqlParameter[] param = new SqlParameter[]
                    {
                         new SqlParameter("V_ID",articleTopicModel.ID),
                        new SqlParameter("V_Topic",articleTopicModel.Topic),
                        new SqlParameter("V_Desc",articleTopicModel.Description),
                        new SqlParameter("V_ModifiedBy",articleTopicModel.ModifiedBy),
                        new SqlParameter("V_Status",articleTopicModel.Status),
                    };
                    statusID = SqlHelper.ExcuteNonQuery(SPName.UpdateArticleTopicMaster, param);
                }
                return statusID;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<ArticleTopicModel> GetTopicList()
        {
            List<ArticleTopicModel> CategoryList = new List<ArticleTopicModel>();
            SqlDataReader dr = null;
            try
            {

                SqlParameter[] param = new SqlParameter[]
                {

                };
                dr = SqlHelper.ExcuteDataReader(SPName.GetArticleTopicList, param);
                if (dr != null)
                {
                    while (dr.HasRows && dr.Read())
                    {
                        var obj = new ArticleTopicModel()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Topic = Convert.ToString(dr["Topic"]),
                            Description = Convert.ToString(dr["Description"]),
                            Status = Convert.ToString(dr["Status"]),

                        };
                        CategoryList.Add(obj);
                    }

                }
                return CategoryList;

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

        public int DeleteTopic(string TopicID)
        {
            int statusID = 0;
            try
            {
                if (TopicID != null)
                {
                    SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("V_ID",TopicID)
                    };
                    statusID = SqlHelper.ExcuteNonQuery(SPName.DeleteArticleTopic, param);
                }
                return statusID;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public ArticleTopicModel GetTopicByID(string TopicID)
        {
            SqlDataReader dr = null;
            ArticleTopicModel obj = new ArticleTopicModel();
            try
            {

                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("V_ID",TopicID)
                };
                dr = SqlHelper.ExcuteDataReader(SPName.GetArticleTopicByID, param);
                if (dr != null)
                {
                    while (dr.HasRows && dr.Read())
                    {
                        obj.ID = Convert.ToInt32(dr["ID"]);
                        obj.Topic = Convert.ToString(dr["Topic"]);
                        obj.Description = Convert.ToString(dr["Description"]);
                        obj.Status = Convert.ToString(dr["Status"]);
                    }
                }
                return obj;

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

        #region Sub Topic Master
        public int AddSubTopic(ArticleTopicModel articleTopicModel)
        {
            int statusID = 0;
            try
            {
                if (articleTopicModel != null)
                {
                    SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("V_Topic",articleTopicModel.Topic),
                         new SqlParameter("V_SubTopic",articleTopicModel.SubTopic),
                        new SqlParameter("V_Desc",articleTopicModel.Description),
                        new SqlParameter("V_CreatedBy",articleTopicModel.CreatedBy),
                        new SqlParameter("V_Status",articleTopicModel.Status),
                    };
                    statusID = SqlHelper.ExcuteNonQuery(SPName.SaveArticleSubTopicMaster, param);
                }
                return statusID;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public int UpdateSubTopic(ArticleTopicModel articleTopicModel)
        {
            int statusID = 0;
            try
            {
                if (articleTopicModel != null)
                {
                    SqlParameter[] param = new SqlParameter[]
                    {
                         new SqlParameter("V_ID",articleTopicModel.ID),
                        new SqlParameter("V_Topic",articleTopicModel.Topic),
                          new SqlParameter("V_SubTopic",articleTopicModel.SubTopic),
                        new SqlParameter("V_Desc",articleTopicModel.Description),
                        new SqlParameter("V_ModifiedBy",articleTopicModel.ModifiedBy),
                        new SqlParameter("V_Status",articleTopicModel.Status),
                    };
                    statusID = SqlHelper.ExcuteNonQuery(SPName.UpdateArticleSubTopicMaster, param);
                }
                return statusID;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<ArticleTopicModel> GetSubTopicList()
        {
            List<ArticleTopicModel> CategoryList = new List<ArticleTopicModel>();
            SqlDataReader dr = null;
            try
            {

                SqlParameter[] param = new SqlParameter[]
                {

                };
                dr = SqlHelper.ExcuteDataReader(SPName.GetArticleSubTopicList, param);
                if (dr != null)
                {
                    while (dr.HasRows && dr.Read())
                    {
                        var obj = new ArticleTopicModel()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Topic = Convert.ToString(dr["Topic"]),
                            SubTopic = Convert.ToString(dr["SubTopic"]),
                            Description = Convert.ToString(dr["Description"]),
                            Status = Convert.ToString(dr["Status"]),

                        };
                        CategoryList.Add(obj);
                    }

                }
                return CategoryList;

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

        public int DeleteSubTopic(string SubTopicID)
        {
            int statusID = 0;
            try
            {
                if (SubTopicID != null)
                {
                    SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("V_ID",SubTopicID)
                    };
                    statusID = SqlHelper.ExcuteNonQuery(SPName.DeleteArticleSubTopic, param);
                }
                return statusID;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public ArticleTopicModel GetSubTopicByID(string SubTopicID)
        {
            SqlDataReader dr = null;
            ArticleTopicModel obj = new ArticleTopicModel();
            try
            {

                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("V_ID",SubTopicID)
                };
                dr = SqlHelper.ExcuteDataReader(SPName.GetArticleSubTopicByID, param);
                if (dr != null)
                {
                    while (dr.HasRows && dr.Read())
                    {
                        obj.ID = Convert.ToInt32(dr["ID"]);
                        obj.Topic = Convert.ToString(dr["Topic"]);
                        obj.SubTopic = Convert.ToString(dr["SubTopic"]);
                        obj.Description = Convert.ToString(dr["Description"]);
                        obj.Status = Convert.ToString(dr["Status"]);
                    }
                }
                return obj;

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

        #region Article
        public int AddArticle(ArticleModel articleModel)
        {
            int statusID = 0;
            try
            {
                if (articleModel != null)
                {
                    SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("V_Topic",articleModel.Topic),
                        new SqlParameter("V_SubTopic",articleModel.SubTopic),
                        new SqlParameter("V_Name",articleModel.Name),
                        new SqlParameter("V_Desc",articleModel.Description),
                        new SqlParameter("V_CreatedBy",articleModel.CreatedBy),
                        new SqlParameter("V_Status",articleModel.Status),
                    };
                    statusID = SqlHelper.ExcuteNonQuery(SPName.SaveArticle, param);
                }
                return statusID;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public int UpdateArticle(ArticleModel articleModel)
        {
            int statusID = 0;
            try
            {
                if (articleModel != null)
                {
                    SqlParameter[] param = new SqlParameter[]
                    {
                         new SqlParameter("V_ID",articleModel.ID),
                        new SqlParameter("V_Topic",articleModel.Topic),
                        new SqlParameter("V_SubTopic",articleModel.SubTopic),
                        new SqlParameter("V_Name",articleModel.Description),
                        new SqlParameter("V_Desc",articleModel.Description),
                        new SqlParameter("V_CreatedBy",articleModel.CreatedBy),
                        new SqlParameter("V_Status",articleModel.Status),
                    };
                    statusID = SqlHelper.ExcuteNonQuery(SPName.UpdateArticle, param);
                }
                return statusID;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<ArticleModel> GetArticleList(string mode,string userId)
        {
            List<ArticleModel> articleModelList = new List<ArticleModel>();
            SqlDataReader dr = null;
            try
            {

                SqlParameter[] param = new SqlParameter[]
                {
                     new SqlParameter("V_Mode",mode),
                     new SqlParameter("V_UserID",userId),
                };
                dr = SqlHelper.ExcuteDataReader(SPName.GetArticleList, param);
                if (dr != null)
                {
                    while (dr.HasRows && dr.Read())
                    {
                        var obj = new ArticleModel()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Topic = Convert.ToString(dr["Topic"]),
                            SubTopic = Convert.ToString(dr["SubTopic"]),
                            Name = Convert.ToString(dr["Name"]),
                            Description = Convert.ToString(dr["Description"]),
                            Status = Convert.ToString(dr["Status"]),

                        };
                        articleModelList.Add(obj);
                    }

                }
                return articleModelList;

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
        public List<ArticleModel> GetPendingArticleList()
        {
            List<ArticleModel> articleModelList = new List<ArticleModel>();
            SqlDataReader dr = null;
            try
            {

                SqlParameter[] param = new SqlParameter[]
                {

                };
                dr = SqlHelper.ExcuteDataReader(SPName.GetPendingArticleList, param);
                if (dr != null)
                {
                    while (dr.HasRows && dr.Read())
                    {
                        var obj = new ArticleModel()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Topic = Convert.ToString(dr["Topic"]),
                            SubTopic = Convert.ToString(dr["SubTopic"]),
                            Name = Convert.ToString(dr["Name"]),
                            Description = Convert.ToString(dr["Description"]),
                            Status = Convert.ToString(dr["Status"]),

                        };
                        articleModelList.Add(obj);
                    }

                }
                return articleModelList;

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

        public int DeleteArticle(string ArticleID)
        {
            int statusID = 0;
            try
            {
                if (ArticleID != null)
                {
                    SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("V_ID",ArticleID)
                    };
                    statusID = SqlHelper.ExcuteNonQuery(SPName.DeleteArticle, param);
                }
                return statusID;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public int ApproveArticle(string ArticleID)
        {
            int statusID = 0;
            try
            {
                if (ArticleID != null)
                {
                    SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("V_ID",ArticleID)
                    };
                    statusID = SqlHelper.ExcuteNonQuery(SPName.ApproveArticle, param);
                }
                return statusID;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public ArticleModel GetArticleByID(string ArticleID)
        {
            SqlDataReader dr = null;
            ArticleModel obj = new ArticleModel();
            try
            {

                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("V_ID",ArticleID)
                };
                dr = SqlHelper.ExcuteDataReader(SPName.GetArticleByID, param);
                if (dr != null)
                {
                    while (dr.HasRows && dr.Read())
                    {
                        obj.ID = Convert.ToInt32(dr["ID"]);
                        obj.Topic = Convert.ToString(dr["Topic"]);
                        obj.SubTopic = Convert.ToString(dr["SubTopic"]);
                        obj.Name = Convert.ToString(dr["Name"]);
                        obj.Description = Convert.ToString(dr["Description"]);
                        obj.Status = Convert.ToString(dr["Status"]);
                    }
                }
                return obj;

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
