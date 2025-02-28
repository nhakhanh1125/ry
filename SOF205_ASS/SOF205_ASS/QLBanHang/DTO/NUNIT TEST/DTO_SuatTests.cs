using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.NUNIT_TEST
{
    [TestFixture]
    public class DTO_SuatTests
    {
        [Test]
        public void Constructor_ShouldInitialize_AllFields_Correctly()
        {
            // Arrange
            long expectedIdSuat = 1;
            long expectedIdPhim = 10;
            long expectedIdPhong = 5;
            DateTime expectedNgayChieu = new DateTime(2025, 3, 10);
            TimeSpan expectedGioChieu = new TimeSpan(18, 30, 0); // 18:30:00

            // Act
            DTO_Suat suat = new DTO_Suat(expectedIdSuat, expectedIdPhim, expectedIdPhong, expectedNgayChieu, expectedGioChieu);

            // Assert
            Assert.That(suat.IdSuat, Is.EqualTo(expectedIdSuat));
            Assert.That(suat.IdPhim, Is.EqualTo(expectedIdPhim));
            Assert.That(suat.IdPhong, Is.EqualTo(expectedIdPhong));
            Assert.That(suat.NgayChieu, Is.EqualTo(expectedNgayChieu));
            Assert.That(suat.GioChieu, Is.EqualTo(expectedGioChieu));
        }

        [Test]
        public void DefaultConstructor_ShouldInitialize_WithDefaultValues()
        {
            // Act
            DTO_Suat suat = new DTO_Suat();

            // Assert
            Assert.That(suat.IdSuat, Is.EqualTo(0)); // Mặc định là 0
            Assert.That(suat.IdPhim, Is.EqualTo(0));
            Assert.That(suat.IdPhong, Is.EqualTo(0));
            Assert.That(suat.NgayChieu, Is.EqualTo(default(DateTime))); // Ngày mặc định
            Assert.That(suat.GioChieu, Is.EqualTo(default(TimeSpan))); // Giờ mặc định
        }

        [Test]
        public void Setters_ShouldModify_Values_Correctly()
        {
            // Arrange
            DTO_Suat suat = new DTO_Suat();

            // Act
            suat.IdSuat = 2;
            suat.IdPhim = 15;
            suat.IdPhong = 7;
            suat.NgayChieu = new DateTime(2025, 5, 20);
            suat.GioChieu = new TimeSpan(20, 45, 0); // 20:45:00

            // Assert
            Assert.That(suat.IdSuat, Is.EqualTo(2));
            Assert.That(suat.IdPhim, Is.EqualTo(15));
            Assert.That(suat.IdPhong, Is.EqualTo(7));
            Assert.That(suat.NgayChieu, Is.EqualTo(new DateTime(2025, 5, 20)));
            Assert.That(suat.GioChieu, Is.EqualTo(new TimeSpan(20, 45, 0)));
        }
    }
}

