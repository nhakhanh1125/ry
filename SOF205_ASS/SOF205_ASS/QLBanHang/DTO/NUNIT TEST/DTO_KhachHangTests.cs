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
    public class DTO_KhachHangTests
    {
        [Test]
        public void Constructor_ShouldInitialize_AllFields_Correctly()
        {
            // Arrange
            string expectedPhone = "0123456789";
            string expectedName = "Nguyen Van A";
            string expectedAddress = "123 Street";
            string expectedGender = "Nam";
            string expectedEmail = "a@example.com";

            // Act
            DTO_KhachHang khachHang = new DTO_KhachHang(expectedPhone, expectedName, expectedAddress, expectedGender, expectedEmail);

            // Assert
            Assert.That(khachHang.soDienThoai, Is.EqualTo(expectedPhone));
            Assert.That(khachHang.tenKhach, Is.EqualTo(expectedName));
            Assert.That(khachHang.diaChi, Is.EqualTo(expectedAddress));
            Assert.That(khachHang.phai, Is.EqualTo(expectedGender));
            Assert.That(khachHang.emailNV, Is.EqualTo(expectedEmail));
        }

        [Test]
        public void Constructor_WithoutEmail_ShouldInitialize_Correctly()
        {
            // Arrange
            string expectedPhone = "0987654321";
            string expectedName = "Tran Thi B";
            string expectedAddress = "456 Avenue";
            string expectedGender = "Nữ";

            // Act
            DTO_KhachHang khachHang = new DTO_KhachHang(expectedPhone, expectedName, expectedAddress, expectedGender);

            // Assert
            Assert.That(khachHang.soDienThoai, Is.EqualTo(expectedPhone));
            Assert.That(khachHang.tenKhach, Is.EqualTo(expectedName));
            Assert.That(khachHang.diaChi, Is.EqualTo(expectedAddress));
            Assert.That(khachHang.phai, Is.EqualTo(expectedGender));
            Assert.That(khachHang.emailNV, Is.Null); // Vì email không có trong constructor
        }

        [Test]
        public void Setters_ShouldModify_Values_Correctly()
        {
            // Arrange
            DTO_KhachHang khachHang = new DTO_KhachHang();

            // Act
            khachHang.soDienThoai = "0999888777";
            khachHang.tenKhach = "Le Van C";
            khachHang.diaChi = "789 Street";
            khachHang.phai = "Nam";
            khachHang.emailNV = "c@example.com";

            // Assert
            Assert.That(khachHang.soDienThoai, Is.EqualTo("0999888777"));
            Assert.That(khachHang.tenKhach, Is.EqualTo("Le Van C"));
            Assert.That(khachHang.diaChi, Is.EqualTo("789 Street"));
            Assert.That(khachHang.phai, Is.EqualTo("Nam"));
            Assert.That(khachHang.emailNV, Is.EqualTo("c@example.com"));
        }
    }
}
