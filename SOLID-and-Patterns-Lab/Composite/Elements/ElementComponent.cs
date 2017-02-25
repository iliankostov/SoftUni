namespace Composite.Elements
{
    using System.Collections;

    public abstract class ElementComponent
    {
        protected string type;

        protected ElementComponent(string type)
        {
            this.type = type;
        }

        public abstract void Add(ElementComponent element);

        public abstract void Remove(ElementComponent element);

        public abstract string Display(int depth = 0);

    }
}
