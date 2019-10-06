using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;


namespace MVC_VISTA_
{
    public partial class Form1 : Form
    {

        clsContacto objcontacto = null;
        ClscontactoMgr objcontactoMgr = null;
        DataTable Dtt;

        public Form1()
        {
            InitializeComponent();
        }

        private void listar()
        {
            objcontacto = new clsContacto();
            objcontacto.opc = 1;
            objcontactoMgr = new ClscontactoMgr(objcontacto);

            Dtt = new DataTable();
            Dtt = objcontactoMgr.Listar();
            if (Dtt.Rows.Count > 0)
            {
                dtregistros.DataSource = Dtt;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listar();
        }
    }
}
