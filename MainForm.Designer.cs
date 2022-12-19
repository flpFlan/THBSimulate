namespace THBSimulate
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.OutPutBox = new System.Windows.Forms.RichTextBox();
            this.startBotton = new System.Windows.Forms.Button();
            this.P1 = new System.Windows.Forms.Panel();
            this.characterP1 = new System.Windows.Forms.ComboBox();
            this.hpP1 = new System.Windows.Forms.Label();
            this.handCardP1 = new System.Windows.Forms.Label();
            this.judgesP1 = new System.Windows.Forms.TextBox();
            this.grimoireP1 = new System.Windows.Forms.TextBox();
            this.weaponP1 = new System.Windows.Forms.TextBox();
            this.sheildP1 = new System.Windows.Forms.TextBox();
            this.redUfoP1 = new System.Windows.Forms.TextBox();
            this.greenUfoP1 = new System.Windows.Forms.TextBox();
            this.nameP1 = new System.Windows.Forms.Label();
            this.P2 = new System.Windows.Forms.Panel();
            this.characterP2 = new System.Windows.Forms.ComboBox();
            this.hpP2 = new System.Windows.Forms.Label();
            this.handCardP2 = new System.Windows.Forms.Label();
            this.judgesP2 = new System.Windows.Forms.TextBox();
            this.grimoireP2 = new System.Windows.Forms.TextBox();
            this.weaponP2 = new System.Windows.Forms.TextBox();
            this.sheildP2 = new System.Windows.Forms.TextBox();
            this.redUfoP2 = new System.Windows.Forms.TextBox();
            this.greenUfoP2 = new System.Windows.Forms.TextBox();
            this.nameP2 = new System.Windows.Forms.Label();
            this.speedControl = new System.Windows.Forms.NumericUpDown();
            this.cardStack = new System.Windows.Forms.Label();
            this.tips = new System.Windows.Forms.Label();
            this.P1.SuspendLayout();
            this.P2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedControl)).BeginInit();
            this.SuspendLayout();
            // 
            // OutPutBox
            // 
            this.OutPutBox.Location = new System.Drawing.Point(995, 1);
            this.OutPutBox.Name = "OutPutBox";
            this.OutPutBox.ReadOnly = true;
            this.OutPutBox.Size = new System.Drawing.Size(288, 848);
            this.OutPutBox.TabIndex = 0;
            this.OutPutBox.Text = "";
            this.OutPutBox.TextChanged += new System.EventHandler(this.OutPutBox_TextChanged);
            // 
            // startBotton
            // 
            this.startBotton.Location = new System.Drawing.Point(442, 672);
            this.startBotton.Name = "startBotton";
            this.startBotton.Size = new System.Drawing.Size(94, 60);
            this.startBotton.TabIndex = 1;
            this.startBotton.Text = "开始";
            this.startBotton.UseVisualStyleBackColor = true;
            this.startBotton.Click += new System.EventHandler(this.startBotton_Click);
            // 
            // P1
            // 
            this.P1.Controls.Add(this.characterP1);
            this.P1.Controls.Add(this.hpP1);
            this.P1.Controls.Add(this.handCardP1);
            this.P1.Controls.Add(this.judgesP1);
            this.P1.Controls.Add(this.grimoireP1);
            this.P1.Controls.Add(this.weaponP1);
            this.P1.Controls.Add(this.sheildP1);
            this.P1.Controls.Add(this.redUfoP1);
            this.P1.Controls.Add(this.greenUfoP1);
            this.P1.Controls.Add(this.nameP1);
            this.P1.Location = new System.Drawing.Point(12, 492);
            this.P1.Name = "P1";
            this.P1.Size = new System.Drawing.Size(257, 237);
            this.P1.TabIndex = 2;
            // 
            // characterP1
            // 
            this.characterP1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.characterP1.FormattingEnabled = true;
            this.characterP1.Items.AddRange(new object[] {
            "白板",
            "妖梦",
            "小恶魔"});
            this.characterP1.Location = new System.Drawing.Point(3, 3);
            this.characterP1.Name = "characterP1";
            this.characterP1.Size = new System.Drawing.Size(251, 27);
            this.characterP1.TabIndex = 10;
            this.characterP1.Text = "小恶魔";
            // 
            // hpP1
            // 
            this.hpP1.AutoSize = true;
            this.hpP1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hpP1.ForeColor = System.Drawing.Color.Red;
            this.hpP1.Location = new System.Drawing.Point(150, 33);
            this.hpP1.Name = "hpP1";
            this.hpP1.Size = new System.Drawing.Size(35, 39);
            this.hpP1.TabIndex = 10;
            this.hpP1.Text = "0";
            this.hpP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // handCardP1
            // 
            this.handCardP1.AutoSize = true;
            this.handCardP1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.handCardP1.Location = new System.Drawing.Point(191, 33);
            this.handCardP1.Name = "handCardP1";
            this.handCardP1.Size = new System.Drawing.Size(35, 39);
            this.handCardP1.TabIndex = 9;
            this.handCardP1.Text = "0";
            this.handCardP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // judgesP1
            // 
            this.judgesP1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.judgesP1.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.judgesP1.Location = new System.Drawing.Point(124, 75);
            this.judgesP1.Multiline = true;
            this.judgesP1.Name = "judgesP1";
            this.judgesP1.ReadOnly = true;
            this.judgesP1.Size = new System.Drawing.Size(130, 159);
            this.judgesP1.TabIndex = 8;
            this.judgesP1.Text = "封";
            // 
            // grimoireP1
            // 
            this.grimoireP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grimoireP1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.grimoireP1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.grimoireP1.Location = new System.Drawing.Point(3, 207);
            this.grimoireP1.MaxLength = 10;
            this.grimoireP1.Name = "grimoireP1";
            this.grimoireP1.ReadOnly = true;
            this.grimoireP1.Size = new System.Drawing.Size(115, 27);
            this.grimoireP1.TabIndex = 7;
            this.grimoireP1.Text = "null";
            this.grimoireP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // weaponP1
            // 
            this.weaponP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weaponP1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.weaponP1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.weaponP1.Location = new System.Drawing.Point(3, 75);
            this.weaponP1.MaxLength = 10;
            this.weaponP1.Name = "weaponP1";
            this.weaponP1.ReadOnly = true;
            this.weaponP1.Size = new System.Drawing.Size(115, 27);
            this.weaponP1.TabIndex = 6;
            this.weaponP1.Text = "null";
            this.weaponP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sheildP1
            // 
            this.sheildP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sheildP1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.sheildP1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.sheildP1.Location = new System.Drawing.Point(3, 108);
            this.sheildP1.MaxLength = 10;
            this.sheildP1.Name = "sheildP1";
            this.sheildP1.ReadOnly = true;
            this.sheildP1.Size = new System.Drawing.Size(115, 27);
            this.sheildP1.TabIndex = 5;
            this.sheildP1.Text = "null";
            this.sheildP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // redUfoP1
            // 
            this.redUfoP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.redUfoP1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.redUfoP1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.redUfoP1.Location = new System.Drawing.Point(3, 141);
            this.redUfoP1.MaxLength = 10;
            this.redUfoP1.Name = "redUfoP1";
            this.redUfoP1.ReadOnly = true;
            this.redUfoP1.Size = new System.Drawing.Size(115, 27);
            this.redUfoP1.TabIndex = 4;
            this.redUfoP1.Text = "null";
            this.redUfoP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // greenUfoP1
            // 
            this.greenUfoP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.greenUfoP1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.greenUfoP1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.greenUfoP1.Location = new System.Drawing.Point(3, 174);
            this.greenUfoP1.MaxLength = 10;
            this.greenUfoP1.Name = "greenUfoP1";
            this.greenUfoP1.ReadOnly = true;
            this.greenUfoP1.Size = new System.Drawing.Size(115, 27);
            this.greenUfoP1.TabIndex = 3;
            this.greenUfoP1.Text = "null";
            this.greenUfoP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nameP1
            // 
            this.nameP1.AutoSize = true;
            this.nameP1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameP1.ForeColor = System.Drawing.Color.Red;
            this.nameP1.Location = new System.Drawing.Point(33, 33);
            this.nameP1.Name = "nameP1";
            this.nameP1.Size = new System.Drawing.Size(53, 39);
            this.nameP1.TabIndex = 2;
            this.nameP1.Text = "P1";
            this.nameP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P2
            // 
            this.P2.Controls.Add(this.characterP2);
            this.P2.Controls.Add(this.hpP2);
            this.P2.Controls.Add(this.handCardP2);
            this.P2.Controls.Add(this.judgesP2);
            this.P2.Controls.Add(this.grimoireP2);
            this.P2.Controls.Add(this.weaponP2);
            this.P2.Controls.Add(this.sheildP2);
            this.P2.Controls.Add(this.redUfoP2);
            this.P2.Controls.Add(this.greenUfoP2);
            this.P2.Controls.Add(this.nameP2);
            this.P2.Location = new System.Drawing.Point(732, 492);
            this.P2.Name = "P2";
            this.P2.Size = new System.Drawing.Size(257, 240);
            this.P2.TabIndex = 3;
            // 
            // characterP2
            // 
            this.characterP2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.characterP2.FormattingEnabled = true;
            this.characterP2.Items.AddRange(new object[] {
            "白板",
            "妖梦",
            "小恶魔"});
            this.characterP2.Location = new System.Drawing.Point(3, 3);
            this.characterP2.Name = "characterP2";
            this.characterP2.Size = new System.Drawing.Size(251, 27);
            this.characterP2.TabIndex = 11;
            this.characterP2.Text = "妖梦";
            // 
            // hpP2
            // 
            this.hpP2.AutoSize = true;
            this.hpP2.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hpP2.ForeColor = System.Drawing.Color.Red;
            this.hpP2.Location = new System.Drawing.Point(149, 36);
            this.hpP2.Name = "hpP2";
            this.hpP2.Size = new System.Drawing.Size(35, 39);
            this.hpP2.TabIndex = 11;
            this.hpP2.Text = "0";
            this.hpP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // handCardP2
            // 
            this.handCardP2.AutoSize = true;
            this.handCardP2.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.handCardP2.Location = new System.Drawing.Point(190, 36);
            this.handCardP2.Name = "handCardP2";
            this.handCardP2.Size = new System.Drawing.Size(35, 39);
            this.handCardP2.TabIndex = 9;
            this.handCardP2.Text = "0";
            this.handCardP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // judgesP2
            // 
            this.judgesP2.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.judgesP2.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.judgesP2.Location = new System.Drawing.Point(124, 78);
            this.judgesP2.Multiline = true;
            this.judgesP2.Name = "judgesP2";
            this.judgesP2.ReadOnly = true;
            this.judgesP2.Size = new System.Drawing.Size(130, 159);
            this.judgesP2.TabIndex = 8;
            this.judgesP2.Text = "封";
            // 
            // grimoireP2
            // 
            this.grimoireP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grimoireP2.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.grimoireP2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.grimoireP2.Location = new System.Drawing.Point(3, 210);
            this.grimoireP2.MaxLength = 10;
            this.grimoireP2.Name = "grimoireP2";
            this.grimoireP2.ReadOnly = true;
            this.grimoireP2.Size = new System.Drawing.Size(115, 27);
            this.grimoireP2.TabIndex = 7;
            this.grimoireP2.Text = "null";
            this.grimoireP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // weaponP2
            // 
            this.weaponP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weaponP2.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.weaponP2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.weaponP2.Location = new System.Drawing.Point(3, 78);
            this.weaponP2.MaxLength = 10;
            this.weaponP2.Name = "weaponP2";
            this.weaponP2.ReadOnly = true;
            this.weaponP2.Size = new System.Drawing.Size(115, 27);
            this.weaponP2.TabIndex = 6;
            this.weaponP2.Text = "null";
            this.weaponP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sheildP2
            // 
            this.sheildP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sheildP2.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.sheildP2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.sheildP2.Location = new System.Drawing.Point(3, 111);
            this.sheildP2.MaxLength = 10;
            this.sheildP2.Name = "sheildP2";
            this.sheildP2.ReadOnly = true;
            this.sheildP2.Size = new System.Drawing.Size(115, 27);
            this.sheildP2.TabIndex = 5;
            this.sheildP2.Text = "null";
            this.sheildP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // redUfoP2
            // 
            this.redUfoP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.redUfoP2.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.redUfoP2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.redUfoP2.Location = new System.Drawing.Point(3, 144);
            this.redUfoP2.MaxLength = 10;
            this.redUfoP2.Name = "redUfoP2";
            this.redUfoP2.ReadOnly = true;
            this.redUfoP2.Size = new System.Drawing.Size(115, 27);
            this.redUfoP2.TabIndex = 4;
            this.redUfoP2.Text = "null";
            this.redUfoP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // greenUfoP2
            // 
            this.greenUfoP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.greenUfoP2.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.greenUfoP2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.greenUfoP2.Location = new System.Drawing.Point(3, 177);
            this.greenUfoP2.MaxLength = 10;
            this.greenUfoP2.Name = "greenUfoP2";
            this.greenUfoP2.ReadOnly = true;
            this.greenUfoP2.Size = new System.Drawing.Size(115, 27);
            this.greenUfoP2.TabIndex = 3;
            this.greenUfoP2.Text = "null";
            this.greenUfoP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nameP2
            // 
            this.nameP2.AutoSize = true;
            this.nameP2.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameP2.ForeColor = System.Drawing.Color.Red;
            this.nameP2.Location = new System.Drawing.Point(40, 36);
            this.nameP2.Name = "nameP2";
            this.nameP2.Size = new System.Drawing.Size(53, 39);
            this.nameP2.TabIndex = 2;
            this.nameP2.Text = "P2";
            this.nameP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // speedControl
            // 
            this.speedControl.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.speedControl.Location = new System.Drawing.Point(420, 561);
            this.speedControl.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.speedControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.speedControl.Name = "speedControl";
            this.speedControl.ReadOnly = true;
            this.speedControl.Size = new System.Drawing.Size(150, 42);
            this.speedControl.TabIndex = 4;
            this.speedControl.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // cardStack
            // 
            this.cardStack.AutoSize = true;
            this.cardStack.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.cardStack.Font = new System.Drawing.Font("Microsoft YaHei UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cardStack.Location = new System.Drawing.Point(12, 12);
            this.cardStack.Name = "cardStack";
            this.cardStack.Size = new System.Drawing.Size(94, 106);
            this.cardStack.TabIndex = 6;
            this.cardStack.Text = "0";
            this.cardStack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tips
            // 
            this.tips.AutoSize = true;
            this.tips.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tips.Location = new System.Drawing.Point(469, 538);
            this.tips.Name = "tips";
            this.tips.Size = new System.Drawing.Size(39, 20);
            this.tips.TabIndex = 8;
            this.tips.Text = "速率";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 851);
            this.Controls.Add(this.tips);
            this.Controls.Add(this.cardStack);
            this.Controls.Add(this.speedControl);
            this.Controls.Add(this.P2);
            this.Controls.Add(this.P1);
            this.Controls.Add(this.startBotton);
            this.Controls.Add(this.OutPutBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Simulate";
            this.P1.ResumeLayout(false);
            this.P1.PerformLayout();
            this.P2.ResumeLayout(false);
            this.P2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox OutPutBox;
        private Button startBotton;
        private Panel P1;
        private TextBox grimoireP1;
        private TextBox weaponP1;
        private TextBox sheildP1;
        private TextBox redUfoP1;
        private TextBox greenUfoP1;
        private Label nameP1;
        private Label handCardP1;
        private TextBox judgesP1;
        private Panel P2;
        private Label handCardP2;
        private TextBox judgesP2;
        private TextBox grimoireP2;
        private TextBox weaponP2;
        private TextBox sheildP2;
        private TextBox redUfoP2;
        private TextBox greenUfoP2;
        private Label nameP2;
        private NumericUpDown speedControl;
        private Label hpP1;
        private Label hpP2;
        private Label cardStack;
        private Label tips;
        private ComboBox characterP1;
        private ComboBox characterP2;
    }
}