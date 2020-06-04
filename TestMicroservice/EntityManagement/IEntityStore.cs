using System.Collections.Generic;

namespace TestMicroservice.EntityManagement
{
    public class IEntityStore
    {
        public List<CustomEntity> EntityList { get; set; }
    }

}
