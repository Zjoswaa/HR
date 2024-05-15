class PasswordManager:
    def init(self):
        self.old_passwords = []

    def get_password(self):
        """
        Returns the most recent password.
        """
        return self.old_passwords[-1] if self.old_passwords else None

    def set_password(self, new_password):
        """
        Sets a new password if it's not already in the list of old passwords.
        Returns True if successful, False otherwise.
        """
        if new_password not in self.old_passwords:
            self.old_passwords.append(new_password)
            return True
        return False

    def is_correct(self, password):
        """
        Checks if the given password matches the most recent password.
        Returns True if correct, False otherwise.
        """
        return password == self.get_password()
