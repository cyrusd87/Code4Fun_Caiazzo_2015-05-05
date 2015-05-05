using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code4Fun.Model;
using KellermanSoftware.CompareNetObjects;

namespace Code4FunTest.Utilities
{
    public static class ComparisonExtensions
    {
        public static bool CompareTo(this ITsvFile first, ITsvFile second)
        {
            var compareLogic = new CompareLogic(new ComparisonConfig {IgnoreObjectTypes = true, CompareStaticProperties = false});
            var result = compareLogic.Compare(first, second);

            if (!result.AreEqual)
                Console.WriteLine(result.DifferencesString);

            return result.AreEqual;
        }
        
    }
}
