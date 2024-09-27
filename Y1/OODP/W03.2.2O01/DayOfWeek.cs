class DayOfWeek {
    private int Index;

    public DayOfWeek(int StartIndex) {
        if (StartIndex < 0) {
            while (StartIndex < 0) {
                StartIndex += 7;
            }
            this.Index = StartIndex;
        } else if (StartIndex > 6) {
            while (StartIndex > 6) {
                StartIndex -= 7;
            }
            this.Index = StartIndex;
        } else {
            this.Index = StartIndex;
        }
    }

    public static string IndexToDay(int Index) {
        switch (Index) {
            case 0:
                return "Monday";
            case 1:
                return "Tuesday";
            case 2:
                return "Wednesday";
            case 3:
                return "Thursday";
            case 4:
                return "Friday";
            case 5:
                return "Saturday";
            case 6:
                return "Sunday";
            default:
                return Index switch {
                    < 0 => IndexToDay(Index + 7),
                    > 6 => IndexToDay(Index - 7)
                };
        }
    }

    public bool IsWeekend() {
        return this.Index == 5 || this.Index == 6;
    }

    public string CurrentDay() {
        switch (this.Index) {
            case 0:
                return "Monday";
            case 1:
                return "Tuesday";
            case 2:
                return "Wednesday";
            case 3:
                return "Thursday";
            case 4:
                return "Friday";
            case 5:
                return "Saturday";
            case 6:
                return "Sunday";
            default:
                return null;
        }
    }

    public void NextDay() {
        this.Index = (this.Index + 1) % 7;
    }
}
