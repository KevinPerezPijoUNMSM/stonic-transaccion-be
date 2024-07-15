using Microsoft.AspNetCore.Mvc;
using stonic_transaccion_be.logic;
using stonic_transaccion_be.model;

namespace stonic_transaccion_be.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionB2CController
    {
        [HttpPost]
        public ReturnValue Post([FromBody] TransaccionB2C item)
        {
            TransaccionB2CLogic TB2CLogic = new TransaccionB2CLogic();
            return TB2CLogic.Registrar(item);
        }
    }
}
