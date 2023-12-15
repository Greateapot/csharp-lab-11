using ConsoleIOLib;
using Lab10Lib.Entities;
using Lab10Lib.Interfaces;

namespace Lab11
{
    public class TestCollections : IInit
    {
        public readonly Stack<Student> students = new();
        public readonly Stack<string> strings = new();
        public readonly SortedDictionary<Person, Student> studentsByPerson = new();
        public readonly SortedDictionary<string, Student> studentsByString = new();

        public int Length => students.Count;

        public void Init()
        {
            students.Clear();
            strings.Clear();
            studentsByPerson.Clear();
            studentsByString.Clear();

            uint length = ConsoleIO.Input<uint>(Messages.InputLength);
            for (int index = 0; index < length; index++)
            {
                var student = new Student();
                do
                {
                    if (student.Name != "--")
                        ConsoleIO.WriteLine(Messages.InputStudentExistsError);

                    student.Init();
                } while (studentsByPerson.ContainsKey(student));
                students.Push(student);
                strings.Push(student.ToString());
                studentsByPerson.Add(student.ToPerson(), student);
                studentsByString.Add(student.ToString(), student);
            }
        }

        public void RandomInit()
        {
            students.Clear();
            strings.Clear();
            studentsByPerson.Clear();
            studentsByString.Clear();

            for (int index = 0; index < 1000; index++)
            {
                var student = new Student();
                do
                {
                    student.RandomInit();
                } while (studentsByPerson.ContainsKey(student));
                students.Push(student);
                strings.Push(student.ToString());
                studentsByPerson.Add(student.ToPerson(), student);
                studentsByString.Add(student.ToString(), student);
            }
        }

        public bool Add(Student student)
        {
            if (students.Contains(student))
                return false;

            students.Push(student);
            strings.Push(student.ToString());
            studentsByPerson.Add(student.ToPerson(), student);
            studentsByString.Add(student.ToString(), student);
            return true;
        }

        public bool Remove(Student student)
        {
            if (!students.Contains(student))
                return false;

            StackRemove(students, student);
            StackRemove(strings, student.ToString());
            studentsByPerson.Remove(student.ToPerson());
            studentsByString.Remove(student.ToString());
            return true;
        }

        private static bool StackRemove<T>(Stack<T> stack, T value)
        {
            if (!stack.Contains(value))
                return false;

            Stack<T> other = new();
            var isFounded = false;
            do
            {
                if (!stack.TryPop(out T? temp))
                    throw new Exception("something went wrong");
                else if (temp!.Equals(value))
                    isFounded = true;
                else
                    other.Push(temp);
            } while (!isFounded);

            while (other.Count > 0)
                stack.Push(other.Pop());

            return true;
        }

        public static T StackElementAt<T>(Stack<T> stack, int index)
        {
            if (index < 0 || index > stack.Count - 1)
                throw new IndexOutOfRangeException();

            Stack<T> other = new();
            for (int i = 0; i < index; i++)
                other.Push(stack.Pop());

            var element = stack.Peek();

            while (other.Count > 0)
                stack.Push(other.Pop());

            return element;

        }
    }
}