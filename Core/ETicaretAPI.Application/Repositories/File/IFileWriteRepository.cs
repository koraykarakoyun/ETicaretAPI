﻿using ETicaretAPI.Domain.Entities.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IFileWriteRepository:IWriteRepository<Domain.Entities.File.File>
    {
    }
}
