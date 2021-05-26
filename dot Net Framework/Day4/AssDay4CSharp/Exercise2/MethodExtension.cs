using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise2_3_4_5
{
    public static class MethodExtension
    {
        public static List<T> Append<T>(this List<T> a, List<T> b)
        {
            var newList = new List<T>(a);
            newList.AddRange(b);
            return newList;
        }
        public static bool Compare(this Customer customer1, Customer customer2)
        {
            if (customer1.CustomerID == customer2.CustomerID &&
                customer1.Name == customer2.Name &&
                customer1.City == customer2.City)
            {
                return true;
            }

            return false;
        }
        public static List<K> FilterBy<K, V>(this Dictionary<K, V> items,KeyValueFilter<K, V> filter)
        {
            var result = new List<K>();

            foreach (KeyValuePair<K, V> element in items)
            {
                if (filter(element.Key, element.Value))
                    result.Add(element.Key);
            }
            return result;
        }


        public delegate bool KeyValueFilter<K, V>(K key, V value);
    }
}
