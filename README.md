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

### Other points
- The `Customer` type is a `record` to help facilitate the easier result checking via the  `ReturnValueValidator` attribute due to the tidy way `record` types handle equality.

## Results

Results are benchmarked against what I found to be one of the most common filtering methods.

### Inclusive filter

Full results in [InclusiveFilterBenchmarks.md](data/InclusiveFilterBenchmarks.md) including:
1. Differing dataset sizes
1. The ID list being bigger than the customer list
1. Shuffed data

The following are some results for interest. There is an analysis below this Results section.

#### Simple case - small

| Method              | ids | customers |       Mean |     Error |    StdDev | Ratio | RatioSD |    Gen0 | Allocated | Alloc Ratio |
| ------------------- | --- | --------- | ---------: | --------: | --------: | ----: | ------: | ------: | --------: | ----------: |
| ForEach             | 100 | 1000      |  81.822 us | 1.5321 us | 3.0950 us |  5.86 |    0.17 |  0.4883 |   2.14 KB |        0.93 |
| LinqAny             | 100 | 1000      | 217.550 us | 4.2392 us | 5.6591 us | 15.80 |    0.45 | 31.0059 |  127.3 KB |       55.42 |
| LinqContains        | 100 | 1000      |  13.875 us | 0.2144 us | 0.2005 us |  1.00 |    0.00 |  0.5493 |    2.3 KB |        1.00 |
| LinqJoin            | 100 | 1000      |  19.695 us | 0.2710 us | 0.2403 us |  1.42 |    0.03 |  3.1738 |  13.04 KB |        5.68 |
| LinqFindAllContains | 100 | 1000      |  10.871 us | 0.1850 us | 0.3608 us |  0.79 |    0.03 |  0.5341 |   2.23 KB |        0.97 |
| LinqFindAllAny      | 100 | 1000      | 214.430 us | 3.5982 us | 5.4948 us | 15.41 |    0.52 | 31.0059 | 127.23 KB |       55.39 |
| HashSetLinq         | 100 | 1000      |   7.144 us | 0.1306 us | 0.1788 us |  0.52 |    0.02 |  1.0071 |   4.13 KB |        1.80 |
| BinarySearch        | 100 | 1000      |  12.257 us | 0.2451 us | 0.2293 us |  0.88 |    0.02 |  0.5493 |    2.3 KB |        1.00 |

#### Simple case - large

| Method              | ids   | customers |           Mean |        Error |       StdDev |         Median |  Ratio | RatioSD |      Gen0 |     Gen1 |    Gen2 |   Allocated | Alloc Ratio |
| ------------------- | ----- | --------- | -------------: | -----------: | -----------: | -------------: | -----: | ------: | --------: | -------: | ------: | ----------: | ----------: |
| ForEach             | 10000 | 100000    |   728,177.5 us | 14,369.58 us | 23,609.63 us |   723,822.6 us |  7.154 |    0.26 |         - |        - |       - |    256.7 KB |        1.00 |
| LinqAny             | 10000 | 100000    | 1,820,223.6 us | 35,856.12 us | 36,821.60 us | 1,814,181.3 us | 17.578 |    0.44 | 3000.0000 |        - |       - | 12756.85 KB |       49.73 |
| LinqContains        | 10000 | 100000    |   103,830.7 us |  1,280.50 us |  1,135.13 us |   104,267.1 us |  1.000 |    0.00 |         - |        - |       - |   256.54 KB |        1.00 |
| LinqJoin            | 10000 | 100000    |     3,290.5 us |     65.72 us |    123.44 us |     3,259.6 us |  0.031 |    0.00 |  253.9063 | 214.8438 | 74.2188 |  1372.25 KB |        5.35 |
| LinqFindAllContains | 10000 | 100000    |    84,017.1 us |  1,632.87 us |  1,943.81 us |    83,295.9 us |  0.816 |    0.02 |         - |        - |       - |   256.46 KB |        1.00 |
| LinqFindAllAny      | 10000 | 100000    | 1,825,391.7 us | 33,343.10 us | 34,240.91 us | 1,825,081.6 us | 17.523 |    0.29 | 3000.0000 |        - |       - | 12756.78 KB |       49.73 |
| HashSetLinq         | 10000 | 100000    |       903.1 us |     15.98 us |     13.35 us |       898.6 us |  0.009 |    0.00 |   79.1016 |  79.1016 | 79.1016 |    414.5 KB |        1.62 |
| BinarySearch        | 10000 | 100000    |     2,294.1 us |     45.81 us |    103.39 us |     2,256.0 us |  0.022 |    0.00 |   39.0625 |  39.0625 | 39.0625 |   256.48 KB |        1.00 |

## Larger IDs case - large
| Method              | ids    | customers |         Mean |        Error |       StdDev |       Median |  Ratio | RatioSD |      Gen0 |      Gen1 |     Gen2 |  Allocated | Alloc Ratio |
| ------------------- | ------ | --------- | -----------: | -----------: | -----------: | -----------: | -----: | ------: | --------: | --------: | -------: | ---------: | ----------: |
| ForEach             | 100000 | 10000     | 725,059.6 us | 14,346.37 us | 13,419.60 us | 727,435.3 us | 168.03 |    4.66 |         - |         - |        - |   256.7 KB |        1.00 |
| LinqAny             | 100000 | 10000     |  94,104.9 us |    620.34 us |    549.91 us |  94,274.0 us |  21.79 |    0.39 |  333.3333 |         - |        - | 1506.53 KB |        5.87 |
| LinqContains        | 100000 | 10000     |   4,314.1 us |     73.97 us |     72.65 us |   4,298.2 us |   1.00 |    0.00 |   39.0625 |   39.0625 |  39.0625 |  256.48 KB |        1.00 |
| LinqJoin            | 100000 | 10000     |  22,211.1 us |    415.23 us |    444.30 us |  22,281.0 us |   5.14 |    0.15 | 1968.7500 | 1406.2500 | 625.0000 | 10899.3 KB |       42.50 |
| LinqFindAllContains | 100000 | 10000     |   4,256.4 us |     40.62 us |     37.99 us |   4,245.5 us |   0.99 |    0.01 |   39.0625 |   39.0625 |  39.0625 |  256.41 KB |        1.00 |
| LinqFindAllAny      | 100000 | 10000     |  94,225.3 us |  1,553.12 us |  1,726.29 us |  93,863.1 us |  21.89 |    0.51 |  333.3333 |         - |        - | 1506.46 KB |        5.87 |
| HashSetLinq         | 100000 | 10000     |     919.5 us |     20.48 us |     58.09 us |     895.9 us |   0.22 |    0.01 |  366.2109 |  333.0078 | 333.0078 | 1956.66 KB |        7.63 |
| BinarySearch        | 100000 | 10000     |   1,127.8 us |     22.25 us |     38.97 us |   1,123.3 us |   0.26 |    0.01 |   41.0156 |   41.0156 |  41.0156 |  256.48 KB |        1.00 |

## Simple shuffled case - large

| Method              | ids   | customers |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |      Gen0 |     Gen1 |    Gen2 |   Allocated | Alloc Ratio |
| ------------------- | ----- | --------- | -----------: | ---------: | ---------: | -----------: | ----: | ------: | --------: | -------: | ------: | ----------: | ----------: |
| ForEach             | 10000 | 100000    |   755.074 ms | 14.7280 ms | 24.1986 ms |   751.576 ms |  6.71 |    0.26 |         - |        - |       - |    256.7 KB |        1.00 |
| LinqAny             | 10000 | 100000    | 1,845.548 ms | 31.0636 ms | 33.2377 ms | 1,842.498 ms | 16.53 |    0.32 | 3000.0000 |        - |       - | 12756.85 KB |       49.73 |
| LinqContains        | 10000 | 100000    |   111.992 ms |  0.9925 ms |  0.8798 ms |   111.959 ms |  1.00 |    0.00 |         - |        - |       - |   256.54 KB |        1.00 |
| LinqJoin            | 10000 | 100000    |     6.063 ms |  0.2152 ms |  0.6069 ms |     5.881 ms |  0.05 |    0.00 |  257.8125 | 226.5625 | 78.1250 |   1372.3 KB |        5.35 |
| LinqFindAllContains | 10000 | 100000    |    90.015 ms |  0.7833 ms |  0.7327 ms |    90.057 ms |  0.80 |    0.01 |         - |        - |       - |   256.46 KB |        1.00 |
| LinqFindAllAny      | 10000 | 100000    | 1,829.869 ms | 35.5146 ms | 40.8987 ms | 1,827.735 ms | 16.29 |    0.40 | 3000.0000 |        - |       - | 12756.78 KB |       49.73 |
| HashSetLinq         | 10000 | 100000    |     1.831 ms |  0.0450 ms |  0.1277 ms |     1.830 ms |  0.02 |    0.00 |   78.1250 |  78.1250 | 78.1250 |    414.5 KB |        1.62 |
| BinarySearch        | 10000 | 100000    |     3.895 ms |  0.0778 ms |  0.1554 ms |     3.883 ms |  0.03 |    0.00 |   39.0625 |  39.0625 | 39.0625 |   256.48 KB |        1.00 |


### Exclusive filter

Full results in [ExclusiveFilterBenchmarks.md](data/ExclusiveFilterBenchmarks.md) including:
1. Differing dataset sizes
1. The ID list being bigger than the customer list
1. Shuffed data

The following are some results for interest. There is an analysis below this Results section.

#### Simple case - small

| Method              | ids | customers |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |    Gen0 |   Gen1 | Allocated | Alloc Ratio |
| ------------------- | --- | --------- | ---------: | --------: | --------: | ---------: | ----: | ------: | ------: | -----: | --------: | ----------: |
| LinqExceptBy        | 100 | 1000      |  26.424 us | 0.5256 us | 1.3282 us |  26.006 us |  2.72 |    0.18 | 18.0054 | 2.9907 |   75488 B |      857.82 |
| RemoveAllAny        | 100 | 1000      | 199.556 us | 3.7019 us | 3.0912 us | 200.238 us | 20.89 |    0.71 | 27.3438 |      - |  115288 B |    1,310.09 |
| RemoveAllContains   | 100 | 1000      |   9.721 us | 0.1909 us | 0.3678 us |   9.618 us |  1.00 |    0.00 |  0.0153 |      - |      88 B |        1.00 |
| LinqAny             | 100 | 1000      | 219.953 us | 4.3188 us | 3.8285 us | 219.816 us | 23.02 |    0.81 | 34.4238 |      - |  144760 B |    1,645.00 |
| LinqContains        | 100 | 1000      |  16.005 us | 0.2873 us | 0.2399 us |  15.955 us |  1.68 |    0.06 |  3.9978 |      - |   16760 B |      190.45 |
| LinqFindAllContains | 100 | 1000      |  15.248 us | 0.3019 us | 0.7953 us |  15.025 us |  1.59 |    0.10 |  3.9673 |      - |   16688 B |      189.64 |
| LinqFindAllAny      | 100 | 1000      | 220.317 us | 4.3331 us | 5.4800 us | 219.060 us | 22.77 |    1.22 | 34.4238 |      - |  144688 B |    1,644.18 |
| HashSetLinq         | 100 | 1000      |  10.146 us | 0.2000 us | 0.3708 us |  10.112 us |  1.05 |    0.06 |  4.4403 |      - |   18632 B |      211.73 |
| BinarySearch        | 100 | 1000      |   9.452 us | 0.1877 us | 0.2441 us |   9.374 us |  0.97 |    0.05 |  0.0153 |      - |      88 B |        1.00 |

#### Simple case - large

| Method              | ids   | customers |         Mean |      Error |     StdDev | Ratio | RatioSD |      Gen0 |     Gen1 |     Gen2 |  Allocated | Alloc Ratio |
| ------------------- | ----- | --------- | -----------: | ---------: | ---------: | ----: | ------: | --------: | -------: | -------: | ---------: | ----------: |
| LinqExceptBy        | 10000 | 100000    |     3.228 ms |  0.0650 ms |  0.1866 ms |  0.03 |    0.00 | 1085.9375 | 996.0938 | 996.0938 |  6931731 B |   44,720.85 |
| RemoveAllAny        | 10000 | 100000    | 1,750.943 ms | 34.2115 ms | 59.9188 ms | 17.77 |    0.68 | 2000.0000 |        - |        - | 11520488 B |   74,325.73 |
| RemoveAllContains   | 10000 | 100000    |    99.564 ms |  1.5792 ms |  1.5510 ms |  1.00 |    0.00 |         - |        - |        - |      155 B |        1.00 |
| LinqAny             | 10000 | 100000    | 1,825.339 ms | 35.4703 ms | 49.7244 ms | 18.36 |    0.53 | 3000.0000 |        - |        - | 14898096 B |   96,116.75 |
| LinqContains        | 10000 | 100000    |   102.404 ms |  0.8751 ms |  0.7758 ms |  1.03 |    0.02 |  400.0000 | 400.0000 | 400.0000 |  2097843 B |   13,534.47 |
| LinqFindAllContains | 10000 | 100000    |    84.919 ms |  1.1003 ms |  0.9188 ms |  0.85 |    0.02 |  333.3333 | 333.3333 | 333.3333 |  2097795 B |   13,534.16 |
| LinqFindAllAny      | 10000 | 100000    | 1,847.875 ms | 35.9421 ms | 35.3000 ms | 18.57 |    0.53 | 3000.0000 |        - |        - | 14898024 B |   96,116.28 |
| HashSetLinq         | 10000 | 100000    |     1.228 ms |  0.0245 ms |  0.0702 ms |  0.01 |    0.00 |  423.8281 | 384.7656 | 380.8594 |  2261241 B |   14,588.65 |
| BinarySearch        | 10000 | 100000    |     1.614 ms |  0.0294 ms |  0.0508 ms |  0.02 |    0.00 |         - |        - |        - |       89 B |        0.57 |

#### Larger IDs case - large

| Method              | ids    | customers |             Mean |            Error |           StdDev |        Ratio |    RatioSD |      Gen0 |     Gen1 |     Gen2 | Allocated | Alloc Ratio |
| ------------------- | ------ | --------- | ---------------: | ---------------: | ---------------: | -----------: | ---------: | --------: | -------: | -------: | --------: | ----------: |
| LinqExceptBy        | 100000 | 10000     |  2,253,643.25 ns |    52,533.304 ns |   150,727.897 ns |   198,289.08 |  17,834.54 | 1031.2500 | 984.3750 | 976.5625 | 4830890 B |   54,896.48 |
| RemoveAllAny        | 100000 | 10000     |         14.56 ns |         0.288 ns |         0.589 ns |         1.28 |       0.09 |    0.0210 |        - |        - |      88 B |        1.00 |
| RemoveAllContains   | 100000 | 10000     |         11.44 ns |         0.286 ns |         0.749 ns |         1.00 |       0.00 |    0.0210 |        - |        - |      88 B |        1.00 |
| LinqAny             | 100000 | 10000     | 95,626,550.00 ns | 1,296,452.777 ns | 1,082,596.786 ns | 8,515,563.47 | 636,920.60 |  166.6667 |        - |        - | 1280259 B |   14,548.40 |
| LinqContains        | 100000 | 10000     |  4,326,451.70 ns |    84,404.469 ns |   103,656.268 ns |   388,852.29 |  29,133.28 |         - |        - |        - |     195 B |        2.22 |
| LinqFindAllContains | 100000 | 10000     |  4,199,831.16 ns |    56,417.082 ns |    57,936.190 ns |   378,043.53 |  25,410.83 |         - |        - |        - |     123 B |        1.40 |
| LinqFindAllAny      | 100000 | 10000     | 96,925,566.67 ns | 1,900,272.640 ns | 1,951,440.095 ns | 8,722,252.62 | 567,078.39 |  166.6667 |        - |        - | 1280187 B |   14,547.58 |
| HashSetLinq         | 100000 | 10000     |  1,411,310.19 ns |    27,844.881 ns |    48,031.052 ns |   125,584.94 |   8,243.57 |  498.0469 | 498.0469 | 498.0469 | 1738616 B |   19,757.00 |
| BinarySearch        | 100000 | 10000     |    495,794.52 ns |     8,896.042 ns |     8,321.364 ns |    44,435.94 |   3,284.39 |         - |        - |        - |      88 B |        1.00 |

#### Simple shuffled case - large

| Method              | ids   | customers |         Mean |      Error |     StdDev | Ratio | RatioSD |      Gen0 |      Gen1 |      Gen2 |  Allocated | Alloc Ratio |
| ------------------- | ----- | --------- | -----------: | ---------: | ---------: | ----: | ------: | --------: | --------: | --------: | ---------: | ----------: |
| LinqExceptBy        | 10000 | 100000    |     6.349 ms |  0.1250 ms |  0.1044 ms |  0.06 |    0.00 | 1078.1250 | 1015.6250 | 1000.0000 |  6928510 B |   41,241.13 |
| RemoveAllAny        | 10000 | 100000    | 1,769.052 ms | 35.3549 ms | 43.4189 ms | 16.87 |    0.69 | 2000.0000 |         - |         - | 11520488 B |   68,574.33 |
| RemoveAllContains   | 10000 | 100000    |   105.250 ms |  2.0780 ms |  1.8421 ms |  1.00 |    0.00 |         - |         - |         - |      168 B |        1.00 |
| LinqAny             | 10000 | 100000    | 1,839.626 ms | 32.8417 ms | 30.7201 ms | 17.50 |    0.48 | 3000.0000 |         - |         - | 14898096 B |   88,679.14 |
| LinqContains        | 10000 | 100000    |   113.640 ms |  2.2552 ms |  2.4131 ms |  1.08 |    0.04 |  400.0000 |  400.0000 |  400.0000 |  2097901 B |   12,487.51 |
| LinqFindAllContains | 10000 | 100000    |    91.844 ms |  1.7566 ms |  1.7252 ms |  0.87 |    0.03 |  333.3333 |  333.3333 |  333.3333 |  2097795 B |   12,486.88 |
| LinqFindAllAny      | 10000 | 100000    | 1,843.463 ms | 28.9160 ms | 24.1462 ms | 17.51 |    0.33 | 3000.0000 |         - |         - | 14897688 B |   88,676.71 |
| HashSetLinq         | 10000 | 100000    |     2.661 ms |  0.0523 ms |  0.1159 ms |  0.03 |    0.00 |  484.3750 |  445.3125 |  441.4063 |  2260480 B |   13,455.24 |
| BinarySearch        | 10000 | 100000    |     2.492 ms |  0.0917 ms |  0.2630 ms |  0.02 |    0.00 |         - |         - |         - |       90 B |        0.54 |

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
1 ms        : 1 Millisecond (0.001 sec)
```

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
| ForEach             |                                                                                                                    |
| LinqAny             | [link](https://stackoverflow.com/a/41929414)                                                                      |
| LinqContains        | [link](https://stackoverflow.com/a/61484703)                                                                       |
| LinqJoin            | [link](https://dotnetable.wordpress.com/2015/06/20/find-all-items-in-list-which-exist-in-another-list-using-linq/) |
| LinqFindAllContains |                                                                                                                    |
| LinqFindAllAny      | 213.987 μs                                                                                                         |
| HashSetLinq         | [link](https://stackoverflow.com/a/32013973)                                                                       |
| BinarySearch        |                                                                                                          |

### Exclusive filter

| Method              | Link                                                                                     |
| ------------------- | ---------------------------------------------------------------------------------------- |
| LinqExceptBy        | [link](https://stackoverflow.com/a/75409994)                                             |
| LinqAny             | [link](https://stackoverflow.com/a/18977915)                                             |
| LinqContains        | [link](https://stackoverflow.com/a/15540930)                                             |
| LinqFindAllContains | [link](https://copyprogramming.com/howto/csharp-linq-filter-list-of-lists-code-example)] |
| LinqFindAllAny      | 215.480 μs                                                                               |
| HashSetLinq         |                                                                                          |
| ForRemoveAt         | [link](https://stackoverflow.com/a/1582317)                                              |
| RemoveAll           | 3,740.263 μs                                                                             |
| BinarySearch        | [link](https://stackoverflow.com/a/15541014)                                             |

## Notes

- A `List` datatype is used for the collections.
- The `Customer` is a `record` because early on I was using `ReturnValueValidator` to ensure everything was as expected as being a `record` allowed `ReturnValueValidator` to make the correct checks. However after moving to `ArgumentsSource` I was no longer able to use `ReturnValueValidator` but kept it as a `record`. After checking with _Simple shuffled case - large_ with `Customer` as a `class` there seems to be no difference in performance.