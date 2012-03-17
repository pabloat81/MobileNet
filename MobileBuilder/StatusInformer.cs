using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobileNet;
using System.Windows.Forms;
using System.Drawing;

namespace TestMobileBuilder
{
    public class StatusInformer : IStatusInformer
    {
        Form Window;
        ToolStripProgressBar Bar;
        RichTextBox Console;
        NotifyIcon Notifier;

        string SEPARATOR = Environment.NewLine + "===============================================" + Environment.NewLine;

        public StatusInformer(Form form, ToolStripProgressBar bar, RichTextBox console, NotifyIcon notifier)
        {
            Window = form;
            Bar = bar;
            Console = console;
            Notifier = notifier;
        }

        public void Log(string msg)
        {
            AppendText(Console, Color.Green, string.Format("{0}[{1}]: {2}{3}", Environment.NewLine, DateTime.Now.ToShortTimeString(), msg, SEPARATOR));
            Window.Refresh();
        }

        public void SetProgress(int percentage)
        {
            Bar.Increment(percentage);
            Window.Refresh();
        }

        public void AddProgress(int percentage)
        {
            Bar.Increment(Bar.Value + percentage);
            Window.Refresh();
        }
        
        public void ResetProgress()
        {
            Bar.Value = 0;
        }
        
        public void LogError(string msg)
        {
            AppendText(Console, Color.Red, string.Format("{0}[{1}]: {2}{3}", Environment.NewLine, DateTime.Now.ToShortTimeString(), msg, SEPARATOR));
            Window.Refresh();
        }

        public void LogAndNotify(string msg, bool error)
        {                      
            Notifier.ShowBalloonTip(2000, "Mobile Builder", msg, ToolTipIcon.Info);
            if (error)
                LogError(msg);
            else
                Log(msg);  
        }

        void AppendText(RichTextBox box, Color color, string text)
        {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;

            // Textbox may transform chars, so (end-start) != text.Length
            box.Select(start, end - start);
            {
                box.SelectionColor = color;
                // could set box.SelectionBackColor, box.SelectionFont too.
            }
            box.SelectionLength = 0; // clear
        }

        public void ClearLog()
        {
            Console.ResetText();
        }
        
        public void Notify(string msg)
        {
            Notifier.ShowBalloonTip(4000, "Mobile Builder", msg, ToolTipIcon.Info);            
        }
    }
}
