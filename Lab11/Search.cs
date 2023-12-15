using System.Diagnostics;

namespace Lab11
{
    public class Search
    {
        public static (bool status, long time) SearchInStack<T>(Stack<T> stack, T value)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            var result = stack.Contains(value);
            stopwatch.Stop();
            return (result, stopwatch.Elapsed.Ticks);
        }

        public static (bool status, long time) SearchInDictionaryByKey<TKey, TValue>(
            SortedDictionary<TKey, TValue> dictionary,
            TKey key
        ) where TKey : notnull
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            var result = dictionary.ContainsKey(key);
            stopwatch.Stop();
            return (result, stopwatch.Elapsed.Ticks);
        }

        public static (bool status, long time) SearchInDictionaryByValue<TKey, TValue>(
            SortedDictionary<TKey, TValue> dictionary,
            TValue value
        ) where TKey : notnull
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            var result = dictionary.ContainsValue(value);
            stopwatch.Stop();
            return (result, stopwatch.Elapsed.Ticks);
        }
    }
}