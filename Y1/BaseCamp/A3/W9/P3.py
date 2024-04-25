class PasswordManager:
    def __init__(self):
        self.old_passwords = []
        self.current_password = None

    def get_password(self):
        return self.current_password

    def set_password(self, new_password: str):
        if new_password != self.current_password:
            if self.current_password is not None:
                self.old_passwords.append(self.current_password)
            self.current_password = new_password

    def is_correct(self, password: str) -> bool:
        return self.current_password == password
