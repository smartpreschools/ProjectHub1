using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ProjectHub.DataSecurity
{
    public class CrossSiteScripting
    {
        #region Scripting  data content on model
        /// <summary>
        /// Method: SafeContentCheckOnModel
        /// Description:Check input data is safe for stroring the database 
        /// Created By :Sourabh Raut
        /// Created On : 15-03-2021
        /// </summary>
        /// <returns>generic model</returns>
        public T SafeContentCheckOnModel<T>(T model)
        {
            Type type = model.GetType();
            PropertyInfo[] props = type.GetProperties();
            foreach (var prop in props)
            {
                if (prop.PropertyType.FullName.ToUpper() == "System.string".ToUpper())
                {
                    var safeValue = Sanitizer.GetSafeHtmlFragment(Convert.ToString(prop.GetValue(model)));
                    prop.SetValue(model, safeValue);
                }
            }
            return model;
        }

        #endregion

        #region Scripting  data content on Parameter
        /// <summary>
        /// Method: SafeContentCheckOnModel
        /// Description:Check input data is safe for storeing the database 
        /// Created By :Sourabh Raut
        /// Created On : 15-03-2021
        /// </summary>
        /// <returns>generic model</returns>
        public string SafeContentCheckOnParameter(string inputValue)
        {
            inputValue = Sanitizer.GetSafeHtmlFragment(inputValue);
            return inputValue;
        }

        #endregion
    }
}
