
using GradeBook.Enums;
using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
	class RankedGradeBook : BaseGradeBook
	{
		public RankedGradeBook(string name) : base(name)
		{
			Type = GradeBookType.Ranked;
		}

		public override char GetLetterGrade (double averageGrade)
		{
			if (Students.Count <5)
			{
				throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
			}
			SortedList<double, double> allGrades = new SortedList<double, double>() ;
			foreach (var student in Students )
			{
				allGrades.Add(student.AverageGrade, student.AverageGrade);
			}
			double twentyPercent = Students.Count / 5;
			switch (averageGrade)
			{
				case double n when n >= allGrades.Values[(int)((twentyPercent  * 5)- 1)]:
					return 'A';
				case double n when n >= allGrades.Values[(int)((twentyPercent * 4) - 1)]:
					return 'B';
				case double n when n >= allGrades.Values[(int)((twentyPercent * 3) - 1)]:
					return 'C';
				case double n when n >= allGrades.Values[(int)((twentyPercent * 2) - 1)]:
					return 'D';
				default:
					break;
					}
			return 'F';
		}

		public override void CalculateStatistics()
		{
			if (Students.Count < 5)
			{
				Console.WriteLine ("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
			}
			else
			{
				base.CalculateStatistics();
			}
			
		}
		public override void CalculateStudentStatistics(string name)
		{
			if (Students.Count < 5)
			{
				Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
			}
			else
			{
				base.CalculateStudentStatistics(name);
			}

		}
	}
}
