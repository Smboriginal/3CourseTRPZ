using System.Collections.Generic;
//Added Entities to DAL
namespace DAL.Entities
{
    class Desk
    {
        public int DeskId { get; set; } //айди доски в сист
        public string Name { get; set; } //ее имя, к примеру Вечерняя_13
        public List<RoutesList> Routes { get; set; }

        /// <summary>
        /// Класс сущности "доска маршрутов" 
        /// </summary>
        /// <param name="deskId">сколько складов - столько и досок</param>
        /// <param name="name">название доски, - в будущем совпадает с номером склада</param>
        /// <param name="routes">Маршруты записываются так: склад 1 - белоцерковка - Буховец - склад 1</param>
        public Desk(int deskId, string name, List<RoutesList> routes)
        {
            DeskId = deskId;
            Name = name;
            Routes = routes;
        }
    }
}
