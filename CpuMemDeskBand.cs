using System.ComponentModel;
using System.Runtime.InteropServices;
using DeskBandUI_NS;
using SharpShell.SharpDeskBand;
using System.Windows.Forms;

namespace DeskBandService_NS
{
    [ComVisible(true)]
    [DisplayName("CPU Mem")]
    public class CpuMemDeskBand : SharpDeskBand {

        protected override System.Windows.Forms.UserControl CreateDeskBand() => new DeskBandUI();

        // https://www.cnblogs.com/1175429393wljblog/p/5377533.html

        protected override BandOptions GetBandOptions() {
            return new BandOptions {
                HasVariableHeight = false,
                IsSunken = false,
                ShowTitle = true,
                Title = "CPU Mem",
                UseBackgroundColour = false,
                AlwaysShowGripper = true
            };
        }
    }
}
