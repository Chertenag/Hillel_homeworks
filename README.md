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
