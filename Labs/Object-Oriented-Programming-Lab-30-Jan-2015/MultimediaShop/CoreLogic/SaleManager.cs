namespace CoreLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;

    internal class SaleManager
    {
        private IList<ISale> sales = new List<ISale>();

        internal void AddSale(ISale sale)
        {
            this.sales.Add(sale);
        }

        internal IList<ISale> GetSales(DateTime startDate)
        {
            var sales = from sale in this.sales
                        where sale.SaleDate >= startDate
                        orderby sale.SaleDate
                        select sale;

            return sales.ToList();
        }
    }
}