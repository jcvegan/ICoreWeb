﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ICoreWeb.Data.Identity.Model;

namespace ICoreWeb.Data.Identity.Service.Interface
{
    public interface IPermissionCategoryDataService
    {
        Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = new CancellationToken());
        Task CreateAsync(string name, CancellationToken cancellationToken = new CancellationToken());
        Task<IEnumerable<CorePermissionCategory>> GetCategoriesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}