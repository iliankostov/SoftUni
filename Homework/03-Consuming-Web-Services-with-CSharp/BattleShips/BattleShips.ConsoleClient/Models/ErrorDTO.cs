namespace BattleShips.ConsoleClient.Models
{
    using System.Collections.Generic;

    internal class ErrorDTO
    {
        public string Message { get; set; }

        public IDictionary<string, IEnumerable<string>> ModelState { get; set; }

        public string Error { get; set; }

        public string Error_Description { get; set; }
    }
}