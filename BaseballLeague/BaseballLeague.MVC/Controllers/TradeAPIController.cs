﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaseballLeague.BLL;
using BaseballLeague.Models;

namespace BaseballLeague.MVC.Controllers
{
    public class TradeAPIController : ApiController
    {
        public HttpResponseMessage Post(Player player)
        {
            var ops = new BaseballBLL();
            ops.TradePlayer((int)player.PlayerID, player.TeamID);

            var response = Request.CreateResponse(HttpStatusCode.Created, player);

            string uri = Url.Link("DefaultApi", new { id = player.PlayerID });
            response.Headers.Location = new Uri(uri);

            return response;

        }
    }
}