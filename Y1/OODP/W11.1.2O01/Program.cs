static class Program {
    static void Main() {
        Console.WriteLine("What is the email address?");
        string emailAddress = Console.ReadLine();
        var parsed = EmailParser.ParseEmail(emailAddress);

        if (parsed == (null, null, null)) {
            Console.WriteLine("Invalid email address");
            return;
        }

        Console.WriteLine("User name: " + parsed.recipient);
        Console.WriteLine("Domain name: " + parsed.domain);
        Console.WriteLine("Top-level domain name: " + parsed.topLevelDomain);
    }
}
