using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileNet
{
    public interface IStatusInformer
    {
        void ClearLog();

        void Log(string msg);
        
        void LogError(string msg);

        void LogAndNotify(string msg, bool error);

        void Notify(string msg);

        void ResetProgress();            

        void SetProgress(int percentage);

        void AddProgress(int percentage);
    }
}
