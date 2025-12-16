using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;
using System.Net.Http;

namespace ProiectSCD
{
    public partial class Form1 : Form
    {
        private DepartmentService departmentService;

        public Form1()
        {
            InitializeComponent();
            departmentService = new DepartmentService();

            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxSpecializari.Items.AddRange(new string[] { "Cardiologie", "Neurologie", "Diabetologie", "Reumatologie", "Pediatrie" });
        }

        private void Load_Click(object sender, EventArgs e)
        {
            try
            {

                var busyDoctors = departmentService.GetBusyDoctors();

                comboBoxDoctors.DataSource = busyDoctors;
                comboBoxDoctors.DisplayMember = "name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nu s-au putut incarca doctorii ocupati: " + ex.Message);
            }
        }

        private void comboBoxDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDoctors.SelectedItem is Doctor selectedDoctor)
            {

                ListaShifturi.Items.Clear();

                foreach (var shift in selectedDoctor.shifts)
                {

                    ListaShifturi.Items.Add($"Shift ID: {shift.id}, Date: {shift.date.ToShortDateString()}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ListaShifturi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListaDoctori_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaShifturi.Items.Clear();

            if (ListaDoctori.SelectedItem is Doctor selectedDoctor)
            {
                if (selectedDoctor.shifts != null && selectedDoctor.shifts.Count > 0)
                {
                    foreach (var shift in selectedDoctor.shifts)
                    {
                        ListaShifturi.Items.Add($"ID: {shift.id}, Date: {shift.date.ToShortDateString()}");
                    }
                }
                else
                {
                    ListaShifturi.Items.Add("Nicio programare");
                }
            }

        }

        private void LoadDoctori_Click(object sender, EventArgs e)
        {
            if (comboBoxSpecializari.SelectedItem == null)
            {
                MessageBox.Show("Selectati o specializare!");
                return;
            }

            string specializare = comboBoxSpecializari.SelectedItem.ToString();

            var doctori = departmentService.GetAllDoctors()
                            .Where(d => d.specialization.Equals(specializare, StringComparison.OrdinalIgnoreCase))
                            .ToList();

            ListaDoctori.DataSource = doctori;
            ListaDoctori.DisplayMember = "name";
        }

        private void comboBoxSpecializari_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void buttonTotiDoctorii_Click(object sender, EventArgs e)
        {
            try
            {
                var totiDoctorii = departmentService.GetAllDoctors();

                comboBoxTotiDoctorii.DataSource = totiDoctorii;
                comboBoxTotiDoctorii.DisplayMember = "name"; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nu s-au putut incarca doctorii: " + ex.Message);
            }
        }

        private void comboBoxTotiDoctorii_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTotiDoctorii.SelectedItem is Doctor selectedDoctor)
            {
                ListaShifturiTotiDoctori.Items.Clear();

                if (selectedDoctor.shifts != null)
                {
                    foreach (var shift in selectedDoctor.shifts)
                    {
                        ListaShifturiTotiDoctori.Items.Add(
                            $"Shift ID: {shift.id}, Date: {shift.date.ToShortDateString()}");
                    }
                }
            }
        }

        private void ListaShifturiTotiDoctori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
