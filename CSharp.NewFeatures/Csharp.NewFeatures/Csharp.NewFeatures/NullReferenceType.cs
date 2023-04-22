using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.NewFeatures
{
    public class NullReferenceType
    {
        public NullReferenceType()
        {
            
        }

        public void PrintBlogPosts(BlogPost post)
        {
            if (post?.Comments == null) return;



            foreach (var comment in post.Comments)
            {
                var commentPreview = comment?.Body is {Length: > 10}
                    ? $"{comment.Body[..10]}..."
                    : comment.Body;
            }
        }
    }


    public class BlogPost
    {
        public string? Title { get; set; }
        public List<Comment>? Comments { get; } = new List<Comment>();
    }

    public class Comment
    {
        public string? Body { get; set; }
        public string? PostedBy { get; set; }
    }

    public class Author
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
