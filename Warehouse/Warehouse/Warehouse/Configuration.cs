namespace Warehouse.Warehouse;

public static class Configuration
{
    public static void RegisterEndpointsForWarehouse(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/warehouse", async (IWarehouseService service, ProductWarehouse productWarehouse) =>
        {
            try
            {
                var recordId = await service.AddProductToWarehouse(productWarehouse);
                return TypedResults.Created("Record created with id: ", recordId);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Results.Problem(detail: "An unexpected error occurred.", statusCode: 500);
            }
        });
    }
}