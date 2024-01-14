namespace HiringDate
{
    public struct HireDate
    {
        private int _day;
        private int _month;
        private int _year;

        public void SetDay(int day) => _day = day;
        public int GetDay() => _day;

        public void SetMonth(int month) => _month = month;
        public int GetMonth() => _month;

        public void SetYear(int year) => _year = year;
        public int GetYear() => _year;

        public string GetFullHireDate()
        {
            return $"{GetDay().ToString()}/{GetMonth().ToString()}/{GetYear().ToString()}";
        }
    }
}


