using MazeLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMaze.Models;

namespace WebMaze.Controllers
{
    public class MazeController : ApiController
    {
        private static IModel mazeModel = new Model();

        // GET: api/Maze
        public IEnumerable<Maze> GetAllMazes()
        {
            return mazeModel.GetAllMazesList();
        }

        // GET: api/Maze/5
     
        public JObject Get(string name, string rows, string cols)
        {

            //return JObject.Parse("{\"name\": \"a\"");
            int mRow = int.Parse(rows);
            int mCol = int.Parse(cols);
            mazeModel.GenerateMaze(name, mRow, mCol);
            return JObject.Parse(mazeModel.GetMaze(name).ToJSON());
        }

        
        public JObject Get(string name)
        {
            return mazeModel.SolveMaze(name);
        }
        

        // POST: api/Maze
        public void Post([FromBody]Maze m)
        {
            mazeModel.AddMaze(m.Name, m);
            //
        }

        // PUT: api/Maze/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Maze/5
        public void Delete(int id)
        {
        }
    }
}
