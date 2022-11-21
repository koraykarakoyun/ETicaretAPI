using ETicaretAPI.Application.Abstraction.ApplicationServices;
using ETicaretAPI.Application.CustomAttributes;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Action = ETicaretAPI.Application.DTOs.Action;

namespace ETicaretAPI.Infrastructure.Services.ApplicationServices
{
    public class ApplicationServices : IApplicationServices
    {
        public List<Menu> GetAuthorizeDefinitonEndpoints(Type type)
        {
            List<Menu> menus = new();
            Assembly assembly = Assembly.GetAssembly(type);
            var controllers = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ControllerBase)));
            foreach (var controller in controllers)
            {
                var actions=controller.GetMethods().Where(f => f.IsDefined(typeof(AuthorizeDefinitionAttribute)));
                foreach (var action in actions)
                {
                    var customAttributes=action.GetCustomAttributes();
                    if (customAttributes != null)
                    {
                        //Menu
                        Menu menu = null;
                        var authorizeAttribute = customAttributes.FirstOrDefault(a => a.GetType() == typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;
                        if (!menus.Any(a => a.Name == authorizeAttribute.Menu))
                        {
                          menu= new Menu() { Name = authorizeAttribute.Menu };
                          menus.Add(menu);
                        }
                        else
                        {
                          menu= menus.FirstOrDefault(a => a.Name == authorizeAttribute.Menu);
                        }


                        //Menu Action
                        Action _action = new() {
                            actionType= Enum.GetName(typeof(ActionType), authorizeAttribute.ActionType)
                            ,Definiton= authorizeAttribute.Definiton
                        };
                        var httpAttribute = customAttributes.FirstOrDefault(a => a.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;
                        if (httpAttribute!=null)
                        {
                           _action.HttpType=httpAttribute.HttpMethods.First();
                        }
                        else 
                        {
                            _action.HttpType = "Get";
                        }
                        menu.Action.Add(_action);

                        _action.Code= $"{_action.HttpType}.{_action.actionType}.{_action.Definiton.Replace(" ", "")}";




                    }

                }

            }

            return menus;

        }

    }
}
