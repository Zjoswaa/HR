class Player {
    public string Name;
    public int Points;
    public int Skill;
    public int Intelligence;
    public int Knowledge;

    public Player(string Name, int Skill, int Intelligence, int Knowledge) {
        this.Name = Name;
        this.Points = 0;
        this.Skill = Skill;
        this.Intelligence = Intelligence;
        this.Knowledge = Knowledge;
    }

    public void Score() {
        this.Points++;
    }

    public static Player WhoIsWinning(Player Player1, Player Player2) {
        if (Player1.Points == Player2.Points) {
            return null;
        }
        return Player1.Points > Player2.Points ? Player1 : Player2;
    }
}
