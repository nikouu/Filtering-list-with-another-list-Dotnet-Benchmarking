# Filtering list with another list Dotnet Benchmarking
Benchmarking various ways to filter a list based on another list for both inclusive and exclusive cases. 

## How to run
1. Get the repo
1. In the same project as the solution run:
```
dotnet run --configuration Release --framework net8.0 --runtimes net8.0 --filter *
```

## Test scenarios

The scenarios have two lists, a larger main list of customers, and a smaller list of IDs. The list of IDs is what's used to filter the customer list. 

The test scenarios were found by searching the internet for ways developers have tried to filter. Credit at the bottom for where I found them.

### Inclusive filter
Where from the main list, we want only the values from the filtering list. 

For example if we had this customer list:
```csharp
var customerList = new List<Customer>
{
    new() { Id = 1 },
    new() { Id = 2 },
    new() { Id = 3 },
    new() { Id = 4 },
    new() { Id = 5 }
};

```

And we had another list which acted as what we wanted to select/filter:

```csharp
var inclusiveFilter = new List<int> { 1, 2, 3 };
```

Our result should be:
```
Customer Id: 1
Customer Id: 2
Customer Id: 3
```

### Exclusive filter
Where from the main list, we want only the values from not in filtering list. 

For example if we had this customer list:
```csharp
var customerList = new List<Customer>
{
    new() { Id = 1 },
    new() { Id = 2 },
    new() { Id = 3 },
    new() { Id = 4 },
    new() { Id = 5 }
};

```

And we had another list which acted as what we wanted to select/filter:

```csharp
var exclusiveFilter = new List<int> { 1, 2, 3 };
```

Our result should be:
```
Customer Id: 4
Customer Id: 5
```

### Dataset

The methods are tested against 9 datasets:

| Dataset                       | ID count | Customer count | Description                                                                               |
| ----------------------------- | -------: | -------------: | ----------------------------------------------------------------------------------------- |
| Simple case - small           |      100 |           1000 | A small volume of the case where there are less IDs than customers                        |
| Simple case - medium          |     1000 |          10000 | A medium volume of the case where there are less IDs than customers                       |
| Simple case - large           |    10000 |         100000 | A large volume of the case where there are less IDs than customers                        |
| Larger IDs case - small       |     1000 |            100 | A small volume of the case where there are more IDs than customers                        |
| Larger IDs case - medium      |    10000 |           1000 | A medium volume of the case where there are more IDs than customers                       |
| Larger IDs case - large       |   100000 |          10000 | A large volume of the case where there are more IDs than customers                        |
| Simple shuffled case - small  |      100 |           1000 | A small volume of the case where there are less IDs than customers but both are shuffled  |
| Simple shuffled case - medium |     1000 |          10000 | A medium volume of the case where there are less IDs than customers but both are shuffled |
| Simple shuffled case - large  |    10000 |         100000 | A large volume of the case where there are less IDs than customers but both are shuffled  |

### Other points
- The `Customer` type is a `record` to help facilitate the easier result checking via the  `ReturnValueValidator` attribute due to the tidy way `record` types handle equality.

## Results

Results are benchmarked against what I found to be one of the most common filtering methods.

There is an analysis below this Results section.

### Inclusive filter

Full results in [InclusiveFilterBenchmarks.md](data/InclusiveFilterBenchmarks.md) including:
1. Differing dataset sizes
1. The ID list being bigger than the customer list
1. Shuffed data

Code found in [InclusiveFilterBenchmarks.cs](/ListFilteringListBenchmarking/InclusiveFilterBenchmarks.cs).

### Exclusive filter

Full results in [ExclusiveFilterBenchmarks.md](data/ExclusiveFilterBenchmarks.md) including:
1. Differing dataset sizes
1. The ID list being bigger than the customer list
1. Shuffed data

Code found in [ExclusiveFilterBenchmarks.cs](/ListFilteringListBenchmarking/ExclusiveFilterBenchmarks.cs).

## Analysis

### Inclusive filter

Taking the top two performers (and baseline, `LinqContains`) for both speed and allocations in all categories. Some cases may have a more performant method but large allocations or vice versa:

| Method              | Dataset                       |    ids | customers |         Mean | **Ratio** | Allocated | **Alloc Ratio** |
| ------------------- | ----------------------------- | -----: | --------: | -----------: | --------: | --------: | --------------: |
| LinqContains        | Simple case - small           |    100 |      1000 |    13.875 us |      1.00 |    2.3 KB |            1.00 |
| LinqFindAllContains | Simple case - small           |    100 |      1000 |    10.871 us |      0.79 |   2.23 KB |            0.97 |
| BinarySearch        | Simple case - small           |    100 |      1000 |    12.257 us |      0.88 |    2.3 KB |            1.00 |
|                     |                               |        |           |              |           |           |                 |
| LinqContains        | Simple case - medium          |   1000 |     10000 |    690.76 us |      1.00 |  16.37 KB |            1.00 |
| LinqFindAllContains | Simple case - medium          |   1000 |     10000 |    807.61 us |      1.14 |   16.3 KB |            1.00 |
| BinarySearch        | Simple case - medium          |   1000 |     10000 |    168.30 us |      0.24 |  16.37 KB |            1.00 |
|                     |                               |        |           |              |           |           |                 |
| LinqContains        | Simple case - large           |  10000 |    100000 | 103,830.7 us |     1.000 | 256.54 KB |            1.00 |
| HashSetLinq         | Simple case - large           |  10000 |    100000 |     903.1 us |     0.009 |  414.5 KB |            1.62 |
| BinarySearch        | Simple case - large           |  10000 |    100000 |   2,294.1 us |     0.022 | 256.48 KB |            1.00 |
|                     |                               |        |           |              |           |           |                 |
| LinqContains        | Larger IDs case - small       |   1000 |       100 |     1.655 us |      1.00 |    2.3 KB |            1.00 |
| LinqFindAllContains | Larger IDs case - small       |   1000 |       100 |     1.391 us |      0.79 |   2.23 KB |            0.97 |
| BinarySearch        | Larger IDs case - small       |   1000 |       100 |     6.108 us |      0.90 |    2.3 KB |            1.00 |
|                     |                               |        |           |              |           |           |                 |
| LinqContains        | Larger IDs case - medium      |  10000 |      1000 |     51.25 us |      1.00 |  16.37 KB |            1.00 |
| LinqFindAllContains | Larger IDs case - medium      |  10000 |      1000 |     50.19 us |      0.99 |   16.3 KB |            1.00 |
| BinarySearch        | Larger IDs case - medium      |  10000 |      1000 |     91.82 us |      1.80 |  16.37 KB |            1.00 |
|                     |                               |        |           |              |           |           |                 |
| LinqContains        | Larger IDs case - large       | 100000 |     10000 |   4,314.1 us |      1.00 | 256.48 KB |            1.00 |
| LinqFindAllContains | Larger IDs case - large       | 100000 |     10000 |   4,256.4 us |      0.99 | 256.41 KB |            1.00 |
| BinarySearch        | Larger IDs case - large       | 100000 |     10000 |   1,127.8 us |      0.26 | 256.48 KB |            1.00 |
|                     |                               |        |           |              |           |           |                 |
| LinqContains        | Simple shuffled case - small  |    100 |      1000 |    14.922 us |      1.00 |    2.3 KB |            1.00 |
| LinqFindAllContains | Simple shuffled case - small  |    100 |      1000 |    11.804 us |      0.79 |   2.23 KB |            0.97 |
| BinarySearch        | Simple shuffled case - small  |    100 |      1000 |    13.418 us |      0.90 |    2.3 KB |            1.00 |
|                     |                               |        |           |              |           |           |                 |
| LinqContains        | Simple shuffled case - medium |   1000 |     10000 |     695.8 us |      1.00 |  16.37 KB |            1.00 |
| LinqFindAllContains | Simple shuffled case - medium |   1000 |     10000 |     807.9 us |      1.16 |   16.3 KB |            1.00 |
| BinarySearch        | Simple shuffled case - medium |   1000 |     10000 |     203.2 us |      0.29 |  16.37 KB |            1.00 |
|                     |                               |        |           |              |           |           |                 |
| LinqContains        | Simple shuffled case - large  |  10000 |    100000 |   111.992 ms |      1.00 | 256.54 KB |            1.00 |
| HashSetLinq         | Simple shuffled case - large  |  10000 |    100000 |     1.831 ms |      0.02 |  414.5 KB |            1.62 |
| BinarySearch        | Simple shuffled case - large  |  10000 |    100000 |     3.895 ms |      0.03 | 256.48 KB |            1.00 |

#### `LinqContains` ⭐

`LinqContains` is the baseline and is nearly always in the top 4. It is a performant, "normal", and an easy to understand piece of code - a solid workhorse.

```csharp
public List<Customer> LinqContains(List<int> ids, List<Customer> customers)
{
    return customers.Where(c => ids.Contains(c.Id)).ToList();
}
```

#### `LinqFindAllContains`

`LinqFindAllContains` tends to be very close in performance to `LinqContains`, even beating it out on some smaller datasets. Also a solid everyday choice.

```csharp
public List<Customer> LinqFindAllContains(List<int> ids, List<Customer> customers)
{
    return customers.FindAll(c => ids.Contains(c.Id));
}
```

#### `BinarySearch`
From research it doesn't seem commonly used, however it is always top 3 for the critera nearly always beating the baseline and sometimes by an incredible margin.

```csharp
public List<Customer> BinarySearch(List<int> ids, List<Customer> customers)
{
    ids.Sort();
    return customers.Where(c => ids.BinarySearch(c.Id) >= 0).ToList();
}
```

#### `HashSetLinq`

While allocations for `HashSetLinq` are often higher than the other top performers (still small enough when compared to the rest of the field), it easily outperforms for large datasets. I believe due to the `O(1)` lookup speed for large datasets - even if we have to take the cost of converting the ID list into a `HashSet`. 

```csharp
public List<Customer> HashSetLinq(List<int> ids, List<Customer> customers)
{
    var idSet = new HashSet<int>(ids);
    return customers.Where(c => idSet.Contains(c.Id)).ToList();
}
```

#### Avoid using `.Any()` and Linq `join`

`.Any()` is nearly always the worst performing and is entirely outclasses by using `.Contains()` inside the `Where()` predicate. Linq `join` sometimes does okay, but it's not worth it when easier, more performant and less unusual methods exist.

### Exclusive filter

Taking the top two performers (and baseline, `RemoveAllContains`) for both speed and allocations in all categories. Some cases may have a more performant method but large allocations or vice versa:


| Method              | Dataset                       |    ids | customers |          Mean | **Ratio** | Allocated | **Alloc Ratio** |
| ------------------- | ----------------------------- | -----: | --------: | ------------: | --------: | --------: | --------------: |
| RemoveAllContains   | Simple case - small           |    100 |      1000 |      9.721 us |      1.00 |      88 B |            1.00 |
| HashSetLinq         | Simple case - small           |    100 |      1000 |     10.146 us |      1.05 |   18632 B |          211.73 |
| BinarySearch        | Simple case - small           |    100 |      1000 |      9.452 us |      0.97 |      88 B |            1.00 |
|                     |                               |        |           |               |           |           |                 |
| RemoveAllContains   | Simple case - medium          |   1000 |     10000 |      771.8 us |      1.00 |      88 B |            1.00 |
| HashSetLinq         | Simple case - medium          |   1000 |     10000 |      142.4 us |      0.19 |  280438 B |        3,186.80 |
| BinarySearch        | Simple case - medium          |   1000 |     10000 |      117.5 us |      0.15 |      88 B |            1.00 |
|                     |                               |        |           |               |           |           |                 |
| RemoveAllContains   | Simple case - large           |  10000 |    100000 |     99.564 ms |      1.00 |     155 B |            1.00 |
| HashSetLinq         | Simple case - large           |  10000 |    100000 |      1.228 ms |      0.01 | 2261241 B |       14,588.65 |
| BinarySearch        | Simple case - large           |  10000 |    100000 |      1.614 ms |      0.02 |      89 B |            0.57 |
|                     |                               |        |           |               |           |           |                 |
| RemoveAllAny        | Larger IDs case - small       |   1000 |       100 |      9.820 ns |      0.94 |      88 B |            1.00 |
| RemoveAllContains   | Larger IDs case - small       |   1000 |       100 |     10.454 ns |      1.00 |      88 B |            1.00 |
| LinqFindAllContains | Larger IDs case - small       |   1000 |       100 |    975.455 ns |     92.84 |     120 B |            1.36 |
|                     |                               |        |           |               |           |           |                 |
| RemoveAllAny        | Larger IDs case - medium      |  10000 |      1000 |      11.51 ns |      1.00 |      88 B |            1.00 |
| RemoveAllContains   | Larger IDs case - medium      |  10000 |      1000 |      11.83 ns |      1.00 |      88 B |            1.00 |
| BinarySearch        | Larger IDs case - medium      |  10000 |      1000 |  44,818.63 ns |  3,874.69 |      88 B |            1.00 |
|                     |                               |        |           |               |           |           |                 |
| RemoveAllAny        | Larger IDs case - large       | 100000 |     10000 |      14.56 ns |      1.28 |      88 B |            1.00 |
| RemoveAllContains   | Larger IDs case - large       | 100000 |     10000 |      11.44 ns |      1.00 |      88 B |            1.00 |
| BinarySearch        | Larger IDs case - large       | 100000 |     10000 | 495,794.52 ns | 44,435.94 |      88 B |            1.00 |
|                     |                               |        |           |               |           |           |                 |
| RemoveAllContains   | Simple shuffled case - small  |    100 |      1000 |      9.706 us |      1.00 |      88 B |            1.00 |
| LinqFindAllContains | Simple shuffled case - small  |    100 |      1000 |     15.892 us |      1.64 |   16688 B |          189.64 |
| BinarySearch        | Simple shuffled case - small  |    100 |      1000 |      9.322 us |      0.95 |      88 B |            1.00 |
|                     |                               |        |           |               |           |           |                 |
| RemoveAllContains   | Simple shuffled case - medium |   1000 |     10000 |      784.9 us |      1.00 |      88 B |            1.00 |
| LinqContains        | Simple shuffled case - medium |   1000 |     10000 |      814.1 us |      1.04 |  262630 B |        2,984.43 |
| BinarySearch        | Simple shuffled case - medium |   1000 |     10000 |      124.7 us |      0.16 |      88 B |            1.00 |
|                     |                               |        |           |               |           |           |                 |
| RemoveAllContains   | Simple shuffled case - large  |  10000 |    100000 |    105.250 ms |      1.00 |     168 B |            1.00 |
| HashSetLinq         | Simple shuffled case - large  |  10000 |    100000 |      2.661 ms |      0.03 | 2260480 B |       13,455.24 |
| BinarySearch        | Simple shuffled case - large  |  10000 |    100000 |      2.492 ms |      0.02 |      90 B |            0.54 |

#### `RemoveAllContains` ⭐

The baseline and best overall utility. A great choice for all cases. 

```csharp
public List<Customer> RemoveAllContains(List<int> ids, List<Customer> customers)
{
    customers.RemoveAll(c => ids.Contains(c.Id));
    return customers;
}
```

#### `BinarySearch`

Always in the top 3. Extremely performant when the ID list is small regardless of the customer list size.

```csharp
public List<Customer> BinarySearch(List<int> ids, List<Customer> customers)
{
    ids.Sort();
    customers.RemoveAll(c => ids.BinarySearch(c.Id) >= 0);

    return customers;
}
```

#### `HashSetLinq`

Higher allocations but can be extremely performant in the right scenarios.

```csharp
public List<Customer> HashSetLinq(List<int> ids, List<Customer> customers)
{
    var idSet = new HashSet<int>(ids);
    return customers.Where(c => !idSet.Contains(c.Id)).ToList();
}
```

#### `RemoveAllAny`

Performant in the cases where the ID list is large.

```csharp
public List<Customer> RemoveAllAny(List<int> ids, List<Customer> customers)
{
    customers.RemoveAll(c => ids.Any(i => i == c.Id));
    return customers;
}
```

#### `LinqContains`

Made it in only because the others are worse.

```csharp
public List<Customer> LinqContains(List<int> ids, List<Customer> customers)
{
    return customers.Where(c => !ids.Contains(c.Id)).ToList();
}
```

## References

Not every filter will have a link as I've picked up how to do some of these anyway, and some are just the inverse.

### Inclusive filter

| Method              | Link                                                                                                               |
| ------------------- | ------------------------------------------------------------------------------------------------------------------ |
| LinqAny             | [link](https://stackoverflow.com/a/41929414)                                                                      |
| LinqContains        | [link](https://stackoverflow.com/a/61484703)                                                                       |
| LinqJoin            | [link](https://dotnetable.wordpress.com/2015/06/20/find-all-items-in-list-which-exist-in-another-list-using-linq/) |
| HashSetLinq         | [link](https://stackoverflow.com/a/32013973)                                                                       |

### Exclusive filter

| Method              | Link                                                                                     |
| ------------------- | ---------------------------------------------------------------------------------------- |
| LinqExceptBy        | [link](https://stackoverflow.com/a/75409994)                                             |
| LinqAny             | [link](https://stackoverflow.com/a/18977915)                                             |
| LinqContains        | [link](https://stackoverflow.com/a/15540930)                                             |
| LinqFindAllContains | [link](https://copyprogramming.com/howto/csharp-linq-filter-list-of-lists-code-example)] |
| ForRemoveAt         | [link](https://stackoverflow.com/a/1582317)                                              |
| BinarySearch        | [link](https://stackoverflow.com/a/15541014)                                             |

## Notes

- A `List` datatype is used for the collections.
- The `Customer` is a `record` because early on I was using `ReturnValueValidator` to ensure everything was as expected as being a `record` allowed `ReturnValueValidator` to make the correct checks. However after moving to `ArgumentsSource` I was no longer able to use `ReturnValueValidator` but kept it as a `record`. After checking with _Simple shuffled case - large_ with `Customer` as a `class` there seems to be no difference in performance.
- The ids and customer columns in the benchmark tables have been edited. Due to how BenchmarkDotnet works, the representation of the datasets ended up being `Syste(...)nt32] [47]` and `Syste(...)omer] [73]` respectively.
- This does not use [`.Except()`](https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.except?view=net-8.0) as that needs both lists to be the same datatype.