using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.NUNIT_TEST
{
    [TestFixture]
    public class DTO_VeGheTests
    {
        [Test]
        public void Constructor_ShouldInitializeProperties_Correctly()
        {
            // Arrange
            long expectedIdVeGhe = 1;
            long expectedIdGhe = 101;
            long expectedIdHoaDon = 202;
            long expectedIdSuat = 303;

            // Act
            DTO_VeGhe veGhe = new DTO_VeGhe(expectedIdVeGhe, expectedIdGhe, expectedIdHoaDon, expectedIdSuat);

            // Assert
            Assert.That(veGhe.IdVeGhe, Is.EqualTo(expectedIdVeGhe));
            Assert.That(veGhe.IdGhe, Is.EqualTo(expectedIdGhe));
            Assert.That(veGhe.IdHoaDon, Is.EqualTo(expectedIdHoaDon));
            Assert.That(veGhe.IdSuat, Is.EqualTo(expectedIdSuat));
        }

        [Test]
        public void Properties_ShouldBeSettable()
        {
            // Arrange
            DTO_VeGhe veGhe = new DTO_VeGhe(0, 0, 0, 0);

            // Act
            veGhe.IdVeGhe = 10;
            veGhe.IdGhe = 111;
            veGhe.IdHoaDon = 222;
            veGhe.IdSuat = 333;

            // Assert
            Assert.That(veGhe.IdVeGhe, Is.EqualTo(10));
            Assert.That(veGhe.IdGhe, Is.EqualTo(111));
            Assert.That(veGhe.IdHoaDon, Is.EqualTo(222));
            Assert.That(veGhe.IdSuat, Is.EqualTo(333));
        }
    }
}
