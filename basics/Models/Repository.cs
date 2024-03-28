namespace basics.Models
{
    public class Repository{

        private static readonly List<Bootcamp> _bootcamp = new();

        static Repository(){
            _bootcamp = new List<Bootcamp>(){
                new Bootcamp() {Id = 1, Title = "Backend Bootcamp", Description = "3 hafta sürecek.", Image = "1.jpg", Tags = new string[] {"aspnet","web geliştirme"},isActive=true,isHome=false},
                new Bootcamp() {Id = 2, Title = "Game Bootcamp", Description = "3 hafta sürecek.", Image = "2.jpg", Tags = new string[] {"aspnet","web geliştirme"},isActive=false,isHome=false},
                new Bootcamp() {Id = 3, Title = "Full Stack Bootcamp", Description = "3 hafta sürecek.", Image = "3.jpg", Tags = new string[] {"aspnet","web geliştirme"},isActive=true,isHome=false},
                new Bootcamp() {Id = 4, Title = "React Bootcamp", Description = "3 hafta sürecek.", Image = "1.jpg", Tags = new string[] {"aspnet","web geliştirme"},isActive=true,isHome=true}
            };
        }

        public static List<Bootcamp> Bootcamps{
            get{
                return _bootcamp;
            }
        }

        public static Bootcamp? GetById(int? id){
            return _bootcamp.FirstOrDefault(c=>c.Id == id);
        }
    }
}