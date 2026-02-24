using CP1.Architecture;
using CP1.Architecture.Mappers;
using CP1.Architecture.Providers;
using CP1.Architecture.ViewModels;
using CP1.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CP1.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodbankApiController(IFoodbankBusiness business) : ControllerBase
{
    [HttpPost]
    public async Task<ComplexObject> Create([FromBody] string complex)
    {
        var result = new ComplexObject();

        var model = JsonProvider.DeserializeSimple<FoodbankViewModel>(complex);
        if (model is null)
        {
            result.Success = false;
            result.Errors.Add("Invalid JSON string body. Expected JSON string representing FoodbankViewModel.");
            return result;
        }

        var ok = await business.CreateFoodItemAsync(model.ToEntity());
        result.Success = ok;
        return result;
    }

    [HttpPut("{id:int}")]
    public async Task<ComplexObject> Update(int id, [FromBody] string complex)
    {
        var result = new ComplexObject();

        var model = JsonProvider.DeserializeSimple<FoodbankViewModel>(complex);
        if (model is null)
        {
            result.Success = false;
            result.Errors.Add("Invalid JSON string body. Expected JSON string representing FoodbankViewModel.");
            return result;
        }

        model.FoodItemId = id;
        var ok = await business.UpdateFoodItemAsync(model.ToEntity());
        result.Success = ok;
        return result;
    }

    [HttpDelete("{id:int}")]
    public async Task<ComplexObject> Delete(int id)
    {
        var result = new ComplexObject();
        var ok = await business.DeleteFoodItemAsync(id);
        result.Success = ok;
        if (!ok) result.Errors.Add("Delete failed (item not found or DB error).");
        return result;
    }
}
