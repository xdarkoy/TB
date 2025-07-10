using Microsoft.EntityFrameworkCore;
using Shared;

namespace Infrastructure.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly ApplicationDbContext _context;

    public ContactRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contact>> GetAllAsync() => await _context.Contacts.ToListAsync();

    public async Task<Contact?> GetByIdAsync(int id) => await _context.Contacts.FindAsync(id);

    public async Task AddAsync(Contact contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Contact contact)
    {
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Contact contact)
    {
        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();
    }
}
