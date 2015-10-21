﻿namespace Chepelare.Views.Shared
{
    using System.Text;

    using Chepelare.Infrastructure;

    public class Error : View
    {
        public Error(string message)
            : base(message)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var message = this.Model as string;
            viewResult.AppendLine("Something happened!!1").AppendLine(message);
        }
    }
}