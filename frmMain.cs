using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eo_NoteTaking
{
    public partial class frmMain : Form
    {
        DataTable c_dtNoteTable;

        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On load create the table and the columns for the grid view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            c_dtNoteTable = new DataTable();

            c_dtNoteTable.Columns.Add("Title", typeof(String));
            c_dtNoteTable.Columns.Add("Message", typeof(String));

            gridvwMessageList.DataSource = c_dtNoteTable;

            gridvwMessageList.Columns["Message"].Visible = false;
            gridvwMessageList.Columns["Title"].Width = 240;
        }

        /// <summary>
        /// Clear the text fields after new has been clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtMessage.Clear();
        }

        /// <summary>
        /// Add the row after save is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            c_dtNoteTable.Rows.Add(txtTitle.Text, txtMessage.Text);
        }

        /// <summary>
        /// Grab the current row and display the title and message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, EventArgs e)
        {
            // Grabbing the current row that is selected.
            int l_intRowIndex = gridvwMessageList.CurrentCell.RowIndex;
            
            // If a row is selected the index can't be -1.
            if (l_intRowIndex > -1)
            {
                // Set the text fields to the stored note they wish to view.
                txtTitle.Text = c_dtNoteTable.Rows[l_intRowIndex]["Title"].ToString();
                txtMessage.Text = c_dtNoteTable.Rows[l_intRowIndex]["Message"].ToString();
            }
        }

        /// <summary>
        /// Delete the selected row from the table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int l_intRowIndex = -1;

            // Avoid Delete functionality when there aren't any rows in the table.
            if (gridvwMessageList.CurrentCell != null)
            {
                l_intRowIndex = gridvwMessageList.CurrentCell.RowIndex;
            }

            // If a row is selected the index can't be -1.
            if (l_intRowIndex > -1)
            {
                c_dtNoteTable.Rows[l_intRowIndex].Delete();
            }
        }
    }
}
