using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using redis_manage.info;

namespace redis_manage.controls
{
    public partial class Operation : UserControl
    {
        private bool showSaveButton = true;
        [Description("show save button ?")]
        public bool ShowSaveButton
        {
            get { return showSaveButton; }
            set { showSaveButton = value; }
        }
        private bool showReLoadButton = true;

        [Description("show reload button ?")]
        public bool ShowReLoadButton
        {
            get { return showReLoadButton; }
            set { showReLoadButton = value; }
        }
        private bool showRemoveButton = true;
        [Description("show rmeove button ?")]
        public bool ShowRemoveButton
        {
            get { return showRemoveButton; }
            set { showRemoveButton = value; }
        }

        public Operation()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Operation_Click != null)
            {
                this.Operation_Click.Invoke(Opera.Save);
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            if (this.Operation_Click != null)
            {
                this.Operation_Click.Invoke(Opera.Reload);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.Operation_Click != null)
            {
                this.Operation_Click.Invoke(Opera.Remove);
            }
        }

        private void Operation_Load(object sender, EventArgs e)
        {
            this.btnReLoad.Visible = this.ShowReLoadButton;
            this.btnRemove.Visible = this.ShowRemoveButton;
            this.btnSave.Visible = this.ShowSaveButton;

            if (!this.ShowSaveButton)
            {
                Point p = this.btnReLoad.Location;
                p.X -= 100;
                this.btnReLoad.Location = p;
                p = this.btnRemove.Location;
                p.X -= 100;
                this.btnRemove.Location = p;
            }
        }

        public delegate void OnOperation_Click(Opera _opera);
        public event OnOperation_Click Operation_Click;
    }
}
