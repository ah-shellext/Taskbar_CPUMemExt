using System;
using System.Windows.Forms;

namespace DeskBandUI_NS
{
    public partial class DeskBandUI : UserControl
    {
        public DeskBandUI()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }
    }
}
