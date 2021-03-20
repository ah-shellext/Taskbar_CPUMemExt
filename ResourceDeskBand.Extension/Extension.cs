using SharpShell.Attributes;
using SharpShell.SharpDeskBand;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ResourceDeskBand.Extension {

    [ComVisible(true)]
    [DisplayName("Resource Performance")]
    public class Extension : SharpDeskBand {

        protected override  UserControl CreateDeskBand() {
            return new DeskBandControl();
        }

        protected override BandOptions GetBandOptions() {
            return new BandOptions {
                HasVariableHeight = true,
                IsSunken = false,
                ShowTitle = true,
                Title = "Resource Performance",
                UseBackgroundColour = false,
                AlwaysShowGripper = true,
            };
        }
    }
}
