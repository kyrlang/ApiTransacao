using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiTransacao.Classes;
using ApiTransacao.Models;
using Newtonsoft.Json;

namespace ApiTransacao.Controllers
{
    public class TransacaoController : ApiController
    {

        [HttpPost]
        [Route("api/v1/transacao/cartao")]
        public IHttpActionResult FinalizarCartao([FromBody] Transacao transacao)
        {
            //Usuario usuario = JsonConvert.DeserializeObject<Usuario>(json);

            HttpResponseMessage response;
            response = GlobalVariablesAuth.WebApiClient.PostAsJsonAsync("autenticacao/login", transacao.Usuario).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (transacao != null)
                    return Json(transacao);
                else
                    return NotFound();
            }
            else
                return BadRequest();
                     



        }

    }
}
