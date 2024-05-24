namespace Bootcamp.Service.Products.DTOs;

public record ProductUpdateDto(string Name, string Barcode, decimal Price, int CategoryId, decimal VatRate);