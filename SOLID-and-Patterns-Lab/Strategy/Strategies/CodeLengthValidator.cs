namespace Strategy
{
    using SharpCompiler.Exceptions;

    class CodeLengthValidator : ICodeValidationStrategy
    {

        public void Validate(string codeString)
        {
            if (codeString.Length < 20)
            {
                throw new CompilationException("Code string is at least 20 characters long.");
            }
        }
    }
}