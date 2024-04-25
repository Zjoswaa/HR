import re


def generate_email():
    email_type = ask_email_type()
    first_name = ask_name(True)
    last_name = ask_name(False)
    job_title = ask_job_title()
    if email_type == "job offer":
        annual_salary = ask_annual_salary()
        starting_date = ask_starting_date()
        print("Here is the final letter to send:")
        print(f"Dear {first_name} {last_name},\n"
              f"After careful evaluation of your application for the position of {job_title}, we are glad to offer"
              f"you the job. Your salary will be {annual_salary} euro annually.\n"
              f"Your start date will be on {starting_date}. Please do not hesitate to contact us with any questions.\n"
              f"Sincerely,\n"
              f"HR Department of XYZ")
    else:
        feedback = ""
        _give_feedback = give_feedback()
        if _give_feedback:
            feedback = ask_feedback()
        print("Here is the final letter to send:")
        print(f"Dear {first_name} {last_name},\n"
              f"After careful evaluation of your application for the position of {job_title}, at this moment we have"
              f"decided to proceed with another candidate.")
        if _give_feedback:
            print(f"Here we would like to provide you our feedback about the interview.\n{feedback}\n")
        print("We wish you the best in finding your future desired career. Please do not hesitate to contact us with"
              "any questions.\n"
              "Sincerely,\nHR Department of XYZ")


def go_again():
    valid = ["yes", "no"]
    while True:
        choice = input().strip().lower()
        if choice in valid:
            if choice == "yes":
                return True
            else:
                return False
        else:
            print("Input error")


def ask_email_type():
    valid = ["job offer", "rejection"]
    while True:
        choice = input().lower()
        if choice in valid:
            return choice
        else:
            print("Input error")


def ask_name(is_first_name):
    valid_pattern = r"[A-Z][a-z]{1,9}"
    while True:
        if is_first_name:
            name = input()
        else:
            name = input()
        if re.match(valid_pattern, name):
            return name
        else:
            print("Input error")


def ask_job_title():
    valid_pattern = r"([A-Z]|[a-z]|[+]|\s){10,}"
    while True:
        job_title = input()
        if re.match(valid_pattern, job_title):
            return job_title
        else:
            print("Input error")


def ask_annual_salary():
    while True:
        annual_salary = input().strip().split(",")
        if ((int(annual_salary[0].replace(".", "")) < 20000 or int(annual_salary[0].replace(".", "")) > 80000)
                or (int(annual_salary[0].replace(".", "")) == 80000 and (int(annual_salary[1].replace(".", "")) != 0))):
            print("Input error")
        else:
            return ','.join(annual_salary)


def ask_starting_date():
    valid_pattern = r"(2021|2022)-(0[1-9]|1[0-2])-([0][1-9]|[1-2][0-9]|3[0-1])"
    while True:
        starting_date = input()
        if re.match(valid_pattern, starting_date):
            return starting_date
        else:
            print("Input error")


def give_feedback():
    valid = ["yes", "no"]
    while True:
        give_feedback = input().strip().lower()
        if give_feedback in valid:
            if give_feedback == "yes":
                return True
            elif give_feedback == "no":
                return False
        else:
            print("Input error")


def ask_feedback():
    feedback = input()
    return feedback


while go_again():
    generate_email()
