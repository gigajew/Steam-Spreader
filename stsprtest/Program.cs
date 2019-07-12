using stsprtest.Input;
using stsprtest.Steam;
using System;
using System.Threading;

namespace stsprtest
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHelper webHelper = new WebHelper();
            webHelper.UpdateThreads();
            webHelper.GetChatWindows();

            // writes hello in each chat window and sends it
            foreach (ChatWindow chatWindow in webHelper.ChatWindows)
            {
                bool minimized = chatWindow.IsMinimized();
                if (minimized)
                {
                    chatWindow.Maximize();
                }
                chatWindow.Focus();
                Thread.Sleep(30);

                Keyboard.InjectKeyPress(ScanCode.KEY_H);
                Thread.Sleep(10);

                Keyboard.InjectKeyPress(ScanCode.KEY_E);
                Thread.Sleep(10);

                Keyboard.InjectKeyPress(ScanCode.KEY_L);
                Thread.Sleep(10);

                Keyboard.InjectKeyPress(ScanCode.KEY_L);
                Thread.Sleep(10);

                Keyboard.InjectKeyPress(ScanCode.KEY_O);
                Thread.Sleep(10);

                //Keyboard.InjectKeyPress(ScanCode.RETURN);
                //Thread.Sleep(10);

                if ( minimized )
                {
                    chatWindow.Minimize();
                }
            }

            Console.ReadLine();
        }
    }
}
