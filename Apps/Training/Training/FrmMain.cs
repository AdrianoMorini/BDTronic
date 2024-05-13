using System;
using System.Drawing;
using System.Windows.Forms;
using bdt.Libs.VisuBase;
using bdt.Libs.VisuBase.Controls.General;

namespace bdt.Apps.B5xxx
{
  public partial class FrmMain : Form
  {
    #region Variables
    private GlobalSettings GlobSettings;
    private Point mouseStartPos;
    private bdt.Libs.VisuBase.BDTUserManagement.Controls.BDTFrmLogin loginWindow;

    #endregion Variables

    #region Methods

    public FrmMain()
    {
      InitApplication();
    }

    /// <summary>
    /// Method for basic application initialisations
    /// </summary>
    private void InitApplication()
    {
      try
      {
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Start();

        FrmSplash.ShowSplash( 200 );
        FrmSplash.NewStatus( 0, "" );
        GlobSettings = GlobalSettings.Instance;

        FrmSplash.NewStatus( 5, "Connection PLC..." );
        GlobSettings.plcManager.FirePLCEvent( bdt.Libs.VisuBase.BDTPLC.BDTPLCManager.PLCEvents.Connect );

        FrmSplash.NewStatus( 10, "Initialize components..." );
        InitializeComponent();
        GlobSettings.FireApplicationEvent( GlobalSettings.ApplicationEvents.ControlsCreated );

        tabControl_Main.Region = new Region( new Rectangle( tabPage1.Left, tabPage1.Top, tabPage1.Width, tabPage1.Height ) );

        GlobSettings.userManagement.OnLogin += UserManagement_OnLogin;

        FrmSplash.NewStatus( 20, "Loading Data..." );
        GlobSettings.persistence.FireProgsEvent( bdt.Libs.VisuBase.BDTPersistence.BDTPersistence.WriteReadLoadEvents.Load );
        GlobSettings.persistence.FireConfigEvent( bdt.Libs.VisuBase.BDTPersistence.BDTPersistence.WriteReadLoadEvents.Load );
        GlobSettings.persistence.FireSecuritySettingsEvent( bdt.Libs.VisuBase.BDTPersistence.BDTPersistence.WriteReadLoadEvents.Load );

        FrmSplash.NewStatus( 25, "Before init..." );
        GlobSettings.FireApplicationEvent( GlobalSettings.ApplicationEvents.BeforeInit );
        GlobSettings.userManagement.Login( "", "" );

        FrmSplash.NewStatus( 30, "Initialize..." );
        GlobSettings.FireApplicationEvent( GlobalSettings.ApplicationEvents.Init );
        GlobSettings.FireApplicationEvent( GlobalSettings.ApplicationEvents.AfterInit );

        FrmSplash.NewStatus( 40, "Reading MachineData..." );
        GlobSettings.persistence.FireConfigEvent( bdt.Libs.VisuBase.BDTPersistence.BDTPersistence.WriteReadLoadEvents.Read );

        FrmSplash.NewStatus( 45, "Reading Programs..." );
        GlobSettings.persistence.FireProgsEvent( bdt.Libs.VisuBase.BDTPersistence.BDTPersistence.WriteReadLoadEvents.Read );

        FrmSplash.NewStatus( 50, "Reading SecuritySettings..." );
        GlobSettings.persistence.FireSecuritySettingsEvent( bdt.Libs.VisuBase.BDTPersistence.BDTPersistence.WriteReadLoadEvents.Read );

        FrmSplash.NewStatus( 60, "Reading MachineConfig..." );
        GlobSettings.persistence.FireMachineCfgEvent( bdt.Libs.VisuBase.BDTPersistence.BDTPersistence.WriteReadLoadEvents.Read );

        FrmSplash.NewStatus( 70, "Register Notifications" );
        GlobSettings.plcManager.RegisterNotifications();

        FrmSplash.NewStatus( 80, "Init Message System..." );
        GlobSettings.messages.InitMessages();

        MenueManager( btnMain1, new EventArgs() );

        FrmSplash.NewStatus( 90, "Finish loading..." );
        GlobSettings.AppInitialized = true;

        FrmSplash.NewStatus( 100 );

        sw.Stop();
        Libs.VisuBase.Logging.BDTMessage msg = new Libs.VisuBase.Logging.BDTMessage( Libs.VisuBase.Messages.Type.Info, this.Name, "Application Start (" + sw.Elapsed.Minutes + ":" + sw.Elapsed.Seconds.ToString( "00" ) + ")", "" );
        GlobSettings.logger.LogMessage( msg );

        FrmSplash.Fadeout();
      }
      catch ( Exception ex )
      {
        bdt.Libs.VisuBase.Logging.BDTMessage msg = new bdt.Libs.VisuBase.Logging.BDTMessage( bdt.Libs.VisuBase.Messages.Type.FatalError, this.CompanyName, "Could not init Application", ex.Message );
        msg.Show();
        GlobSettings.logger.LogMessage( msg );
        GlobSettings.CloseApplication( false );
      }
    }

    #endregion Methods

    #region Events

    private void UserManagement_OnLogin( object sender, bdt.Libs.VisuBase.BDTUserManagement.LoginEventArgs e )
    {
      if ( GlobSettings.userManagement.UserHasPermission( bdt.Libs.VisuBase.BDTUserManagement.BDTUserManagement.UserLevels.LevelProgrammierer ) )
        tlp_Menue.ColumnStyles[tlp_Menue.ColumnCount - 2].Width = 32;
      else
        tlp_Menue.ColumnStyles[tlp_Menue.ColumnCount - 2].Width = 0;
    }

    private void picBDT_Click( object sender, EventArgs e )
    {
      btnMain1.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnMain2.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnMain3.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnMain5.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnMain6.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnMain7.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnMain8.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnMain10.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnMain11.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnMain4.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnMain9.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnMain12.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnMain13.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnMain14.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnMain15.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnMessages.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnUser.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
      btnRecipe.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;

      tabControl_Main.SelectTab( tabPageSettingsMain );
      tabControlSettings.SelectedTab = tabPageInfo;
    }

    private void picBDT_MouseDown( object sender, MouseEventArgs e )
    {
      if ( GlobSettings.userManagement.UserHasPermission( bdt.Libs.VisuBase.BDTUserManagement.BDTUserManagement.UserLevels.LevelProgrammierer ) )
        mouseStartPos = new Point( e.X, e.Y );
    }

    private void picBDT_MouseMove( object sender, MouseEventArgs e )
    {
      if ( e.Button == MouseButtons.Left && GlobSettings.userManagement.UserHasPermission( bdt.Libs.VisuBase.BDTUserManagement.BDTUserManagement.UserLevels.LevelProgrammierer ) )
      {
        Point offset = new Point( e.X - mouseStartPos.X, e.Y - mouseStartPos.Y );
        Location = new Point( Location.X + offset.X, Location.Y + offset.Y );
      }
    }

    private void btnSaveConfig_Click( object sender, EventArgs e )
    {
      GlobSettings.persistence.FireMachineCfgEvent( bdt.Libs.VisuBase.BDTPersistence.BDTPersistence.WriteReadLoadEvents.Write );
    }

    #endregion Events

    #region MainMenue

    private void MenueManager( object sender, EventArgs e )
    {
      if ( sender.Equals( btnMain1 ) )
        btnMain1.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;

      if ( typeof( bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton ) == sender.GetType() )
      {
        if ( !((bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton)sender).Enabled || !((bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton)sender).Visible )
          return;

        btnMain1.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnMain2.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnMain3.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnMain4.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnMain5.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnMain6.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnMain7.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnMain8.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnMain9.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnMain10.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnMain11.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnMain12.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnMain13.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnMain14.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnMain15.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnMessages.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnUser.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;
        btnRecipe.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Gradiant;

        if ( sender.Equals( btnMain1 ) )
        {
          btnMain1.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPage1 );
        }
        else if ( sender.Equals( btnMain2 ) )
        {
          btnMain2.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPage2 );
        }
        else if ( sender.Equals( btnMain3 ) )
        {
          btnMain3.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPage3 );
        }
        else if ( sender.Equals( btnMain4 ) )
        {
          btnMain4.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPage4 );
        }
        else if ( sender.Equals( btnMain5 ) )
        {
          btnMain5.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPage5 );
        }
        else if ( sender.Equals( btnMain6 ) )
        {
          btnMain6.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPage6 );
        }
        else if ( sender.Equals( btnMain7 ) )
        {
          btnMain7.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPage7 );
        }
        else if ( sender.Equals( btnMain8 ) )
        {
          btnMain8.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPage8 );
        }
        else if ( sender.Equals( btnMain9 ) )
        {
          btnMain9.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPage9 );
        }
        else if ( sender.Equals( btnMain10 ) )
        {
          btnMain10.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPage10 );
        }
        else if ( sender.Equals( btnMain11 ) )
        {
          btnMain11.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPage11 );
        }
        else if ( sender.Equals( btnMain12 ) )
        {
          btnMain12.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPage12 );
        }
        else if ( sender.Equals( btnMain13 ) )
        {
          btnMain13.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPage13 );
        }
        else if ( sender.Equals( btnMain14 ) )
        {
          btnMain14.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPage14 );
        }
        else if ( sender.Equals( btnMain15 ) )
        {
          btnMain15.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPage15 );
        }
        else if ( sender.Equals( btnMessages ) )
        {
          btnMessages.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPageMessages );
          tabControlLogfile.SelectedTab = tabPageActiveMessages;
        }
        else if ( sender.Equals( btnUser ) )
        {
          //Login
          if ( loginWindow == null || loginWindow.IsDisposed )
            loginWindow = new bdt.Libs.VisuBase.BDTUserManagement.Controls.BDTFrmLogin( GlobSettings.NumpadVisible );

          if ( !loginWindow.Visible )
          {
            loginWindow.StartPosition = FormStartPosition.CenterScreen;
            try
            {
              loginWindow.Show( this );
            }
            catch ( Exception ex )
            {
              MessageBox.Show( ex.Message );
            }
          }
          else
            loginWindow.Focus();
        }
        else if ( sender.Equals( btnRecipe ) )
        {
          btnRecipe.ButtonEffect = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonEffectTypes.Flat;
          tabControl_Main.SelectTab( tabPageRecipe );
        }
      }
    }

    protected override bool ProcessCmdKey( ref Message msg, Keys keyData )
    {
      switch ( keyData )
      {
        case Keys.F1:
          MenueManager( btnMain1, new EventArgs() );
          break;
        case Keys.F2:
          MenueManager( btnMain2, new EventArgs() );
          break;
        case Keys.F3:
          MenueManager( btnMain3, new EventArgs() );
          break;
        case Keys.F4:
          MenueManager( btnMain5, new EventArgs() );
          break;
        case Keys.F5:
          MenueManager( btnMain6, new EventArgs() );
          break;
        case Keys.F6:
          MenueManager( btnMain7, new EventArgs() );
          break;
        case Keys.F7:
          MenueManager( btnMain8, new EventArgs() );
          break;
        case Keys.F8:
          MenueManager( btnMain10, new EventArgs() );
          break;
        case Keys.F9:
          MenueManager( btnMain15, new EventArgs() );
          break;
        case Keys.F10:
          MenueManager( btnRecipe, new EventArgs() );
          break;
        case Keys.F11:
          MenueManager( btnMessages, new EventArgs() );
          break;
        case Keys.F12:
          MenueManager( btnUser, new EventArgs() );
          break;
      }
      return base.ProcessCmdKey( ref msg, keyData );
    }

    #endregion MainMenue

    private void FrmMain_FormClosing( object sender, FormClosingEventArgs e )
    {
      if ( !GlobSettings.userManagement.UserHasPermission( Libs.VisuBase.BDTUserManagement.BDTUserManagement.UserLevels.LevelProgrammierer ) )
        e.Cancel = true;
    }
  }
}