using ConsoleIOLib;
using Lab11;

namespace Lab11Tests;

public class Lab11Test
{
    [Fact(Timeout = 30)]
    public void Test()
    {
        TestableConsoleIO consoleIO = new();

        consoleIO.PushKey(ConsoleKey.Enter);
        consoleIO.PushTest(
            TestOption1StackStudentStatus,
            TestOption1StackStringStatus,
            TestOption1SortedDictionaryPersonOfStudentsStatus,
            TestOption1SortedDictionaryStringOfStudentsStatus
        );
        consoleIO.PushKey(ConsoleKey.Enter);
        consoleIO.PushKey(ConsoleKey.DownArrow, ConsoleKey.Enter);
        consoleIO.PushKey(ConsoleKey.Enter, ConsoleKey.Enter);
        consoleIO.PushKey(ConsoleKey.Enter, ConsoleKey.DownArrow, ConsoleKey.Enter);
        consoleIO.PushLine(
            "фамилия",
            "имя",
            "отчество",
            "23",
            "0",
            "4,3",
            "104"
        );
        consoleIO.PushTest(TestOption2);
        consoleIO.PushKey(ConsoleKey.Enter);
        consoleIO.PushKey(ConsoleKey.DownArrow, ConsoleKey.Enter);
        consoleIO.PushKey(ConsoleKey.Enter, ConsoleKey.Enter);
        consoleIO.PushKey(ConsoleKey.Enter, ConsoleKey.DownArrow, ConsoleKey.Enter);
        consoleIO.PushLine(
            "фамилия",
            "имя",
            "отчество",
            "23",
            "0",
            "4,3",
            "104"
        );
        consoleIO.PushTest(TestOption3);
        consoleIO.PushKey(ConsoleKey.Enter);
        consoleIO.PushKey(ConsoleKey.DownArrow, ConsoleKey.Enter);
        consoleIO.PushKey(ConsoleKey.Enter, ConsoleKey.Backspace);

        Program.Main();
    }

    private static void TestOption1StackStudentStatus(string? output)
    {
        // arrange
        var exceptedString1 = "Поиск первого элемента в коллекции Stack<Student>...\nСтатус: Найден;";
        var exceptedString2 = "Поиск центрального элемента в коллекции Stack<Student>...\nСтатус: Найден;";
        var exceptedString3 = "Поиск последнего элемента в коллекции Stack<Student>...\nСтатус: Найден;";
        var exceptedString4 = "Поиск элемента, не входящего в коллекции Stack<Student>...\nСтатус: Не найден;";

        // act

        // assert
        Assert.Contains(exceptedString1, output);
        Assert.Contains(exceptedString2, output);
        Assert.Contains(exceptedString3, output);
        Assert.Contains(exceptedString4, output);
    }


    private static void TestOption1StackStringStatus(string? output)
    {
        // arrange
        var exceptedString1 = "Поиск первого элемента в коллекции Stack<string>...\nСтатус: Найден;";
        var exceptedString2 = "Поиск центрального элемента в коллекции Stack<string>...\nСтатус: Найден;";
        var exceptedString3 = "Поиск последнего элемента в коллекции Stack<string>...\nСтатус: Найден;";
        var exceptedString4 = "Поиск элемента, не входящего в коллекции Stack<string>...\nСтатус: Не найден;";

        // act

        // assert
        Assert.Contains(exceptedString1, output);
        Assert.Contains(exceptedString2, output);
        Assert.Contains(exceptedString3, output);
        Assert.Contains(exceptedString4, output);
    }


    private static void TestOption1SortedDictionaryPersonOfStudentsStatus(string? output)
    {
        // arrange
        var exceptedString1 = "Поиск первого элемента в коллекции SortedDictionary<Person, Student>...\nСтатус: Найден;";
        var exceptedString2 = "Поиск центрального элемента в коллекции SortedDictionary<Person, Student>...\nСтатус: Найден;";
        var exceptedString3 = "Поиск последнего элемента в коллекции SortedDictionary<Person, Student>...\nСтатус: Найден;";
        var exceptedString4 = "Поиск элемента, не входящего в коллекции SortedDictionary<Person, Student>...\nСтатус: Не найден;";

        // act

        // assert
        Assert.Contains(exceptedString1, output);
        Assert.Contains(exceptedString2, output);
        Assert.Contains(exceptedString3, output);
        Assert.Contains(exceptedString4, output);
    }


    private static void TestOption1SortedDictionaryStringOfStudentsStatus(string? output)
    {
        // arrange
        var exceptedString1 = "Поиск первого элемента в коллекции SortedDictionary<string, Student>...\nСтатус: Найден;";
        var exceptedString2 = "Поиск центрального элемента в коллекции SortedDictionary<string, Student>...\nСтатус: Найден;";
        var exceptedString3 = "Поиск последнего элемента в коллекции SortedDictionary<string, Student>...\nСтатус: Найден;";
        var exceptedString4 = "Поиск элемента, не входящего в коллекции SortedDictionary<string, Student>...\nСтатус: Не найден;";

        // act

        // assert
        Assert.Contains(exceptedString1, output);
        Assert.Contains(exceptedString2, output);
        Assert.Contains(exceptedString3, output);
        Assert.Contains(exceptedString4, output);
    }

    private static void TestOption2(string? output) {
        // arrange
        var exceptedString = "(surname: фамилия, name: имя, patronymic: отчество, age: 23, nicknames: [], rating: 4,3, universityID: 104)\nЭлемент добавлен успешно";

        // act

        // assert
        Assert.Contains(exceptedString, output);
    }
    
    private static void TestOption3(string? output) {
        // arrange
        var exceptedString = "(surname: фамилия, name: имя, patronymic: отчество, age: 23, nicknames: [], rating: 4,3, universityID: 104)\nЭлемент удален успешно";

        // act

        // assert
        Assert.Contains(exceptedString, output);
    }
}
