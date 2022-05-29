using System.ComponentModel.DataAnnotations;

namespace CurrencyExchangeAPI.Models
{
    public class Exchange
    {
        [Key] public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal ValueInUsd { get; set; }
    }
}
