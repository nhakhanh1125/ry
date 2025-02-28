using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.NUNIT_TEST
{
    [TestFixture]
    public class DTO_PhimTests
    {
        [Test]
        public void Constructor_ShouldInitialize_AllFields_Correctly()
        {
            // Arrange
            long expectedId = 1;
            string expectedTenPhim = "Avengers: Endgame";
            string expectedThoiLuong = "3h 2m";
            string expectedMoTaNgan = "Siêu phẩm Avengers cuối cùng.";
            string expectedDaoDien = "Anthony Russo, Joe Russo";
            string expectedDienVien = "Robert Downey Jr., Chris Evans";
            string expectedHinhAnh1 = "hinh1.jpg";
            string expectedHinhAnh2 = "hinh2.jpg";
            string expectedHinhAnh3 = "hinh3.jpg";
            string expectedHinhAnh4 = "hinh4.jpg";
            string expectedVideo = "trailer.mp4";
            string expectedTheLoai = "Hành động, Phiêu lưu";
            DateTime expectedNgayCongChieu = new DateTime(2019, 4, 26);
            int expectedGioiHanTuoi = 13;
            string expectedDinhDangPhim = "IMAX 3D";
            bool expectedTrangThai = true;

            // Act
            DTO_Phim phim = new DTO_Phim(expectedId, expectedTenPhim, expectedThoiLuong, expectedMoTaNgan,
                                         expectedDaoDien, expectedDienVien, expectedHinhAnh1, expectedHinhAnh2,
                                         expectedHinhAnh3, expectedHinhAnh4, expectedVideo, expectedTheLoai,
                                         expectedNgayCongChieu, expectedGioiHanTuoi, expectedDinhDangPhim, expectedTrangThai);

            // Assert
            Assert.That(phim.IdPhim, Is.EqualTo(expectedId));
            Assert.That(phim.TenPhim, Is.EqualTo(expectedTenPhim));
            Assert.That(phim.ThoiLuong, Is.EqualTo(expectedThoiLuong));
            Assert.That(phim.MoTaNgan, Is.EqualTo(expectedMoTaNgan));
            Assert.That(phim.DaoDien, Is.EqualTo(expectedDaoDien));
            Assert.That(phim.DienVien, Is.EqualTo(expectedDienVien));
            Assert.That(phim.HinhAnh1, Is.EqualTo(expectedHinhAnh1));
            Assert.That(phim.HinhAnh2, Is.EqualTo(expectedHinhAnh2));
            Assert.That(phim.HinhAnh3, Is.EqualTo(expectedHinhAnh3));
            Assert.That(phim.HinhAnh4, Is.EqualTo(expectedHinhAnh4));
            Assert.That(phim.Video, Is.EqualTo(expectedVideo));
            Assert.That(phim.TheLoai, Is.EqualTo(expectedTheLoai));
            Assert.That(phim.NgayCongChieu, Is.EqualTo(expectedNgayCongChieu));
            Assert.That(phim.GioiHanTuoi, Is.EqualTo(expectedGioiHanTuoi));
            Assert.That(phim.DinhDangPhim, Is.EqualTo(expectedDinhDangPhim));
            Assert.That(phim.TrangThai, Is.EqualTo(expectedTrangThai));
        }

        [Test]
        public void DefaultConstructor_ShouldInitialize_WithDefaultValues()
        {
            // Act
            DTO_Phim phim = new DTO_Phim();

            // Assert
            Assert.That(phim.IdPhim, Is.EqualTo(0)); // Mặc định là 0
            Assert.That(phim.TenPhim, Is.Null);
            Assert.That(phim.ThoiLuong, Is.Null);
            Assert.That(phim.MoTaNgan, Is.Null);
            Assert.That(phim.DaoDien, Is.Null);
            Assert.That(phim.DienVien, Is.Null);
            Assert.That(phim.HinhAnh1, Is.Null);
            Assert.That(phim.HinhAnh2, Is.Null);
            Assert.That(phim.HinhAnh3, Is.Null);
            Assert.That(phim.HinhAnh4, Is.Null);
            Assert.That(phim.Video, Is.Null);
            Assert.That(phim.TheLoai, Is.Null);
            Assert.That(phim.NgayCongChieu, Is.EqualTo(default(DateTime))); // Mặc định là 01/01/0001
            Assert.That(phim.GioiHanTuoi, Is.EqualTo(0));
            Assert.That(phim.DinhDangPhim, Is.Null);
            Assert.That(phim.TrangThai, Is.False); // Mặc định là false
        }

        [Test]
        public void Constructor_WithLimitedParameters_ShouldInitialize_Correctly()
        {
            // Arrange
            long expectedId = 2;
            string expectedTenPhim = "Spider-Man: No Way Home";
            string expectedThoiLuong = "2h 30m";
            string expectedDaoDien = "Jon Watts";
            string expectedDienVien = "Tom Holland, Zendaya";
            string expectedTheLoai = "Hành động, Khoa học viễn tưởng";
            DateTime expectedNgayCongChieu = new DateTime(2021, 12, 17);
            int expectedGioiHanTuoi = 13;

            // Act
            DTO_Phim phim = new DTO_Phim(expectedId, expectedTenPhim, expectedThoiLuong, expectedDaoDien,
                                         expectedDienVien, expectedTheLoai, expectedNgayCongChieu, expectedGioiHanTuoi);

            // Assert
            Assert.That(phim.IdPhim, Is.EqualTo(expectedId));
            Assert.That(phim.TenPhim, Is.EqualTo(expectedTenPhim));
            Assert.That(phim.ThoiLuong, Is.EqualTo(expectedThoiLuong));
            Assert.That(phim.DaoDien, Is.EqualTo(expectedDaoDien));
            Assert.That(phim.DienVien, Is.EqualTo(expectedDienVien));
            Assert.That(phim.TheLoai, Is.EqualTo(expectedTheLoai));
            Assert.That(phim.NgayCongChieu, Is.EqualTo(expectedNgayCongChieu));
            Assert.That(phim.GioiHanTuoi, Is.EqualTo(expectedGioiHanTuoi));
        }

        [Test]
        public void Setters_ShouldModify_Values_Correctly()
        {
            // Arrange
            DTO_Phim phim = new DTO_Phim();

            // Act
            phim.IdPhim = 3;
            phim.TenPhim = "Batman";
            phim.ThoiLuong = "2h 45m";
            phim.MoTaNgan = "Một bộ phim siêu anh hùng hấp dẫn.";
            phim.DaoDien = "Matt Reeves";
            phim.DienVien = "Robert Pattinson";
            phim.HinhAnh1 = "batman1.jpg";
            phim.HinhAnh2 = "batman2.jpg";
            phim.HinhAnh3 = "batman3.jpg";
            phim.HinhAnh4 = "batman4.jpg";
            phim.Video = "batman_trailer.mp4";
            phim.TheLoai = "Hành động, Kịch tính";
            phim.NgayCongChieu = new DateTime(2022, 3, 4);
            phim.GioiHanTuoi = 16;
            phim.DinhDangPhim = "4DX";
            phim.TrangThai = true;

            // Assert
            Assert.That(phim.IdPhim, Is.EqualTo(3));
            Assert.That(phim.TenPhim, Is.EqualTo("Batman"));
            Assert.That(phim.ThoiLuong, Is.EqualTo("2h 45m"));
            Assert.That(phim.MoTaNgan, Is.EqualTo("Một bộ phim siêu anh hùng hấp dẫn."));
            Assert.That(phim.DaoDien, Is.EqualTo("Matt Reeves"));
            Assert.That(phim.DienVien, Is.EqualTo("Robert Pattinson"));
            Assert.That(phim.HinhAnh1, Is.EqualTo("batman1.jpg"));
            Assert.That(phim.HinhAnh2, Is.EqualTo("batman2.jpg"));
            Assert.That(phim.HinhAnh3, Is.EqualTo("batman3.jpg"));
            Assert.That(phim.HinhAnh4, Is.EqualTo("batman4.jpg"));
            Assert.That(phim.Video, Is.EqualTo("batman_trailer.mp4"));
            Assert.That(phim.TheLoai, Is.EqualTo("Hành động, Kịch tính"));
            Assert.That(phim.NgayCongChieu, Is.EqualTo(new DateTime(2022, 3, 4)));
            Assert.That(phim.GioiHanTuoi, Is.EqualTo(16));
            Assert.That(phim.DinhDangPhim, Is.EqualTo("4DX"));
            Assert.That(phim.TrangThai, Is.True);
        }
    }
}
