using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;


namespace CustomerApp.Core.ApplicationService.Services
{
    public class GroupSpaceProvider : IGroupSpaceProvider
    {
        private readonly IGroupSpaceRepository _groupSpaceRepository;
        public GroupSpaceProvider(IGroupSpaceRepository groupSpaceRepository)
        {
            _groupSpaceRepository = groupSpaceRepository;
        }

        public GroupSpace GetGroupSpace()
        {
            return _groupSpaceRepository.GetGroupSpace();
        }
    }
}
