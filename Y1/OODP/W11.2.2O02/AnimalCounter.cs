static class AnimalCounter {
    public static (int sameSpeciesCount, int sameSpeciesAgeCount) CountOccurrences(Animal[][] Animals, Animal Searched) {
        (int sameSpeciesCount, int sameSpeciesAgeCount) Counter = (0, 0);

        for (int i = 0; i < Animals.Length; i++) {
            for (int j = 0; j < Animals[i].Length; j++) {
                if (Animals[i][j].Species == Searched.Species && Animals[i][j].Age == Searched.Age) {
                    Counter.sameSpeciesAgeCount++;
                }
                if (Animals[i][j].Species == Searched.Species) {
                    Counter.sameSpeciesCount++;
                }
            }
        }

        return Counter;
    }
}
