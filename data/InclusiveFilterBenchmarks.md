# Inclusive filter results

## Simple case - small

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

## Simple case - medium

| Method              | ids  | customers |         Mean |      Error |     StdDev | Ratio | RatioSD |     Gen0 |   Gen1 |  Allocated | Alloc Ratio |
| ------------------- | ---- | --------- | -----------: | ---------: | ---------: | ----: | ------: | -------: | -----: | ---------: | ----------: |
| ForEach             | 1000 | 10000     |  7,370.69 us | 146.828 us | 365.652 us | 10.79 |    0.62 |        - |      - |   16.21 KB |        0.99 |
| LinqAny             | 1000 | 10000     | 17,968.50 us | 194.112 us | 172.076 us | 25.47 |    1.15 | 281.2500 |      - | 1266.39 KB |       77.37 |
| LinqContains        | 1000 | 10000     |    690.76 us |  13.602 us |  28.090 us |  1.00 |    0.00 |   3.9063 |      - |   16.37 KB |        1.00 |
| LinqJoin            | 1000 | 10000     |    190.24 us |   3.672 us |   4.510 us |  0.27 |    0.01 |  28.8086 |      - |   118.5 KB |        7.24 |
| LinqFindAllContains | 1000 | 10000     |    807.61 us |  15.657 us |  14.646 us |  1.14 |    0.05 |   3.9063 |      - |    16.3 KB |        1.00 |
| LinqFindAllAny      | 1000 | 10000     | 18,097.39 us | 244.061 us | 190.547 us | 25.74 |    1.34 | 281.2500 |      - | 1266.31 KB |       77.37 |
| HashSetLinq         | 1000 | 10000     |     65.20 us |   0.387 us |   0.302 us |  0.09 |    0.00 |   8.1787 | 0.7324 |   33.76 KB |        2.06 |
| BinarySearch        | 1000 | 10000     |    168.30 us |   2.815 us |   2.891 us |  0.24 |    0.01 |   3.9063 |      - |   16.37 KB |        1.00 |

## Simple case - large

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

## Larger IDs case - small

| Method              | ids  | customers |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |    Gen0 |   Gen1 | Allocated | Alloc Ratio |
| ------------------- | ---- | --------- | --------: | --------: | --------: | --------: | ----: | ------: | ------: | -----: | --------: | ----------: |
| ForEach             | 1000 | 100       | 76.914 us | 1.4602 us | 1.4996 us | 76.868 us | 46.02 |    1.23 |  0.4883 |      - |   2.14 KB |        0.93 |
| LinqAny             | 1000 | 100       | 14.312 us | 0.2853 us | 0.3286 us | 14.303 us |  8.60 |    0.32 |  3.6163 |      - |   14.8 KB |        6.44 |
| LinqContains        | 1000 | 100       |  1.655 us | 0.0326 us | 0.0579 us |  1.632 us |  1.00 |    0.00 |  0.5608 |      - |    2.3 KB |        1.00 |
| LinqJoin            | 1000 | 100       | 37.025 us | 0.7358 us | 0.9822 us | 36.951 us | 22.32 |    0.85 | 25.5127 | 0.1221 | 104.43 KB |       45.47 |
| LinqFindAllContains | 1000 | 100       |  1.391 us | 0.0327 us | 0.0922 us |  1.358 us |  0.87 |    0.07 |  0.5436 |      - |   2.23 KB |        0.97 |
| LinqFindAllAny      | 1000 | 100       | 14.242 us | 0.2501 us | 0.3339 us | 14.156 us |  8.59 |    0.37 |  3.6011 |      - |  14.73 KB |        6.41 |
| HashSetLinq         | 1000 | 100       |  8.538 us | 0.1703 us | 0.4146 us |  8.392 us |  5.25 |    0.31 |  4.8065 |      - |  19.69 KB |        8.57 |
| BinarySearch        | 1000 | 100       |  6.108 us | 0.1170 us | 0.1095 us |  6.097 us |  3.65 |    0.15 |  0.5569 |      - |    2.3 KB |        1.00 |

## Larger IDs case - medium
| Method              | ids   | customers |        Mean |      Error |     StdDev |      Median |  Ratio | RatioSD |     Gen0 |     Gen1 |    Gen2 |  Allocated | Alloc Ratio |
| ------------------- | ----- | --------- | ----------: | ---------: | ---------: | ----------: | -----: | ------: | -------: | -------: | ------: | ---------: | ----------: |
| ForEach             | 10000 | 1000      | 7,459.88 us | 148.894 us | 424.804 us | 7,324.83 us | 151.58 |    8.72 |        - |        - |       - |   16.22 KB |        0.99 |
| LinqAny             | 10000 | 1000      |   980.73 us |  17.491 us |  31.091 us |   971.23 us |  19.56 |    0.74 |  34.1797 |        - |       - |  141.37 KB |        8.64 |
| LinqContains        | 10000 | 1000      |    51.25 us |   0.920 us |   0.768 us |    51.15 us |   1.00 |    0.00 |   3.9673 |        - |       - |   16.37 KB |        1.00 |
| LinqJoin            | 10000 | 1000      | 1,055.91 us |  20.956 us |  37.787 us | 1,062.86 us |  20.78 |    0.65 | 171.8750 | 121.0938 | 56.6406 | 1132.02 KB |       69.16 |
| LinqFindAllContains | 10000 | 1000      |    50.19 us |   0.987 us |   1.212 us |    49.72 us |   0.99 |    0.03 |   3.9673 |        - |       - |    16.3 KB |        1.00 |
| LinqFindAllAny      | 10000 | 1000      |   996.63 us |  19.661 us |  32.304 us |   990.35 us |  19.21 |    0.59 |  34.1797 |        - |       - |   141.3 KB |        8.63 |
| HashSetLinq         | 10000 | 1000      |   120.69 us |   2.303 us |   2.154 us |   120.99 us |   2.35 |    0.06 |  38.4521 |  38.4521 | 38.4521 |   174.4 KB |       10.66 |
| BinarySearch        | 10000 | 1000      |    91.82 us |   1.827 us |   2.311 us |    91.09 us |   1.80 |    0.05 |   3.9063 |        - |       - |   16.37 KB |        1.00 |

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

## Simple shuffled case - small

| Method              | ids | customers |       Mean |     Error |    StdDev | Ratio | RatioSD |    Gen0 | Allocated | Alloc Ratio |
| ------------------- | --- | --------- | ---------: | --------: | --------: | ----: | ------: | ------: | --------: | ----------: |
| ForEach             | 100 | 1000      |  81.353 us | 1.6078 us | 2.7734 us |  5.48 |    0.25 |  0.4883 |   2.14 KB |        0.93 |
| LinqAny             | 100 | 1000      | 211.180 us | 2.7980 us | 2.3364 us | 13.93 |    0.44 | 31.0059 |  127.3 KB |       55.42 |
| LinqContains        | 100 | 1000      |  14.922 us | 0.2929 us | 0.4201 us |  1.00 |    0.00 |  0.5493 |    2.3 KB |        1.00 |
| LinqJoin            | 100 | 1000      |  22.878 us | 0.3502 us | 0.3104 us |  1.51 |    0.05 |  3.1738 |  13.04 KB |        5.68 |
| LinqFindAllContains | 100 | 1000      |  11.804 us | 0.2305 us | 0.3914 us |  0.79 |    0.03 |  0.5341 |   2.23 KB |        0.97 |
| LinqFindAllAny      | 100 | 1000      | 211.609 us | 3.7310 us | 3.3074 us | 13.95 |    0.43 | 31.0059 | 127.23 KB |       55.39 |
| HashSetLinq         | 100 | 1000      |   8.049 us | 0.1558 us | 0.3674 us |  0.52 |    0.03 |  1.0071 |   4.13 KB |        1.80 |
| BinarySearch        | 100 | 1000      |  13.418 us | 0.2643 us | 0.3529 us |  0.90 |    0.04 |  0.5493 |    2.3 KB |        1.00 |

## Simple shuffled case - medium

| Method              | ids  | customers |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |     Gen0 |   Gen1 |  Allocated | Alloc Ratio |
| ------------------- | ---- | --------- | ----------: | --------: | --------: | ----------: | ----: | ------: | -------: | -----: | ---------: | ----------: |
| ForEach             | 1000 | 10000     |  7,320.1 us | 136.83 us | 282.57 us |  7,220.9 us | 10.73 |    0.47 |        - |      - |   16.21 KB |        0.99 |
| LinqAny             | 1000 | 10000     | 18,687.8 us | 363.53 us | 636.69 us | 18,484.7 us | 27.48 |    1.22 | 281.2500 |      - | 1266.38 KB |       77.37 |
| LinqContains        | 1000 | 10000     |    695.8 us |   4.74 us |   4.20 us |    695.7 us |  1.00 |    0.00 |   3.9063 |      - |   16.37 KB |        1.00 |
| LinqJoin            | 1000 | 10000     |    225.2 us |   4.15 us |   8.47 us |    222.0 us |  0.33 |    0.01 |  28.8086 |      - |   118.5 KB |        7.24 |
| LinqFindAllContains | 1000 | 10000     |    807.9 us |  15.61 us |  14.60 us |    798.6 us |  1.16 |    0.03 |   3.9063 |      - |    16.3 KB |        1.00 |
| LinqFindAllAny      | 1000 | 10000     | 18,499.1 us | 358.23 us | 707.11 us | 18,196.2 us | 26.63 |    0.83 | 281.2500 |      - | 1266.31 KB |       77.37 |
| HashSetLinq         | 1000 | 10000     |    108.3 us |   2.15 us |   4.77 us |    107.1 us |  0.16 |    0.01 |   8.1787 | 0.7324 |   33.76 KB |        2.06 |
| BinarySearch        | 1000 | 10000     |    203.2 us |   4.00 us |   5.20 us |    202.8 us |  0.29 |    0.01 |   3.9063 |      - |   16.37 KB |        1.00 |

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

```
ids         : The number of IDs 
customers	: The number of customers
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