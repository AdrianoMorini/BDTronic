using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bdt.Apps.B5xxx
{
  public partial class UcCarTraffcLight : bdt.Libs.VisuBase.BDTControlBase
  {
    public enum Types { South, North, East, West }

    private Types _type = Types.South;
    [Category("TrafficLight"), DefaultValue(Types.South)]
    public Types Type
    {
      get { return _type; }
      set
      {
        _type = value;

        this.tlpMain.RowStyles.Clear();
        this.tlpMain.ColumnStyles.Clear();
        this.tlpMain.Controls.Clear();

        switch (_type) 
        {
          case Types.South:
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.RowCount = 3;

            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));

            this.tlpMain.Controls.Add(this.ledRed, 0, 0);
            this.tlpMain.Controls.Add(this.ledYellow, 0, 1);
            this.tlpMain.Controls.Add(this.ledGreen, 0, 2);

            if (Size.Width > Size.Height)
              Size = new Size(Size.Height, Size.Width);


            break;
          case Types.North:
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.RowCount = 3;

            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));

            this.tlpMain.Controls.Add(this.ledRed, 0, 2);
            this.tlpMain.Controls.Add(this.ledYellow, 0, 1);
            this.tlpMain.Controls.Add(this.ledGreen, 0, 0);

            if (Size.Width > Size.Height)
              Size = new Size(Size.Height, Size.Width);

            break;
          case Types.East:
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.RowCount = 1;

            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));

            this.tlpMain.Controls.Add(this.ledRed, 0, 0);
            this.tlpMain.Controls.Add(this.ledYellow, 1, 0);
            this.tlpMain.Controls.Add(this.ledGreen, 2, 0);

            if (Size.Height > Size.Width)
              Size = new Size(Size.Height, Size.Width);

            break;
          case Types.West:
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.RowCount = 1;

            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));

            this.tlpMain.Controls.Add(this.ledRed, 2, 0);
            this.tlpMain.Controls.Add(this.ledYellow, 1, 0);
            this.tlpMain.Controls.Add(this.ledGreen, 0, 0);

            if (Size.Height > Size.Width)
              Size = new Size(Size.Height, Size.Width);

            break;
        }
      }
    }


    private bdt.Libs.VisuBase.BDTPLC.BDTPLCManager.PLCs _plc_No = Libs.VisuBase.BDTPLC.BDTPLCManager.PLCs.PLC1;
    [Category("PLC"), DefaultValue(Libs.VisuBase.BDTPLC.BDTPLCManager.PLCs.PLC1)]
    public bdt.Libs.VisuBase.BDTPLC.BDTPLCManager.PLCs PLC_No
    {
      get { return _plc_No; }
      set
      {
        _plc_No = value;
        ledRed.PLC_No = _plc_No;
        ledYellow.PLC_No = _plc_No;
        ledGreen.PLC_No = _plc_No;
      }
    }

    private string _plcVar_FB_TrafficLight;
    [Category("PLC"), DefaultValue(Libs.VisuBase.BDTPLC.BDTPLCManager.PLCs.PLC1), Description("FB_TrafficLight")]
    public string PLC_Var_FB_TrafficLight
    {
      get { return _plcVar_FB_TrafficLight; }
      set
      {
        _plcVar_FB_TrafficLight = value;
        if (!string.IsNullOrEmpty(_plcVar_FB_TrafficLight))
        {
          ledRed.PLCVar_In = $"{_plcVar_FB_TrafficLight}.red";
          ledYellow.PLCVar_In = $"{_plcVar_FB_TrafficLight}.yellow";
          ledGreen.PLCVar_In = $"{_plcVar_FB_TrafficLight}.green";
        }
      }
    }

    private int _cycleTime = 500;
    [Category("PLC"), DefaultValue(500)]
    public int CycleTime
    {
      get { return _cycleTime; }
      set
      {
        _cycleTime = value;
        ledRed.CycleTime = _cycleTime;
        ledYellow.CycleTime = _cycleTime;
        ledGreen.CycleTime = _cycleTime;
      }
    }

    public UcCarTraffcLight()
    {
      InitializeComponent();
    }
  }
}
