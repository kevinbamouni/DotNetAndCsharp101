// See https://aka.ms/new-console-template for more information
using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;

using(var streamReader =  new StreamReader(@"C:\Users\work\source\repos\databasesoft\CsvDataDynamicReader\data\insurance_claims.csv"))
{
    using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
    {
        var records = csvReader.GetRecords<dynamic>().ToList();
    }
}