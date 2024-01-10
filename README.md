# Filtering-list-with-another-list-Dotnet-Benchmarking
Benchmarking various ways to filter a list based on another list for both inclusive and exclusive cases. 

## How to run
1. Get the repo
1. In the same project as the solution run:
```
dotnet run --configuration Release --framework net8.0 --runtimes net8.0 --filter *
```

## Test scenarios

The scenarios have two lists, a larger main list of customers, and a smaller list of IDs. The list of IDs is what's used to filter the customer list.

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

### Other points
- The `Customer` type is a `record` to help facilitate the easier result checking via the  `ReturnValueValidator` attribute due to the tidy way `record` types handle equality.

## Results

### Inclusive filter

| Method              | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|-------------------- |-----------:|----------:|----------:|------:|--------:|--------:|----------:|------------:|
| ForEach             | 126.510 μs | 2.0016 μs | 1.7744 μs |  1.00 |    0.00 |  0.4883 |   2.14 KB |        1.00 |
| LinqAny             | 214.280 μs | 4.2639 μs | 3.7798 μs |  1.69 |    0.04 | 31.0059 | 127.27 KB |       59.46 |
| LinqContains        |  13.740 μs | 0.2694 μs | 0.2646 μs |  0.11 |    0.00 |  0.5493 |   2.27 KB |        1.06 |
| LinqJoin            |  19.502 μs | 0.1942 μs | 0.1817 μs |  0.15 |    0.00 |  3.1738 |  13.04 KB |        6.09 |
| LinqFindAllContains |  10.755 μs | 0.2029 μs | 0.1993 μs |  0.08 |    0.00 |  0.5341 |    2.2 KB |        1.03 |
| LinqFindAllAny      | 213.987 μs | 4.1455 μs | 4.7740 μs |  1.69 |    0.05 | 31.0059 |  127.2 KB |       59.42 |
| HashSetLinq         |   7.122 μs | 0.1410 μs | 0.1679 μs |  0.06 |    0.00 |  1.0071 |   4.13 KB |        1.93 |
| BinarySearch        |  12.256 μs | 0.2344 μs | 0.2879 μs |  0.10 |    0.00 |  0.5493 |   2.27 KB |        1.06 |

### Exclusive filter

| Method              | Mean         | Error       | StdDev      | Median       | Ratio | RatioSD | Gen0    | Gen1   | Allocated | Alloc Ratio |
|-------------------- |-------------:|------------:|------------:|-------------:|------:|--------:|--------:|-------:|----------:|------------:|
| LinqExceptBy        |    26.087 μs |   0.5127 μs |   0.8132 μs |    26.087 μs |     ? |       ? | 18.0054 | 2.9907 |   75488 B |           ? |
| LinqAny             |   213.216 μs |   1.3942 μs |   1.1642 μs |   213.480 μs |     ? |       ? | 34.4238 |      - |  144736 B |           ? |
| LinqContains        |    15.485 μs |   0.2731 μs |   0.2923 μs |    15.395 μs |     ? |       ? |  3.9978 |      - |   16736 B |           ? |
| LinqFindAllContains |    14.419 μs |   0.2836 μs |   0.3153 μs |    14.313 μs |     ? |       ? |  3.9825 |      - |   16664 B |           ? |
| LinqFindAllAny      |   215.480 μs |   3.8609 μs |   3.7919 μs |   214.491 μs |     ? |       ? | 34.4238 |      - |  144664 B |           ? |
| HashSetLinq         |     9.872 μs |   0.1967 μs |   0.2757 μs |     9.823 μs |     ? |       ? |  4.4403 |      - |   18632 B |           ? |
|                     |              |             |             |              |       |         |         |        |           |             |
| ForRemoveAt         |    43.022 μs |   1.5692 μs |   4.2425 μs |    41.400 μs |  1.00 |    0.00 |       - |      - |     400 B |        1.00 |
| RemoveAll           | 3,740.263 μs | 112.7253 μs | 319.7828 μs | 3,626.700 μs | 87.83 |   10.62 |       - |      - |  128464 B |      321.16 |
| BinarySearch        |    30.889 μs |   0.6213 μs |   1.0381 μs |    31.000 μs |  0.70 |    0.07 |       - |      - |     464 B |        1.16 |

_A question mark '?' symbol indicates that it was not possible to compute the (Ratio, RatioSD, Alloc Ratio) column(s) because the baseline value is too close to zero._

```
Size        : Value of the 'Size' parameter - the number of weather records returned per request
Mean        : Arithmetic mean of all measurements
Error       : Half of 99.9% confidence interval
StdDev      : Standard deviation of all measurements
Median      : Value separating the higher half of all measurements (50th percentile)
Ratio       : Mean of the ratio distribution ([Current]/[Baseline])
RatioSD     : Standard deviation of the ratio distribution ([Current]/[Baseline])
Gen0        : GC Generation 0 collects per 1000 operations
Gen1        : GC Generation 1 collects per 1000 operations
Gen2        : GC Generation 2 collects per 1000 operations
Allocated   : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
Alloc Ratio : Allocated memory ratio distribution ([Current]/[Baseline])
1 μs        : 1 Microsecond (0.000001 sec)
```

## Short analysis

### Other points

- This does not test a larger ID list against a smaller customer list.
- A `List` datatype is used for the collections.
- The `Customer` is a record.