using System.Collections.Generic;

namespace PowerDocu.Common
{
    public class ControlEntity
    {
        public string ID;
        public string Name;
        public string Type;
        public List<Expression> Properties = new List<Expression>();
        public List<ControlEntity> Children = new List<ControlEntity>();
        public List<Rule> Rules = new List<Rule>();
        public ControlEntity Parent;
        public ControlEntity()
        {
        }

        public ControlEntity Screen()
        {
            if (this.Type == "screen") return this;
            if (Parent != null) return Parent.Screen();
            return null;
        }

        public static List<ControlEntity> getAllChildControls(ControlEntity control)
        {
            List<ControlEntity> childControls = new List<ControlEntity>();
            foreach (ControlEntity childControl in control.Children)
            {
                childControls.Add(childControl);
                childControls.AddRange(getAllChildControls(childControl));
            }
            return childControls;
        }
    }

    public class Rule
    {
        public string Property;
        public string Category;
        public string InvariantScript;
        public string RuleProviderType;
        public string NameMap;
    }
}