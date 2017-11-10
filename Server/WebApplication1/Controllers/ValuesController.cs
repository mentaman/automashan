using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using ReflectionTry;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class ValuesController : ApiController
    {
        public CategoryController controller = new CategoryController(Assembly.LoadFile(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\ClassLibrary2\bin\Debug\ClassLibrary2.dll")));
        
        

        [Route("api/GetAll")]
        public Dictionary<int, SerializeableData> GetAll()
        {
            IdController.SetIdsTo(controller);
            return IdController.GetAll().GetSerializeable().ToDictionary(k => k.Id, v => v);
        }

        /*private Data GetData(int line, string id)
        {
            if (id == 0)
            {
                return controller;
            }
            else
            {
                return lines[line].GetById(id);
            }
        }

        [Route("api/Lines/{line}/Datas/{id}/next")]
        public IEnumerable<SerializeableData> Get(int line, int id)
        {
            return GetData(line, id).GetContinue().GetSerializeable();
        }

        [HttpPost]
        [Route("api/Lines/{line}/Datas/{id}/next/{idx}")]
        public void Post(int line, int id, int idx)
        {
            var data = GetData(line, id);
            var con = data.GetContinue().Skip(idx).First();
            lines[line].Add(con);
        }*/
    }
}
