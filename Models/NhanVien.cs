﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaiTap6.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    public partial class NhanVien
    {
        public int Id { get; set; }
        [DisplayName("Mã nhân viên")]
        public string maNhanVien { get; set; }
        [DisplayName("Họ")]

        public string hoNhanVien { get; set; }
        [DisplayName("Tên")]

        public string tenNhanVien { get; set; }
        [DisplayName("Giới tính")]

        public bool gioiTinh { get; set; }
        [DisplayName("Ngày sinh")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public System.DateTime ngaySinh { get; set; }
        [DisplayName("Lương")]

        public Nullable<decimal> luong { get; set; }
        [DisplayName("Ảnh nhân viên")]

        public string anhNhanVien { get; set; }
        public HttpPostedFileBase empImg { get; set; }
        [DisplayName("Địa chỉ")]

        public string diaChi { get; set; }
        [DisplayName("Mã phòng ban")]

        public string maPhongBan { get; set; }
    
        public virtual PhongBan PhongBan { get; set; }
    }
}
