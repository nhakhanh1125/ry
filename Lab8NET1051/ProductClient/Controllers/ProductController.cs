using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using ProductClient.Models;
using System.Net.Http;

namespace ProductClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductController()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5106/api/products/") };
        }

        // 🏷️ Hiển thị danh sách sản phẩm
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync(""); // Gọi API lấy danh sách
                if (!response.IsSuccessStatusCode)
                {
                    return View(new List<Product>()); // Trả về danh sách rỗng nếu lỗi
                }

                var json = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(json);
                return View(products ?? new List<Product>());
            }
            catch (Exception ex)
            {
                // Ghi log lỗi (tuỳ bạn implement)
                return View(new List<Product>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync(id.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    return NotFound(); // Nếu API không tìm thấy sản phẩm
                }

                var json = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(json);

                if (product == null)
                {
                    return NotFound(); // Nếu API trả về null
                }

                return View(product); // ✅ Đảm bảo trả về đúng một đối tượng Product
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // 🏷️ Hiển thị form tạo sản phẩm
        public IActionResult Create() => View();

        // 🏷️ Xử lý tạo sản phẩm
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid) return View(product); // Kiểm tra dữ liệu đầu vào

            try
            {
                var json = JsonConvert.SerializeObject(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("", content);
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", "Lỗi tạo sản phẩm!");
                    return View(product);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi kết nối đến API!");
                return View(product);
            }
        }

        // 🏷️ Hiển thị form chỉnh sửa sản phẩm
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync(id.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    return NotFound();
                }

                var json = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(json);
                return View(product);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // 🏷️ Xử lý chỉnh sửa sản phẩm
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid) return View(product);

            try
            {
                var json = JsonConvert.SerializeObject(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(product.Id.ToString(), content);
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", "Lỗi cập nhật sản phẩm!");
                    return View(product);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi kết nối đến API!");
                return View(product);
            }
        }

        // 🏷️ Xử lý xoá sản phẩm
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(id.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", "Lỗi khi xoá sản phẩm!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi kết nối API!");
            }

            return RedirectToAction("Index");
        }
    }
}
