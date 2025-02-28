using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.NUNIT_TEST
{
    [TestFixture]
    public class DTO_GheTests
    {
        [Test]
        public void Constructor_ShouldInitialize_Properties_Correctly()
        {
            // Arrange
            long expectedIdGhe = 1;
            int expectedGheSo = 10;
            long expectedIdDayGhe = 2;
            long expectedIdLoaiGhe = 3;

            // Act
            DTO_Ghe ghe = new DTO_Ghe(expectedIdGhe, expectedGheSo, expectedIdDayGhe, expectedIdLoaiGhe);

            // Assert
            Assert.That(ghe.IdGhe, Is.EqualTo(expectedIdGhe));
            Assert.That(ghe.GheSo, Is.EqualTo(expectedGheSo));
            Assert.That(ghe.IdDayGhe, Is.EqualTo(expectedIdDayGhe));
            Assert.That(ghe.IdLoaiGhe, Is.EqualTo(expectedIdLoaiGhe));
        }

        [Test]
        public void DefaultConstructor_ShouldInitialize_DefaultValues()
        {
            // Act
            DTO_Ghe ghe = new DTO_Ghe();

            // Assert
            Assert.That(ghe.IdGhe, Is.EqualTo(0));
            Assert.That(ghe.GheSo, Is.EqualTo(0));
            Assert.That(ghe.IdDayGhe, Is.EqualTo(0));
            Assert.That(ghe.IdLoaiGhe, Is.EqualTo(0));
        }

        [Test]
        public void Setters_ShouldModify_Properties_Correctly()
        {
            // Arrange
            DTO_Ghe ghe = new DTO_Ghe();

            // Act
            ghe.IdGhe = 5;
            ghe.GheSo = 15;
            ghe.IdDayGhe = 25;
            ghe.IdLoaiGhe = 35;

            // Assert
            Assert.That(ghe.IdGhe, Is.EqualTo(5));
            Assert.That(ghe.GheSo, Is.EqualTo(15));
            Assert.That(ghe.IdDayGhe, Is.EqualTo(25));
            Assert.That(ghe.IdLoaiGhe, Is.EqualTo(35));
        }
    }
}
