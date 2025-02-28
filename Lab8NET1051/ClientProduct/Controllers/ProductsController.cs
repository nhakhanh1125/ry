using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using ClientProduct.Models;
using ProductClient.Models;

namespace ClientProduct.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "http://localhost:5106/api/products";

        public ProductsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Lấy danh sách sản phẩm
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetStringAsync(_apiUrl);
            var products = JsonConvert.DeserializeObject<List<Product>>(response);
            return View(products);
        }

        // Hiển thị chi tiết sản phẩm
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetStringAsync($"{_apiUrl}/{id}");
            var product = JsonConvert.DeserializeObject<Product>(response);
            return View(product);
        }

        // Hiển thị form tạo sản phẩm
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý tạo sản phẩm
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_apiUrl, content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(product);
        }

        // Hiển thị form chỉnh sửa sản phẩm
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetStringAsync($"{_apiUrl}/{id}");
            var product = JsonConvert.DeserializeObject<Product>(response);
            return View(product);
        }

        // Xử lý cập nhật sản phẩm
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_apiUrl}/{id}", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(product);
        }

        // Xóa sản phẩm
        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"{_apiUrl}/{id}");
            return RedirectToAction("Index");
        }
    }
}
