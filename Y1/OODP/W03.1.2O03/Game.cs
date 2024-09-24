class Game {
    Player Player1;
    Player Player2;

    public Game(Player Player1, Player Player2) {
        this.Player1 = Player1;
        this.Player2 = Player2;
    }

    public Player Round1() {
        if (this.Player1.Skill == this.Player2.Skill) {
            return this.Player1;
        }
        return this.Player1.Skill > this.Player2.Skill ? this.Player1 : this.Player2;
    }

    public Player Round2() {
        if (this.Player1.Intelligence == this.Player2.Intelligence) {
            return this.Player1;
        }
        return this.Player1.Intelligence > this.Player2.Intelligence ? this.Player1 : this.Player2;
    }

    public Player Round3() {
        if (this.Player1.Knowledge == this.Player2.Knowledge) {
            return this.Player1;
        }
        return this.Player1.Knowledge > this.Player2.Knowledge ? this.Player1 : this.Player2;
    }

    public static string Instructions() {
        return $"Win at least 2 rounds to win!";
    }
}
