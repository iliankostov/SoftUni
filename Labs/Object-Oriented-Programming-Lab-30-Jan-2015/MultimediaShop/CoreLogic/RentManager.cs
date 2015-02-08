namespace CoreLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Enumerables;
    using Interfaces;

    internal class RentManager
    {
        private IList<IRent> rents = new List<IRent>();

        internal IList<IRent> GetOverdueRents()
        {
            var overdueRents = from rent in this.rents
                               where rent.RentState == RentState.Overdue
                               orderby rent.RentFine, rent.RentItem.Title
                               select rent;

            return overdueRents.ToList();
        }

        internal void AddRent(IRent rent)
        {
            this.rents.Add(rent);
        }
    }
}