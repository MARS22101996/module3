using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Core.Interfaces
{
    public interface IConsoleProcessor
    {
        void Process();

        void ProcessAddCommand(string input);
    }
}
