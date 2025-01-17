List<Restaurant> restaurants = new List<Restaurant>() {
    new Restaurant() { Name = "De Gouden Draak", City = "Rotterdam", OpeningYear = 1998 },
    new Restaurant() { Name = "De Vergulde lepel", City = "Rotterdam", OpeningYear = 2001 },
    new Restaurant() { Name = "Het Zalmpje", City = "Gouda", OpeningYear = 1998 },
    new Restaurant() { Name = "Wokcity", City = "Utrecht", OpeningYear = 2002 },
    new Restaurant() { Name = "Pizzaria Italia", City = "Utrecht", OpeningYear = 2001 },
    new Restaurant() { Name = "Restaurant Garam Masala", City = "Rotterdam", OpeningYear = 2006 },
    new Restaurant() { Name = "Friethuis Zuid", City = "Rotterdam", OpeningYear = 2012 },
    new Restaurant() { Name = "Pizzaria Della Nonna", City = "Gouda", OpeningYear = 2001 },
    new Restaurant() { Name = "Punjabi Foods", City = "Utrecht", OpeningYear = 2009 },
};

var restaurantsByYear = restaurants.GroupBy(r => r.OpeningYear).Select(g => new {Year = g.Key, Count = g.Count()}).OrderByDescending(e => e.Count).ToList();

foreach (var entry in restaurantsByYear) {
    Console.WriteLine($"{entry.Year}:{entry.Count}");
}
