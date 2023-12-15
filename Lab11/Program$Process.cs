using ConsoleDialogLib;
using ConsoleIOLib;
using Lab10Lib.Entities;

namespace Lab11
{
    public partial class Program
    {

        private static void Task1Process()
        {
            Task1Collection1Process();
            ConsoleIO.WriteLine(null);
            Task1Collection2Process();
            ConsoleIO.WriteLine(null);
            Task1Collection3Process();
            ConsoleIO.WriteLine(null);
            Task1Collection4Process();
        }

        private static void Task2Process()
        {
            Student student = new();
            var isRandom = (bool?)ConsoleDialog.ShowDialog(ChoiceInputMethodDialog());
            if (isRandom is null)
            {
                ConsoleIO.WriteLine(Messages.ChoiceInputMethodDialogCancel);
                return;
            }
            else if (isRandom == true) // Самый тупой NullSafety, кт я видел
            {
                student.RandomInit();
            }
            else
            {
                student.Init();
            }
            ConsoleIO.WriteLineFormat(Messages.Student, student);
            ConsoleIO.WriteLine(collections.Add(student) ? Messages.AddTrue : Messages.AddFalse);
        }

        private static void Task3Process()
        {
            Student student = new();
            var isRandom = (bool?)ConsoleDialog.ShowDialog(ChoiceInputMethodDialog());
            if (isRandom is null)
            {
                ConsoleIO.WriteLine(Messages.ChoiceInputMethodDialogCancel);
                return;
            }
            else if (isRandom == true) // дубль 2
            {
                student.RandomInit();
            }
            else
            {
                student.Init();
            }
            ConsoleIO.WriteLineFormat(Messages.Student, student);
            ConsoleIO.WriteLine(collections.Remove(student) ? Messages.RemoveTrue : Messages.RemoveFalse);
        }

        private static void Task4Process()
        {
            if (collections.Length == 0)
                ConsoleIO.WriteLine(Messages.EmptyCollections);
            else
                foreach (var item in collections.students)
                    ConsoleIO.WriteLine(item);
        }

        private static void Task1Collection1Process()
        {
            foreach (var keyValuePair in new Dictionary<string, Student>() {
                {Messages.FirstElement, collections.students.First().ShallowCopy()},
                {
                    Messages.CenterElement,
                    TestCollections.StackElementAt(
                        collections.students,
                        collections.students.Count / 2
                    ).ShallowCopy()
                },
                {Messages.LastElement, collections.students.Last().ShallowCopy()},
                {Messages.NonIncludedElement, new()},
            })
            {
                var (status, time) = Search.SearchInStack(
                    collections.students,
                    keyValuePair.Value
                );
                ConsoleIO.WriteLineFormat(
                    Messages.Task1Process,
                    keyValuePair.Key,
                    Messages.StackStudent,
                    status
                        ? Messages.StatusFound
                        : Messages.StatusNotFound,
                    time
                );
            }
        }

        private static void Task1Collection2Process()
        {
            foreach (var keyValuePair in new Dictionary<string, string>() {
                {Messages.FirstElement, collections.strings.First()},
                {
                    Messages.CenterElement,
                    TestCollections.StackElementAt(
                        collections.strings,
                        collections.strings.Count / 2
                    )
                },
                {Messages.LastElement, collections.strings.Last()},
                {Messages.NonIncludedElement, "nothing here"},
            })
            {
                var (status, time) = Search.SearchInStack(
                    collections.strings,
                    keyValuePair.Value
                );
                ConsoleIO.WriteLineFormat(
                    Messages.Task1Process,
                    keyValuePair.Key,
                    Messages.StackString,
                    status
                        ? Messages.StatusFound
                        : Messages.StatusNotFound,
                    time
                );
            }
        }

        private static void Task1Collection3Process()
        {
            foreach (var keyValuePair in new Dictionary<string, Person>() {
                {Messages.FirstElement, collections.studentsByPerson.Keys.First().ShallowCopy()},
                {
                    Messages.CenterElement,
                    collections.studentsByPerson.Keys.ElementAt(collections.studentsByPerson.Count / 2).ShallowCopy()
                },
                {Messages.LastElement, collections.studentsByPerson.Keys.Last().ShallowCopy()},
                {Messages.NonIncludedElement, new()},
            })
            {
                var (status, time) = Search.SearchInDictionaryByKey(
                    collections.studentsByPerson,
                    keyValuePair.Value
                );
                ConsoleIO.WriteLineFormat(
                    Messages.Task1Process,
                    keyValuePair.Key,
                    Messages.SortedDictionaryPersonOfStudent,
                    status
                        ? Messages.StatusFound
                        : Messages.StatusNotFound,
                    time
                );
            }
        }

        private static void Task1Collection4Process()
        {
            foreach (var keyValuePair in new Dictionary<string, Student>() {
                {Messages.FirstElement, collections.studentsByString.Values.First().ShallowCopy()},
                {
                    Messages.CenterElement,
                    collections.studentsByString.Values.ElementAt(collections.studentsByString.Count / 2).ShallowCopy()
                },
                {Messages.LastElement, collections.studentsByString.Values.Last().ShallowCopy()},
                {Messages.NonIncludedElement, new()},
            })
            {
                var (status, time) = Search.SearchInDictionaryByValue(
                    collections.studentsByString,
                    keyValuePair.Value
                );
                ConsoleIO.WriteLineFormat(
                    Messages.Task1Process,
                    keyValuePair.Key,
                    Messages.SortedDictionaryStringOfStudent,
                    status
                        ? Messages.StatusFound
                        : Messages.StatusNotFound,
                    time
                );
            }
        }

    }
}