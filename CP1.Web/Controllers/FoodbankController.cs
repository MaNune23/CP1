using CP1.Architecture;
using CP1.Architecture.Providers;
using CP1.Architecture.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CP1.Web.Controllers;

public class FoodbankController(IRestProvider restProvider, IConfiguration configuration) : Controller
{
    private readonly string _minimalBaseUrl = configuration["Endpoints:MinimalBaseUrl"] ?? "https://localhost:7192";
    private readonly string _apiBaseUrl = configuration["Endpoints:ApiBaseUrl"] ?? "https://localhost:7191";

    private string MinimalEndpoint(string path) => $"{_minimalBaseUrl}{path}";
    private string ApiEndpoint(string path) => $"{_apiBaseUrl}{path}";

    // Listado principal de Foodbank.
    public async Task<IActionResult> Index()
    {
        var json = await restProvider.GetAsync(MinimalEndpoint("/foodbank"), "");

        var complex = JsonProvider.DeserializeSimple<ComplexObject>(json);

        // Minimal devuelve cada registro como texto JSON; aqui se convierte a lista de FoodbankViewModel.
        var jsonStrings = complex?.Entities is null
            ? new List<string>()
            : JsonProvider.DeserializeSimple<List<string>>(JsonProvider.Serialize(complex.Entities)) ?? new List<string>();

        var items = jsonStrings
            .Select(s => JsonProvider.DeserializeSimple<FoodbankViewModel>(s))
            .Where(vm => vm is not null)
            .Cast<FoodbankViewModel>()
            .ToList();

        return View(items);
    }

    // Formulario de creacion.
    public IActionResult Create()
    {
        return View(new FoodbankViewModel());
    }

    // Guardar nuevo registro.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(FoodbankViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        // Esta API recibe un JSON envuelto como texto JSON.
        var innerJson = JsonProvider.Serialize(model);
        var body = JsonProvider.Serialize(innerJson);

        var response = await restProvider.PostAsync(ApiEndpoint("/api/foodbankapi"), body);

        return RedirectToAction(nameof(Index));
    }

    // Formulario de edicion por id (consulta por Minimal).
    public async Task<IActionResult> Edit(int id)
    {
        var json = await restProvider.GetAsync(MinimalEndpoint($"/foodbank/{id}"), "");
        var complex = JsonProvider.DeserializeSimple<ComplexObject>(json);

        // Igual que en Index convertir los textos JSON a FoodbankViewModel.
        var jsonStrings = complex?.Entities is null
            ? new List<string>()
            : JsonProvider.DeserializeSimple<List<string>>(JsonProvider.Serialize(complex.Entities)) ?? new List<string>();

        var item = jsonStrings
            .Select(s => JsonProvider.DeserializeSimple<FoodbankViewModel>(s))
            .Where(vm => vm is not null)
            .Cast<FoodbankViewModel>()
            .FirstOrDefault();

        if (item is null) return NotFound();
        return View(item);
    }

    // Guardar cambios de un registro.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, FoodbankViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        model.FoodItemId = id;

        var innerJson = JsonProvider.Serialize(model);
        var body = JsonProvider.Serialize(innerJson);

        await restProvider.PutAsync(ApiEndpoint("/api/foodbankapi/"), id.ToString(), body);
        return RedirectToAction(nameof(Index));
    }

    // Eliminar registro por id.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await restProvider.DeleteAsync(ApiEndpoint("/api/foodbankapi/"), id.ToString());
        return RedirectToAction(nameof(Index));
    }
}
