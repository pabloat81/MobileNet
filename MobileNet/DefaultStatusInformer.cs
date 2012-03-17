using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileNet
{
    public class DefaultStatusInformer : IStatusInformer
    {
        int Percentage = 0;

        public void Log(string msg)
        {
            Console.Write(msg);
        }
        
        public void AddProgress(int percentage)
        {
            Console.WriteLine("+ Build: " + (Percentage + percentage).ToString() + "%");
        }
        
        public void SetProgress(int percentage)
        {
            Console.WriteLine("+ Build: " + percentage.ToString() + "%");
        }
        
        public void ResetProgress()
        {
            Percentage = 0;
        }

        public void LogError(string msg)
        {
            Log(msg);
        }

        public void LogAndNotify(string msg, bool error)
        {
            if (error)
                LogError(msg);
            else
                Log(msg);
        }

        public void ClearLog()
        {
            
        }

        public void Notify(string msg)
        {
            
        }
    }
}
