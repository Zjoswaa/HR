class Robot {
    private int _Power;

    public int Power {
        get => _Power;
        private set => _Power = Math.Max(0, value);
    }
    public bool IsFused { get; private set; }

    public Robot(int Power) {
        this.Power = Power;
        this.IsFused = false;
    }

    private Robot(int Power, bool IsFused) {
        this.Power = Power;
        this.IsFused = IsFused;
    }

    public int Attack() {
        if (IsFused) {
            int ToReturn = Power;
            this.Power /= 2;
            return ToReturn;
        }
        return this.Power;
    }
    
    public static Robot operator +(Robot r1, Robot r2) {
        if (r1 is null && r2 is null) {
            return null;
        }
        if (r1 is null) {
            return r2;
        }
        if (r2 is null) {
            return r1;
        }

        return new Robot(r1.Power + r2.Power, false);
    }

    public static Robot operator *(Robot r1, Robot r2) {
        if (r1 is null && r2 is null) {
            return null;
        }
        if (r1 is null) {
            return r2;
        }
        if (r2 is null) {
            return r1;
        }

        return new Robot(r1.Power * r2.Power, true);
    }
}
