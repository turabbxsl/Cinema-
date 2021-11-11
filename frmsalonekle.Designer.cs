namespace Sinema_Proqrami
{
    partial class frmsalonekle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.txtsalonadi = new System.Windows.Forms.TextBox();
            this.btnsalonekle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(21, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "Salon Adi";
            // 
            // txtsalonadi
            // 
            this.txtsalonadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtsalonadi.Location = new System.Drawing.Point(152, 53);
            this.txtsalonadi.Name = "txtsalonadi";
            this.txtsalonadi.Size = new System.Drawing.Size(264, 34);
            this.txtsalonadi.TabIndex = 13;
            // 
            // btnsalonekle
            // 
            this.btnsalonekle.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnsalonekle.FlatAppearance.BorderSize = 0;
            this.btnsalonekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsalonekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnsalonekle.ForeColor = System.Drawing.Color.White;
            this.btnsalonekle.Location = new System.Drawing.Point(152, 112);
            this.btnsalonekle.Name = "btnsalonekle";
            this.btnsalonekle.Size = new System.Drawing.Size(264, 69);
            this.btnsalonekle.TabIndex = 15;
            this.btnsalonekle.Text = "Salon Elave Et";
            this.btnsalonekle.UseVisualStyleBackColor = false;
            this.btnsalonekle.Click += new System.EventHandler(this.btnsalonekle_Click);
            // 
            // frmsalonekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(440, 215);
            this.Controls.Add(this.btnsalonekle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtsalonadi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmsalonekle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmsalonekle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmsalonekle_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtsalonadi;
        private System.Windows.Forms.Button btnsalonekle;
    }
}