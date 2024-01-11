using BenchmarkDotNet.Attributes;

namespace ListFilteringListBenchmarking
{
    public class IntroArrayParam
    {
        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public int ArrayIndexOf(int[] array, int value)
            => Array.IndexOf(array, value);

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public int ManualIndexOf(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == value)
                    return i;

            return -1;
        }

        public IEnumerable<object[]> Data()
        {
            yield return new object[] { new int[] { 1, 2, 3 }, 4 };
            yield return new object[] { Enumerable.Range(0, 100).ToArray(), 4 };
            yield return new object[] { Enumerable.Range(0, 100).ToArray(), 101 };
        }

        [Benchmark]
        [ArgumentsSource(nameof(Numbers))]
        public double ManyArguments(double x, double y) => Math.Pow(x, y);

        public IEnumerable<object[]> Numbers() // for multiple arguments it's an IEnumerable of array of objects (object[])
        {
            yield return new object[] { 1.0, 1.0 };
            yield return new object[] { 2.0, 2.0 };
            yield return new object[] { 4.0, 4.0 };
            yield return new object[] { 10.0, 10.0 };
        }

        [Benchmark]
        [ArgumentsSource(nameof(TimeSpans))]
        public void SingleArgument(TimeSpan time) => Thread.Sleep(time);

        public IEnumerable<object> TimeSpans() // for single argument it's an IEnumerable of objects (object)
        {
            yield return TimeSpan.FromMilliseconds(10);
            yield return TimeSpan.FromMilliseconds(100);
        }
    }
}
