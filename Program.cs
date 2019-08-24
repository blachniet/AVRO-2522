using System;
using System.Collections.Generic;
using System.IO;
using Avro.File;
using Avro.Specific;
using AvroListOfLists.Records;

namespace AvroListOfLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var myNullableRecord = new MyNullableRecord
            {
                MyNullable = 1,
            };

            var myIListRecord = new MyIListRecord
            {
                MyIList = new List<int> { 1, 2, 3, },
            };

            var listOfListsRecord = new ListOfListsRecord
            {
                MyListOfLists = new List<IList<int>>
                {
                    new List<int>{ 1, 2, 3, },
                    new List<int>{ 4, 5, 6, },
                },
            };

            var listOfNullablesRecord = new ListOfNullablesRecord
            {
                MyListOfNullables = new List<int?>
                {
                    1, null, 3, 4, null, null,
                }
            };

            var listOfNillablesRecord = new ListOfNillablesRecord
            {
                MyListOfNullables = new List<int?>
                {
                    1, null, 3, 4, null, null,
                }
            };

            var matrixRecord = new MatrixRecord
            {
                MyMatrix = new List<IList<IList<int>>>
                {
                    new List<IList<int>>
                    {
                        new List<int> { 1, 2, },
                        new List<int> { 3, 4, },
                    },
                    new List<IList<int>>
                    {
                        new List<int> { 5, 6, },
                        new List<int> { 7, 8, },
                    }
                }
            };

            var matrixOfNullablesRecord = new MatrixOfNullablesRecord
            {
                MyMatrix = new List<IList<IList<int?>>>
                {
                    new List<IList<int?>>
                    {
                        new List<int?> { null, 2, },
                        new List<int?> { 3, 4, },
                    },
                    new List<IList<int?>>
                    {
                        new List<int?> { 5, null, },
                        new List<int?> { null, null, },
                    }
                }
            };

            var matrixOfNillablesRecord = new MatrixOfNillablesRecord
            {
                MyMatrix = new List<IList<IList<int?>>>
                {
                    new List<IList<int?>>
                    {
                        new List<int?> { null, 2, },
                        new List<int?> { 3, 4, },
                    },
                    new List<IList<int?>>
                    {
                        new List<int?> { 5, null, },
                        new List<int?> { null, null, },
                    }
                }
            };

            WriteAndRead(myNullableRecord);
            WriteAndRead(myIListRecord);
            WriteAndRead(listOfListsRecord);
            WriteAndRead(listOfNullablesRecord);
            WriteAndRead(listOfNillablesRecord);
            WriteAndRead(matrixRecord);
            WriteAndRead(matrixOfNullablesRecord);
            WriteAndRead(matrixOfNillablesRecord);
        }
        
        private static void WriteAndRead<T>(T datum)
            where T : ISpecificRecord
        {
            Console.Write($"{typeof(T).Name}");

            try
            {
                var tempFile = Path.GetTempFileName();
                var writer = new SpecificDatumWriter<T>(datum.Schema);

                using (var dfw = DataFileWriter<T>.OpenWriter(writer, tempFile))
                {
                    dfw.Append(datum);
                }

                using (var dfr = DataFileReader<T>.OpenReader(tempFile, datum.Schema))
                {
                    while (dfr.HasNext())
                    {
                        var readDatum = dfr.Next();
                    }
                }


                var prevColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.WriteLine($"✓ {typeof(T).Name}");
                Console.ForegroundColor = prevColor;

            }
            catch (Exception ex)
            {
                var prevColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.WriteLine($"X {typeof(T).Name}");
                Console.ForegroundColor = prevColor;

                if (!ex.Message.Contains("Unable to find type "))
                {
                    Console.WriteLine($"Unexpected Exception: {ex.Message}");
                }
            }
        }
    }
}
