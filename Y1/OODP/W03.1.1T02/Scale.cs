class Scale {
    public bool UseKg = true;

    public static double ConvertKgToLbs(double Kgs) {
        return Kgs * 2.2;
    }

    public string DisplayWeight(double Weight) {
        return this.UseKg ? $"{Weight} kg" : $"{ConvertKgToLbs(Weight)} lbs";
    }
}
