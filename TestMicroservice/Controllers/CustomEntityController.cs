using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TestMicroservice.EntityManagement;

namespace TestMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomEntityController : ControllerBase
    {            
        private readonly ILogger<CustomEntityController> _logger;
        private IEntityStore _entityStore;

        public CustomEntityController(ILogger<CustomEntityController> logger, IEntityStore entityStore)
        {
            _logger = logger;
            _entityStore = entityStore;
        }

        //Purpose of below method is to return entire collection of entities in json response.
        [HttpGet]
        public IEnumerable<CustomEntity> Get()
        {
            return _entityStore.EntityList.ToArray();
        }

        //Purpose of below method is to return entity with matching id in json response.
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var entityFound = _entityStore.EntityList.Find(x => x.EntityId == id);
            return new OkObjectResult(entityFound);
        }

        //Purpose of below method is to return collection of entities with similar names in json response.
        [HttpGet("{name}/all")]
        public IActionResult Get(String name)
        {
            var found = _entityStore.EntityList.FindAll(x => x.EntityName == name);
            return new OkObjectResult(found);
        }

        //Purpose of below method is to insert new entity to collection.
        [HttpPost]
        public IActionResult Post()
        {
            //I wanted to insert customentity using json body but couldn't do it through it through Postman maybe because of Guid format.
            //public IActionResult Post([FromBody] CustomEntity customEntity) : 

            CustomEntity customEntity = new CustomEntity(){ EntityId = Guid.NewGuid(), EntityName = "PostEntity" };
            _entityStore.EntityList.Add(customEntity);
            return CreatedAtAction(nameof(Get), new { id = customEntity.EntityId }, customEntity);
        }

    }
}
