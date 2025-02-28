using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.NUNIT_TEST
{
    [TestFixture]
    public class DTO_SuatPhimTests
    {
        [Test]
        public void Constructor_ShouldInitialize_ID_Phim_Correctly()
        {
            // Arrange
            long expectedIdPhim = 100;

            // Act
            DTO_SuatPhim suatPhim = new DTO_SuatPhim(expectedIdPhim);

            // Assert
            Assert.That(suatPhim.ID_Phim, Is.EqualTo(expectedIdPhim));
        }

        [Test]
        public void DefaultConstructor_ShouldInitialize_ID_Phim_ToZero()
        {
            // Act
            DTO_SuatPhim suatPhim = new DTO_SuatPhim(0);

            // Assert
            Assert.That(suatPhim.ID_Phim, Is.EqualTo(0));
        }

        [Test]
        public void ToString_ShouldReturn_CorrectStringRepresentation()
        {
            // Arrange
            long expectedIdPhim = 200;
            DTO_SuatPhim suatPhim = new DTO_SuatPhim(expectedIdPhim);

            // Act
            string result = suatPhim.ToString();

            // Assert
            Assert.That(result, Is.EqualTo("200"));
        }

        [Test]
        public void Set_ID_Phim_ShouldModifyValue_Correctly()
        {
            // Arrange
            DTO_SuatPhim suatPhim = new DTO_SuatPhim(300);

            // Act
            suatPhim.ID_Phim = 500;

            // Assert
            Assert.That(suatPhim.ID_Phim, Is.EqualTo(500));
        }
    }
}
