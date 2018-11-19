using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.ApplicationService
{
    public interface IGroupSpaceProvider
    {
        GroupSpace GetGroupSpace();
    }
}
