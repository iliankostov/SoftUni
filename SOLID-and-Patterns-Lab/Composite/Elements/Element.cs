namespace Composite.Elements
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Element : ElementComponent
    {
        private IList<ElementComponent> children = new List<ElementComponent>();

        public Element(string type, params Element[] children)
            : base(type)
        {
            foreach (var child in children)
            {
                this.children.Add(child);
            }
        }

        public IEnumerable<ElementComponent> Children
        {
            get
            {
                return this.children;
            }
        }

        public override void Add(ElementComponent element)
        {
            if (element == null)
            {
                throw new NullReferenceException("Cannot add null element!");
            }

            this.children.Add(element);
        }

        public override void Remove(ElementComponent element)
        {
            if (element == null)
            {
                throw new NullReferenceException("Cannot remove null element!");
            }

            this.children.Remove(element);
        }

        public override string Display(int depth = 0)
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(new String(' ', depth) + string.Format("<{0}>", this.type));

            foreach (var child in children)
            {
                output.AppendLine(child.Display(depth + 4));
            }

            output.Append(new String(' ', depth) + string.Format("</{0}>", this.type));

            return output.ToString();
        }
    }
}
