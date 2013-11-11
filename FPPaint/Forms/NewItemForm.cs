using System;
using System.Windows.Forms;

namespace FPPaint.Forms
{
    public partial class NewItemForm : Form
    {
        public int height { get; private set; }
        public int width { get; private set; }

        public NewItemForm()
        {
            InitializeComponent();
        }

        private void NewItemForm_Load(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            height = int.Parse(Height.Value.ToString());
            width = int.Parse(Width.Value.ToString());
            Close();
        }
    }
}
