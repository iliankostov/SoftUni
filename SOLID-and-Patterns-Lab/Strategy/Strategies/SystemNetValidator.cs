namespace Strategy
{
    using SharpCompiler.Exceptions;

    class SystemNetValidator : ICodeValidationStrategy
    {
        public void Validate(string codeString)
        {
            if (codeString.Contains("using System.Net"))
            {
                throw new CompilationException("Code does not contain using System.Net reference.");
            }
        }
    }
}