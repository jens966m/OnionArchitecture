using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.DomainService
{
    public interface IGroupSpaceRepository
    {
        GroupSpace GetGroupSpace();
    }
}
