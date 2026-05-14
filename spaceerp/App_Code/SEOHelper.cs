using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for SEOHelper
/// </summary>
public partial class SEOHelper
{
    #region Methods
    /// <summary>
    /// Renders page meta tag
    /// </summary>
    /// <param name="page">Page instance</param>
    /// <param name="name">Meta name</param>
    /// <param name="content">Content</param>
    /// <param name="overwriteExisting">Overwrite existing content if exists</param>
    public static void RenderMetaTag(Page page, string name,
        string content, bool overwriteExisting)
    {
        if (page == null || page.Header == null)
            return;

        if (content == null)
            content = string.Empty;

        foreach (var control in page.Header.Controls)
            if (control is HtmlMeta)
            {
                var meta = (HtmlMeta)control;
                if (meta.Name.ToLower().Equals(name.ToLower()) && !string.IsNullOrEmpty(content))
                {
                    if (overwriteExisting)
                        meta.Content = content;
                    else
                    {
                        if (String.IsNullOrEmpty(meta.Content))
                            meta.Content = content;
                    }
                }
            }
    }

  
   

    #endregion
}