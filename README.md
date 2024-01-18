# Filtering list with another list Dotnet Benchmarking
Benchmarking various ways to filter a list based on another list for both inclusive and exclusive cases. 

## How to run
1. Get the repo
1. Uncomment the data you want to use in the `Data()` function in either benchmark file
1. In the same project as the solution run either:
```
dotnet run --configuration Release --framework net8.0 --runtimes net8.0 --filter *InclusiveFilterBenchmarks*
dotnet run --configuration Release --framework net8.0 --runtimes net8.0 --filter *ExclusiveFilterBenchmarks*
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

The code for the inclusive benchmark scenarios can be found in [InclusiveFilterBenchmarks.cs](/ListFilteringListBenchmarking/InclusiveFilterBenchmarks.cs).

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

The code for the exclusive benchmark scenarios can be found in [ExclusiveFilterBenchmarks.cs](/ListFilteringListBenchmarking/ExclusiveFilterBenchmarks.cs).

### Dataset

The methods are tested against 9 datasets:

| Dataset                       | Abbrev | ID count | Customer count | Description                                                                               |
| ----------------------------- | ------ | -------: | -------------: | ----------------------------------------------------------------------------------------- |
| Simple case - small           | sc-s   |      100 |           1000 | A small volume of the case where there are less IDs than customers                        |
| Simple case - medium          | sc-m   |     1000 |          10000 | A medium volume of the case where there are less IDs than customers                       |
| Simple case - large           | sc-l   |    10000 |         100000 | A large volume of the case where there are less IDs than customers                        |
| Larger IDs case - small       | lic-s  |     1000 |            100 | A small volume of the case where there are more IDs than customers                        |
| Larger IDs case - medium      | lic-m  |    10000 |           1000 | A medium volume of the case where there are more IDs than customers                       |
| Larger IDs case - large       | lic-l  |   100000 |          10000 | A large volume of the case where there are more IDs than customers                        |
| Simple shuffled case - small  | ssc-s  |      100 |           1000 | A small volume of the case where there are less IDs than customers but both are shuffled  |
| Simple shuffled case - medium | ssc-m  |     1000 |          10000 | A medium volume of the case where there are less IDs than customers but both are shuffled |
| Simple shuffled case - large  | ssc-l  |    10000 |         100000 | A large volume of the case where there are less IDs than customers but both are shuffled  |

### Other points
- The `Customer` type is a `record` to help facilitate the easier result checking via the  `ReturnValueValidator` attribute due to the tidy way `record` types handle equality.

## Results

Results are benchmarked against what I found to be one of the most common filtering methods.

As the data is large, you can find the results in their own files:
- [InclusiveFilterBenchmarks.md](data/InclusiveFilterBenchmarks.md)
- [ExclusiveFilterBenchmarks.md](data/ExclusiveFilterBenchmarks.md)

## Analysis

### Inclusive filter

Taking the top two performers (and baseline, `Where_Contains`) for both speed and allocations in all categories. Some cases may have a more performant method but large allocations or vice versa:



| Method                   | Dataset |         Mean | **Ratio** | Allocated | **Alloc Ratio** |
| ------------------------ | ------- | -----------: | --------: | --------: | --------------: |
| Where_Contains           | sc-s    |    12.417 us |      1.00 |    2.3 KB |            1.00 |
| FindAll_Contains         | sc-s    |    10.345 us |      0.83 |   2.23 KB |            0.97 |
| FindAll_BinarySearch     | sc-s    |    11.618 us |      0.94 |   2.23 KB |            0.97 |
|                          |         |              |           |           |                 |
| Where_Contains           | sc-m    |    813.29 us |      1.00 |  16.37 KB |            1.00 |
| Where_BinarySearch       | sc-m    |    163.59 us |      0.20 |  16.37 KB |            1.00 |
| FindAll_BinarySearch     | sc-m    |    163.38 us |      0.20 |   16.3 KB |            1.00 |
|                          |         |              |           |           |                 |
| Where_Contains           | sc-l    | 103,707.2 us |     1.000 | 256.54 KB |            1.00 |
| HashSet_Where_Contains   | sc-l    |     907.3 us |     0.009 |  414.5 KB |            1.62 |
| HashSet_FindAll_Contains | sc-l    |     815.9 us |     0.008 | 414.43 KB |            1.62 |
|                          |         |              |           |           |                 |
| Where_Contains           | lic-s   |     1.483 us |      1.00 |    2.3 KB |            1.00 |
| FindAll_Contains         | lic-s   |     1.308 us |      0.89 |   2.23 KB |            0.97 |
| FindAll_BinarySearch     | lic-s   |     6.037 us |      4.06 |   2.23 KB |            0.97 |
|                          |         |              |           |           |                 |
| Where_Contains           | lic-m   |     50.74 us |      1.00 |  16.37 KB |            1.00 |
| FindAll_Contains         | lic-m   |     50.15 us |      0.99 |   16.3 KB |            1.00 |
| Where_BinarySearch       | lic-m   |     90.35 us |      1.78 |  16.37 KB |            1.00 |
|                          |         |              |           |           |                 |
| Where_Contains           | lic-l   |   4,358.1 us |      1.00 | 256.48 KB |            1.00 |
| Where_BinarySearch       | lic-l   |   1,081.8 us |      0.24 | 256.48 KB |            1.00 |
| FindAll_BinarySearch     | lic-l   |   1,103.9 us |      0.25 | 256.41 KB |            1.00 |
|                          |         |              |           |           |                 |
| Where_Contains           | ssc-s   |    14.850 us |      1.00 |    2.3 KB |            1.00 |
| FindAll_Contains         | ssc-s   |    11.342 us |      0.76 |   2.23 KB |            0.97 |
| FindAll_BinarySearch     | ssc-s   |    13.286 us |      0.90 |   2.23 KB |            0.97 |
|                          |         |              |           |           |                 |
| Where_Contains           | ssc-m   |    837.87 us |      1.00 |  16.37 KB |            1.00 |
| HashSet_FindAll_Contains | ssc-m   |     92.02 us |      0.11 |  33.69 KB |            2.06 |
| FindAll_BinarySearch     | ssc-m   |    185.69 us |      0.22 |   16.3 KB |            1.00 |
|                          |         |              |           |           |                 |
| Where_Contains           | ssc-l   |   112.498 ms |      1.00 | 256.56 KB |            1.00 |
| HashSet_Where_Contains   | ssc-l   |     1.607 ms |      0.01 |  414.5 KB |            1.62 |
| HashSet_FindAll_Contains | ssc-l   |     1.524 ms |      0.01 | 414.43 KB |            1.62 |

#### `Where_Contains` and `FindAll_Contains`⭐

`Where_Contains` is the baseline and is nearly always in the top 4. It is a performant, "normal", and an easy to understand piece of code - a solid workhorse. Similarly `FindAll_Contains` is very close in performance, sometimes beating `Where_Contains` in speed and allocations.

```csharp
public List<Customer> Where_Contains(List<int> ids, List<Customer> customers)
{
    return customers.Where(c => ids.Contains(c.Id)).ToList();
}
```

#### `FindAll_BinarySearch` and `Where_BinarySearch`
From research it doesn't seem commonly used, however using `BinarySearch` is always top 3 for the critera nearly always beating the baseline and sometimes by an incredible margin.

```csharp
public List<Customer> FindAll_BinarySearch(List<int> ids, List<Customer> customers)
{
    ids.Sort();
    return customers.FindAll(c => ids.BinarySearch(c.Id) >= 0);
}

public List<Customer> Where_BinarySearch(List<int> ids, List<Customer> customers)
{
    ids.Sort();
    return customers.Where(c => ids.BinarySearch(c.Id) >= 0).ToList();
}
```

#### `HashSet_Where_Contains` and `HashSet_FindAll_Contains`

While allocations for the `HashSet` duo are often higher than the other top performers (still small enough when compared to the rest of the field), they easily outperform for large datasets. I believe due to the `O(1)` lookup speed for large datasets - even if we have to take the cost of converting the ID list into a `HashSet`. 

```csharp
public List<Customer> HashSet_Where_Contains(List<int> ids, List<Customer> customers)
{
    var idSet = new HashSet<int>(ids);
    return customers.Where(c => idSet.Contains(c.Id)).ToList();
}

public List<Customer> HashSet_FindAll_Contains(List<int> ids, List<Customer> customers)
{
    var idSet = new HashSet<int>(ids);
    return customers.FindAll(c => idSet.Contains(c.Id));
}
```

#### Avoid using `.Any()` and Linq `join`

`.Any()` is nearly always the worst performing and is entirely outclassed by using `.Contains()` inside the `Where()` predicate. Linq `join` sometimes does okay, but it's not worth it when easier, more performant and less unusual methods exist.

### Exclusive filter

Taking the top two performers (and baseline, `RemoveAll_Contains`) for both speed and allocations in all categories. Some cases may have a more performant method but large allocations or vice versa:

| Method                     | Dataset |          Mean | **Ratio** | Allocated | **Alloc Ratio** |
| -------------------------- | ------- | ------------: | --------: | --------: | --------------: |
| RemoveAll_Contains         | sc-s    |      9.418 us |      1.00 |      88 B |            1.00 |
| HashSet_RemoveAll_Contains | sc-s    |      5.367 us |      0.57 |    1960 B |           22.27 |
| RemoveAll_BinarySearch     | sc-s    |      9.344 us |      1.00 |      88 B |            1.00 |
|                            |         |               |           |           |                 |
| RemoveAll_Contains         | sc-m    |     755.26 us |      1.00 |      88 B |            1.00 |
| HashSet_RemoveAll_Contains | sc-m    |      52.25 us |      0.07 |   17896 B |          203.36 |
| RemoveAll_BinarySearch     | sc-m    |     118.02 us |      0.16 |      88 B |            1.00 |
|                            |         |               |           |           |                 |
| RemoveAll_Contains         | sc-l    |   81,210.8 us |     1.000 |     145 B |            1.00 |
| HashSet_RemoveAll_Contains | sc-l    |      647.3 us |     0.008 |  161909 B |        1,116.61 |
| RemoveAll_BinarySearch     | sc-l    |    1,564.6 us |     0.019 |      89 B |            0.61 |
|                            |         |               |           |           |                 |
| RemoveAll_Any              | lic-s   |      12.18 ns |      1.05 |      88 B |            1.00 |
| RemoveAll_Contains         | lic-s   |      11.69 ns |      1.00 |      88 B |            1.00 |
| FindAll_Contains           | lic-s   |     947.80 ns |     82.01 |     120 B |            1.36 |
|                            |         |               |           |           |                 |
| RemoveAll_Any              | lic-m   |      11.54 ns |      0.96 |      88 B |            1.00 |
| RemoveAll_Contains         | lic-m   |      12.01 ns |      1.00 |      88 B |            1.00 |
| RemoveAll_BinarySearch     | lic-m   |  44,010.89 ns |  3,579.00 |      88 B |            1.00 |
|                            |         |               |           |           |                 |
| RemoveAll_Any              | lic-l   |      14.14 ns |      1.28 |      88 B |            1.00 |
| RemoveAll_Contains         | lic-l   |      11.02 ns |      1.00 |      88 B |            1.00 |
| RemoveAll_BinarySearch     | lic-l   | 493,290.26 ns | 44,890.50 |      88 B |            1.00 |
|                            |         |               |           |           |                 |
| RemoveAll_Contains         | ssc-s   |      9.714 us |      1.00 |      88 B |            1.00 |
| HashSet_RemoveAll_Contains | ssc-s   |      5.850 us |      0.60 |    1960 B |           22.27 |
| RemoveAll_BinarySearch     | ssc-s   |      9.138 us |      0.94 |      88 B |            1.00 |
|                            |         |               |           |           |                 |
| RemoveAll_Contains         | ssc-m   |     636.78 us |      1.00 |      88 B |            1.00 |
| HashSet_RemoveAll_Contains | ssc-m   |      68.90 us |      0.11 |   17896 B |          203.36 |
| RemoveAll_BinarySearch     | ssc-m   |     122.05 us |      0.19 |      88 B |            1.00 |
|                            |         |               |           |           |                 |
| RemoveAll_Contains         | ssc-l   |     87.107 ms |      1.00 |     155 B |            1.00 |
| HashSet_RemoveAll_Contains | ssc-l   |      1.222 ms |      0.01 |  161909 B |        1,044.57 |
| RemoveAll_BinarySearch     | ssc-l   |      2.205 ms |      0.03 |      90 B |            0.58 |

#### `RemoveAll_Contains` ⭐

The baseline and best overall utility. A decent choice for all cases when compared to the other options. `RemoveAll_Contains` has very similar performance. Overall, `RemoveAll()` works very well when paired with a fast way to work out which ID to pick up.

```csharp
public List<Customer> RemoveAll_Contains(List<int> ids, List<Customer> customers)
{
    customers.RemoveAll(c => ids.Contains(c.Id));
    return customers;
}
```

#### `HashSet_RemoveAll_Contains` 

Always extremely performant when compared to the baseline, often performing the action in ~1% of the baseline time. If you require performance, it's worth looking into how a `HashSet` can improve your scenario.

```csharp
public List<Customer> HashSet_RemoveAll_Contains(List<int> ids, List<Customer> customers)
{
    var idSet = new HashSet<int>(ids);
    customers.RemoveAll(c => idSet.Contains(c.Id));

    return customers;
}
```

#### `RemoveAll_BinarySearch` 

Anather extremely performant runner up, often performing similar to `HashSet_RemoveAll_Contains` without the allocation.. The advantage this has over the hashset examples is this will often run at the lowest allocations out of all the scenarios tested.

```csharp
public List<Customer> RemoveAll_BinarySearch(List<int> ids, List<Customer> customers)
{
    ids.Sort();
    customers.RemoveAll(c => ids.BinarySearch(c.Id) >= 0);

    return customers;
}
```

#### Avoid using `.Any()` and Linq `join`

`.Any()` is nearly always the worst performing and is entirely outclasses by using `.Contains()` inside the `Where()` predicate. Linq `join` sometimes does okay, but it's not worth it when easier, more performant and less unusual methods exist. While `Any()` turned up in some of the results, outside of proper usage it has extremely poor performance. 

## References

Not every filter will have a link as I've picked up how to do some of these anyway, and some are just the inverse.

### Inclusive filter

| Method       | Link                                                                                                               |
| ------------ | ------------------------------------------------------------------------------------------------------------------ |
| LinqAny      | [link](https://stackoverflow.com/a/41929414)                                                                       |
| LinqContains | [link](https://stackoverflow.com/a/61484703)                                                                       |
| LinqJoin     | [link](https://dotnetable.wordpress.com/2015/06/20/find-all-items-in-list-which-exist-in-another-list-using-linq/) |
| HashSetLinq  | [link](https://stackoverflow.com/a/32013973)                                                                       |

### Exclusive filter

| Method              | Link                                                                                    |
| ------------------- | --------------------------------------------------------------------------------------- |
| LinqExceptBy        | [link](https://stackoverflow.com/a/75409994)                                            |
| LinqAny             | [link](https://stackoverflow.com/a/18977915)                                            |
| LinqContains        | [link](https://stackoverflow.com/a/15540930)                                            |
| LinqFindAllContains | [link](https://copyprogramming.com/howto/csharp-linq-filter-list-of-lists-code-example) |
| ForRemoveAt         | [link](https://stackoverflow.com/a/1582317)                                             |
| BinarySearch        | [link](https://stackoverflow.com/a/15541014)                                            |

## Notes

- A `List` datatype is used for the collections.
- The `Customer` is a `record` because early on I was using `ReturnValueValidator` to ensure everything was as expected as being a `record` allowed `ReturnValueValidator` to make the correct checks. However after moving to `ArgumentsSource` I was no longer able to use `ReturnValueValidator` but kept it as a `record`. After checking with _Simple shuffled case - large_ with `Customer` as a `class` there seems to be no difference in performance.
- The ids and customer columns in the benchmark tables have been edited. Due to how BenchmarkDotnet works, the representation of the datasets ended up being `Syste(...)nt32] [47]` and `Syste(...)omer] [73]` respectively.
- This does not use [`.Except()`](https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.except?view=net-8.0) or [`Intersect()`](https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.intersect?view=net-8.0) as they needs both lists to be the same datatype. ([`ExceptBy`](https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.exceptby?view=net-8.0) features in the results however.)