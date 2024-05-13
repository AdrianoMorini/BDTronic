using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using bdt.Libs.VisuBase;

namespace bdt.Apps.B5xxx
{
  internal static class Program
  {
    [DllImport( "user32.dll" )]
    private static extern bool SetForegroundWindow( IntPtr hWnd );
    [DllImport( "user32.dll" )]
    private static extern bool ShowWindowAsync( IntPtr hWnd, int nCmdShow );
    [DllImport( "user32.dll" )]
    private static extern bool IsIconic( IntPtr hWnd );

    private const int SW_HIDE = 0;
    private const int SW_SHOWNORMAL = 1;
    private const int SW_SHOWMINIMIZED = 2;
    private const int SW_SHOWMAXIMIZED = 3;
    private const int SW_SHOWNOACTIVATE = 4;
    private const int SW_RESTORE = 9;
    private const int SW_SHOWDEFAULT = 10;

    [STAThread]
    private static void Main()
    {
      bool createdNew;

      System.Threading.Mutex mutex = new System.Threading.Mutex( true, "BDT", out createdNew );
      if ( createdNew )
      {
        try
        {
          GlobalSettings.DesignTime = false;
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault( false );
          Application.Run( new FrmMain() );
          mutex.ReleaseMutex();
        }
        catch ( Exception ex )
        {
          GlobalSettings.Instance.exceptionLogger.Log( ex );
        }
      }
      else
      {
        Process myApp = Process.GetCurrentProcess();

        Process[] myAppProzesses = Process.GetProcessesByName( myApp.ProcessName );

        // Geht nicht in der Debugging-Umgebung!!!!
        if ( myAppProzesses.Length > 1 )
        {
          int n = 0;

          if ( myAppProzesses[0].Id == myApp.Id )
            n = 1;

          // get the window handle
          IntPtr hWnd = myAppProzesses[n].MainWindowHandle;

          if ( IsIconic( hWnd ) )
          {
            ShowWindowAsync( hWnd, SW_RESTORE );
          }

          SetForegroundWindow( hWnd );

          return;
        }
      }
    }
  }
}