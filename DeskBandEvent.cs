using System;
using System.Windows.Forms;
using Util;

namespace DeskBandUI_NS
{
    public partial class DeskBandUI : UserControl {
        public DeskBandUI() {
            InitializeComponent();
        }

        private void timer_Monitor_Tick(object sender, EventArgs e) {
            double cpuRate = SystemTimesInfo.getCPURate();

            Int64 phav = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
            Int64 tot = PerformanceInfo.GetTotalMemoryInMiB();
            decimal percentFree = ((decimal) phav / (decimal) tot) * 100;
            decimal percentOccupied = 100 - percentFree;
            double memRate = (double) percentOccupied;

            label_CPU.Text = "CPU：" + cpuRate.ToString("F1") + "%";
            label_Mem.Text = "Mem：" + memRate.ToString("F1") + "%";
            Console.WriteLine(memRate);
        }

        private void ToolStripMenuItem_Setting_Click(object sender, EventArgs e) {
            MessageBox.Show("Test");
        }
    }
}
