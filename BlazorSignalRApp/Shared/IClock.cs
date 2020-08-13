using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSignalRApp.Shared
{
    public interface IClock
    {
        Task ShowTime( DateTime currentTime);
    }
}
