namespace bdt.Apps.B5xxx
{
  partial class UcPedestrianTraffcLight
  {
    /// <summary> 
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Komponenten-Designer generierter Code

    /// <summary> 
    /// Erforderliche Methode für die Designerunterstützung. 
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.ledGreen = new bdt.Libs.VisuBase.Controls.Basic.BDTLed();
      this.ledRed = new bdt.Libs.VisuBase.Controls.Basic.BDTLed();
      this.pbtnRequest = new bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton();
      this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
      this.tlpMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // ledGreen
      // 
      this.ledGreen.BackColor = System.Drawing.Color.Transparent;
      this.ledGreen.ClickType = bdt.Libs.VisuBase.Controls.Basic.BDTLed.LedClickType.rastend;
      this.ledGreen.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ledGreen.LedType = bdt.Libs.VisuBase.Controls.Basic.BDTLed.LedTypes.Round;
      this.ledGreen.Location = new System.Drawing.Point(3, 36);
      this.ledGreen.Name = "ledGreen";
      this.ledGreen.Size = new System.Drawing.Size(27, 27);
      this.ledGreen.TabIndex = 0;
      // 
      // ledRed
      // 
      this.ledRed.BackColor = System.Drawing.Color.Transparent;
      this.ledRed.ClickType = bdt.Libs.VisuBase.Controls.Basic.BDTLed.LedClickType.rastend;
      this.ledRed.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ledRed.LedColor = System.Drawing.Color.Red;
      this.ledRed.LedType = bdt.Libs.VisuBase.Controls.Basic.BDTLed.LedTypes.Round;
      this.ledRed.Location = new System.Drawing.Point(3, 3);
      this.ledRed.Name = "ledRed";
      this.ledRed.Size = new System.Drawing.Size(27, 27);
      this.ledRed.TabIndex = 1;
      // 
      // pbtnRequest
      // 
      this.pbtnRequest.BackColor = System.Drawing.Color.Gold;
      this.pbtnRequest.ButtonTyp = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.ButtonTypes.tastend;
      this.pbtnRequest.CycleTime = 100;
      this.pbtnRequest.DataType = bdt.Libs.VisuBase.Controls.Basic.BDTPictureButton.DataTypes.Bool;
      this.pbtnRequest.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pbtnRequest.InputActiveColor = System.Drawing.Color.Red;
      this.pbtnRequest.Integer = ((short)(0));
      this.pbtnRequest.Location = new System.Drawing.Point(3, 69);
      this.pbtnRequest.MinimumSize = new System.Drawing.Size(10, 10);
      this.pbtnRequest.Name = "pbtnRequest";
      this.pbtnRequest.PLCVar_Out = "";
      this.pbtnRequest.Size = new System.Drawing.Size(27, 28);
      this.pbtnRequest.TabIndex = 2;
      this.pbtnRequest.TranslatorActive = false;
      this.pbtnRequest.UseVisualStyleBackColor = false;
      // 
      // tlpMain
      // 
      this.tlpMain.ColumnCount = 1;
      this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlpMain.Controls.Add(this.ledGreen, 0, 1);
      this.tlpMain.Controls.Add(this.pbtnRequest, 0, 2);
      this.tlpMain.Controls.Add(this.ledRed, 0, 0);
      this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlpMain.Location = new System.Drawing.Point(0, 0);
      this.tlpMain.Name = "tlpMain";
      this.tlpMain.RowCount = 3;
      this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tlpMain.Size = new System.Drawing.Size(33, 100);
      this.tlpMain.TabIndex = 3;
      // 
      // UcPedestrianTraffcLight
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tlpMain);
      this.Name = "UcPedestrianTraffcLight";
      this.Size = new System.Drawing.Size(33, 100);
      this.tlpMain.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Libs.VisuBase.Controls.Basic.BDTLed ledGreen;
    private Libs.VisuBase.Controls.Basic.BDTLed ledRed;
    private Libs.VisuBase.Controls.Basic.BDTPictureButton pbtnRequest;
    private System.Windows.Forms.TableLayoutPanel tlpMain;
  }
}
