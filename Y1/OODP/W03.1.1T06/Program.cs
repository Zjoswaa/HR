class Program {
    public static void Main() {
        const int spdOfLightInMperS = 299792458;
        const double daysInYear = 365.242199;
        const string planetName = "LP 890-9b";
        const double distanceFromEarthInLightYear = 100;

        Console.WriteLine($"The planet {planetName} is {distanceFromEarthInLightYear} lightyears away from Earth");
        Console.WriteLine($"In meters this is {daysInYear * 24 * 60 * 60 * spdOfLightInMperS}");
    }
}
