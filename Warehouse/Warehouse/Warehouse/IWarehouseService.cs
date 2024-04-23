namespace Warehouse.Warehouse;

public interface IWarehouseService
{
    Task<int> AddProductToWarehouse(ProductWarehouse productWarehouse);
}