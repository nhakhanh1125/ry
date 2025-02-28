using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.NUNIT_TEST
{
    [TestFixture]
    public class DTO_TaiKhoanTests
    {
        [Test]
        public void Constructor_ShouldInitializeProperties_Correctly()
        {
            // Arrange
            long expectedIdTaiKhoan = 1;
            long expectedIdLoaiTaiKhoan = 2;
            string expectedTaiKhoan = "user123";
            string expectedMatKhau = "password";
            string expectedHoTen = "Nguyen Van A";
            string expectedSoDienThoai = "0123456789";
            string expectedDiaChi = "123 Street, City";
            string expectedEmail = "user@example.com";
            int expectedDiemTichLuy = 100;

            // Act
            DTO_TaiKhoan taiKhoan = new DTO_TaiKhoan(expectedIdTaiKhoan, expectedIdLoaiTaiKhoan, expectedTaiKhoan, expectedMatKhau, expectedHoTen, expectedSoDienThoai, expectedDiaChi, expectedEmail, expectedDiemTichLuy);

            // Assert
            Assert.That(taiKhoan.idTaiKhoan, Is.EqualTo(expectedIdTaiKhoan));
            Assert.That(taiKhoan.idLoaiTaiKhoan, Is.EqualTo(expectedIdLoaiTaiKhoan));
            Assert.That(taiKhoan.taiKhoan, Is.EqualTo(expectedTaiKhoan));
            Assert.That(taiKhoan.matKhau, Is.EqualTo(expectedMatKhau));
            Assert.That(taiKhoan.hoTen, Is.EqualTo(expectedHoTen));
            Assert.That(taiKhoan.soDienThoai, Is.EqualTo(expectedSoDienThoai));
            Assert.That(taiKhoan.diaChi, Is.EqualTo(expectedDiaChi));
            Assert.That(taiKhoan.email, Is.EqualTo(expectedEmail));
            Assert.That(taiKhoan.diemTichLuy, Is.EqualTo(expectedDiemTichLuy));
        }

        [Test]
        public void DefaultConstructor_ShouldInitializePropertiesToDefaultValues()
        {
            // Act
            DTO_TaiKhoan taiKhoan = new DTO_TaiKhoan();

            // Assert
            Assert.That(taiKhoan.idTaiKhoan, Is.EqualTo(0));
            Assert.That(taiKhoan.idLoaiTaiKhoan, Is.EqualTo(0));
            Assert.That(taiKhoan.taiKhoan, Is.Null);
            Assert.That(taiKhoan.matKhau, Is.Null);
            Assert.That(taiKhoan.hoTen, Is.Null);
            Assert.That(taiKhoan.soDienThoai, Is.Null);
            Assert.That(taiKhoan.diaChi, Is.Null);
            Assert.That(taiKhoan.email, Is.Null);
            Assert.That(taiKhoan.diemTichLuy, Is.EqualTo(0));
        }

        [Test]
        public void Properties_ShouldBeSettable()
        {
            // Arrange
            DTO_TaiKhoan taiKhoan = new DTO_TaiKhoan();

            // Act
            taiKhoan.idTaiKhoan = 10;
            taiKhoan.idLoaiTaiKhoan = 5;
            taiKhoan.taiKhoan = "newUser";
            taiKhoan.matKhau = "newPassword";
            taiKhoan.hoTen = "Le Thi B";
            taiKhoan.soDienThoai = "0987654321";
            taiKhoan.diaChi = "456 Avenue, City";
            taiKhoan.email = "newuser@example.com";
            taiKhoan.diemTichLuy = 50;

            // Assert
            Assert.That(taiKhoan.idTaiKhoan, Is.EqualTo(10));
            Assert.That(taiKhoan.idLoaiTaiKhoan, Is.EqualTo(5));
            Assert.That(taiKhoan.taiKhoan, Is.EqualTo("newUser"));
            Assert.That(taiKhoan.matKhau, Is.EqualTo("newPassword"));
            Assert.That(taiKhoan.hoTen, Is.EqualTo("Le Thi B"));
            Assert.That(taiKhoan.soDienThoai, Is.EqualTo("0987654321"));
            Assert.That(taiKhoan.diaChi, Is.EqualTo("456 Avenue, City"));
            Assert.That(taiKhoan.email, Is.EqualTo("newuser@example.com"));
            Assert.That(taiKhoan.diemTichLuy, Is.EqualTo(50));
        }
    }
}
