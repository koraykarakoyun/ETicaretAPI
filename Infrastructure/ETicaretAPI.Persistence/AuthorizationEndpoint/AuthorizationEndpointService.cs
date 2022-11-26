using ETicaretAPI.Application.Abstraction.ApplicationServices;
using ETicaretAPI.Application.Abstraction.AuthorizationEndpoint;
using ETicaretAPI.Application.Repositories.Endpoint;
using ETicaretAPI.Application.Repositories.Menu;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.AuthorizationEndpoint
{
    public class AuthorizationEndpointService : IAuthorizationEndpointService
    {

        IMenuReadRepository _menuReadRepository;
        IMenuWriteRepository _menuWriteRepository;
        IEndpointReadRepository _endpointReadRepository;
        IEndpointWriteRepository _endpointWriteRepository;
        IApplicationServices _applicationServices;
        RoleManager<AppRole> _roleManager;

        public AuthorizationEndpointService(IMenuReadRepository menuReadRepository, IMenuWriteRepository menuWriteRepository, IEndpointReadRepository endpointReadRepository, IEndpointWriteRepository endpointWriteRepository, IApplicationServices applicationServices, RoleManager<AppRole> roleManager)
        {
            _menuReadRepository = menuReadRepository;
            _menuWriteRepository = menuWriteRepository;
            _endpointReadRepository = endpointReadRepository;
            _endpointWriteRepository = endpointWriteRepository;
            _applicationServices = applicationServices;
            _roleManager = roleManager;
        }

        public async Task AssingRoleEndpointAsync(string Code, string[] Roles, Type type, string Menu)
        {

            Menu _menu = await _menuReadRepository.GetSingleAsync(m => m.Name == Menu);

            if (_menu == null)
            {
                _menu = new()
                {
                    Id = Guid.NewGuid(),
                    Name = Menu
                };
                await _menuWriteRepository.AddAsync(_menu);
                await _menuWriteRepository.SaveAsync();
            }
            Endpoint? _endpoint = await _endpointReadRepository.Table.Include(t => t.Menu).FirstOrDefaultAsync(m => m.Menu.Name == Menu && m.Code == Code);

            if (_endpoint == null)
            {
                var action = _applicationServices.GetAuthorizeDefinitonEndpoints(type).FirstOrDefault(m => m.Name == Menu)?.Action.FirstOrDefault(a => a.Code == Code);

                _endpoint = new()
                {
                    Code = action.Code,
                    ActionType = action.actionType,
                    Definiton = action.Definiton,
                    HttpType = action.HttpType,
                    Id = Guid.NewGuid(),
                    Menu = _menu
                };

                await _endpointWriteRepository.AddAsync(_endpoint);
                await _endpointWriteRepository.SaveAsync();

            }


            var approles = await _roleManager.Roles.Where(r => Roles.Contains(r.Name)).ToListAsync();

            foreach (var role in approles)
            {
                _endpoint.Roles.Add(role);
            }
            await _endpointWriteRepository.SaveAsync();
    
        }
    }
}
