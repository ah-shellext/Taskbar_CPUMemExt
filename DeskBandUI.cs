using System.Drawing;

namespace DeskBandUI_NS
{
    partial class DeskBandUI
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_CPU = new System.Windows.Forms.Label();
            this.label_Mem = new System.Windows.Forms.Label();
            this.timer_Monitor = new System.Windows.Forms.Timer(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Setting = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_CPU
            // 
            this.label_CPU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_CPU.BackColor = System.Drawing.Color.Transparent;
            this.label_CPU.Location = new System.Drawing.Point(2, 3);
            this.label_CPU.Name = "label_CPU";
            this.label_CPU.Size = new System.Drawing.Size(77, 15);
            this.label_CPU.TabIndex = 1;
            this.label_CPU.Text = "CPU：0%";
            // 
            // label_Mem
            // 
            this.label_Mem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Mem.BackColor = System.Drawing.Color.Transparent;
            this.label_Mem.Location = new System.Drawing.Point(2, 22);
            this.label_Mem.Name = "label_Mem";
            this.label_Mem.Size = new System.Drawing.Size(77, 15);
            this.label_Mem.TabIndex = 2;
            this.label_Mem.Text = "Mem：0%";
            // 
            // timer_Monitor
            // 
            this.timer_Monitor.Enabled = true;
            this.timer_Monitor.Interval = 1000;
            this.timer_Monitor.Tick += new System.EventHandler(this.timer_Monitor_Tick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Setting});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(113, 26);
            // 
            // ToolStripMenuItem_Setting
            // 
            this.ToolStripMenuItem_Setting.Name = "ToolStripMenuItem_Setting";
            this.ToolStripMenuItem_Setting.Size = new System.Drawing.Size(112, 22);
            this.ToolStripMenuItem_Setting.Text = "設定(&S)";
            this.ToolStripMenuItem_Setting.Click += new System.EventHandler(this.ToolStripMenuItem_Setting_Click);
            // 
            // DeskBandUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.label_Mem);
            this.Controls.Add(this.label_CPU);
            // this.Font = new Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DeskBandUI";
            this.Size = new System.Drawing.Size(81, 40);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_CPU;
        private System.Windows.Forms.Label label_Mem;
        private System.Windows.Forms.Timer timer_Monitor;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Setting;
    }
}
