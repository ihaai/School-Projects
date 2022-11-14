using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLTask
{
    public partial class DialogWindow : Form
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        public static bool HasExited = false;

        public DialogWindow(object dataObject, string specialty, int variant)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dbViewDuplicateGrid.DataSource = ((List<RuntimeData>)dataObject).FindAll(x => x.Specialty == specialty && x.Variant == variant);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            HasExited = true;
            this.Close();
        }

        private void DBViewDuplicateGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SQLTask.Menu.DialogSelectedRow = e.RowIndex;
            HasExited = true;
            this.Close();
        }
    }
}
