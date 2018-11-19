using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerApp.Infrastructure.Data.Repositories
{

    public class GroupSpaceRepository: IGroupSpaceRepository
    {
        private readonly MultigroupSpaceDbContext _context;
        public GroupSpaceRepository(MultigroupSpaceDbContext context)
        {
            _context = context;
        }
    //    private static IList<GroupSpace> groupSpaces = new List<GroupSpace>
    //{
    //    new GroupSpace { Id = MultigroupSpaceDbContext.Tenant1Id, Name = "Imaginary corp", DatabaseConnectionString = "ConnStr1" },
    //    new GroupSpace { Id = MultigroupSpaceDbContext.Tenant2Id, Name = "The Very Big corp", DatabaseConnectionString = "ConnStr2" },
    //};

        public GroupSpace GetGroupSpace()
        {
            return _context.GroupSpaces.First();
        }
    }
}
