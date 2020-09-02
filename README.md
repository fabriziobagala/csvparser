# CsvParser

CsvParser is a simple console application that allows you to perform a search within a [comma-separated values (CSV)](https://en.wikipedia.org/wiki/Comma-separated_values) file.

## Prerequisites

To start the solution, it must be installed in your machine:

- [C# 8.0](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8)
- [.NET Framework 4.8](https://dotnet.microsoft.com/)
- [Visual Studio 2019](https://visualstudio.microsoft.com/)

## Third-Party Libraries

I used the following [Nuget](https://www.nuget.org/) packages:
- [CsvHelper](https://joshclose.github.io/CsvHelper/) is a .NET library for reading and writing CSV files.
- [Castle Windsor](http://www.castleproject.org/) is a mature Inversion of Control container available for .NET.

## Get Started

The application receives as command line arguments the path to a CSV file to import, a column number to search in and a keyword. It is invoked as follows:

    $ CsvParser.exe ./file.csv 2 Alberto

The [CSV](resources/file.csv) file is formatted as in the example below:

    1,Rossi,Fabio,01/06/1990
    2,Gialli,Alessandro,02/07/1989
    3,Verdi,Alberto,03/08/1987
    4,Rossi,Giacomo,12/03/1994

Taking into consideration the arguments passed to the application with the data in the example, the following output will be produced:

    3,Verdi,Alberto,03/08/1987

Before starting the search operation, it checks are carried out on the number of arguments entered and on the arguments themselves. For example, it checks that the specified file exists.

The search is case insensitive, so searching for "Alberto" or "alBertO" in column number 2 will produce the same result. Separate discussion for the ID and date of birth which must be written correctly in order to be found.

In case of equal values, the application will return the first result found.

## License

Licensed under the [GNU General Public License v3.0](LICENSE) license.
