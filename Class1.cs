﻿using NJsonSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace StackOverflow1
{
    class Class1
    {
        public class L2
        {
            public string Name { get; set; }
            public string contact { get; set; }
            public string address { get; set; }



            public class L1
            {

                public string gender { get; set; }
                public string contact { get; set; }
                public string mail_address { get; set; }
            }

            class Other
            {
                void Stuff()
                {
                    Tuple<L1, L2> list = new Tuple<L1, L2>(null, null);

                    int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 }; int[] numbersB = { 1, 3, 5, 7, 8 };

                    var pairs = from a in numbersA
                                from b in numbersB
                                where a < b
                                select (a, b);

                    Console.WriteLine("Pairs where a < b:");
                    foreach (var (a, b) in pairs)
                    {
                        Console.WriteLine($"{a} is less than {b}");
                    }
                }

                void CoolCursorEffect()
                {
                    Console.WriteLine("A cool cursor effect\n");
                    var array = new char[] { '\\', '|', '/', '―' };
                    var delay = 200;
                    var iterations = 50;

                    for (int i = 0; i < iterations; i++)
                    {
                        for (int j = 0; i < array.Length; i++)
                        {
                            Console.Write($"\r{array[j]}");
                            Thread.Sleep(delay);
                        }
                        for (int j = array.Length - 1; j >= 0; j--)
                        {
                            Console.Write($"\r{array[j]}");
                            Thread.Sleep(delay);
                        }
                    }
                }
            }


            Dictionary<string, Type> GetPropertiesFromDataSchema(JsonSchema schema)
            {
                var propMap = new Dictionary<string, Type>();

                foreach (var prop in schema.ActualProperties)
                {
                    Type type = GetType(prop);
                    if (type != null)
                    {
                        propMap.Add(prop.Key, type);
                        if (type.FullName == "System.Object")
                        {
                            string parentkey = prop.Key.ToString();
                            foreach (var nestedprop in prop.Value.ActualProperties)
                            {
                                type = GetType(nestedprop);
                                string colName = parentkey + "_" + nestedprop.Key;
                                propMap.Add(colName, type);
                            }
                        }

                    }
                }
                return propMap;
            }

            private Type GetType(KeyValuePair<string, JsonSchemaProperty> prop)
            {
                return prop.Value.Type switch
                {
                    JsonObjectType.Boolean => typeof(bool),
                    JsonObjectType.Number => typeof(double),
                    JsonObjectType.Integer => typeof(long),
                    JsonObjectType.Object => typeof(object),
                    JsonObjectType.Array => typeof(Array),
                    JsonObjectType.String => typeof(string),
                    _ => null
                };
            }
        }
    }
}
