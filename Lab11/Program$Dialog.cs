using ConsoleDialogLib;

namespace Lab11
{
    public partial class Program
    {
        private static ConsoleDialog MainDialog() => new(
            Messages.MainDialogWelcomeText,
            new() {
                new(
                    Messages.MainDialogOption1,
                    _ => Task1Process(),
                    pauseAfterExecuted: true
                ),
                new(
                    Messages.MainDialogOption2,
                    _ => Task2Process(),
                    pauseAfterExecuted: true
                ),
                new(
                    Messages.MainDialogOption3,
                    _ => Task3Process(),
                    pauseAfterExecuted: true
                ),
                new(
                    Messages.MainDialogOption4,
                    _ => Task4Process(),
                    pauseAfterExecuted: true
                )
            }
        );

        private static ConsoleDialog ChoiceInputMethodDialog() => new(
            Messages.ChoiceInputMethodDialogWelcomeText,
            new(){
                new(
                    Messages.ChoiceInputMethodDialogRandom,
                    _ => true,
                    exitAfterExecuted: true
                ),
                new(
                    Messages.ChoiceInputMethodDialogManual,
                    _ => false,
                    exitAfterExecuted: true
                ),
            }
        );
    }
}