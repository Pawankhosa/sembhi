using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LLRM.Areas.Auth.Models
{
    public class Home
    {

    }
    public class slider
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string Image { get; set; }

    }
    public class News
    {
        public int id { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string Image { get; set; }

    }
    public class Campuslife
    {
        public int id{ get; set; }
        public string Image { get; set; }
    }
    public class Tour
    {
        public int id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Url { get; set; }
        public string Image { get; set; }
    }
    public class Pages
    {
        public int id { get; set; }
        public string PageName { get; set; }
        

        [AllowHtml]
        public string Description { get; set; }
        public string Image { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }

    }
    public class Service
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="Service Name")]
        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        public string Thumbnail { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        

    }
   
    public class Album
    {
        [Key]
        public int albumid { get; set; }
        public string AlbumName { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Gallery> Galleries { get; set; }

    }
    public class Gallery
    {
        [Key]
        public int GalleryId { get; set; }
        [DisplayName("Album")]
        public int Albumid { get; set; }

        public virtual Album Albums { get; set; }
        public string Name { get; set; }
        public string Thumb { get; set; }
        public string Image { get; set; }
    }

    public class Contact
    {
        public int id { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
     
    }
}