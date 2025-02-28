using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.NUNIT_TEST
{

    [TestFixture]
    public class DTO_IDPhongTests
    {
        [Test]
        public void Constructor_ShouldInitialize_IdPhong_Correctly()
        {
            // Arrange
            long expectedId = 12345;

            // Act
            DTO_IDPhong phong = new DTO_IDPhong(expectedId);

            // Assert
            Assert.That(phong.IdPhong, Is.EqualTo(expectedId));
        }

        [Test]
        public void Setters_ShouldModify_IdPhong_Correctly()
        {
            // Arrange
            DTO_IDPhong phong = new DTO_IDPhong(1);

            // Act
            phong.IdPhong = 67890;

            // Assert
            Assert.That(phong.IdPhong, Is.EqualTo(67890));
        }

        [Test]
        public void ToString_ShouldReturn_CorrectStringValue()
        {
            // Arrange
            DTO_IDPhong phong = new DTO_IDPhong(555);

            // Act
            string result = phong.ToString();

            // Assert
            Assert.That(result, Is.EqualTo("555"));
        }
    }
}
