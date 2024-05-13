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
  public partial class UcPedestrianTraffcLight : bdt.Libs.VisuBase.BDTControlBase
  {
    private bdt.Libs.VisuBase.BDTPLC.BDTPLCManager.PLCs _plc_No = Libs.VisuBase.BDTPLC.BDTPLCManager.PLCs.PLC1;
    [Category("PLC"), DefaultValue(Libs.VisuBase.BDTPLC.BDTPLCManager.PLCs.PLC1)]
    public bdt.Libs.VisuBase.BDTPLC.BDTPLCManager.PLCs PLC_No
    {
      get { return _plc_No; }
      set
      {
        _plc_No = value;
        ledRed.PLC_No = _plc_No;
        ledGreen.PLC_No = _plc_No;
        pbtnRequest.PLC_No = _plc_No;
      }
    }


    private string _plcVar_PedestrianTrafficLight;
    [Category("PLC"), DefaultValue(Libs.VisuBase.BDTPLC.BDTPLCManager.PLCs.PLC1), Description("FB_TrafficLight_Pedestrian")]
    public string PLC_Var_PedestrianTrafficLight
    {
      get { return _plcVar_PedestrianTrafficLight; }
      set
      {
        _plcVar_PedestrianTrafficLight = value;
        if (!string.IsNullOrEmpty(_plcVar_PedestrianTrafficLight))
        {
          ledRed.PLCVar_In = $"{_plcVar_PedestrianTrafficLight}.red";
          ledGreen.PLCVar_In = $"{_plcVar_PedestrianTrafficLight}.green";
          pbtnRequest.PLCVar_In = $"{_plcVar_PedestrianTrafficLight}.request";
          pbtnRequest.PLCVar_Out = $"{_plcVar_PedestrianTrafficLight}.button";
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
        ledGreen.CycleTime = _cycleTime;
        pbtnRequest.CycleTime = _cycleTime;
      }
    }




    public UcPedestrianTraffcLight()
    {
      InitializeComponent();
    }
  }
}
