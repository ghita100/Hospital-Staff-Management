namespace ProiectSCD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            GetBusyDoctors = new Label();
            btnLoad = new Button();
            comboBoxDoctors = new ComboBox();
            Exit = new Button();
            ListaShifturi = new ListBox();
            comboBoxSpecializari = new ComboBox();
            LoadDoctori = new Button();
            ListaDoctori = new ListBox();
            GetAllDoctors = new Label();
            buttonTotiDoctorii = new Button();
            comboBoxTotiDoctorii = new ComboBox();
            ListaShifturiTotiDoctori = new ListBox();
            SuspendLayout();
            // 
            // GetBusyDoctors
            // 
            GetBusyDoctors.AutoSize = true;
            GetBusyDoctors.Location = new Point(0, 114);
            GetBusyDoctors.Name = "GetBusyDoctors";
            GetBusyDoctors.Size = new Size(114, 20);
            GetBusyDoctors.TabIndex = 0;
            GetBusyDoctors.Text = "GetBusyDoctors";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(120, 110);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += Load_Click;
            // 
            // comboBoxDoctors
            // 
            comboBoxDoctors.FormattingEnabled = true;
            comboBoxDoctors.Location = new Point(25, 145);
            comboBoxDoctors.Name = "comboBoxDoctors";
            comboBoxDoctors.Size = new Size(189, 28);
            comboBoxDoctors.TabIndex = 2;
            comboBoxDoctors.SelectedIndexChanged += comboBoxDoctors_SelectedIndexChanged;
            // 
            // Exit
            // 
            Exit.Location = new Point(706, 421);
            Exit.Name = "Exit";
            Exit.Size = new Size(94, 29);
            Exit.TabIndex = 3;
            Exit.Text = "Exit";
            Exit.UseVisualStyleBackColor = true;
            Exit.Click += button1_Click;
            // 
            // ListaShifturi
            // 
            ListaShifturi.FormattingEnabled = true;
            ListaShifturi.Location = new Point(25, 179);
            ListaShifturi.Name = "ListaShifturi";
            ListaShifturi.Size = new Size(189, 104);
            ListaShifturi.TabIndex = 4;
            ListaShifturi.SelectedIndexChanged += ListaShifturi_SelectedIndexChanged;
            // 
            // comboBoxSpecializari
            // 
            comboBoxSpecializari.FormattingEnabled = true;
            comboBoxSpecializari.Location = new Point(262, 114);
            comboBoxSpecializari.Name = "comboBoxSpecializari";
            comboBoxSpecializari.Size = new Size(151, 28);
            comboBoxSpecializari.TabIndex = 5;
            comboBoxSpecializari.SelectedIndexChanged += comboBoxSpecializari_SelectedIndexChanged;
            // 
            // LoadDoctori
            // 
            LoadDoctori.Location = new Point(291, 148);
            LoadDoctori.Name = "LoadDoctori";
            LoadDoctori.Size = new Size(94, 29);
            LoadDoctori.TabIndex = 6;
            LoadDoctori.Text = "Load";
            LoadDoctori.UseVisualStyleBackColor = true;
            LoadDoctori.Click += LoadDoctori_Click;
            // 
            // ListaDoctori
            // 
            ListaDoctori.FormattingEnabled = true;
            ListaDoctori.Location = new Point(262, 179);
            ListaDoctori.Name = "ListaDoctori";
            ListaDoctori.Size = new Size(151, 104);
            ListaDoctori.TabIndex = 7;
            ListaDoctori.SelectedIndexChanged += ListaDoctori_SelectedIndexChanged;
            // 
            // GetAllDoctors
            // 
            GetAllDoctors.AutoSize = true;
            GetAllDoctors.Location = new Point(457, 117);
            GetAllDoctors.Name = "GetAllDoctors";
            GetAllDoctors.Size = new Size(102, 20);
            GetAllDoctors.TabIndex = 8;
            GetAllDoctors.Text = "GetAllDoctors";
            // 
            // buttonTotiDoctorii
            // 
            buttonTotiDoctorii.Location = new Point(565, 114);
            buttonTotiDoctorii.Name = "buttonTotiDoctorii";
            buttonTotiDoctorii.Size = new Size(94, 29);
            buttonTotiDoctorii.TabIndex = 9;
            buttonTotiDoctorii.Text = "Load";
            buttonTotiDoctorii.UseVisualStyleBackColor = true;
            buttonTotiDoctorii.Click += buttonTotiDoctorii_Click;
            // 
            // comboBoxTotiDoctorii
            // 
            comboBoxTotiDoctorii.FormattingEnabled = true;
            comboBoxTotiDoctorii.Location = new Point(472, 145);
            comboBoxTotiDoctorii.Name = "comboBoxTotiDoctorii";
            comboBoxTotiDoctorii.Size = new Size(187, 28);
            comboBoxTotiDoctorii.TabIndex = 10;
            comboBoxTotiDoctorii.SelectedIndexChanged += comboBoxTotiDoctorii_SelectedIndexChanged;
            // 
            // ListaShifturiTotiDoctori
            // 
            ListaShifturiTotiDoctori.FormattingEnabled = true;
            ListaShifturiTotiDoctori.Location = new Point(472, 179);
            ListaShifturiTotiDoctori.Name = "ListaShifturiTotiDoctori";
            ListaShifturiTotiDoctori.Size = new Size(187, 104);
            ListaShifturiTotiDoctori.TabIndex = 11;
            ListaShifturiTotiDoctori.SelectedIndexChanged += ListaShifturiTotiDoctori_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(ListaShifturiTotiDoctori);
            Controls.Add(comboBoxTotiDoctorii);
            Controls.Add(buttonTotiDoctorii);
            Controls.Add(GetAllDoctors);
            Controls.Add(ListaDoctori);
            Controls.Add(LoadDoctori);
            Controls.Add(comboBoxSpecializari);
            Controls.Add(ListaShifturi);
            Controls.Add(Exit);
            Controls.Add(comboBoxDoctors);
            Controls.Add(btnLoad);
            Controls.Add(GetBusyDoctors);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label GetBusyDoctors;
        private Button btnLoad;
        private ComboBox comboBoxDoctors;
        private Button Exit;
        private ListBox ListaShifturi;
        private ComboBox comboBoxSpecializari;
        private Button LoadDoctori;
        private ListBox ListaDoctori;
        private Label GetAllDoctors;
        private Button buttonTotiDoctorii;
        private ComboBox comboBoxTotiDoctorii;
        private ListBox ListaShifturiTotiDoctori;
    }
}
