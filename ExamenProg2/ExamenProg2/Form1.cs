using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenProg2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            verificar();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            verificar();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            verificar();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            verificar();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            verificar();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            //años
            dgvTabla.Columns.Add("Columna1", "años");
            int plazo = int.Parse(txtPlazo.Text);
            for (int i = 0; i < plazo; i++)
            {
                dgvTabla.Columns.Add("Columna" + i, "" + i);

            }
            dgvTabla.Columns.Add("Columna" + plazo, "" + plazo);
            //ingresos
            String[] ingresos = new string[plazo + 2];
            ingresos[0] = "Ingresos Anuales";
            for (int i = 2; i < plazo + 2; i++)
            {
                ingresos[i] = txtIngresos.Text;
            }
            dgvTabla.Rows.Add(ingresos);
            //Costos
            String[] costos = new string[plazo + 2];
            costos[0] = "Costos Fijos";
            for (int i = 2; i < plazo + 2; i++)
            {
                costos[i] = txtCostos.Text;
            }
            dgvTabla.Rows.Add(costos);
            //depreciacion
            String[] depreciacion = new string[plazo + 2];
            depreciacion[0] = "Depreciacion";
            for (int i = 2; i < plazo + 2; i++)
            {

                int dep = int.Parse(txtInversion.Text) / (plazo - 2);

                depreciacion[i] = dep.ToString();
            }
            dgvTabla.Rows.Add(depreciacion);
            //Utilidad antes de <IR
            String[] utilidad = new string[plazo + 2];
            utilidad[0] = "Utilidad antes de IR";
            for (int i = 2; i < plazo + 2; i++)
            {
                int utilidades = int.Parse(txtIngresos.Text) - int.Parse(txtCostos.Text) - int.Parse(depreciacion[3]);
                utilidad[i] = utilidades.ToString();
            }
            dgvTabla.Rows.Add(utilidad);


            //Ir
            String[] ir = new string[plazo + 2];
            ir[0] = "IR";
            for (int i = 2; i < plazo + 2; i++)
            {
                int irs = ((int.Parse(txtIngresos.Text) - int.Parse(txtCostos.Text) - int.Parse(depreciacion[3])) * 30) / 100;


                ir[i] = irs.ToString();
            }
            dgvTabla.Rows.Add(ir);
            //Utilidad despues de IR
            String[] DespuesIr = new string[plazo + 2];
            DespuesIr[0] = "Utilidad despues de IR";
            for (int i = 2; i < plazo + 2; i++)
            {
                int dIr = ((int.Parse(txtIngresos.Text) - int.Parse(txtCostos.Text) - int.Parse(depreciacion[3])) * 70) / 100;


                DespuesIr[i] = dIr.ToString();
            }
            dgvTabla.Rows.Add(DespuesIr);
            //Repetimos depreciacion

            depreciacion[0] = "Depreciacion";
            for (int i = 2; i < plazo + 2; i++)
            {

                int dep = int.Parse(txtInversion.Text) / (plazo - 2);

                depreciacion[i] = dep.ToString();
            }
            dgvTabla.Rows.Add(depreciacion);

            //Valor salvamento
            String[] valorSalvamento = new string[plazo + 2];
            valorSalvamento[0] = "Valor Salvamento";
            for (int i = 2; i < plazo + 1; i++)
            {
                valorSalvamento[i] = " 0";
            }
            valorSalvamento[plazo + 1] = txtSalvamento.Text;
            dgvTabla.Rows.Add(valorSalvamento);
            //Inversion
            String[] inversion = new string[plazo + 2];
            inversion[0] = "Inversion";
            inversion[1] = txtInversion.Text;

            for (int i = 3; i < plazo + 2; i++)
            {
                inversion[i] = " 0";
            }
            dgvTabla.Rows.Add(inversion);
            //Fne
            String[] fne = new string[plazo + 2];
            fne[0] = "FNE";
            fne[1] = "-" + txtInversion.Text;
            for (int i = 2; i < plazo + 1; i++)
            {
                int totalFNE = int.Parse(DespuesIr[3]) + int.Parse(depreciacion[3]);
                fne[i] = totalFNE.ToString();
            }
            int totalFinal = int.Parse(DespuesIr[3]) + int.Parse(depreciacion[3]) + int.Parse(valorSalvamento[plazo + 1]);
            fne [plazo + 1] = totalFinal.ToString();

            dgvTabla.Rows.Add(fne);
            //FNe acumulado
            String[] fneAcum = new string[plazo + 2];
            int acump = int.Parse(fne[1]);
            fneAcum[0] = "FNE Acumulado";
            fneAcum[1] = fne[1];
            for (int i = 2; i < plazo + 1; i++)
            {
                int fneA = int.Parse(fne[i - 1]);
                int fneF = fneA + int.Parse(fne[i]);
                fneAcum[i] = fneF.ToString();
            }
            fneAcum[plazo + 1] = "-";
            dgvTabla.Rows.Add(fneAcum);
            //vpn
            string[] vpnF = new string[plazo+2];
            double[] vpnFF = new double[plazo+2];
            
            double total = 0;
            for (int i = 2; i < plazo + 2; i++)
            {
                double tasa = (double.Parse(txtTasa.Text) / 100)+1;
                
               
                 
                double ciclo = double.Parse(fne[i]) /Math.Pow(tasa,i);
                total += ciclo;

                    
            }
            
            double resultado = total + double.Parse(fne[1]);

            txtVpn.Text =Math.Round(resultado).ToString();
            //pr
            for(int i = 1; i < plazo + 1; i++)
            {
                if (int.Parse(fneAcum[i])>0)
                {
                    txtPr.Text = i.ToString()+" Años";
                    break;
                }
            }
        }
        private void verificar()
        {
            var vr = !string.IsNullOrEmpty(txtInversion.Text) && !string.IsNullOrEmpty(txtPlazo.Text) && !string.IsNullOrEmpty(txtTasa.Text)
                && !string.IsNullOrEmpty(txtSalvamento.Text) 
                && !string.IsNullOrEmpty(txtIngresos.Text) && !string.IsNullOrEmpty(txtCostos.Text);
            
                btnCrear.Enabled = vr;
            

        }
         

        private void Form1_Load(object sender, EventArgs e)
        {
            btnCrear.Enabled = false;
        }

        private void txtInversion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar >=32 && e.KeyChar <= 47)||(e.KeyChar>=58 && e.KeyChar <= 252))
            {
                MessageBox.Show("Solo digitar numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            
        }
    }
}
