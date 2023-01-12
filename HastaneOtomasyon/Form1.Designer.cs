
namespace HastaneOtomasyon
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BtnRandevu = new System.Windows.Forms.Button();
            this.BtnHasta = new System.Windows.Forms.Button();
            this.BtnPersonel = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // BtnRandevu
            // 
            this.BtnRandevu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BtnRandevu.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnRandevu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRandevu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnRandevu.ForeColor = System.Drawing.Color.Navy;
            this.BtnRandevu.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnRandevu.ImageKey = "medical-appointment.png";
            this.BtnRandevu.ImageList = this.ımageList1;
            this.BtnRandevu.Location = new System.Drawing.Point(753, 119);
            this.BtnRandevu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnRandevu.Name = "BtnRandevu";
            this.BtnRandevu.Size = new System.Drawing.Size(258, 213);
            this.BtnRandevu.TabIndex = 8;
            this.BtnRandevu.Text = "RANDEVU";
            this.BtnRandevu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnRandevu.UseVisualStyleBackColor = false;
            this.BtnRandevu.Click += new System.EventHandler(this.BtnRandevu_Click);
            // 
            // BtnHasta
            // 
            this.BtnHasta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BtnHasta.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnHasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnHasta.ForeColor = System.Drawing.Color.Navy;
            this.BtnHasta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnHasta.ImageKey = "patient(1).png";
            this.BtnHasta.ImageList = this.ımageList1;
            this.BtnHasta.Location = new System.Drawing.Point(438, 119);
            this.BtnHasta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnHasta.Name = "BtnHasta";
            this.BtnHasta.Size = new System.Drawing.Size(258, 213);
            this.BtnHasta.TabIndex = 7;
            this.BtnHasta.Text = "HASTA";
            this.BtnHasta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnHasta.UseVisualStyleBackColor = false;
            this.BtnHasta.Click += new System.EventHandler(this.BtnHasta_Click);
            // 
            // BtnPersonel
            // 
            this.BtnPersonel.BackColor = System.Drawing.Color.Thistle;
            this.BtnPersonel.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnPersonel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPersonel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnPersonel.ForeColor = System.Drawing.Color.Navy;
            this.BtnPersonel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPersonel.ImageKey = "medical-team(2).png";
            this.BtnPersonel.ImageList = this.ımageList1;
            this.BtnPersonel.Location = new System.Drawing.Point(125, 119);
            this.BtnPersonel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnPersonel.Name = "BtnPersonel";
            this.BtnPersonel.Size = new System.Drawing.Size(258, 213);
            this.BtnPersonel.TabIndex = 6;
            this.BtnPersonel.Text = "PERSONEL";
            this.BtnPersonel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPersonel.UseVisualStyleBackColor = false;
            this.BtnPersonel.Click += new System.EventHandler(this.BtnPersonel_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "icons8-remove-96(1).png");
            this.ımageList1.Images.SetKeyName(1, "icons8-save-96.png");
            this.ımageList1.Images.SetKeyName(2, "icons8-update-left-rotation-96(1).png");
            this.ımageList1.Images.SetKeyName(3, "medical-appointment.png");
            this.ımageList1.Images.SetKeyName(4, "medical-team(2).png");
            this.ımageList1.Images.SetKeyName(5, "patient(1).png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = global::HastaneOtomasyon.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1162, 776);
            this.Controls.Add(this.BtnRandevu);
            this.Controls.Add(this.BtnHasta);
            this.Controls.Add(this.BtnPersonel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnRandevu;
        private System.Windows.Forms.Button BtnHasta;
        private System.Windows.Forms.Button BtnPersonel;
        private System.Windows.Forms.ImageList ımageList1;
    }
}

