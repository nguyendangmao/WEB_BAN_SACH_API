//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BTL_WebBanSach05.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CT_HDBAN
    {
        public int MACT_HDB { get; set; }
        public int MASACH { get; set; }
        public int MAHDBAN { get; set; }
        public int SLBAN { get; set; }
        public string KHUYENMAI { get; set; }
    
        public virtual HOADONBAN HOADONBAN { get; set; }
        public virtual SACH SACH { get; set; }
    }
}
