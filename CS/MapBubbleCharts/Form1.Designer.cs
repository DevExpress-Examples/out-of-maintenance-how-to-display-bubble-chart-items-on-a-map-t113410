namespace MapBubbleCharts {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraMap.ImageLayer imageTilesLayer1 = new DevExpress.XtraMap.ImageLayer();
            DevExpress.XtraMap.BingMapDataProvider bingMapDataProvider1 = new DevExpress.XtraMap.BingMapDataProvider();
            DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer1 = new DevExpress.XtraMap.VectorItemsLayer();
            DevExpress.XtraMap.SizeLegend sizeLegend1 = new DevExpress.XtraMap.SizeLegend();
            this.mapControl1 = new DevExpress.XtraMap.MapControl();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // mapControl1
            // 
            this.mapControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            imageTilesLayer1.DataProvider = bingMapDataProvider1;
            vectorItemsLayer1.Name = "BubbleLayer";
            vectorItemsLayer1.ToolTipPattern = "<b>{Month}.{Day}.{Year}</b>\r\nMagnitude: {Magnitude}\r\nDepth: {Depth}";
            this.mapControl1.Layers.Add(imageTilesLayer1);
            this.mapControl1.Layers.Add(vectorItemsLayer1);
            sizeLegend1.Header = "Magnitude";
            sizeLegend1.Layer = vectorItemsLayer1;
            this.mapControl1.Legends.Add(sizeLegend1);
            this.mapControl1.Location = new System.Drawing.Point(0, 0);
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(836, 525);
            this.mapControl1.TabIndex = 0;
            this.mapControl1.ToolTipController = this.toolTipController1;
            // 
            // toolTipController1
            // 
            this.toolTipController1.AllowHtmlText = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 525);
            this.Controls.Add(this.mapControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraMap.MapControl mapControl1;
        private DevExpress.Utils.ToolTipController toolTipController1;
    }
}