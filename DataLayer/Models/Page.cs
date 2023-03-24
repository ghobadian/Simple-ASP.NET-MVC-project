using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }

        [Display(Name = "گروه صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int GroupId { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250)]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Text { get; set; }
        [Display(Name = "")]
        public int Visit { get; set; }
        [Display(Name = "تعداد بازدید")]
        public string ImageName { get; set; }
        [Display(Name = "نشان در اسلایدر")]
        public bool ShowInSlider { get; set; }
        [Display(Name = "زمان ایجاد")]
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }

        public virtual PageGroup PageGroup { get; set; }

        public virtual List<PageComment> PageComments { get; set; }

        public Page()
        {
            
        }

    }
}
