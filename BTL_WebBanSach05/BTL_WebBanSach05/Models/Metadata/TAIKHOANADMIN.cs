using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BTL_WebBanSach05.Models.Metadata
{
    [MetadataTypeAttribute(typeof(TAIKHOANADMINMetadata))]
    public partial class TAIKHOANADMIN
    {
        internal sealed class TAIKHOANADMINMetadata
        {
            public int ID_ADMIN { get; set; }
            [Display(Name = "Số Điện Thoại")]
            [Required(ErrorMessage = "Bạn Phải Nhập 10 Số")]
            [RegularExpression(@"^[0-9]{10}$")]
            public string SDT_ADMIN { get; set; }
            [Display(Name = "Mật khẩu")]
            [Required(ErrorMessage = "Bạn Phải Nhập 10 Số")]
            [RegularExpression(@"^[0-9]{10}$")]
            public string MATKHAU { get; set; }
        }
    }
}

