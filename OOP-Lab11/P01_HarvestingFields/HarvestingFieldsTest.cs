namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);

            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            FieldInfo[] allFields = type.GetFields(flags);

            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                foreach (var field in allFields)
                {
                    bool shouldPrint = false;
                    string accessModifier = string.Empty;

                    if (field.IsPrivate)
                    {
                        accessModifier = "private";
                        if (command == "private" || command == "all")
                        {
                            shouldPrint = true;
                        }
                    }
                    else if (field.IsFamily) 
                    {
                        accessModifier = "protected";
                        if (command == "protected" || command == "all")
                        {
                            shouldPrint = true;
                        }
                    }
                    else if (field.IsPublic)
                    {
                        accessModifier = "public";
                        if (command == "public" || command == "all")
                        {
                            shouldPrint = true;
                        }
                    }

                    if (shouldPrint)
                    {
                        Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
                    }
                }
            }
        }
    }
}