using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsConstraints
{
    class Program
    {
        static void Main(string[] args)
        {
            var biggestString = GenericDemo<string>.GetBiggerValue("b", "a");
            var biggestInt = GenericDemo<int>.GetBiggerValue(123, 456);

            //var doesNotWork = GenericDemo<char[]>.GetBiggerValue("a".ToCharArray, "b".ToCharArray());
            // this does not compile because char[] does not implement iComparable

            var compiles = GenericDemo2<HasParameterLessConstructor>.CreateNewInstance();
            var alsoCompiles = GenericDemo2<List<int>>.CreateNewInstance();
            var mustCompile = GenericDemo2<myClassWithParameterLessConstructor>.CreateNewInstance();
            //var doesNotCompile = GenericDemo2<DoesNotHaveParameterLessConstructor>.CreateNewInstance();
        }
    }

    public class GenericDemo<T> where T : IComparable<T>
    {
        public void Foo(T Value)
        {
            // what does the compiler know about value?
        }

        public static T GetBiggerValue(T value1, T value2)
        {
            if (value1.CompareTo(value2) >= 0) return value1;
            return value2;
        }
    }

    public class HasParameterLessConstructor
    {
        public HasParameterLessConstructor() { }
    }

    public class myClassWithParameterLessConstructor
    {
        public myClassWithParameterLessConstructor()
        {

        }
    }
    public class DoesNotHaveParameterLessConstructor
    {
        public DoesNotHaveParameterLessConstructor(int parameter1, string parameter2) { }
    }

    public class GenericDemo2<T> where T : new() // where T : new() means type T must not have a parameterless constructor
    {
        public static T CreateNewInstance()
        {
            var newInstance = new T();
            return newInstance;
        }
    }

    public class GenericDemo3<T> where T : class, IComparable<T> // 'class' means T must be a reference type
    {
        public static T GetBiggerValue(T value1, T value2)
        {
            if (value1.CompareTo(value2) >= 0) return value1;
            return value2;
        }
    }

    public class GenericDemo4<T> where T : struct, IComparable<T> // 'struct' means T must be a value type
    {
        public static T GetBiggerValue(T value1, T value2)
        {
            if (value1.CompareTo(value2) >= 0) return value1;
            return value2;
        }
    }


}
