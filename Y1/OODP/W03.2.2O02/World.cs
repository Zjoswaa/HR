using System.Numerics;
using System.Threading;

static class World {
    //Player
    public static readonly List<int> ExperienceChart = new() { 10, 25, 45, 75, 115, 160, 235, 300 };
    public static readonly int PlayerBaseHP = 30;
    public static readonly int PlayerBaseStrength = 20;

    //Monsters
    //Regular
    //Bat
    public static readonly string BatName = "Bat";
    public static readonly int BatHP = 5;
    public static readonly int BatStrength = 10;
    public static readonly int BatExperience = 15;
    //Skeleton
    public static readonly string SkeletonName = "Skeleton";
    public static readonly int SkeletonHP = 15;
    public static readonly int SkeletonStrength = 15;
    public static readonly int SkeletonExperience = 20;
    //Zombie
    public static readonly string ZombieName = "Zombie";
    public static readonly int ZombieHP = 20;
    public static readonly int ZombieStrength = 10;
    public static readonly int ZombieExperience = 20;
    //Bosses
    //Vampire
    public static readonly string VampireName = "Vampire";
    public static readonly int VampireHP = 80;
    public static readonly int VampireStrength = 25;
    public static readonly int VampireExperience = 100;

    //Spawning
    //Player
    public static Player SpawnPlayer() => new Player(PlayerBaseHP, PlayerBaseStrength);
    //Regular
    public static Monster SpawnBat() => new Monster(BatName, BatHP, BatStrength, BatExperience);
    public static Monster SpawnSkeleton() => new Monster(SkeletonName, SkeletonHP, SkeletonStrength, SkeletonExperience);
    public static Monster SpawnZombie() => new Monster(ZombieName, ZombieHP, ZombieStrength, ZombieExperience);
    //Boss
    public static Monster SpawnVampire() => new Monster(VampireName, VampireHP, VampireStrength, VampireExperience);
}
