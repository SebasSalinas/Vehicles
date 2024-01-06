using Microsoft.VisualStudio.Services.Users;
using Vehicles.API.Data.Entities;
using Vehicles.API.Helpers;
using Vehicles.common.Enums;




namespace Vehicles.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckVehiclesTypeAsync();
            await CheckBrandsAsync();
            await CheckDocumentTypesAsync();
            await CheckProceduresAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Sebastian", "Salinas", "sebas@yopmail.com", "682 320 1180", "Texas", UserType.Admin);
            await CheckUserAsync("2020", "Fulano", "Perez", "fulano@yopmail.com", "682 320 1180", "Texas", UserType.Admin);
            await CheckUserAsync("3030", "Mengano", "Gomez", "mengano@yopmail.com", "682 320 1180", "Texas", UserType.Admin);
        }

        private async Task CheckUserAsync(string document, string firstName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            Entities.User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new Entities.User
                {
                    Address = address,
                    Document = document,
                    DocumentType = _context.DocumentTypes.FirstOrDefault(x => x.Description == "Cedula"),
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType
                };
                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());

        }

        private async Task CheckProceduresAsync()
        {
            if (!_context.Procedures.Any())
            {
                _context.Procedures.Add(new Entities.Procedure { Description = "Alineacion" });
                _context.Procedures.Add(new Entities.Procedure { Description = "Frenos Delanteros" });
                _context.Procedures.Add(new Entities.Procedure { Description = "Frenos Traceros" });
                _context.Procedures.Add(new Entities.Procedure { Description = "Quarter Panel" });
                await _context.SaveChangesAsync();

            }
        }

        private async Task CheckDocumentTypesAsync()
        {
            if (!_context.DocumentTypes.Any())
            {
                _context.DocumentTypes.Add(new Entities.DocumentType { Description = "Cedula" });
                _context.DocumentTypes.Add(new Entities.DocumentType { Description = "Tarjeta de Identidad" });
                _context.DocumentTypes.Add(new Entities.DocumentType { Description = "ID" });
                _context.DocumentTypes.Add(new Entities.DocumentType { Description = "Pasaporte" });
                await _context.SaveChangesAsync();

            }
        }

        private async Task CheckBrandsAsync()
        {
            if (!_context.Brands.Any())
            {
                _context.Brands.Add(new Entities.Brand { Description = "Ford" });
                _context.Brands.Add(new Entities.Brand { Description = "Chevrolet" });
                _context.Brands.Add(new Entities.Brand { Description = "Toyota" });
                _context.Brands.Add(new Entities.Brand { Description = "Honda" });
                await _context.SaveChangesAsync();

            }
        }

        private async Task CheckVehiclesTypeAsync()
        {
            if (!_context.VehicleTypes.Any())
            {
                _context.VehicleTypes.Add(new Entities.VehicleType { Description = "Carro" });
                _context.VehicleTypes.Add(new Entities.VehicleType { Description = "Moto" });
                await _context.SaveChangesAsync();

            }
        }
    }
}
