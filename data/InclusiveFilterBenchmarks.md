# Inclusive filter results

```
BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3803/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.100
```

## Simple case - small

| Method                   | ids | customers |       Mean |     Error |    StdDev | Ratio | RatioSD |    Gen0 | Allocated | Alloc Ratio |
| ------------------------ | --: | --------: | ---------: | --------: | --------: | ----: | ------: | ------: | --------: | ----------: |
| ForEach                  | 100 |      1000 |  79.172 us | 1.5667 us | 2.2965 us |  6.48 |    0.19 |  0.4883 |   2.14 KB |        0.93 |
| Where_Any                | 100 |      1000 | 203.936 us | 1.6365 us | 1.3665 us | 16.41 |    0.20 | 31.0059 |  127.3 KB |       55.42 |
| Where_Contains           | 100 |      1000 |  12.417 us | 0.1071 us | 0.1001 us |  1.00 |    0.00 |  0.5493 |    2.3 KB |        1.00 |
| Join                     | 100 |      1000 |  18.915 us | 0.2204 us | 0.2062 us |  1.52 |    0.02 |  3.1738 |  13.04 KB |        5.68 |
| FindAll_Contains         | 100 |      1000 |  10.345 us | 0.0544 us | 0.0508 us |  0.83 |    0.01 |  0.5341 |   2.23 KB |        0.97 |
| FindAll_Any              | 100 |      1000 | 204.671 us | 1.6473 us | 1.3755 us | 16.47 |    0.18 | 31.0059 | 127.23 KB |       55.39 |
| HashSet_Where_Contains   | 100 |      1000 |   6.994 us | 0.1398 us | 0.2726 us |  0.58 |    0.03 |  1.0071 |   4.13 KB |        1.80 |
| HashSet_FindAll_Contains | 100 |      1000 |   6.396 us | 0.1257 us | 0.2360 us |  0.52 |    0.02 |  0.9918 |   4.05 KB |        1.77 |
| Where_BinarySearch       | 100 |      1000 |  12.010 us | 0.1792 us | 0.1676 us |  0.97 |    0.01 |  0.5493 |    2.3 KB |        1.00 |
| FindAll_BinarySearch     | 100 |      1000 |  11.618 us | 0.2248 us | 0.2924 us |  0.94 |    0.03 |  0.5341 |   2.23 KB |        0.97 |

## Simple case - medium

| Method                   |  ids | customers |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |     Gen0 |   Gen1 |  Allocated | Alloc Ratio |
| ------------------------ | ---: | --------: | -----------: | ---------: | ---------: | -----------: | ----: | ------: | -------: | -----: | ---------: | ----------: |
| ForEach                  | 1000 |     10000 |  7,180.90 us | 139.203 us | 148.946 us |  7,149.29 us |  8.87 |    0.20 |        - |      - |   16.21 KB |        0.99 |
| Where_Any                | 1000 |     10000 | 18,209.17 us | 303.304 us | 268.871 us | 18,123.65 us | 22.39 |    0.37 | 281.2500 |      - | 1266.38 KB |       77.37 |
| Where_Contains           | 1000 |     10000 |    813.29 us |   6.256 us |   5.224 us |    812.26 us |  1.00 |    0.00 |   3.9063 |      - |   16.37 KB |        1.00 |
| Join                     | 1000 |     10000 |    188.83 us |   3.760 us |   5.020 us |    185.92 us |  0.24 |    0.01 |  28.8086 |      - |   118.5 KB |        7.24 |
| FindAll_Contains         | 1000 |     10000 |    794.57 us |   4.299 us |   3.590 us |    794.31 us |  0.98 |    0.01 |   3.9063 |      - |    16.3 KB |        1.00 |
| FindAll_Any              | 1000 |     10000 | 17,918.60 us | 170.236 us | 150.909 us | 17,886.73 us | 22.04 |    0.28 | 281.2500 |      - | 1266.31 KB |       77.37 |
| HashSet_Where_Contains   | 1000 |     10000 |     66.59 us |   1.019 us |   0.903 us |     66.30 us |  0.08 |    0.00 |   8.1787 | 0.7324 |   33.76 KB |        2.06 |
| HashSet_FindAll_Contains | 1000 |     10000 |     59.40 us |   0.678 us |   0.634 us |     59.16 us |  0.07 |    0.00 |   8.2397 |      - |   33.69 KB |        2.06 |
| Where_BinarySearch       | 1000 |     10000 |    163.59 us |   1.445 us |   1.281 us |    163.38 us |  0.20 |    0.00 |   3.9063 |      - |   16.37 KB |        1.00 |
| FindAll_BinarySearch     | 1000 |     10000 |    163.38 us |   3.188 us |   3.411 us |    162.00 us |  0.20 |    0.00 |   3.9063 |      - |    16.3 KB |        1.00 |

## Simple case - large

| Method                   |   ids | customers |           Mean |        Error |       StdDev |         Median |  Ratio | RatioSD |      Gen0 |     Gen1 |    Gen2 |   Allocated | Alloc Ratio |
| ------------------------ | ----: | --------: | -------------: | -----------: | -----------: | -------------: | -----: | ------: | --------: | -------: | ------: | ----------: | ----------: |
| ForEach                  | 10000 |    100000 |   753,846.4 us | 19,917.17 us | 56,501.70 us |   737,211.5 us |  7.017 |    0.22 |         - |        - |       - |    256.7 KB |        1.00 |
| Where_Any                | 10000 |    100000 | 1,830,634.8 us | 36,010.03 us | 66,746.90 us | 1,802,770.1 us | 17.970 |    0.83 | 3000.0000 |        - |       - | 12756.85 KB |       49.73 |
| Where_Contains           | 10000 |    100000 |   103,707.2 us |    678.19 us |    566.32 us |   103,754.6 us |  1.000 |    0.00 |         - |        - |       - |   256.54 KB |        1.00 |
| Join                     | 10000 |    100000 |     3,225.3 us |     63.35 us |    100.48 us |     3,235.5 us |  0.031 |    0.00 |  253.9063 | 210.9375 | 74.2188 |  1372.23 KB |        5.35 |
| FindAll_Contains         | 10000 |    100000 |   103,326.4 us |    618.05 us |    516.10 us |   103,361.7 us |  0.996 |    0.01 |         - |        - |       - |   256.47 KB |        1.00 |
| FindAll_Any              | 10000 |    100000 | 1,792,824.2 us | 22,724.98 us | 20,145.10 us | 1,787,334.6 us | 17.306 |    0.23 | 3000.0000 |        - |       - | 12756.78 KB |       49.73 |
| HashSet_Where_Contains   | 10000 |    100000 |       907.3 us |     18.07 us |     30.20 us |       900.4 us |  0.009 |    0.00 |   79.1016 |  79.1016 | 79.1016 |    414.5 KB |        1.62 |
| HashSet_FindAll_Contains | 10000 |    100000 |       815.9 us |     13.62 us |     12.74 us |       815.2 us |  0.008 |    0.00 |   79.1016 |  79.1016 | 79.1016 |   414.43 KB |        1.62 |
| Where_BinarySearch       | 10000 |    100000 |     2,224.5 us |     42.88 us |     42.11 us |     2,214.9 us |  0.022 |    0.00 |   39.0625 |  39.0625 | 39.0625 |   256.48 KB |        1.00 |
| FindAll_BinarySearch     | 10000 |    100000 |     2,150.5 us |     42.66 us |     52.39 us |     2,152.6 us |  0.021 |    0.00 |   39.0625 |  39.0625 | 39.0625 |   256.41 KB |        1.00 |

## Larger IDs case - small

| Method                   |  ids | customers |      Mean |     Error |    StdDev | Ratio | RatioSD |    Gen0 |   Gen1 | Allocated | Alloc Ratio |
| ------------------------ | ---: | --------: | --------: | --------: | --------: | ----: | ------: | ------: | -----: | --------: | ----------: |
| ForEach                  | 1000 |       100 | 71.854 us | 1.3989 us | 1.3739 us | 48.42 |    1.32 |  0.4883 |      - |   2.14 KB |        0.93 |
| Where_Any                | 1000 |       100 | 14.080 us | 0.2793 us | 0.3431 us |  9.51 |    0.24 |  3.6163 |      - |   14.8 KB |        6.44 |
| Where_Contains           | 1000 |       100 |  1.483 us | 0.0287 us | 0.0294 us |  1.00 |    0.00 |  0.5608 |      - |    2.3 KB |        1.00 |
| Join                     | 1000 |       100 | 35.508 us | 0.7078 us | 0.7574 us | 23.94 |    0.71 | 25.5127 | 0.1221 | 104.43 KB |       45.47 |
| FindAll_Contains         | 1000 |       100 |  1.308 us | 0.0261 us | 0.0391 us |  0.89 |    0.03 |  0.5436 |      - |   2.23 KB |        0.97 |
| FindAll_Any              | 1000 |       100 | 14.066 us | 0.2784 us | 0.2468 us |  9.46 |    0.19 |  3.6011 |      - |  14.73 KB |        6.41 |
| HashSet_Where_Contains   | 1000 |       100 |  8.079 us | 0.1328 us | 0.1304 us |  5.44 |    0.13 |  4.8065 |      - |  19.69 KB |        8.57 |
| HashSet_FindAll_Contains | 1000 |       100 |  7.932 us | 0.1581 us | 0.2318 us |  5.33 |    0.22 |  4.7913 |      - |  19.62 KB |        8.54 |
| Where_BinarySearch       | 1000 |       100 |  6.148 us | 0.1119 us | 0.1046 us |  4.14 |    0.11 |  0.5569 |      - |    2.3 KB |        1.00 |
| FindAll_BinarySearch     | 1000 |       100 |  6.037 us | 0.0697 us | 0.0582 us |  4.06 |    0.12 |  0.5417 |      - |   2.23 KB |        0.97 |

## Larger IDs case - medium

| Method                   |   ids | customers |        Mean |      Error |     StdDev |  Ratio | RatioSD |     Gen0 |     Gen1 |    Gen2 |  Allocated | Alloc Ratio |
| ------------------------ | ----: | --------: | ----------: | ---------: | ---------: | -----: | ------: | -------: | -------: | ------: | ---------: | ----------: |
| ForEach                  | 10000 |      1000 | 7,115.13 us | 140.411 us | 177.575 us | 140.52 |    3.91 |        - |        - |       - |   16.21 KB |        0.99 |
| Where_Any                | 10000 |      1000 |   955.12 us |   8.168 us |   7.241 us |  18.82 |    0.21 |  33.2031 |        - |       - |  141.37 KB |        8.64 |
| Where_Contains           | 10000 |      1000 |    50.74 us |   0.341 us |   0.302 us |   1.00 |    0.00 |   3.9673 |        - |       - |   16.37 KB |        1.00 |
| Join                     | 10000 |      1000 |   989.02 us |  19.121 us |  18.779 us |  19.53 |    0.32 | 168.9453 | 118.1641 | 58.5938 | 1132.02 KB |       69.16 |
| FindAll_Contains         | 10000 |      1000 |    50.15 us |   0.294 us |   0.261 us |   0.99 |    0.01 |   3.9673 |        - |       - |    16.3 KB |        1.00 |
| FindAll_Any              | 10000 |      1000 |   953.65 us |   6.445 us |   5.382 us |  18.79 |    0.18 |  34.1797 |        - |       - |   141.3 KB |        8.63 |
| HashSet_Where_Contains   | 10000 |      1000 |   115.76 us |   0.687 us |   0.574 us |   2.28 |    0.02 |  38.3301 |  38.3301 | 38.3301 |   174.4 KB |       10.66 |
| HashSet_FindAll_Contains | 10000 |      1000 |   115.38 us |   1.251 us |   1.044 us |   2.27 |    0.02 |  38.4521 |  38.4521 | 38.4521 |  174.33 KB |       10.65 |
| Where_BinarySearch       | 10000 |      1000 |    90.35 us |   1.778 us |   1.576 us |   1.78 |    0.03 |   3.9063 |        - |       - |   16.37 KB |        1.00 |
| FindAll_BinarySearch     | 10000 |      1000 |    90.05 us |   1.800 us |   2.210 us |   1.79 |    0.05 |   3.9063 |        - |       - |    16.3 KB |        1.00 |

## Larger IDs case - large

| Method                   |    ids | customers |         Mean |        Error |       StdDev |       Median |  Ratio | RatioSD |      Gen0 |      Gen1 |     Gen2 |  Allocated | Alloc Ratio |
| ------------------------ | -----: | --------: | -----------: | -----------: | -----------: | -----------: | -----: | ------: | --------: | --------: | -------: | ---------: | ----------: |
| ForEach                  | 100000 |     10000 | 713,752.7 us | 13,982.27 us | 20,495.03 us | 706,319.5 us | 161.67 |    7.92 |         - |         - |        - |   256.7 KB |        1.00 |
| Where_Any                | 100000 |     10000 |  94,512.6 us |  1,778.63 us |  1,826.52 us |  93,423.9 us |  21.16 |    1.15 |  333.3333 |         - |        - | 1506.53 KB |        5.87 |
| Where_Contains           | 100000 |     10000 |   4,358.1 us |     85.31 us |    172.33 us |   4,286.7 us |   1.00 |    0.00 |   39.0625 |   39.0625 |  39.0625 |  256.48 KB |        1.00 |
| Join                     | 100000 |     10000 |  22,461.5 us |    445.08 us |    878.55 us |  22,516.4 us |   5.16 |    0.25 | 1968.7500 | 1406.2500 | 625.0000 | 10898.9 KB |       42.49 |
| FindAll_Contains         | 100000 |     10000 |   4,240.0 us |     42.27 us |     37.47 us |   4,231.3 us |   0.94 |    0.05 |   39.0625 |   39.0625 |  39.0625 |  256.41 KB |        1.00 |
| FindAll_Any              | 100000 |     10000 |  93,539.0 us |    645.70 us |    572.39 us |  93,423.0 us |  20.82 |    0.92 |  333.3333 |         - |        - | 1506.46 KB |        5.87 |
| HashSet_Where_Contains   | 100000 |     10000 |     927.4 us |     18.48 us |     38.17 us |     928.5 us |   0.21 |    0.01 |  365.2344 |  333.9844 | 333.9844 | 1956.67 KB |        7.63 |
| HashSet_FindAll_Contains | 100000 |     10000 |     889.6 us |     10.19 us |      7.96 us |     893.1 us |   0.20 |    0.01 |  365.2344 |  333.9844 | 333.9844 |  1956.6 KB |        7.63 |
| Where_BinarySearch       | 100000 |     10000 |   1,081.8 us |     12.40 us |     10.99 us |   1,078.4 us |   0.24 |    0.01 |   41.0156 |   41.0156 |  41.0156 |  256.48 KB |        1.00 |
| FindAll_BinarySearch     | 100000 |     10000 |   1,103.9 us |     18.88 us |     17.66 us |   1,103.7 us |   0.25 |    0.01 |   41.0156 |   41.0156 |  41.0156 |  256.41 KB |        1.00 |

## Simple shuffled case - small

| Method                   | ids | customers |       Mean |     Error |    StdDev | Ratio | RatioSD |    Gen0 | Allocated | Alloc Ratio |
| ------------------------ | --- | --------- | ---------: | --------: | --------: | ----: | ------: | ------: | --------: | ----------: |
| ForEach                  | 100 | 1000      |  81.216 us | 1.5774 us | 2.2113 us |  5.47 |    0.23 |  0.4883 |   2.14 KB |        0.93 |
| Where_Any                | 100 | 1000      | 215.449 us | 4.2511 us | 7.4454 us | 14.59 |    0.73 | 31.0059 |  127.3 KB |       55.42 |
| Where_Contains           | 100 | 1000      |  14.850 us | 0.2953 us | 0.3735 us |  1.00 |    0.00 |  0.5493 |    2.3 KB |        1.00 |
| Join                     | 100 | 1000      |  22.601 us | 0.3596 us | 0.3364 us |  1.52 |    0.04 |  3.1738 |  13.04 KB |        5.68 |
| FindAll_Contains         | 100 | 1000      |  11.342 us | 0.1448 us | 0.1355 us |  0.76 |    0.03 |  0.5341 |   2.23 KB |        0.97 |
| FindAll_Any              | 100 | 1000      | 209.210 us | 2.6888 us | 2.5151 us | 14.03 |    0.40 | 31.0059 | 127.23 KB |       55.39 |
| HashSet_Where_Contains   | 100 | 1000      |   7.782 us | 0.1545 us | 0.1954 us |  0.52 |    0.02 |  1.0071 |   4.13 KB |        1.80 |
| HashSet_FindAll_Contains | 100 | 1000      |   6.988 us | 0.1378 us | 0.1792 us |  0.47 |    0.02 |  0.9918 |   4.05 KB |        1.77 |
| Where_BinarySearch       | 100 | 1000      |  13.303 us | 0.1461 us | 0.1295 us |  0.89 |    0.03 |  0.5493 |    2.3 KB |        1.00 |
| FindAll_BinarySearch     | 100 | 1000      |  13.286 us | 0.2646 us | 0.3532 us |  0.90 |    0.04 |  0.5341 |   2.23 KB |        0.97 |

## Simple shuffled case - medium

| Method                   | ids  | customers |         Mean |      Error |     StdDev | Ratio | RatioSD |     Gen0 |   Gen1 |  Allocated | Alloc Ratio |
| ------------------------ | ---- | --------- | -----------: | ---------: | ---------: | ----: | ------: | -------: | -----: | ---------: | ----------: |
| ForEach                  | 1000 | 10000     |  7,173.17 us | 135.308 us | 119.947 us |  8.56 |    0.18 |        - |      - |   16.22 KB |        0.99 |
| Where_Any                | 1000 | 10000     | 18,743.49 us | 337.161 us | 688.730 us | 22.90 |    1.00 | 281.2500 |      - | 1266.38 KB |       77.37 |
| Where_Contains           | 1000 | 10000     |    837.87 us |  12.826 us |  11.370 us |  1.00 |    0.00 |   3.9063 |      - |   16.37 KB |        1.00 |
| Join                     | 1000 | 10000     |    221.17 us |   3.640 us |   3.404 us |  0.26 |    0.01 |  28.8086 |      - |   118.5 KB |        7.24 |
| FindAll_Contains         | 1000 | 10000     |    799.67 us |   4.756 us |   4.449 us |  0.95 |    0.01 |   3.9063 |      - |    16.3 KB |        1.00 |
| FindAll_Any              | 1000 | 10000     | 18,104.46 us | 212.147 us | 177.152 us | 21.63 |    0.30 | 281.2500 |      - | 1266.31 KB |       77.37 |
| HashSet_Where_Contains   | 1000 | 10000     |    100.52 us |   1.464 us |   1.298 us |  0.12 |    0.00 |   8.1787 | 0.7324 |   33.76 KB |        2.06 |
| HashSet_FindAll_Contains | 1000 | 10000     |     92.02 us |   0.887 us |   0.787 us |  0.11 |    0.00 |   8.1787 |      - |   33.69 KB |        2.06 |
| Where_BinarySearch       | 1000 | 10000     |    196.08 us |   3.869 us |   7.636 us |  0.24 |    0.01 |   3.9063 |      - |   16.37 KB |        1.00 |
| FindAll_BinarySearch     | 1000 | 10000     |    185.69 us |   1.837 us |   1.434 us |  0.22 |    0.00 |   3.9063 |      - |    16.3 KB |        1.00 |

## Simple shuffled case - large

| Method                   | ids   | customers |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |      Gen0 |     Gen1 |    Gen2 |   Allocated | Alloc Ratio |
| ------------------------ | ----- | --------- | -----------: | ---------: | ---------: | -----------: | ----: | ------: | --------: | -------: | ------: | ----------: | ----------: |
| ForEach                  | 10000 | 100000    |   713.256 ms | 14.1595 ms | 18.9025 ms |   703.959 ms |  6.36 |    0.18 |         - |        - |       - |    256.7 KB |        1.00 |
| Where_Any                | 10000 | 100000    | 1,818.698 ms | 35.1901 ms | 29.3854 ms | 1,822.414 ms | 16.21 |    0.49 | 3000.0000 |        - |       - | 12756.85 KB |       49.72 |
| Where_Contains           | 10000 | 100000    |   112.498 ms |  2.1952 ms |  2.5280 ms |   111.085 ms |  1.00 |    0.00 |         - |        - |       - |   256.56 KB |        1.00 |
| Join                     | 10000 | 100000    |     5.338 ms |  0.1460 ms |  0.4141 ms |     5.203 ms |  0.05 |    0.00 |  250.0000 | 210.9375 | 70.3125 |  1372.18 KB |        5.35 |
| FindAll_Contains         | 10000 | 100000    |   109.129 ms |  1.4986 ms |  1.4018 ms |   109.114 ms |  0.97 |    0.03 |         - |        - |       - |   256.47 KB |        1.00 |
| FindAll_Any              | 10000 | 100000    | 1,804.795 ms | 35.8512 ms | 38.3604 ms | 1,790.680 ms | 16.06 |    0.48 | 3000.0000 |        - |       - | 12756.78 KB |       49.72 |
| HashSet_Where_Contains   | 10000 | 100000    |     1.607 ms |  0.0241 ms |  0.0213 ms |     1.601 ms |  0.01 |    0.00 |   78.1250 |  78.1250 | 78.1250 |    414.5 KB |        1.62 |
| HashSet_FindAll_Contains | 10000 | 100000    |     1.524 ms |  0.0299 ms |  0.0584 ms |     1.491 ms |  0.01 |    0.00 |   78.1250 |  78.1250 | 78.1250 |   414.43 KB |        1.62 |
| Where_BinarySearch       | 10000 | 100000    |     3.191 ms |  0.0461 ms |  0.0385 ms |     3.206 ms |  0.03 |    0.00 |   39.0625 |  39.0625 | 39.0625 |   256.48 KB |        1.00 |
| FindAll_BinarySearch     | 10000 | 100000    |     3.538 ms |  0.1231 ms |  0.3452 ms |     3.383 ms |  0.03 |    0.00 |   39.0625 |  39.0625 | 39.0625 |   256.41 KB |        1.00 |

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