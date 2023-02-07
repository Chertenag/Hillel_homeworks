## Hillel_hw_5
Консольное приложение, которое принимает на вход строку текста, ищет слова которые повторяются (без учёта регистра) и удаляет дубликаты. 
## BenchmarkTests

Проект тестирования трёх подходов использования regex из Hillel_hw_5. А именно сгенирированного с помощью атрибута GeneretadRegex, с флагом Compiled и без него.<br />
Первая группа тестов, тестирует regex "\b(?<dubl1>\w+)\b(?<dubl2>\s\b\<dubl1>)\b"<br />
Вторая группа тестов, тестирует regex "(?<dubl1>\w+)(?<dubl2>\s\<dubl1>)"<br />

#### Benchmark test results
``` ini
BenchmarkDotNet=v0.13.4, OS=Windows 10 (10.0.19044.2364/21H2/November2021Update)
11th Gen Intel Core i5-11400H 2.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
```

|            Method |     Mean |     Error |    StdDev |
|------------------ |---------:|----------:|----------:|
|  GeneretedReplace | 4.629 μs | 0.0196 μs | 0.0174 μs |
|   CompiledReplace | 1.781 μs | 0.0042 μs | 0.0039 μs |
|    DefaultReplace | 4.496 μs | 0.0141 μs | 0.0132 μs |
| GeneretedReplace2 | 8.518 μs | 0.0193 μs | 0.0181 μs |
|  CompiledReplace2 | 2.147 μs | 0.0048 μs | 0.0042 μs |
|   DefaultReplace2 | 8.470 μs | 0.0216 μs | 0.0168 μs |

## Hillel_hw_6_ClassLibrary
Библиотека классов (или точнее всего 1 класс). Содержит следующие методы:
1. Метод, который меняет местами значени двух целочисельных переменных.
2. Метод, который возвращает вторым аргументом количество цифр в первом аргументе.
3. Метод, который возвращает третьим аргументом символ из текста (1ый аргумент) по индексу (2ой аргумент).

## Hillel_hw_6_MSTests
Проект MSTest`ов методов из библиотеки Hillel_hw_6_ClassLibrary.

## Hillel_hw_7
Проект который содержит benchmark тесты на сравнения скорости работы обычной конкатенации строк (разными способами) и с использованием StringBuilder`а.
Тестирование проводилось на сгенерированных строках случайной длинны из заданного диапазона. 

``` ini
BenchmarkDotNet=v0.13.4, OS=Windows 10 (10.0.19044.2364/21H2/November2021Update)
11th Gen Intel Core i5-11400H 2.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
```

#### 10 строк 100-200 символов
|                     Method |     Mean |   Error |  StdDev |
|--------------------------- |---------:|--------:|--------:|
|       StringPlusStringPlus | 171.2 ns | 1.05 ns | 0.88 ns |
|          StringPlusInCycle | 713.5 ns | 5.90 ns | 5.23 ns |
| StringBuilderAppendInCycle | 443.9 ns | 2.18 ns | 1.93 ns |
|   StringContactListToArray | 176.0 ns | 0.93 ns | 0.77 ns |
|      StringJoinListToArray | 203.2 ns | 0.53 ns | 0.50 ns |

#### 10 строк 2500-3000 символов
|                     Method |      Mean |     Error |    StdDev |
|--------------------------- |----------:|----------:|----------:|
|       StringPlusStringPlus |  2.853 μs | 0.0154 μs | 0.0137 μs |
|          StringPlusInCycle | 13.623 μs | 0.0647 μs | 0.0605 μs |
| StringBuilderAppendInCycle |  5.505 μs | 0.0456 μs | 0.0404 μs |
|   StringContactListToArray |  2.898 μs | 0.0077 μs | 0.0072 μs |
|      StringJoinListToArray |  2.954 μs | 0.0255 μs | 0.0239 μs |

#### 50 строк 100-200 символов
|                     Method |        Mean |     Error |    StdDev |
|--------------------------- |------------:|----------:|----------:|
|       StringPlusStringPlus |    812.4 ns |  12.00 ns |  11.22 ns |
|          StringPlusInCycle | 15,518.8 ns | 253.65 ns | 237.26 ns |
| StringBuilderAppendInCycle |  1,924.9 ns |  19.26 ns |  18.01 ns |
|   StringContactListToArray |    789.1 ns |   3.79 ns |   3.55 ns |
|      StringJoinListToArray |    909.5 ns |  12.09 ns |  10.72 ns |

#### 50 строк 2500-3000 символов
|                     Method |        Mean |     Error |    StdDev |
|--------------------------- |------------:|----------:|----------:|
|       StringPlusStringPlus |    90.71 μs |  1.249 μs |  1.169 μs |
|          StringPlusInCycle | 1,589.65 μs | 12.567 μs | 11.755 μs |
| StringBuilderAppendInCycle |   117.24 μs |  0.428 μs |  0.379 μs |
|   StringContactListToArray |    90.50 μs |  1.293 μs |  1.210 μs |
|      StringJoinListToArray |    91.54 μs |  0.851 μs |  0.796 μs |

#### 100 строк 100-200 символов
|                     Method |      Mean |     Error |    StdDev |
|--------------------------- |----------:|----------:|----------:|
|       StringPlusStringPlus |  1.835 μs | 0.0133 μs | 0.0118 μs |
|          StringPlusInCycle | 59.163 μs | 0.7173 μs | 0.6359 μs |
| StringBuilderAppendInCycle |  3.402 μs | 0.0267 μs | 0.0249 μs |
|   StringContactListToArray |  1.722 μs | 0.0081 μs | 0.0072 μs |
|      StringJoinListToArray |  1.789 μs | 0.0202 μs | 0.0169 μs |

#### 100 строк 2500-3500 символов
|                     Method |       Mean |    Error |   StdDev |
|--------------------------- |-----------:|---------:|---------:|
|       StringPlusStringPlus |   183.3 μs |  3.00 μs |  2.81 μs |
|          StringPlusInCycle | 3,106.3 μs | 41.47 μs | 38.79 μs |
| StringBuilderAppendInCycle |   244.5 μs |  4.39 μs |  4.10 μs |
|   StringContactListToArray |   183.2 μs |  1.68 μs |  1.58 μs |
|      StringJoinListToArray |   182.6 μs |  2.47 μs |  2.31 μs |

#### 500 строк 100-200 символов
|                     Method |        Mean |     Error |    StdDev |
|--------------------------- |------------:|----------:|----------:|
|          StringPlusInCycle | 3,296.25 μs | 30.206 μs | 28.255 μs |
| StringBuilderAppendInCycle |    66.80 μs |  0.847 μs |  0.793 μs |
|   StringContactListToArray |    50.36 μs |  0.519 μs |  0.486 μs |
|      StringJoinListToArray |    51.28 μs |  0.515 μs |  0.482 μs |

#### 500 строк 2500-3000 символов
|                     Method |         Mean |       Error |      StdDev |
|--------------------------- |-------------:|------------:|------------:|
|          StringPlusInCycle | 127,657.4 μs | 2,485.03 μs | 2,958.25 μs |
| StringBuilderAppendInCycle |   3,073.3 μs |    60.79 μs |   122.79 μs |
|   StringContactListToArray |     326.6 μs |     5.74 μs |     5.37 μs |
|      StringJoinListToArray |     328.3 μs |     4.85 μs |     4.53 μs |

Для простоты далее в тексте примем следющие обозначения:
* Метод_1 - str = str1 + str2 + str3
* Метод_2 - str += strList[i] в цикле for
* Метод_3 - StringBuilder.Append(strList[i]) в цикле for
* Метод_4 - String.Concat(strList.ToArray())
* Метод_5 - String.Join("", strList.ToArray())

Исходя из полученных результатов можно сделать следующие выводы:
1. **Метод_2** при любом количестве строк любой длины является найхудшим вариантом. Чем больше и длинеей строки, тем сильнее разрыв в скорости работы метода. (В худшем случае тест показал разницу в ~150 раз).
2. **Метод_1** тестировался только для 10, 50 и 100 строк (тесты №1-6). Результаты практически одинаковы с **Метод_4** и **Метод_5**. Разница крайне незначительна.
Но так как написание кода для данного метода является крайне неудобным и подходит, разве что, для малого количества строк, использование не рекомендуется.
3. **Метод_4** и **Метод_5** во всех тестах (кроме теста №1 и №2) показал практически идентичные результаты. В тестах №1 и №3 **Метод_4** оказался еффективнее на 13-14%.
4. **Метод_3** во всех результатах оказался на 2ом месте по скорости. Только в тестах №4, №6 и №7 результы отстают от **Метод_4** и **Метод_5**, на ~33%. Во всех остальных разница в 2 и более раз.

В итоге найболее еффективным в данных тестах оказался **Метод_4** и использование **Метод_3** (StringBuilder) не рекомендуется ни в одном из **_проверенных_** случаев. 
