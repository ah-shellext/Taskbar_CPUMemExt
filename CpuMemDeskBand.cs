using System.ComponentModel;
using System.Runtime.InteropServices;
using SharpShell.SharpDeskBand;
using DeskBandUI_NS;

namespace DeskBandService_NS
{
    [ComVisible(true)]
    [DisplayName("CPU Mem")]
    public class CpuMemDeskBand : SharpDeskBand {

        protected override System.Windows.Forms.UserControl CreateDeskBand() => new DeskBandUI();

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
