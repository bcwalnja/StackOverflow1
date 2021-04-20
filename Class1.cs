using NJsonSchema;
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
        }
    }

    class Other
    {
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

        public void KendynsChallenge()
        {
            for (int x = 0; x < 5; x++)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write($"\r");
                    for (int j = 0; j < 10; j++)
                    {
                        if (i == j)
                        {
                            Console.Write("-");
                            continue;
                        }
                        Console.Write("*");
                    }
                    Thread.Sleep(200);
                }
            }
        }
    }
}