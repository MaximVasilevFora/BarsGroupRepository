using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsGroupHW2Part2
{
    internal class Program
    {
        public class Entity
        {
            public int Id;
            public int ParentId;
            public string Name;
        }

        public static Dictionary<int, List<Entity>> SomeFunction(List<Entity> entities)
        { 
            var dictionary = new Dictionary<int, List<Entity>>();

            foreach (var item in entities)
            {
                if (dictionary.ContainsKey(item.ParentId))
                {
                    dictionary[item.ParentId].Add(item);
                }
                else
                {
                    dictionary.Add(item.ParentId, new List<Entity>());
                    dictionary[item.ParentId].Add(item);
                }            
            }

            return dictionary;
        }
        static void Main(string[] args)
        {
            Entity entityFirst = new Entity();
            entityFirst.Id = 1;
            entityFirst.Name = "RootEntity";
            entityFirst.ParentId = 0;
            Entity entitySecond = new Entity();
            entitySecond.Id = 2;
            entitySecond.Name = "Child of 1 entity";
            entitySecond.ParentId = 1;
            Entity entityThird = new Entity();
            entityThird.Id = 3;
            entityThird.Name = "Child of 1 entity";
            entityThird.ParentId = 1;
            Entity entityFourth = new Entity();
            entityFourth.Id = 4;
            entityFourth.Name = "Child of 2 entity";
            entityFourth.ParentId = 2;
            Entity entityFiveth = new Entity();
            entityFiveth.Id = 5;
            entityFiveth.Name = "Child of 4 entity";
            entityFiveth.ParentId = 4;

            List<Entity> list = new List<Entity>();
            list.Add(entityFirst);
            list.Add(entitySecond);
            list.Add(entityThird);
            list.Add(entityFourth);
            list.Add(entityFiveth);

            Dictionary<int, List<Entity>> dic = SomeFunction(list);
            foreach (var item in dic)
            {
                Console.WriteLine(item.Key);
                item.Value.ForEach(e => Console.WriteLine(e.Id + " " + e.ParentId + " " + e.Name));
            }
            Console.Read();
        }
    }
}
