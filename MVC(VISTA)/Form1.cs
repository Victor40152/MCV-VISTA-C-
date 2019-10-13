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
        private void guardar()
        {
            objcontacto = new clsContacto();
            objcontacto.opc = 2;
            objcontacto.Id = Convert.ToInt32(txtcodigo.Text);
            objcontacto.Nombre = txtnombre.Text;
            objcontacto.Telefono = txttelefono.Text;
            objcontactoMgr = new ClscontactoMgr(objcontacto);
            objcontactoMgr.Guardardatos();
            MessageBox.Show("Contacto Guardado Exitosamente", "Mensaje");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listar();
            txtcodigo.Focus();
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            guardar();
            listar();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtcodigo.Clear();
            txtnombre.Clear();
            txttelefono.Clear();
            txtcodigo.Focus();
        }

        private void GuardarCambios()
        {
            objcontacto = new clsContacto();
            objcontacto.opc = 3;
            objcontacto.Id = Convert.ToInt32(txtcodigo.Text);
            objcontacto.Nombre = txtnombre.Text;
            objcontacto.Telefono = txttelefono.Text;
            objcontactoMgr = new ClscontactoMgr(objcontacto);
            objcontactoMgr.Guardardatos();
            MessageBox.Show("Cambios Guardados Exitosamente", "Mensaje");
        }

        private void dtregistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[0].Value.ToString();
            txtnombre.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[1].Value.ToString();
            txttelefono.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[2].Value.ToString();
            btnguardar.Enabled = false;
            btnguardarcambios.Enabled = true;
            txtcodigo.Enabled = false;
            btneliminar.Enabled = true;
        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
           
                GuardarCambios();
                listar();
              
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            txtcodigo.Enabled = true;
            btneliminar.Enabled = false;
            LimpiarCampos();

        }

        public void Eliminar()
        {
            objcontacto = new clsContacto();
            objcontacto.opc = 4;
            objcontacto.Id = Convert.ToInt32(txtcodigo.Text);
            objcontactoMgr = new ClscontactoMgr(objcontacto);
            objcontactoMgr.EliminarDatos();
            MessageBox.Show("Registro Eliminado Correctamente", "Mensaje");

           
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            listar();

            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            txtcodigo.Enabled = true;
            btneliminar.Enabled = false;
            LimpiarCampos();

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            txtcodigo.Enabled = true;
            listar();
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            LimpiarCampos();
        }
    }
}
