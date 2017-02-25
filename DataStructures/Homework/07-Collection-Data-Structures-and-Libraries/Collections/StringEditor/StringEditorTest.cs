namespace StringEditor
{
    using System;

    internal class StringEditorTest
    {
        private static void Main()
        {
            var stringEditor = new StringEditor();
            string command = string.Empty;
            while (command != "END")
            {
                try
                {
                    var input = Console.ReadLine().Split(' ');
                    command = input[0].ToUpper();

                    switch (command)
                    {
                        case "INSERT":
                            stringEditor.Insert(input);
                            break;
                        case "APPEND":
                            stringEditor.Append(input);
                            break;
                        case "DELETE":
                            stringEditor.Delete(input);
                            break;
                        case "REPLACE":
                            stringEditor.Replace(input);
                            break;
                        case "PRINT":
                            Console.WriteLine(stringEditor.PrintString());
                            break;
                        case "END":
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("INVALID" + " COMMAND");
                    }

                    Console.WriteLine("OK");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("ERROR " + ex.ParamName);
                }
            }
        }
    }
}