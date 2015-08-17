namespace StringEditor
{
    using System.Linq;

    using Wintellect.PowerCollections;

    internal class StringEditor
    {
        private readonly BigList<char> rope;

        public StringEditor()
        {
            this.rope = new BigList<char>();
        }

        public void Insert(string[] input)
        {
            var chars = input[1].Select(ch => ch);
            var startIndex = int.Parse(input[2]);

            this.rope.InsertRange(startIndex, chars);
        }

        public void Append(string[] input)
        {
            var chars = input[1].Select(ch => ch);
            this.rope.AddRange(chars);
        }

        public void Delete(string[] input)
        {
            var startIndex = int.Parse(input[1]);
            var count = int.Parse(input[2]);

            this.rope.RemoveRange(startIndex, count);
        }

        public void Replace(string[] input)
        {
            var startIndex = int.Parse(input[1]);
            var count = int.Parse(input[2]);
            var chars = input[3].Select(ch => ch);

            this.rope.RemoveRange(startIndex, count);
            this.rope.InsertRange(startIndex, chars);
        }

        public string PrintString()
        {
            return string.Join(string.Empty, this.rope);
        }
    }
}