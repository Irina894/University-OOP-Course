using System;
using System.Reflection;

namespace P02_BlackBoxInteger
{
    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type blackBoxType = typeof(BlackBoxInteger);

            object blackBoxInstance = Activator.CreateInstance(blackBoxType, true);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] parts = input.Split('_');
                string methodName = parts[0];
                int value = int.Parse(parts[1]);

                MethodInfo method = blackBoxType.GetMethod(
                    methodName,
                    BindingFlags.NonPublic | BindingFlags.Instance);

                method.Invoke(blackBoxInstance, new object[] { value });

                FieldInfo field = blackBoxType.GetField(
                    "innerValue",
                    BindingFlags.NonPublic | BindingFlags.Instance);

                int currentValue = (int)field.GetValue(blackBoxInstance);

                Console.WriteLine(currentValue);
            }
        }
    }
}
