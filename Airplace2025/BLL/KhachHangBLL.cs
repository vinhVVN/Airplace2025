using Airplace2025.BLL.DTO;
using Airplace2025.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Airplace2025.BLL
{
    /// <summary>
    /// Business Logic Layer for KhachHang (Customer)
    /// </summary>
    public class KhachHangBLL
    {
        private static KhachHangBLL _instance;
        public static KhachHangBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new KhachHangBLL();
                return _instance;
            }
        }

        private KhachHangBLL() { }

        /// <summary>
        /// Search customer with validation
        /// </summary>
        public List<KhachHangDTO> SearchCustomer(string searchType, string searchValue)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(searchValue))
                throw new Exception("Vui lòng nhập thông tin tìm kiếm");

            // Validate search type
            string normalizedSearchType = NormalizeSearchType(searchType);

            // Search
            DataTable dt = KhachHangDAO.Instance.SearchCustomer(normalizedSearchType, searchValue.Trim());

            // Convert to DTO
            return ConvertDataTableToList(dt);
        }

        /// <summary>
        /// Smart search - automatically detects search type
        /// </summary>
        public List<KhachHangDTO> SmartSearchCustomer(string searchValue)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(searchValue))
                throw new Exception("Vui lòng nhập thông tin tìm kiếm");

            // Search with auto-detection
            DataTable dt = KhachHangDAO.Instance.SmartSearchCustomer(searchValue.Trim());

            // Convert to DTO
            return ConvertDataTableToList(dt);
        }

        /// <summary>
        /// Convert DataTable to List of KhachHangDTO
        /// </summary>
        private List<KhachHangDTO> ConvertDataTableToList(DataTable dt)
        {
            List<KhachHangDTO> customers = new List<KhachHangDTO>();
            foreach (DataRow row in dt.Rows)
            {
                customers.Add(new KhachHangDTO
                {
                    MaKhachHang = row["MaKhachHang"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    NgaySinh = row["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(row["NgaySinh"]) : (DateTime?)null,
                    GioiTinh = row["GioiTinh"]?.ToString(),
                    DiaChi = row["DiaChi"]?.ToString(),
                    CCCD = row["CCCD"]?.ToString(),
                    SoDienThoai = row["SoDienThoai"]?.ToString(),
                    Email = row["Email"]?.ToString(),
                    LoaiKhachHang = row["LoaiKhachHang"].ToString()
                });
            }
            return customers;
        }

        /// <summary>
        /// Normalize search type for database
        /// </summary>
        private string NormalizeSearchType(string searchType)
        {
            if (string.IsNullOrEmpty(searchType))
                return "HoTen";

            string lower = searchType.ToLower();
            if (lower.Contains("cccd") || lower.Contains("cmnd"))
                return "CCCD";
            else if (lower.Contains("điện thoại") || lower.Contains("phone") || lower.Contains("sdt"))
                return "SoDienThoai";
            else if (lower.Contains("email"))
                return "Email";
            else
                return "HoTen";
        }

        /// <summary>
        /// Create new customer with validation
        /// </summary>
        public string CreateCustomer(KhachHangDTO customer)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(customer.HoTen))
                throw new Exception("Họ tên không được để trống");

            customer.HoTen = customer.HoTen.Trim();

            if (customer.HoTen.Length < 2)
                throw new Exception("Họ tên phải có ít nhất 2 ký tự");

            // Normalize optional fields to null if empty
            if (string.IsNullOrWhiteSpace(customer.DiaChi))
                customer.DiaChi = null;
            else
                customer.DiaChi = customer.DiaChi.Trim();

            // Validate phone number if provided (can be null for children)
            if (!string.IsNullOrEmpty(customer.SoDienThoai))
            {
                customer.SoDienThoai = customer.SoDienThoai.Trim();
                
                // Convert empty string to null to avoid unique constraint violations
                if (string.IsNullOrWhiteSpace(customer.SoDienThoai))
                {
                    customer.SoDienThoai = null;
                }
                else
                {
                    if (customer.SoDienThoai.Length < 10 || customer.SoDienThoai.Length > 15)
                        throw new Exception("Số điện thoại không hợp lệ (10-15 ký tự)");

                    // Check if all characters are digits
                    if (!System.Text.RegularExpressions.Regex.IsMatch(customer.SoDienThoai, @"^\d+$"))
                        throw new Exception("Số điện thoại chỉ được chứa số");
                }
            }

            // Validate email if provided
            if (!string.IsNullOrEmpty(customer.Email))
            {
                customer.Email = customer.Email.Trim(); // Trim white spaces
                
                // Convert empty string to null to avoid unique constraint violations
                if (string.IsNullOrWhiteSpace(customer.Email))
                {
                    customer.Email = null;
                }
                else if (!IsValidEmail(customer.Email))
                {
                    throw new Exception("Email không hợp lệ");
                }
            }

            // Validate CCCD if provided (can be null for children)
            if (!string.IsNullOrEmpty(customer.CCCD))
            {
                customer.CCCD = customer.CCCD.Trim();
                
                // Convert empty string to null to avoid unique constraint violations
                if (string.IsNullOrWhiteSpace(customer.CCCD))
                {
                    customer.CCCD = null;
                }
                else
                {
                    if (customer.CCCD.Length != 12)
                        throw new Exception("CCCD phải có 12 số");

                    if (!System.Text.RegularExpressions.Regex.IsMatch(customer.CCCD, @"^\d+$"))
                        throw new Exception("CCCD chỉ được chứa số");
                }
            }

            // Validate date of birth
            if (customer.NgaySinh.HasValue)
            {
                if (customer.NgaySinh.Value >= DateTime.Now)
                    throw new Exception("Ngày sinh không hợp lệ");

                int age = DateTime.Now.Year - customer.NgaySinh.Value.Year;
                if (customer.NgaySinh.Value.Date > DateTime.Now.AddYears(-age)) age--;

                if (age > 150)
                    throw new Exception("Ngày sinh không hợp lệ");
            }

            // Validate gender
            if (!string.IsNullOrEmpty(customer.GioiTinh))
            {
                if (customer.GioiTinh != "Nam" && customer.GioiTinh != "Nữ" && customer.GioiTinh != "Khác")
                    throw new Exception("Giới tính không hợp lệ");
            }

            // Create customer
            string maKhachHang = KhachHangDAO.Instance.CreateCustomer(
                customer.HoTen,
                customer.NgaySinh,
                customer.GioiTinh,
                customer.DiaChi,
                customer.CCCD,
                customer.SoDienThoai,
                customer.Email,
                customer.LoaiKhachHang ?? "Red"
            );

            return maKhachHang;
        }

        /// <summary>
        /// Validate email format
        /// </summary>
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get customer by ID
        /// </summary>
        public KhachHangDTO GetCustomerById(string maKhachHang)
        {
            if (string.IsNullOrWhiteSpace(maKhachHang))
                throw new Exception("Mã khách hàng không hợp lệ");

            DataRow row = KhachHangDAO.Instance.GetCustomerById(maKhachHang);

            if (row == null)
                return null;

            return new KhachHangDTO
            {
                MaKhachHang = row["MaKhachHang"].ToString(),
                HoTen = row["HoTen"].ToString(),
                NgaySinh = row["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(row["NgaySinh"]) : (DateTime?)null,
                GioiTinh = row["GioiTinh"]?.ToString(),
                DiaChi = row["DiaChi"]?.ToString(),
                CCCD = row["CCCD"]?.ToString(),
                SoDienThoai = row["SoDienThoai"]?.ToString(),
                Email = row["Email"]?.ToString(),
                LoaiKhachHang = row["LoaiKhachHang"].ToString()
            };
        }
    }
}


