using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.NUNIT_TEST
{
    [TestFixture]
    public class DTO_PhongTests
    {
        [Test]
        public void Constructor_ShouldInitialize_AllFields_Correctly()
        {
            // Arrange
            long expectedId = 1;
            string expectedTenPhong = "Phòng VIP";
            long expectedSoLuongGhe = 100;

            // Act
            DTO_Phong phong = new DTO_Phong(expectedId, expectedTenPhong, expectedSoLuongGhe);

            // Assert
            Assert.That(phong.IdPhong, Is.EqualTo(expectedId));
            Assert.That(phong.TenPhong, Is.EqualTo(expectedTenPhong));
            Assert.That(phong.SoLuongGhe, Is.EqualTo(expectedSoLuongGhe));
        }

        [Test]
        public void DefaultConstructor_ShouldInitialize_WithDefaultValues()
        {
            // Act
            DTO_Phong phong = new DTO_Phong();

            // Assert
            Assert.That(phong.IdPhong, Is.EqualTo(0)); // Mặc định là 0
            Assert.That(phong.TenPhong, Is.Null);
            Assert.That(phong.SoLuongGhe, Is.EqualTo(0));
        }

        [Test]
        public void Setters_ShouldModify_Values_Correctly()
        {
            // Arrange
            DTO_Phong phong = new DTO_Phong();

            // Act
            phong.IdPhong = 2;
            phong.TenPhong = "Phòng 4DX";
            phong.SoLuongGhe = 120;

            // Assert
            Assert.That(phong.IdPhong, Is.EqualTo(2));
            Assert.That(phong.TenPhong, Is.EqualTo("Phòng 4DX"));
            Assert.That(phong.SoLuongGhe, Is.EqualTo(120));
        }
    }
}
