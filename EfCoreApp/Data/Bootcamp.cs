using System.ComponentModel.DataAnnotations;

namespace EfCoreApp.Data
{
    public class Bootcamp{
        [Key]
        public int BootcampId { get; set; }
        public string? Baslik {get;set;}
        public int? EgitmenId {get;set;}
        public Egitmen Egitmen {get;set;} = null!;
        public ICollection<BootcampKayit> BootcampKayit {get;set;} = new List<BootcampKayit>();
    }
}