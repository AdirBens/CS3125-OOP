using ConsoleUI;
using System;

namespace TerminalUI
{
    public class Program
    {
        private static void Main()
        {
            try
            {
                TerminalUserInterface userInterface = new TerminalUserInterface();
                userInterface.RunProgram();
            }
            catch (QuitProgramRaiseException)
            {
                TerminalRenderer.renderEndProgramScreen();
            }
        }
    }
}
