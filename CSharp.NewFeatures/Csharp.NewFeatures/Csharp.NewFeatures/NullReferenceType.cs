using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.NewFeatures
{
    public class NullReferenceType
    {
        public NullReferenceType()
        {
            
        }
    }


    public class BlogPost
    {
        public string Title { get; set; }
        public List<Comment> Comments{ get; set; }
    }

    public class Comment
    {
        public string Body { get; set; }
        public string PostedBy { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
