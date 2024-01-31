namespace LabThree.HiringDate
{
    public struct HireDate
    {
        private int _day;
        private int _month;
        private int _year;

        /// <summary>
        /// Gets or sets the day of the month, ensuring it is valid.
        /// </summary>
        /// <exception cref="Exception">Thrown when the day is not between 1 and 31.</exception>
        public int Day { get => _day; set => _day = ValidDay(value); }
        
        /// <summary>
        /// Gets or sets the month, ensuring it is valid.
        /// </summary>
        /// <exception cref="Exception">Thrown when the month is not between 1 and 12.</exception>
        public int Month { get => _month; set => _month = ValidMonth(value); }
        /// <summary>
        /// Gets or sets the year, ensuring it is valid.
        /// </summary>
        /// <exception cref="Exception">Thrown when the year is not between 1991 and 2024.</exception>
        public int Year { get => _year; set => _year = ValidYear(value); }

        /// <summary>
        /// Initializes a new instance of the <see cref="HireDate"/> class with specified day, month, and year.
        /// </summary>
        /// <param name="day">The day of the month.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        public HireDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        /// <summary>
        /// Validates the day.
        /// </summary>
        /// <param name="day">The day to validate.</param>
        /// <returns>The validated day.</returns>
        /// <exception cref="Exception">Thrown when the day is not between 1 and 31.</exception>
        private int ValidDay(int day)
        {
            if (day > 0 && day <= 31)
            {
                return day;
            }
            else
            {
                throw new Exception("Day must be between 1 - 31");
            }
        }
        
        /// <summary>
        /// Validates the month.
        /// </summary>
        /// /// <param name="month">The month to validate.</param>
        /// <returns>The validated month.</returns>
        /// <exception cref="Exception">Thrown when the month is not between 1 and 12.</exception>
        private int ValidMonth(int month)
        {
            if (month > 0 && month <= 12)
            {
                return month;
            }
            else
            {
                throw new Exception("Month must be between 1 and 12");
            }
        }

        /// <summary>
        /// Validates the year.
        /// </summary>
        /// <param name="year">The year to validate.</param>
        /// <returns>The validated year.</returns>
        /// <exception cref="Exception">Thrown when the year is not between 1991 and 2024.</exception>
        private int ValidYear(int year)
        {
            if (year > 1990 && year <= 2024)
            {
                return year;
            }
            else
            {
                throw new Exception("Year must be between 1991 and 2024");
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current hire date in the format "day/month/year".</returns>
        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }
}


