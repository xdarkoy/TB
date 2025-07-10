using Xunit;
using System.Collections.Generic;
using Moq;
using Server.Services;
using Infrastructure.Repositories;
using Shared;

namespace UnitTests;

public class ContactServiceTests
{
    [Fact]
    public async Task GetContacts_Returns_List()
    {
        var repo = new Mock<IContactRepository>();
        repo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Contact>());
        var mapper = new AutoMapper.Mapper(new AutoMapper.MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        var service = new ContactService(repo.Object, mapper);

        var result = await service.GetContactsAsync();

        Assert.NotNull(result);
    }
}
