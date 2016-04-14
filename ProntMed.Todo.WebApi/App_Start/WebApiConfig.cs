using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using ProntMed.Todo.WebApi.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Web.Http;

namespace ProntMed.Todo.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //ativa o cors pra eu conseguir acessar lá do angular e tal
            config.EnableCors();

            //Aqui eu to mandando retornar os dados em JSON (JavaScript Object Notation)
            //Json é uma linguagem para intercâmbio de dados, muito melhor que xml, mais leve, mais bonito, mais top
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //pra poder comprimir os dados que vou retornar, vou usar essa dll
            //Install-Package Microsoft.AspNet.WebApi.MessageHandlers.Compression
            //O que isso daqui faz? Ele zipa nossa resposta, com isso consigo diminuir em até 7x o tamanho do meus "todo"
            //Isso é essencial no brasil, onde nossa internet é zuada e a tim cobra quando estora o 3g
            config.MessageHandlers.Insert(0, new ServerCompressionHandler( new GZipCompressor(), new DeflateCompressor()));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
