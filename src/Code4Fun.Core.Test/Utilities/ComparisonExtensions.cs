using System;
using Code4Fun.Core.Model;
using KellermanSoftware.CompareNetObjects;

namespace Code4Fun.Core.Test.Utilities
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
