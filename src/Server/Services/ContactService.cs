using AutoMapper;
using Infrastructure.Repositories;
using Shared;

namespace Server.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _repo;
    private readonly IMapper _mapper;

    public ContactService(IContactRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<ContactDto> CreateAsync(ContactDto dto)
    {
        var contact = _mapper.Map<Contact>(dto);
        await _repo.AddAsync(contact);
        return _mapper.Map<ContactDto>(contact);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var contact = await _repo.GetByIdAsync(id);
        if (contact == null) return false;
        await _repo.DeleteAsync(contact);
        return true;
    }

    public async Task<ContactDto?> GetByIdAsync(int id)
    {
        var contact = await _repo.GetByIdAsync(id);
        return contact == null ? null : _mapper.Map<ContactDto>(contact);
    }

    public async Task<IEnumerable<ContactDto>> GetContactsAsync()
    {
        var contacts = await _repo.GetAllAsync();
        return contacts.Select(c => _mapper.Map<ContactDto>(c));
    }

    public async Task<ContactDto?> UpdateAsync(int id, ContactDto dto)
    {
        var contact = await _repo.GetByIdAsync(id);
        if (contact == null) return null;
        _mapper.Map(dto, contact);
        await _repo.UpdateAsync(contact);
        return _mapper.Map<ContactDto>(contact);
    }
}
