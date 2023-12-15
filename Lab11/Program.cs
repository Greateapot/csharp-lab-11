using ConsoleDialogLib;

namespace Lab11
{
    public partial class Program
    {
        private static readonly TestCollections collections = new();

        public static void Main()
        {
            collections.RandomInit();
            ConsoleDialog.ShowDialog(MainDialog());
        }
    }
}
