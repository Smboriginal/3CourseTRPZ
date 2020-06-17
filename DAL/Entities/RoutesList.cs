namespace DAL.Entities
{
    class RoutesList
    {
        public int MainRouteId { get; set; } //Route id, it storages in DB
        public string Name { get; set; } //it`s name
        public FASTRole Role { get; set; } // using role
        public string Route { get; set; } 

        public RoutesList(int routeId, string name, FASTRole role, string route)
        {
            MainRouteId = routeId;
            Name = name;
            Role = role;
            Route = route;
        }
    }
}
