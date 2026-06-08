using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Dtos;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("mesa")]
    public class MesaController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public MesaController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

    }
}