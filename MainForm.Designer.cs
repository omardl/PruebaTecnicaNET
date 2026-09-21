namespace PruebaTecnicaNET
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            SuspendLayout();
 
            button1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.AntiqueWhite;
            button1.FlatAppearance.BorderColor = SystemColors.HotTrack;
            button1.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(371, 194);
            button1.Name = "button1";
            button1.Size = new Size(239, 82);
            button1.TabIndex = 0;
            button1.Text = "Cargar datos";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button_getData;
 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.Azure;
            label1.Font = new Font("Courier New", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Coral;
            label1.Location = new Point(254, 37);
            label1.Name = "label1";
            label1.Size = new Size(500, 46);
            label1.TabIndex = 1;
            label1.Text = "NET - Prueba técnica";
            label1.TextAlign = ContentAlignment.MiddleCenter;
 
            button2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button2.BackColor = Color.AntiqueWhite;
            button2.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(371, 370);
            button2.Name = "button2";
            button2.Size = new Size(239, 82);
            button2.TabIndex = 2;
            button2.Text = "Mostrar datos filtrados";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button_showData;
 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Courier New", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.HotTrack;
            label4.Location = new Point(379, 109);
            label4.Name = "label4";
            label4.Size = new Size(231, 34);
            label4.TabIndex = 5;
            label4.Text = "Omar Delgado";
            label4.TextAlign = ContentAlignment.MiddleCenter;
 
            textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = Color.Azure;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(275, 293);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(479, 23);
            textBox1.TabIndex = 7;
            textBox1.Text = "Guardar en local el listado de clientes";
            textBox1.TextAlign = HorizontalAlignment.Center;
  
            textBox2.BackColor = Color.Azure;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(65, 470);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(878, 23);
            textBox2.TabIndex = 8;
            textBox2.Text = "Filtrar y mostrar sólo los datos cuyo atributo TagSerie comience por 602";
            textBox2.TextAlign = HorizontalAlignment.Center;
    
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Azure;
            ClientSize = new Size(1035, 577);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPrincipal";
            Text = "Prueba técnica NET - Omar Delgado";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Button button2;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}
