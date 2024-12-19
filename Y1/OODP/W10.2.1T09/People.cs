using System.Collections;

class People : IEnumerable<Person> {
    private List<Person> Persons = new();

    public IEnumerator<Person> GetEnumerator() {
        foreach (Person person in Persons) {
            yield return person;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public void Add(Person person) {
        this.Persons.Add(person);
    }
}
