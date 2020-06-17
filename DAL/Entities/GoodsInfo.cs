using System.Collections.Generic;

namespace DAL.Entities
{
    /// <summary>
    /// Инфо о загружении запасами
    /// </summary>
    class GoodsInfo
    {
        public List<Desk> InformationDesks { get; set; }
        public List<RegStorage> UserGroups { get; set; }
    }
}
