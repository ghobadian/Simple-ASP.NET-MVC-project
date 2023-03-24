using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageComment
    {
        [Key]
        public int CommentID { get; set; }
        [Display(Name = "صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int PageID { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Name { get; set; }
        [Display(Name = "ایمیل")]
        [MaxLength(200)]
        public string Email { get; set; }
        [Display(Name = "وبسایت")]
        public string Website { get; set; }
        [Display(Name = "متن کامنت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string Comment { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public virtual DateTime CreationDate { get; set; }

        public Page Page { get; set; }
        public PageComment()
        {

        }
    }
}
