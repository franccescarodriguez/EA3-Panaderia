using Microsoft.AspNetCore.Mvc;
using Panaderia.Mvc.Models;
using System.Text;
using System.Text.Json;

public class ProductosController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductosController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("PanaderiaApi");
        var response = await client.GetAsync("api/productos");

        if (!response.IsSuccessStatusCode)
            return View(new List<ProductoViewModel>());

        var json = await response.Content.ReadAsStringAsync();
        var productos = JsonSerializer.Deserialize<List<ProductoViewModel>>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return View(productos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductoViewModel producto)
    {
        var client = _httpClientFactory.CreateClient("PanaderiaApi");

        var json = JsonSerializer.Serialize(producto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await client.PostAsync("api/productos", content);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("PanaderiaApi");
        var response = await client.GetAsync($"api/productos/{id}");

        var json = await response.Content.ReadAsStringAsync();
        var producto = JsonSerializer.Deserialize<ProductoViewModel>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return View(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, ProductoViewModel producto)
    {
        var client = _httpClientFactory.CreateClient("PanaderiaApi");

        var json = JsonSerializer.Serialize(producto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await client.PutAsync($"api/productos/{id}", content);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("PanaderiaApi");
        await client.DeleteAsync($"api/productos/{id}");
        return RedirectToAction(nameof(Index));
    }
}
