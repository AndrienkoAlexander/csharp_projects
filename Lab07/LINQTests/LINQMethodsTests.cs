using Microsoft.VisualStudio.TestTools.UnitTesting;
using LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Tests
{
    [TestClass()]
    public class LINQMethodsTests
    {
        [TestMethod()]
        public void SortTest()
        {
            LINQMethods LINQMethods = new LINQMethods();
            // исходные данные
            Student[] expected = new Student[] { new Student(1,"Александр", "Aндриенко", "Игоревич", Convert.ToDateTime("01.06.1999"), "525", 95.8, 1300),
                        new Student(2,"Иван", "Великий", "Иванович", Convert.ToDateTime("09.08.1999"), "525", 81.6, 1300),
                        new Student(3,"Роман", "Герлиц", "Сергеевич", Convert.ToDateTime("02.02.1998"), "525а", 77, 1300),
                        new Student(4,"Сергей", "Малый", "Романович", Convert.ToDateTime("01.01.1999"), "525б", 92, 1300),
                        new Student(5,"Никита", "Брихунцов", "Владимирович", Convert.ToDateTime("09.07.1997"), "525б", 68, 800)};
            Student[] source = new Student[] { new Student(4,"Сергей", "Малый", "Романович", Convert.ToDateTime("01.01.1999"), "525б", 92, 1300),
                        new Student(2,"Иван", "Великий", "Иванович", Convert.ToDateTime("09.08.1999"), "525", 81.6, 1300),
                        new Student(5,"Никита", "Брихунцов", "Владимирович", Convert.ToDateTime("09.07.1997"), "525б", 68, 800),
                        new Student(3,"Роман", "Герлиц", "Сергеевич", Convert.ToDateTime("02.02.1998"), "525а", 77, 1300),
                        new Student(1,"Александр", "Aндриенко", "Игоревич", Convert.ToDateTime("01.06.1999"), "525", 95.8, 1300)};
            // получение значения с помощью тестируемого метода
            var actual = LINQMethods.Sort(0, true, expected);
            // сравнение ожидаемого результата с полученным
            int i = 0;
            foreach(Student s in actual)
            {
                Assert.AreEqual(s.id, expected[i].id);
                i++;
            }
        }

        [TestMethod()]
        public void SortTest1()
        {
            LINQMethods LINQMethods = new LINQMethods();
            // исходные данные
            Student[] expected = new Student[] { new Student(1,"Aндриенко", "Александр",  "Игоревич", Convert.ToDateTime("01.06.1999"), "525", 95.8, 1300),
                        new Student(5,"Брихунцов","Никита",  "Владимирович", Convert.ToDateTime("09.07.1997"), "525б", 68, 800),
                        new Student(2,"Великий", "Иван",  "Иванович", Convert.ToDateTime("09.08.1999"), "525", 81.6, 1300),
                        new Student(3,"Герлиц", "Роман",  "Сергеевич", Convert.ToDateTime("02.02.1998"), "525а", 77, 1300),
                        new Student(4,"Малый", "Сергей",  "Романович", Convert.ToDateTime("01.01.1999"), "525б", 92, 1300)};
            Student[] source = new Student[] { new Student(4,"Сергей", "Малый", "Романович", Convert.ToDateTime("01.01.1999"), "525б", 92, 1300),
                        new Student(2,"Великий", "Иван",  "Иванович", Convert.ToDateTime("09.08.1999"), "525", 81.6, 1300),
                        new Student(5,"Брихунцов", "Никита",  "Владимирович", Convert.ToDateTime("09.07.1997"), "525б", 68, 800),
                        new Student(3,"Герлиц", "Роман",  "Сергеевич", Convert.ToDateTime("02.02.1998"), "525а", 77, 1300),
                        new Student(1,"Aндриенко","Александр",  "Игоревич", Convert.ToDateTime("01.06.1999"), "525", 95.8, 1300)};
            // получение значения с помощью тестируемого метода
            var actual = LINQMethods.Sort(2, true, expected);
            // сравнение ожидаемого результата с полученным
            int i = 0;
            foreach (Student s in actual)
            {
                Assert.AreEqual(s.second_name, expected[i].second_name);
                i++;
            }
        }

        [TestMethod()]
        public void FiltrationTest()
        {
            LINQMethods LINQMethods = new LINQMethods();
            // исходные данные
            Student[] expected = new Student[] { new Student(4,"Сергей", "Малый", "Романович", Convert.ToDateTime("01.01.1999"), "525б", 92, 1300),
                        new Student(2,"Великий", "Иван",  "Иванович", Convert.ToDateTime("09.08.1999"), "525", 81.6, 1300)};
            Student[] source = new Student[] { new Student(4,"Сергей", "Малый", "Романович", Convert.ToDateTime("01.01.1999"), "525б", 92, 1300),
                        new Student(2,"Великий", "Иван",  "Иванович", Convert.ToDateTime("09.08.1999"), "525", 81.6, 1300),
                        new Student(5,"Брихунцов", "Никита",  "Владимирович", Convert.ToDateTime("09.07.1997"), "525б", 68, 800),
                        new Student(3,"Герлиц", "Роман",  "Сергеевич", Convert.ToDateTime("02.02.1998"), "525а", 77, 1300),
                        new Student(1,"Aндриенко","Александр",  "Игоревич", Convert.ToDateTime("01.06.1999"), "525", 95.8, 1300)};
            // получение значения с помощью тестируемого метода
            var actual = LINQMethods.Filtration(0, "", source);
            // сравнение ожидаемого результата с полученным
            int i = 0;
            foreach (Student s in actual)
            {
                Assert.AreEqual(s.id, expected[i].id);
                i++;
            }
        }

        [TestMethod()]
        public void FiltrationTest1()
        {
            LINQMethods LINQMethods = new LINQMethods();
            // исходные данные
            Student[] expected = new Student[] {new Student(5,"Авдеев","Никита",  "Владимирович", Convert.ToDateTime("09.07.1997"), "525б", 68, 800),
                        new Student(1,"Aндриенко", "Александр",  "Игоревич", Convert.ToDateTime("01.06.1999"), "525", 95.8, 1300)};
            Student[] source = new Student[] { new Student(4,"Сергей", "Малый", "Романович", Convert.ToDateTime("01.01.1999"), "525б", 92, 1300),
                        new Student(2,"Великий", "Иван",  "Иванович", Convert.ToDateTime("09.08.1999"), "525", 81.6, 1300),
                        new Student(5,"Авдеев", "Никита",  "Владимирович", Convert.ToDateTime("09.07.1997"), "525б", 68, 800),
                        new Student(3,"Герлиц", "Роман",  "Сергеевич", Convert.ToDateTime("02.02.1998"), "525а", 77, 1300),
                        new Student(1,"Aндриенко","Александр",  "Игоревич", Convert.ToDateTime("01.06.1999"), "525", 95.8, 1300)};
            // получение значения с помощью тестируемого метода
            var actual = LINQMethods.Filtration(2, "А", source);
            // сравнение ожидаемого результата с полученным
            int i = 0;
            foreach (Student s in actual)
            {
                Assert.AreEqual(s.id, expected[i].id);
                i++;
            }
        }

        [TestMethod()]
        public void GroupingTest()
        {
            LINQMethods LINQMethods = new LINQMethods();
            // исходные данные
            Student[] expected = new Student[] { new Student(4,"Сергей", "Малый", "Романович", Convert.ToDateTime("01.01.1999"), "525б", 92, 1300),
                        new Student(5,"Никита", "Брихунцов", "Владимирович", Convert.ToDateTime("09.07.1997"), "525б", 68, 800),
                        new Student(2,"Иван", "Великий", "Иванович", Convert.ToDateTime("09.08.1999"), "525", 81.6, 1300),
                        new Student(1,"Александр", "Aндриенко", "Игоревич", Convert.ToDateTime("01.06.1999"), "525", 95.8, 1300),
                        new Student(3,"Роман", "Герлиц", "Сергеевич", Convert.ToDateTime("02.02.1998"), "525а", 77, 1300)};
            Student[] source = new Student[] { new Student(4,"Сергей", "Малый", "Романович", Convert.ToDateTime("01.01.1999"), "525б", 92, 1300),
                        new Student(2,"Иван", "Великий", "Иванович", Convert.ToDateTime("09.08.1999"), "525", 81.6, 1300),
                        new Student(5,"Никита", "Брихунцов", "Владимирович", Convert.ToDateTime("09.07.1997"), "525б", 68, 800),
                        new Student(3,"Роман", "Герлиц", "Сергеевич", Convert.ToDateTime("02.02.1998"), "525а", 77, 1300),
                        new Student(1,"Александр", "Aндриенко", "Игоревич", Convert.ToDateTime("01.06.1999"), "525", 95.8, 1300)};
            // получение значения с помощью тестируемого метода
            var actual = LINQMethods.Grouping(0, source);
            // сравнение ожидаемого результата с полученным
            int i = 0;
            foreach (var g in actual)
            {
                foreach (var s in g)
                {
                    Assert.AreEqual(s.group, expected[i].group);
                    i++;
                }
            }
        }

        [TestMethod()]
        public void GroupingTest1()
        {
            LINQMethods LINQMethods = new LINQMethods();
            // исходные данные
            Student[] expected = new Student[] { new Student(1,"Александр", "Aндриенко", "Игоревич", Convert.ToDateTime("01.06.1999"), "525", 95.8, 1300),
                        new Student(2,"Иван", "Великий", "Иванович", Convert.ToDateTime("09.08.1999"), "525", 81.6, 1300),
                        new Student(3,"Роман", "Герлиц", "Сергеевич", Convert.ToDateTime("02.02.1998"), "525а", 77, 1300),
                        new Student(4,"Сергей", "Малый", "Романович", Convert.ToDateTime("01.01.1999"), "525б", 92, 900),
                        new Student(5,"Никита", "Брихунцов", "Владимирович", Convert.ToDateTime("09.07.1997"), "525б", 68, 800)};
            Student[] source = new Student[] { new Student(4,"Сергей", "Малый", "Романович", Convert.ToDateTime("01.01.1999"), "525б", 92, 1300),
                        new Student(2,"Иван", "Великий", "Иванович", Convert.ToDateTime("09.08.1999"), "525", 81.6, 1300),
                        new Student(5,"Никита", "Брихунцов", "Владимирович", Convert.ToDateTime("09.07.1997"), "525б", 68, 1300),
                        new Student(3,"Роман", "Герлиц", "Сергеевич", Convert.ToDateTime("02.02.1998"), "525а", 77, 900),
                        new Student(1,"Александр", "Aндриенко", "Игоревич", Convert.ToDateTime("01.06.1999"), "525", 95.8, 800)};
            // получение значения с помощью тестируемого метода
            var actual = LINQMethods.Grouping(2, source);
            // сравнение ожидаемого результата с полученным
            int i = 0;
            foreach (var g in actual)
            {
                foreach (var s in g)
                {
                    Assert.AreEqual(s.scholarship, expected[i].scholarship);
                    i++;
                }
            }
        }

        [TestMethod()]
        public void AggregateTest()
        {
            LINQMethods LINQMethods = new LINQMethods();
            // исходные данные
            double expected = 5600;
            Student[] source = new Student[] { new Student(4,"Сергей", "Малый", "Романович", Convert.ToDateTime("01.01.1999"), "525б", 92, 1300),
                        new Student(2,"Иван", "Великий", "Иванович", Convert.ToDateTime("09.08.1999"), "525", 81.6, 1300),
                        new Student(5,"Никита", "Брихунцов", "Владимирович", Convert.ToDateTime("09.07.1997"), "525б", 68, 1300),
                        new Student(3,"Роман", "Герлиц", "Сергеевич", Convert.ToDateTime("02.02.1998"), "525а", 77, 900),
                        new Student(1,"Александр", "Aндриенко", "Игоревич", Convert.ToDateTime("01.06.1999"), "525", 95.8, 800)};
            // получение значения с помощью тестируемого метода
            var actual = LINQMethods.Aggregate(2, source);
            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(actual, expected);

        }

        [TestMethod()]
        public void AggregateTest1()
        {
            LINQMethods LINQMethods = new LINQMethods();
            // исходные данные
            double expected = 95.8;
            Student[] source = new Student[] { new Student(4,"Сергей", "Малый", "Романович", Convert.ToDateTime("01.01.1999"), "525б", 92, 1300),
                        new Student(2,"Иван", "Великий", "Иванович", Convert.ToDateTime("09.08.1999"), "525", 81.6, 1300),
                        new Student(5,"Никита", "Брихунцов", "Владимирович", Convert.ToDateTime("09.07.1997"), "525б", 68, 1300),
                        new Student(3,"Роман", "Герлиц", "Сергеевич", Convert.ToDateTime("02.02.1998"), "525а", 77, 900),
                        new Student(1,"Александр", "Aндриенко", "Игоревич", Convert.ToDateTime("01.06.1999"), "525", 95.8, 800)};
            // получение значения с помощью тестируемого метода
            var actual = LINQMethods.Aggregate(0, source);
            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(actual, expected);
        }
    }
}