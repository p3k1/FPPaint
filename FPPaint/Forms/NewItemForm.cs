using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.height = int.Parse(Height.Value.ToString());
            this.width = int.Parse(Width.Value.ToString());
            this.Close();
        }
    }
}
