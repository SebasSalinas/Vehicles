using System.Drawing.Text;
using Vehicles.API.Data;
using Vehicles.API.Data.Entities;
using Vehicles.API.Models;

namespace Vehicles.API.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelpers;

        public ConverterHelper(DataContext context, ICombosHelper combosHelpers)
        {
            _context = context;
            _combosHelpers = combosHelpers;
        }

        public async Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool isNew)
        {
            return new User
            {
                Address = model.Address,
                Document = model.Document,
                DocumentType = await _context.DocumentTypes.FindAsync(model.DocumentTypeId),
                Email = model.Email,
                FirstName = model.FirstName,
                Id = isNew ? Guid.NewGuid().ToString() : model.Id,
                //ImageID = imageId,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName,
                UserType = model.UserType,
                Vehicles = model.Vehicles,
            };
        }

        public UserViewModel ToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Address = user.Address,
                Document = user.Document,
                DocumentType = user.DocumentType,
                DocumentTypeId = user.DocumentType.Id,
                DocumentTypes = _combosHelpers.GetComboDocumentTypes(),
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                UserType = user.UserType,
                Vehicles = user.Vehicles,
            };
        }
    }
}
