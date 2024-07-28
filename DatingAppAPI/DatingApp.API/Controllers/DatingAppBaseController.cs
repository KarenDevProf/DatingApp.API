using AutoMapper;
using DatingApp.BusinessLayer.Exceptions;
using DatingApp.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    public class DatingAppBaseController : Controller
    {
        private readonly IDatingAppServices _services;
        protected IMapper Mapper => _services.GetService<IMapper>();
        public DatingAppBaseController(IDatingAppServices services)
        {
            this._services = services;
        }
        protected void CheckModelState()
        {
            if (!ModelState.IsValid)
                throw new InvalidModelStateException();
        }
    }
}
