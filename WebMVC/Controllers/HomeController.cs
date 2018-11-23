using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
           
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Pedido").Result;
            return View(response.Content.ReadAsAsync<IEnumerable<Models.PedidoMVC>>().Result);
        }
        public ActionResult AdicionarPedido (int id = 0)
        {
            return View(new Models.PedidoMVC());
        }
        [HttpPost]
        public ActionResult AdicionarPedido(Models.PedidoMVC pedido)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("Pedido", pedido).Result;
            return RedirectToAction("Index");
        }
        public ActionResult EditarPedido(int id = 0)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Pedido/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<Models.PedidoMVC>().Result);
        }
        [HttpPost]
        public ActionResult EditarPedido(Models.PedidoMVC pedido)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.PutAsJsonAsync("Pedido/" + pedido.IdPedido, pedido).Result;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.DeleteAsync("Pedido/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}