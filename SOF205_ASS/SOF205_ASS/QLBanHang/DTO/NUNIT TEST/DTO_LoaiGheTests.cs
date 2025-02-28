using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.NUNIT_TEST
{
    [TestFixture]
    public class DTO_LoaiGheTests
    {
        [Test]
        public void Constructor_ShouldInitialize_AllFields_Correctly()
        {
            // Arrange
            long expectedId = 1;
            string expectedName = "VIP";
            long expectedPrice = 100000;

            // Act
            DTO_LoaiGhe loaiGhe = new DTO_LoaiGhe(expectedId, expectedName, expectedPrice);

            // Assert
            Assert.That(loaiGhe.IdLoaiGhe, Is.EqualTo(expectedId));
            Assert.That(loaiGhe.TenLoaiGhe, Is.EqualTo(expectedName));
            Assert.That(loaiGhe.Gia, Is.EqualTo(expectedPrice));
        }

        [Test]
        public void DefaultConstructor_ShouldInitialize_WithDefaultValues()
        {
            // Act
            DTO_LoaiGhe loaiGhe = new DTO_LoaiGhe();

            // Assert
            Assert.That(loaiGhe.IdLoaiGhe, Is.EqualTo(0)); // Mặc định là 0
            Assert.That(loaiGhe.TenLoaiGhe, Is.Null); // Mặc định là null
            Assert.That(loaiGhe.Gia, Is.EqualTo(0)); // Mặc định là 0
        }

        [Test]
        public void Setters_ShouldModify_Values_Correctly()
        {
            // Arrange
            DTO_LoaiGhe loaiGhe = new DTO_LoaiGhe();

            // Act
            loaiGhe.IdLoaiGhe = 2;
            loaiGhe.TenLoaiGhe = "Standard";
            loaiGhe.Gia = 50000;

            // Assert
            Assert.That(loaiGhe.IdLoaiGhe, Is.EqualTo(2));
            Assert.That(loaiGhe.TenLoaiGhe, Is.EqualTo("Standard"));
            Assert.That(loaiGhe.Gia, Is.EqualTo(50000));
        }
    }
}
