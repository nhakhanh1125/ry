using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.NUNIT_TEST
{
    [TestFixture]
    public class DTO_DayGheTests
    {
        [Test]
        public void Constructor_ShouldInitialize_Properties_Correctly()
        {
            // Arrange
            long expectedIdDayGhe = 1;
            string expectedTenDay = "A";
            long expectedIdPhong = 101;

            // Act
            DTO_DayGhe dayGhe = new DTO_DayGhe(expectedIdDayGhe, expectedTenDay, expectedIdPhong);

            // Assert
            Assert.That(dayGhe.IdDayGhe, Is.EqualTo(expectedIdDayGhe));
            Assert.That(dayGhe.TenDay, Is.EqualTo(expectedTenDay));
            Assert.That(dayGhe.IdPhong, Is.EqualTo(expectedIdPhong));
        }

        [Test]
        public void DefaultConstructor_ShouldInitialize_NullOrDefaultValues()
        {
            // Act
            DTO_DayGhe dayGhe = new DTO_DayGhe();

            // Assert
            Assert.That(dayGhe.IdDayGhe, Is.EqualTo(0));
            Assert.That(dayGhe.TenDay, Is.Null);
            Assert.That(dayGhe.IdPhong, Is.EqualTo(0));
        }

        [Test]
        public void Setters_ShouldModify_Properties_Correctly()
        {
            // Arrange
            DTO_DayGhe dayGhe = new DTO_DayGhe();

            // Act
            dayGhe.IdDayGhe = 2;
            dayGhe.TenDay = "B";
            dayGhe.IdPhong = 202;

            // Assert
            Assert.That(dayGhe.IdDayGhe, Is.EqualTo(2));
            Assert.That(dayGhe.TenDay, Is.EqualTo("B"));
            Assert.That(dayGhe.IdPhong, Is.EqualTo(202));
        }
    }
}