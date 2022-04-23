using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Composite.Models
{
    public abstract class BookComposite : IComponent
    {
        private readonly List<IComponent> children;

        public string Name { get; }
        public virtual string Type => GetType().Name;
        protected abstract string HeadingTagName { get; }

        public BookComposite(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            children = new List<IComponent>();
        }

        public void Add(IComponent component)
        {
            children.Add(component);
        }

        public virtual int Count()
        {
            return children.Sum(x => x.Count());
        }

        public virtual string Display()
        {
            var sb = new StringBuilder();
            sb.Append("<section class=\"card\">");
            AppendHeader(sb);
            AppendBody(sb);
            AppendFooter(sb);
            sb.Append("</section>");
            return sb.ToString();
        }

        private void AppendFooter(StringBuilder sb)
        {
            sb.Append("<div class=\"card-footer text-muted\">");
            sb.Append($"<small class=\"text-muted text-right\">{Type}</small>");
            sb.Append("</div>");
        }

        private void AppendBody(StringBuilder sb)
        {
            sb.Append($"<ul class=\"list-group list-group-flush\">");
            children.ForEach(child =>
            {
                sb.Append($"<li class=\"list-group-item\">");
                sb.Append(child.Display());
                sb.Append("</li>");
            });
            sb.Append("</ul>");
        }

        private void AppendHeader(StringBuilder sb)
        {
            sb.Append($"<{HeadingTagName} class=\"card-header\">");
            sb.Append(Name);
            sb.Append($" - <span class=\"badge badge-secondary float-right\">{Count()} books</span>");
            sb.Append($"</{HeadingTagName}>");
        }

        public void Remove(IComponent component)
        {
            children.Remove(component);
        }
    }
}