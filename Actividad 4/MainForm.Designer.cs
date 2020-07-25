namespace Actividad_4
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnCargarImagen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnGrafo;
        private System.Windows.Forms.Label labelMenor;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCargarImagen = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGrafo = new System.Windows.Forms.Button();
            this.labelMenor = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BtnAgentePrim = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BtnARMporPrim = new System.Windows.Forms.Button();
            this.BtnARMporKruskal = new System.Windows.Forms.Button();
            this.lblSubgrafos = new System.Windows.Forms.Label();
            this.lblNumeroSubgrafos = new System.Windows.Forms.Label();
            this.TamAristasPrim = new System.Windows.Forms.ListBox();
            this.BtnAgenteKruskal = new System.Windows.Forms.Button();
            this.TamAristasKruskal = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnCargarImagen
            // 
            this.btnCargarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarImagen.Location = new System.Drawing.Point(942, 12);
            this.btnCargarImagen.Name = "btnCargarImagen";
            this.btnCargarImagen.Size = new System.Drawing.Size(184, 54);
            this.btnCargarImagen.TabIndex = 0;
            this.btnCargarImagen.Text = "Cargar Imagen";
            this.btnCargarImagen.UseVisualStyleBackColor = true;
            this.btnCargarImagen.Click += new System.EventHandler(this.BtnCargarImagenClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(930, 561);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(1092, 591);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(92, 39);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrarClick);
            // 
            // btnGrafo
            // 
            this.btnGrafo.Enabled = false;
            this.btnGrafo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrafo.Location = new System.Drawing.Point(1132, 13);
            this.btnGrafo.Name = "btnGrafo";
            this.btnGrafo.Size = new System.Drawing.Size(184, 53);
            this.btnGrafo.TabIndex = 5;
            this.btnGrafo.Text = "Crear Grafo";
            this.btnGrafo.UseVisualStyleBackColor = true;
            this.btnGrafo.Click += new System.EventHandler(this.BtnGrafoClick);
            // 
            // labelMenor
            // 
            this.labelMenor.Location = new System.Drawing.Point(9, 681);
            this.labelMenor.Name = "labelMenor";
            this.labelMenor.Size = new System.Drawing.Size(996, 23);
            this.labelMenor.TabIndex = 7;
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(943, 72);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(92, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BtnAgentePrim
            // 
            this.BtnAgentePrim.Enabled = false;
            this.BtnAgentePrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgentePrim.Location = new System.Drawing.Point(943, 150);
            this.BtnAgentePrim.Name = "BtnAgentePrim";
            this.BtnAgentePrim.Size = new System.Drawing.Size(171, 34);
            this.BtnAgentePrim.TabIndex = 9;
            this.BtnAgentePrim.Text = "Agente por Prim";
            this.BtnAgentePrim.UseVisualStyleBackColor = true;
            this.BtnAgentePrim.Click += new System.EventHandler(this.BtnAgentePrim_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(943, 397);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(374, 186);
            this.listBox1.TabIndex = 10;
            // 
            // BtnARMporPrim
            // 
            this.BtnARMporPrim.Enabled = false;
            this.BtnARMporPrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnARMporPrim.Location = new System.Drawing.Point(1134, 72);
            this.BtnARMporPrim.Name = "BtnARMporPrim";
            this.BtnARMporPrim.Size = new System.Drawing.Size(183, 32);
            this.BtnARMporPrim.TabIndex = 13;
            this.BtnARMporPrim.Text = "Crear ARM por Prim";
            this.BtnARMporPrim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnARMporPrim.UseVisualStyleBackColor = true;
            this.BtnARMporPrim.Click += new System.EventHandler(this.BtnARMporPrim_Click);
            // 
            // BtnARMporKruskal
            // 
            this.BtnARMporKruskal.Enabled = false;
            this.BtnARMporKruskal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnARMporKruskal.Location = new System.Drawing.Point(1135, 110);
            this.BtnARMporKruskal.Name = "BtnARMporKruskal";
            this.BtnARMporKruskal.Size = new System.Drawing.Size(182, 30);
            this.BtnARMporKruskal.TabIndex = 14;
            this.BtnARMporKruskal.Text = "Crear ARM por Kruskal";
            this.BtnARMporKruskal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnARMporKruskal.UseVisualStyleBackColor = true;
            this.BtnARMporKruskal.Click += new System.EventHandler(this.BtnARMporKruskal_Click);
            // 
            // lblSubgrafos
            // 
            this.lblSubgrafos.AutoSize = true;
            this.lblSubgrafos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubgrafos.Location = new System.Drawing.Point(942, 104);
            this.lblSubgrafos.Name = "lblSubgrafos";
            this.lblSubgrafos.Size = new System.Drawing.Size(87, 20);
            this.lblSubgrafos.TabIndex = 15;
            this.lblSubgrafos.Text = "Subgrafos:";
            // 
            // lblNumeroSubgrafos
            // 
            this.lblNumeroSubgrafos.AutoSize = true;
            this.lblNumeroSubgrafos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroSubgrafos.Location = new System.Drawing.Point(1035, 101);
            this.lblNumeroSubgrafos.Name = "lblNumeroSubgrafos";
            this.lblNumeroSubgrafos.Size = new System.Drawing.Size(0, 24);
            this.lblNumeroSubgrafos.TabIndex = 16;
            // 
            // TamAristasPrim
            // 
            this.TamAristasPrim.FormattingEnabled = true;
            this.TamAristasPrim.Location = new System.Drawing.Point(946, 203);
            this.TamAristasPrim.Name = "TamAristasPrim";
            this.TamAristasPrim.Size = new System.Drawing.Size(180, 186);
            this.TamAristasPrim.TabIndex = 17;
            // 
            // BtnAgenteKruskal
            // 
            this.BtnAgenteKruskal.Enabled = false;
            this.BtnAgenteKruskal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgenteKruskal.Location = new System.Drawing.Point(1135, 150);
            this.BtnAgenteKruskal.Name = "BtnAgenteKruskal";
            this.BtnAgenteKruskal.Size = new System.Drawing.Size(181, 34);
            this.BtnAgenteKruskal.TabIndex = 18;
            this.BtnAgenteKruskal.Text = "Agente por Kruskal";
            this.BtnAgenteKruskal.UseVisualStyleBackColor = true;
            this.BtnAgenteKruskal.Click += new System.EventHandler(this.BtnKruskal_Click);
            // 
            // TamAristasKruskal
            // 
            this.TamAristasKruskal.FormattingEnabled = true;
            this.TamAristasKruskal.Location = new System.Drawing.Point(1135, 203);
            this.TamAristasKruskal.Name = "TamAristasKruskal";
            this.TamAristasKruskal.Size = new System.Drawing.Size(182, 186);
            this.TamAristasKruskal.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 641);
            this.Controls.Add(this.TamAristasKruskal);
            this.Controls.Add(this.BtnAgenteKruskal);
            this.Controls.Add(this.TamAristasPrim);
            this.Controls.Add(this.lblNumeroSubgrafos);
            this.Controls.Add(this.lblSubgrafos);
            this.Controls.Add(this.BtnARMporKruskal);
            this.Controls.Add(this.BtnARMporPrim);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.BtnAgentePrim);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelMenor);
            this.Controls.Add(this.btnGrafo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCargarImagen);
            this.Name = "MainForm";
            this.Text = "Actividad 4";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BtnAgentePrim;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BtnARMporPrim;
        private System.Windows.Forms.Button BtnARMporKruskal;
        private System.Windows.Forms.Label lblSubgrafos;
        private System.Windows.Forms.Label lblNumeroSubgrafos;
        private System.Windows.Forms.ListBox TamAristasPrim;
        private System.Windows.Forms.Button BtnAgenteKruskal;
        private System.Windows.Forms.ListBox TamAristasKruskal;
    }
}