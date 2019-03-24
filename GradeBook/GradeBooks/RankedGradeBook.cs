using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            var sortedList = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToArray();
            var gradeIncrement = (int)(Students.Count * 0.2);

            if (averageGrade >= sortedList[gradeIncrement - 1])
                return 'A';
            if (averageGrade >= sortedList[gradeIncrement * 2 - 1])
                return 'B';
            if (averageGrade >= sortedList[gradeIncrement * 3 - 1])
                return 'C';
            if (averageGrade >= sortedList[gradeIncrement * 4 - 1])
                return 'D';

            return 'F';
        }
    }
}
