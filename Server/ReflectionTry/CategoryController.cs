using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectionTry
{
    public class CategoryController : Data
    {
        public CategoryController(Assembly asm)
        {
            Id = asm.FullName;
            var categories = new Dictionary<string, List<Data>>();
            foreach (Type type in asm.GetTypes())
            {
                var category = GetCategory(type);
                AddCategory(categories, category, type);
            }
            _categories = new List<Category>();
            foreach (var category in categories)
            {
                _categories.Add(new Category(category.Value, category.Key));
            }
        }

        private void AddCategory(Dictionary<string, List<Data>> categories, string name, Type type)
        {
            if (!categories.ContainsKey(name))
            {
                categories[name] = new List<Data>();
            }
            categories[name].Add(new ClassData(true, type));
        }

        private string GetCategory(Type type)
        {
            var nameattr = type.GetCustomAttributes().OfType<TestUICategory>().FirstOrDefault();
            return (nameattr == null) ? "Default" : nameattr.Name;
        }

        public override string Id { get; protected set; }
        public override string Name => "Start";
        private readonly List<Category> _categories;
        public override IEnumerable<Data> GetContinue()
        {
            return _categories;
        }
        

        public override Data ResultType => new NoData();
        public override bool CanContinue => true;
        public override bool CanEnd => false;
        public override string GiveCode(bool isEnd) => "";
    }
}
