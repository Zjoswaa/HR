public class DiceBag {
    public List<Die> Dice = new() { }; // contains all Die objects

    /*
        Add a die to the bag.
    */
    public void Add(Die die) {
        Dice.Add(die);
    }

    /*
        Reroll the values of all dice in the bag and print info for each die.
    */
    public void Reroll() => Dice.ForEach(dice => dice.Roll());


    /*
        Custom method like ToString, but prints directly to the console.
    */
    public void Info() {
        this.Dice.ForEach(die => Console.WriteLine(die));
    }
}
