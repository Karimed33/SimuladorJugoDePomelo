
namespace SimuladorJugoDePomelo.Vistas
{
    partial class UserPasteurizador
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbEstadoVerde = new System.Windows.Forms.PictureBox();
            this.lbSolucion = new System.Windows.Forms.Label();
            this.txtLitrosAgregados = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEstadoVerde)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(132)))), ((int)(((byte)(19)))));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 393F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.Controls.Add(this.pbEstadoVerde, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbSolucion, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLitrosAgregados, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(618, 55);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pbEstadoVerde
            // 
            this.pbEstadoVerde.Location = new System.Drawing.Point(3, 3);
            this.pbEstadoVerde.Name = "pbEstadoVerde";
            this.pbEstadoVerde.Size = new System.Drawing.Size(59, 47);
            this.pbEstadoVerde.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEstadoVerde.TabIndex = 273;
            this.pbEstadoVerde.TabStop = false;
            this.pbEstadoVerde.Click += new System.EventHandler(this.pbEstado_Click);
            // 
            // lbSolucion
            // 
            this.lbSolucion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSolucion.AutoSize = true;
            this.lbSolucion.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSolucion.ForeColor = System.Drawing.Color.White;
            this.lbSolucion.Location = new System.Drawing.Point(68, 0);
            this.lbSolucion.Name = "lbSolucion";
            this.lbSolucion.Size = new System.Drawing.Size(387, 55);
            this.lbSolucion.TabIndex = 272;
            // 
            // txtLitrosAgregados
            // 
            this.txtLitrosAgregados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(132)))), ((int)(((byte)(19)))));
            this.txtLitrosAgregados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLitrosAgregados.Font = new System.Drawing.Font("Century Gothic", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLitrosAgregados.ForeColor = System.Drawing.Color.White;
            this.txtLitrosAgregados.Location = new System.Drawing.Point(461, 3);
            this.txtLitrosAgregados.Name = "txtLitrosAgregados";
            this.txtLitrosAgregados.Size = new System.Drawing.Size(65, 26);
            this.txtLitrosAgregados.TabIndex = 274;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(538, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 275;
            // 
            // UserPasteurizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserPasteurizador";
            this.Size = new System.Drawing.Size(621, 61);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEstadoVerde)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbSolucion;
        private System.Windows.Forms.PictureBox pbEstadoVerde;
        private System.Windows.Forms.TextBox txtLitrosAgregados;
        private System.Windows.Forms.Label label1;
    }
}
