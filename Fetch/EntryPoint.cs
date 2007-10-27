using System;
using System.IO;
using System.Net;

using System.Windows.Forms;

namespace Fetch {
  class EntryPoint {
    
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args) {
      Application.Run(new MainForm());
    }

    
  }
}
