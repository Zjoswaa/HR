static class EmailParser {
    public static (string? recipient, string? domain, string? topLevelDomain) ParseEmail(string email) {
        email = email.Trim();
        if (!(email.Contains('@') && email.Contains('.'))) {
            return (null,null,null);
        }
        if (email.StartsWith('@') || email.EndsWith('.') || email.Length < 5) {
            return (null, null, null);
        }

        return (email.Split("@")[0], email.Split("@")[1], email.Split("@")[1].Split(".")[1]);
    }
}
