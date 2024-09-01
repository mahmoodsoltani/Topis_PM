using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PM.Models
{
  [MetadataType(typeof(DashboardMetaData))]
    public partial class Dashboard
    {
    }
    public class DashboardMetaData
    {
        [Display(Name = "کل فیلم ها")]
        public int FilmAll { get; set; }

        [Display(Name = " فعال")]
        public int FilmActive { get; set; }

        [Display(Name = "غیر فعال")]
        public int FilmDisable { get; set; }

        [Display(Name = "کل موسیقی ها")]
        public int MusicAll { get; set; }

        [Display(Name = "فعال")]
        public int MusicActive { get; set; }

        [Display(Name = "غیر فعال")]
        public int MusicDisable { get; set; }
        [Display(Name = "کل تلوزیونها")]
        public int TVAll { get; set; }

        [Display(Name = "فعال")]
        public int TVActive { get; set; }

        [Display(Name = "غیر فعال")]
        public int TVDisable { get; set; }

        [Display(Name = "کل شبکه ها")]
        public int ChannelAll { get; set; }

        [Display(Name = "تلوزیونی")]
        public int ChannelActive { get; set; }

        [Display(Name = "رادیویی")]
        public int ChannelDisable { get; set; }

      

        [Display(Name = "اخبار فارسی")]
        public int RssFaAll { get; set; }
        [Display(Name = "تاریخ بروز رسانی")]
        public string RssFaUpdateDate { get; set; }
        [Display(Name = "اخبار انگلیسی")]
        public int RssEnAll { get; set; }
        [Display(Name = "تاریخ بروز رسانی")]
        public string RssEnUpdateDate { get; set; }
        [Display(Name = "اخبار عربی")]
        public int RssArAll { get; set; }
        [Display(Name = "تاریخ بروز رسانی")]
        public string RssArUpdateDate { get; set; }

        [Display(Name = "نرخ ارز")]
        public int RssArsAll { get; set; }
        [Display(Name = "تاریخ بروز رسانی ارز")]
        public string RssArsUpdateDate { get; set; }

        [Display(Name = "تاریخ بروز رسانی آب و هوا")]
        public string WeatherUpdateDate { get; set; }
    }
}

