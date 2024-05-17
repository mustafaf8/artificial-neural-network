namespace YSAP
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
            this.btnEgit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.listBoxSonuclar = new System.Windows.Forms.ListBox();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnYukle = new System.Windows.Forms.Button();
            this.btnTestEt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEgit
            // 
            this.btnEgit.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEgit.Location = new System.Drawing.Point(334, 12);
            this.btnEgit.Name = "btnEgit";
            this.btnEgit.Size = new System.Drawing.Size(96, 48);
            this.btnEgit.TabIndex = 0;
            this.btnEgit.Text = "Eğit";
            this.btnEgit.UseVisualStyleBackColor = true;
            this.btnEgit.Click += new System.EventHandler(this.btnEgit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(35, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(274, 266);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Location = new System.Drawing.Point(334, 124);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(96, 49);
            this.btnKaydet.TabIndex = 2;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // listBoxSonuclar
            // 
            this.listBoxSonuclar.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSonuclar.FormattingEnabled = true;
            this.listBoxSonuclar.ItemHeight = 15;
            this.listBoxSonuclar.Location = new System.Drawing.Point(461, 12);
            this.listBoxSonuclar.Name = "listBoxSonuclar";
            this.listBoxSonuclar.Size = new System.Drawing.Size(305, 259);
            this.listBoxSonuclar.TabIndex = 3;
            // 
            // btnTemizle
            // 
            this.btnTemizle.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Location = new System.Drawing.Point(334, 229);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(96, 49);
            this.btnTemizle.TabIndex = 4;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnYukle
            // 
            this.btnYukle.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYukle.Location = new System.Drawing.Point(334, 179);
            this.btnYukle.Name = "btnYukle";
            this.btnYukle.Size = new System.Drawing.Size(96, 44);
            this.btnYukle.TabIndex = 5;
            this.btnYukle.Text = "Yükle";
            this.btnYukle.UseVisualStyleBackColor = true;
            this.btnYukle.Click += new System.EventHandler(this.btnYukle_Click);
            // 
            // btnTestEt
            // 
            this.btnTestEt.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTestEt.Location = new System.Drawing.Point(334, 66);
            this.btnTestEt.Name = "btnTestEt";
            this.btnTestEt.Size = new System.Drawing.Size(96, 52);
            this.btnTestEt.TabIndex = 6;
            this.btnTestEt.Text = "Test Et";
            this.btnTestEt.UseVisualStyleBackColor = true;
            this.btnTestEt.Click += new System.EventHandler(this.btnTestEt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 300);
            this.Controls.Add(this.btnTestEt);
            this.Controls.Add(this.btnYukle);
            this.Controls.Add(this.listBoxSonuclar);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnEgit);
            this.Controls.Add(this.btnTemizle);
            this.Name = "Form1";
            this.Text = "Yapay Sinir Ağı";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEgit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.ListBox listBoxSonuclar;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnYukle;
        private System.Windows.Forms.Button btnTestEt;
    }
}
