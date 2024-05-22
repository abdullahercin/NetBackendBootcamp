using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Service.Products.DTOs
{
    public record ProductCreateDto(string Name, decimal Price, int CategoryId, decimal VatRate, string Barcode);
}
