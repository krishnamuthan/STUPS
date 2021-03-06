﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/3/2013
 * Time: 12:52 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System.Collections.Generic;

    /// <summary>
    /// Description of Util.
    /// </summary>
    public static class Util
    {
        static Util()
        {
        }
        
        public static List<T> AsList<T>(this IEnumerable<object> collection)
        /*
        public static System.Collections.Generic.List<T> AsList<T>(this System.Collections.ObjectModel.Collection<object> collection)
        */
        {
            List<T> resultList =
                new List<T>(); //collection);

            foreach (object element in collection) {

                resultList.Add((T)element);

            }

            return resultList;
        }
        
        public static T[] AsArray<T>(this System.Collections.ObjectModel.Collection<object> collection)
        {
            List<T> resultList =
                new List<T>(); //collection);
            
            return resultList.ToArray();
        }
    }
}
