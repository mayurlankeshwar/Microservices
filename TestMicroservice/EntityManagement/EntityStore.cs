using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace TestMicroservice.EntityManagement
{
    public class EntityStore : IEntityStore
    {
        private readonly ILogger<EntityStore> _logger;

        public EntityStore(ILogger<EntityStore> logger)
        {
            _logger = logger;
            EntityList = new List<CustomEntity>
            {
                //Add few sample customentities with unique name and unique guid.
                new CustomEntity() { EntityId = Guid.NewGuid(), EntityName = "CustomEntity1" },
                new CustomEntity() { EntityId = Guid.NewGuid(), EntityName = "CustomEntity2" },
                new CustomEntity() { EntityId = Guid.NewGuid(), EntityName = "CustomEntity3" },

                //Add few sample customentities with similar name and unique guid
                new CustomEntity() { EntityId = Guid.NewGuid(), EntityName = "CustomEntity4" },
                new CustomEntity() { EntityId = Guid.NewGuid(), EntityName = "CustomEntity4" },
                new CustomEntity() { EntityId = Guid.NewGuid(), EntityName = "CustomEntity4" },

                //Add few sample customentities with similar name and unique guid
                new CustomEntity() { EntityId = Guid.NewGuid(), EntityName = "CustomEntity5" },
                new CustomEntity() { EntityId = Guid.NewGuid(), EntityName = "CustomEntity5" },

                //Add few sample customentities with similar name and unique guid
                new CustomEntity() { EntityId = Guid.NewGuid(), EntityName = "CustomEntity6" },
                new CustomEntity() { EntityId = Guid.NewGuid(), EntityName = "CustomEntity6" },

            };
        }
    }
}
