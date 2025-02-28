using DTO_QLBanHang;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.NUNIT_TEST
{

    [TestFixture]
    public class DTO_HangTests
    {
        [Test]
        public void Constructor_ShouldInitialize_Properties_Correctly()
        {
            // Arrange
            int expectedMaHang = 1;
            string expectedTenHang = "Laptop";
            int expectedSoLuong = 10;
            float expectedDonGiaNhap = 500.5f;
            float expectedDonGiaBan = 600.5f;
            string expectedHinhAnh = "laptop.jpg";
            string expectedGhiChu = "Hàng mới";

            // Act
            DTO_Hang hang = new DTO_Hang(expectedMaHang, expectedTenHang, expectedSoLuong, expectedDonGiaNhap, expectedDonGiaBan, expectedHinhAnh, expectedGhiChu);

            // Assert
            Assert.That(hang.maHang, Is.EqualTo(expectedMaHang));
            Assert.That(hang.tenHang, Is.EqualTo(expectedTenHang));
            Assert.That(hang.soLuong, Is.EqualTo(expectedSoLuong));
            Assert.That(hang.donGiaNhap, Is.EqualTo(expectedDonGiaNhap));
            Assert.That(hang.donGiaBan, Is.EqualTo(expectedDonGiaBan));
            Assert.That(hang.hinhAnh, Is.EqualTo(expectedHinhAnh));
            Assert.That(hang.ghiChu, Is.EqualTo(expectedGhiChu));
        }

        [Test]
        public void Constructor_WithoutMaHang_ShouldInitialize_Properties_Correctly()
        {
            // Arrange
            string expectedTenHang = "Bàn phím";
            int expectedSoLuong = 5;
            float expectedDonGiaNhap = 100.0f;
            float expectedDonGiaBan = 150.0f;
            string expectedHinhAnh = "keyboard.jpg";
            string expectedGhiChu = "Hàng nhập khẩu";
            string expectedEmail = "support@example.com";

            // Act
            DTO_Hang hang = new DTO_Hang(expectedTenHang, expectedSoLuong, expectedDonGiaNhap, expectedDonGiaBan, expectedHinhAnh, expectedGhiChu, expectedEmail);

            // Assert
            Assert.That(hang.tenHang, Is.EqualTo(expectedTenHang));
            Assert.That(hang.soLuong, Is.EqualTo(expectedSoLuong));
            Assert.That(hang.donGiaNhap, Is.EqualTo(expectedDonGiaNhap));
            Assert.That(hang.donGiaBan, Is.EqualTo(expectedDonGiaBan));
            Assert.That(hang.hinhAnh, Is.EqualTo(expectedHinhAnh));
            Assert.That(hang.ghiChu, Is.EqualTo(expectedGhiChu));
            Assert.That(hang.email, Is.EqualTo(expectedEmail));
        }

        [Test]
        public void DefaultConstructor_ShouldInitialize_DefaultValues()
        {
            // Act
            DTO_Hang hang = new DTO_Hang();

            // Assert
            Assert.That(hang.maHang, Is.EqualTo(0));
            Assert.That(hang.tenHang, Is.Null);
            Assert.That(hang.soLuong, Is.EqualTo(0));
            Assert.That(hang.donGiaNhap, Is.EqualTo(0f));
            Assert.That(hang.donGiaBan, Is.EqualTo(0f));
            Assert.That(hang.hinhAnh, Is.Null);
            Assert.That(hang.ghiChu, Is.Null);
            Assert.That(hang.email, Is.Null);
        }

        [Test]
        public void Setters_ShouldModify_Properties_Correctly()
        {
            // Arrange
            DTO_Hang hang = new DTO_Hang();

            // Act
            hang.maHang = 2;
            hang.tenHang = "Chuột không dây";
            hang.soLuong = 20;
            hang.donGiaNhap = 50.0f;
            hang.donGiaBan = 75.0f;
            hang.hinhAnh = "mouse.jpg";
            hang.ghiChu = "Hàng chính hãng";
            hang.email = "contact@store.com";

            // Assert
            Assert.That(hang.maHang, Is.EqualTo(2));
            Assert.That(hang.tenHang, Is.EqualTo("Chuột không dây"));
            Assert.That(hang.soLuong, Is.EqualTo(20));
            Assert.That(hang.donGiaNhap, Is.EqualTo(50.0f));
            Assert.That(hang.donGiaBan, Is.EqualTo(75.0f));
            Assert.That(hang.hinhAnh, Is.EqualTo("mouse.jpg"));
            Assert.That(hang.ghiChu, Is.EqualTo("Hàng chính hãng"));
            Assert.That(hang.email, Is.EqualTo("contact@store.com"));
        }
    }
}
