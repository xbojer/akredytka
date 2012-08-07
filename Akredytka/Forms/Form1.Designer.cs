using BrightIdeasSoftware;
using BrightIdeasSoftware.Design;

namespace Akredytka
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cofnij = new System.Windows.Forms.Button();
            this.RL = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumnSName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RL)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(448, 32);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "TU WPISZ DANE OSOBY";
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.cofnij);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 440);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 51);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.GreenYellow;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(111, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(233, 51);
            this.button2.TabIndex = 1;
            this.button2.Text = "WPUŚĆ (ENTER)";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 51);
            this.button3.TabIndex = 2;
            this.button3.Text = "KUPNO (F8)";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cofnij
            // 
            this.cofnij.BackColor = System.Drawing.Color.Red;
            this.cofnij.Dock = System.Windows.Forms.DockStyle.Right;
            this.cofnij.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cofnij.Location = new System.Drawing.Point(344, 0);
            this.cofnij.Name = "cofnij";
            this.cofnij.Size = new System.Drawing.Size(104, 51);
            this.cofnij.TabIndex = 0;
            this.cofnij.Text = "COFNIJ (F12)";
            this.cofnij.UseVisualStyleBackColor = false;
            this.cofnij.Click += new System.EventHandler(this.cofnij_Click);
            // 
            // RL
            // 
            this.RL.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.RL.AllColumns.Add(this.olvColumnSName);
            this.RL.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RL.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnSName});
            this.RL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RL.EmptyListMsg = "Zacznij wpisywać dane...";
            this.RL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RL.FullRowSelect = true;
            this.RL.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.RL.HideSelection = false;
            this.RL.HighlightBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.RL.HighlightForegroundColor = System.Drawing.Color.White;
            this.RL.IsSearchOnSortColumn = false;
            this.RL.Location = new System.Drawing.Point(0, 32);
            this.RL.MultiSelect = false;
            this.RL.Name = "RL";
            this.RL.RowHeight = 60;
            this.RL.SelectAllOnControlA = false;
            this.RL.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.RL.ShowGroups = false;
            this.RL.ShowSortIndicators = false;
            this.RL.Size = new System.Drawing.Size(448, 408);
            this.RL.SortGroupItemsByPrimaryColumn = false;
            this.RL.TabIndex = 3;
            this.RL.UnfocusedHighlightBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.RL.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.RL.UseAlternatingBackColors = true;
            this.RL.UseCellFormatEvents = true;
            this.RL.UseCompatibleStateImageBehavior = false;
            this.RL.UseCustomSelectionColors = true;
            this.RL.UseExplorerTheme = true;
            this.RL.View = System.Windows.Forms.View.Details;
            this.RL.VirtualMode = true;
            this.RL.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.fastObjectListView1_FormatCell);
            this.RL.Click += new System.EventHandler(this.fastObjectListView1_Click);
            // 
            // olvColumnSName
            // 
            this.olvColumnSName.AspectName = "Id";
            this.olvColumnSName.FillsFreeSpace = true;
            this.olvColumnSName.Hideable = false;
            this.olvColumnSName.Text = "Znalezione osoby:";
            this.olvColumnSName.Width = 111;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 491);
            this.Controls.Add(this.RL);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Fouton - akredytacja";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button cofnij;
        private FastObjectListView RL;
        private OLVColumn olvColumnSName;
    }
}

