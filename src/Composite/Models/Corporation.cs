using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Composite.Models
{
    public class Corporation
    {
        private readonly List<Corporation> children;

        public string Name { get; }
        public string Type => GetType().Name;

        public Corporation(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            children = new List<Corporation>();
        }

        public void Add(Corporation component)
        {
            children.Add(component);
        }

        public virtual int Count()
        {
            return children.Sum(x => x.Count());
        }

        public void Remove(Corporation component)
        {
            children.Remove(component);
        }

        public virtual string Display()
        {
            var sb = new StringBuilder();
            sb.Append("<section class=\"card\">");

            sb.Append($"<h1 class=\"card-header\">");
            sb.Append(Name);
            sb.Append($"<span class=\"badge badge-secondary float-right\">{Count()} books</span>");
            sb.Append($"</h1>");

            sb.Append($"<ul class=\"list-group list-group-flush\">");
            children.ForEach(child =>
            {
                sb.Append($"<li class=\"list-group-item\">");
                sb.Append(child.Display());
                sb.Append("</li>");
            });
            sb.Append("</ul>");

            sb.Append("<div class=\"card-footer text-muted\">");
            sb.Append($"<small class=\"text-muted text-right\">{Type}</small>");
            sb.Append("</div>");

            sb.Append("</section>");

            return sb.ToString();
        }
    }
}
