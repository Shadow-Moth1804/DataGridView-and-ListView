using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace presentacion
{
    internal class AccionesComunes
    {
        static DataTable dt;
        public static void Mensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void LlenarCombo(string consulta, ComboBox combo, string  id, string txt)
        {
            combo.Items.Clear();
            combo.ValueMember=id;
            combo.DisplayMember=txt;
            dt=conexion.EjecutaSeleccion(consulta);
            DataRow r = dt.NewRow();
            r[0] = 0;
            r[1] = "todos";
            dt.Rows.InsertAt(r, 0);
            if (dt==null)
            {
                return;
            }
            combo.DataSource=dt;
        }

        public static void llenaDatagrid(string consulta, DataGridView datag)
        {
            dt=conexion.EjecutaSeleccion(consulta);
            if (dt == null)
            {
                return;
            }
            datag.DataSource=dt;
        }

        public static void llenalist(string consulta, ListView datal)
        {
            datal.Clear();
            dt=conexion.EjecutaSeleccion(consulta);
            if(dt == null)
            {
                return;
            }
            int col = dt.Columns.Count;
            datal.View=View.Details;

            
            foreach(DataColumn itemc in dt.Columns)
            {
               datal.Columns.Add(Convert.ToString(itemc));
            }

            foreach(DataRow row in dt.Rows)
            {
                ListViewItem iteml= new ListViewItem(Convert.ToString(row[0])); 
                for(int i=1; i<col; i++)
                {
                    iteml.SubItems.Add(Convert.ToString(row[i])); 
                }
                datal.Items.Add(iteml);
            }
        }

    }
}
