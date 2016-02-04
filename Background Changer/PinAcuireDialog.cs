using System.Windows.Forms;

namespace Background_Changer
{
    public partial class PinAcuireDialog : Form
    {
        public string PINCode
        {
            get { return pinTextBox.Text.Trim(); }
        }

        public PinAcuireDialog()
        {
            InitializeComponent();
        }
    }
}