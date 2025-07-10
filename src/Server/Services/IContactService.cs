using Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Services;

public interface IContactService
{
    Task<IEnumerable<ContactDto>> GetContactsAsync();
    Task<ContactDto?> GetByIdAsync(int id);
    Task<ContactDto> CreateAsync(ContactDto dto);
    Task<ContactDto?> UpdateAsync(int id, ContactDto dto);
    Task<bool> DeleteAsync(int id);
}
