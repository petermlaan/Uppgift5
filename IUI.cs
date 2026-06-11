using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5;

interface IUI
{
    void Clear();
    void Write(string text);
    void WriteLine(string text);
    string ReadLine();
    string AskForString(string type);
    int AskForInt(string type, int defaultValue);
    void Error(string message);
    void WaitForUser();
}
