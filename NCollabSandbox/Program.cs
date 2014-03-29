using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab;
using NCollab.Metrics;

namespace NCollabSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var customRecommendation = new CustomRecommendation(new Euclidian<Preference>());
            var users = customRecommendation.LoadData();
            var result = customRecommendation.GetRecomendations(users.First(c => c.Name == "Toby"), users.ToList());

            foreach (var item in result.ToList().OrderByDescending(c => c.Value))
            {
                Console.WriteLine("{0} {1}", item.Key.FilmName, item.Value);
            }
            var pref = users.First().Preferenceses.First();
            var invert = customRecommendation.GroupMainObjectsByPreference(users);
            Console.WriteLine("Film \"{0}\" watched by :", pref.FilmName);
            foreach (var item in invert[pref])
            {
                Console.WriteLine("{0} {1}", item.Name, item.Preferenceses.First(c => c.Equals(c, pref)).Rating);
            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
