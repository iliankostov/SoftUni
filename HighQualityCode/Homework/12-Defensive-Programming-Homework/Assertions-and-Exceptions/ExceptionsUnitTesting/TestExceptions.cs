using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExceptionsUnitTesting
{
    [TestClass]
    public class TestExceptions
    {
        [TestMethod]
        public void TestingMethodSubsequenceWithValidArgs()
        {
            var substr = Exceptions.Subsequence("Hello!".ToCharArray(), 2, 3);
            Assert.AreEqual("llo", string.Join("", substr));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestingMethodSubsequenceWithStartIndexOutOfBounds()
        {
            Exceptions.Subsequence("Hello!".ToCharArray(), 6, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestingMethodSubsequenceWithCountIndexOutOfBounds()
        {
            Exceptions.Subsequence("Hello!".ToCharArray(), 0, -1);
        }

        [TestMethod]
        public void TestingMethodExtractEndingWithValidArgs()
        {
            string ending = Exceptions.ExtractEnding("I love C#", 2);
            Assert.AreEqual("C#", ending);
        }

        [TestMethod]       
        public void TestingMethodExtractEndingWithInvalidCount()
        {
            string invalid = Exceptions.ExtractEnding("I love C#", 10);
            Assert.AreEqual("Invalid count!", invalid);
        }

        [TestMethod]
        public void TestingMethodCalcAverageExamResultInPercentsWithValidArgs()
        {
            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Assert.AreEqual(0.61d, peterAverageResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestingMethodCalcAverageExamResultInPercentsWithNullAsExams()
        {
            Student peter = new Student("Peter", "Petrov", null);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestingMethodCalcAverageExamResultInPercentsWithNoExams()
        {
            List<Exam> peterExams = new List<Exam>();
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestingCSharpExamWithNegativeScore()
        {
            Exam exam = new CSharpExam(-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestingExamWithNegativeScore()
        {
            Exam exam = new CSharpExam(-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestingCreatingNewStudentWithNullArgs()
        {
            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };
            Student peter = new Student(null, "Petrov", peterExams);
        }
    }
}