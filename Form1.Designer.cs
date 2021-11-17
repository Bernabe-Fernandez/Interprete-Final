
namespace Interprete_v1
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblSoft = new System.Windows.Forms.Label();
            this.TxtSalida = new System.Windows.Forms.TextBox();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnIniciar = new System.Windows.Forms.Button();
            this.TxtError = new System.Windows.Forms.TextBox();
            this.LstVTabla = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Valor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TxtSoftware = new System.Windows.Forms.TextBox();
            this.LblError = new System.Windows.Forms.Label();
            this.LblSalida = new System.Windows.Forms.Label();
            this.LblSimbol = new System.Windows.Forms.Label();
            this.BtnAbrir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblSoft
            // 
            this.LblSoft.AutoSize = true;
            this.LblSoft.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSoft.Location = new System.Drawing.Point(12, 17);
            this.LblSoft.Name = "LblSoft";
            this.LblSoft.Size = new System.Drawing.Size(75, 18);
            this.LblSoft.TabIndex = 1;
            this.LblSoft.Text = "Software";
            // 
            // TxtSalida
            // 
            this.TxtSalida.Location = new System.Drawing.Point(8, 283);
            this.TxtSalida.Multiline = true;
            this.TxtSalida.Name = "TxtSalida";
            this.TxtSalida.Size = new System.Drawing.Size(428, 211);
            this.TxtSalida.TabIndex = 19;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.Red;
            this.BtnLimpiar.Location = new System.Drawing.Point(361, 10);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(70, 23);
            this.BtnLimpiar.TabIndex = 18;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnIniciar
            // 
            this.BtnIniciar.BackColor = System.Drawing.Color.Lime;
            this.BtnIniciar.Location = new System.Drawing.Point(285, 10);
            this.BtnIniciar.Name = "BtnIniciar";
            this.BtnIniciar.Size = new System.Drawing.Size(70, 23);
            this.BtnIniciar.TabIndex = 17;
            this.BtnIniciar.Text = "Iniciar";
            this.BtnIniciar.UseVisualStyleBackColor = false;
            this.BtnIniciar.Click += new System.EventHandler(this.BtnIniciar_Click);
            // 
            // TxtError
            // 
            this.TxtError.Location = new System.Drawing.Point(443, 283);
            this.TxtError.Multiline = true;
            this.TxtError.Name = "TxtError";
            this.TxtError.Size = new System.Drawing.Size(263, 211);
            this.TxtError.TabIndex = 16;
            // 
            // LstVTabla
            // 
            this.LstVTabla.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Tipo,
            this.Valor});
            this.LstVTabla.HideSelection = false;
            this.LstVTabla.Location = new System.Drawing.Point(443, 39);
            this.LstVTabla.Name = "LstVTabla";
            this.LstVTabla.Size = new System.Drawing.Size(263, 220);
            this.LstVTabla.TabIndex = 15;
            this.LstVTabla.UseCompatibleStateImageBehavior = false;
            this.LstVTabla.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // Tipo
            // 
            this.Tipo.Text = "TIPO";
            // 
            // Valor
            // 
            this.Valor.Text = "VALOR";
            // 
            // TxtSoftware
            // 
            this.TxtSoftware.Location = new System.Drawing.Point(8, 39);
            this.TxtSoftware.Multiline = true;
            this.TxtSoftware.Name = "TxtSoftware";
            this.TxtSoftware.Size = new System.Drawing.Size(428, 220);
            this.TxtSoftware.TabIndex = 14;
            // 
            // LblError
            // 
            this.LblError.AutoSize = true;
            this.LblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblError.Location = new System.Drawing.Point(446, 262);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(65, 18);
            this.LblError.TabIndex = 13;
            this.LblError.Text = "Errores";
            // 
            // LblSalida
            // 
            this.LblSalida.AutoSize = true;
            this.LblSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSalida.Location = new System.Drawing.Point(5, 262);
            this.LblSalida.Name = "LblSalida";
            this.LblSalida.Size = new System.Drawing.Size(54, 18);
            this.LblSalida.TabIndex = 12;
            this.LblSalida.Text = "Salida";
            // 
            // LblSimbol
            // 
            this.LblSimbol.AutoSize = true;
            this.LblSimbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSimbol.Location = new System.Drawing.Point(440, 17);
            this.LblSimbol.Name = "LblSimbol";
            this.LblSimbol.Size = new System.Drawing.Size(151, 18);
            this.LblSimbol.TabIndex = 11;
            this.LblSimbol.Text = "Tabla De Simbolos";
            // 
            // BtnAbrir
            // 
            this.BtnAbrir.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnAbrir.Location = new System.Drawing.Point(209, 10);
            this.BtnAbrir.Name = "BtnAbrir";
            this.BtnAbrir.Size = new System.Drawing.Size(70, 23);
            this.BtnAbrir.TabIndex = 20;
            this.BtnAbrir.Text = "Abrir";
            this.BtnAbrir.UseVisualStyleBackColor = false;
            this.BtnAbrir.Click += new System.EventHandler(this.BtnAbrir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 515);
            this.Controls.Add(this.BtnAbrir);
            this.Controls.Add(this.TxtSalida);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnIniciar);
            this.Controls.Add(this.TxtError);
            this.Controls.Add(this.LstVTabla);
            this.Controls.Add(this.TxtSoftware);
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.LblSalida);
            this.Controls.Add(this.LblSimbol);
            this.Controls.Add(this.LblSoft);
            this.Name = "Form1";
            this.Text = "Interprete 1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblSoft;
        private System.Windows.Forms.TextBox TxtSalida;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnIniciar;
        private System.Windows.Forms.TextBox TxtError;
        private System.Windows.Forms.ListView LstVTabla;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Tipo;
        private System.Windows.Forms.ColumnHeader Valor;
        private System.Windows.Forms.TextBox TxtSoftware;
        private System.Windows.Forms.Label LblError;
        private System.Windows.Forms.Label LblSalida;
        private System.Windows.Forms.Label LblSimbol;
        private System.Windows.Forms.Button BtnAbrir;
    }
}

