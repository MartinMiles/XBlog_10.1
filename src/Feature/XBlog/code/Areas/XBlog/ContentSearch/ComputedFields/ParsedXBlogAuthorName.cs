using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Feature.XBlog.Areas.XBlog.Models.Blog;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Feature.XBlog.Areas.XBlog.Items.Blog;

namespace Sitecore.Feature.XBlog.Areas.XBlog.ContentSearch.ComputedFields
{
    public class ParsedXBlogAuthorName : IComputedIndexField
    {
        public object ComputeFieldValue(IIndexable indexable)
        {
            Item item = (Item)(indexable as SitecoreIndexableItem);
            List<string> list = new List<string>();
            if (item.IsValidType<BlogPost>())
            {
                List<Author> authorItems = item.CreateAs<BlogPost>().Authors.ToList();
                if (authorItems.Any())
                {
                    authorItems.ForEach(tItem =>
                    {
                        if (tItem != null)
                            list.Add(tItem.InnerItem.Name);
                    });
                }
            }
            return list;

        }

        public string FieldName
        {
            get;
            set;
        }

        public string ReturnType
        {
            get;
            set;
        }
    }
}
