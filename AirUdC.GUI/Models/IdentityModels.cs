using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AirUdC.GUI.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que authenticationType debe coincidir con el valor definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar reclamaciones de usuario personalizadas aquí
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<AirUdC.GUI.Models.Parameters.CountryModel> CountryModels { get; set; }

        public System.Data.Entity.DbSet<AirUdC.GUI.Models.Parameters.CityModel> CityModels { get; set; }

        object placeHolderVariable;
        public System.Data.Entity.DbSet<AirUdC.GUI.Models.Manager.CustomerModel> CustomerModels { get; set; }

        public System.Data.Entity.DbSet<AirUdC.GUI.Models.Manager.PropertyOwnerModel> PropertyOwnerModels { get; set; }

        public System.Data.Entity.DbSet<AirbnbUdC.Repository.Implementation.DataModel.Feedback> Feedbacks { get; set; }

        public System.Data.Entity.DbSet<AirbnbUdC.Repository.Implementation.DataModel.Reservation> Reservations { get; set; }

        public System.Data.Entity.DbSet<AirbnbUdC.Repository.Implementation.DataModel.PropertyMultimedia> PropertyMultimedias { get; set; }

        public System.Data.Entity.DbSet<AirbnbUdC.Repository.Implementation.DataModel.MultimediaType> MultimediaTypes { get; set; }

        public System.Data.Entity.DbSet<AirbnbUdC.Repository.Implementation.DataModel.Property> Properties { get; set; }

        public System.Data.Entity.DbSet<AirUdC.GUI.Models.Manager.ReservationModel> ReservationModels { get; set; }
    }
}