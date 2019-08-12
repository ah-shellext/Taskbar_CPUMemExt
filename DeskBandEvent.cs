using System;
using System.Windows.Forms;
using Util;

namespace DeskBandUI_NS
{
    public partial class DeskBandUI : UserControl {
        public DeskBandUI() {
            InitializeComponent();
        }

        private string CPU_Label { set; get; } = "CPU :";
        private string Mem_Label { set; get; } = "Mem :";

        private void timer_Monitor_Tick(object sender, EventArgs e) {
            double cpuRate = SystemTimesInfo.getCPURate();

            Int64 phav = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
            Int64 tot = PerformanceInfo.GetTotalMemoryInMiB();
            decimal percentFree = ((decimal) phav / (decimal) tot) * 100;
            decimal percentOccupied = 100 - percentFree;
            double memRate = (double) percentOccupied;

            label_CPU.Text = $"{CPU_Label} {cpuRate.ToString("F1").PadLeft(4, ' ')}%"; // xx.x%
            label_Mem.Text = $"{Mem_Label} {memRate.ToString("F1").PadLeft(4, ' ')}%";

            string tips = label_CPU.Text + '\n' + label_Mem.Text;

            this.toolTip.SetToolTip(mainPanel, tips);
            foreach (Control obj in mainPanel.Controls)
                this.toolTip.SetToolTip(obj, tips);
        }

        private void ToolStripMenuItem_Setting_Click(object sender, EventArgs e) {
            MessageBox.Show("Test");
        }
    }
}
