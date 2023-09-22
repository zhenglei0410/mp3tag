namespace mp3tag
{
    partial class mainForm
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
            gBPendingFiles = new GroupBox();
            btnAddFiles = new Button();
            lVPendingFiles = new ListView();
            gBProcessedFiles = new GroupBox();
            lbMessage = new Label();
            lVProcessedFiles = new ListView();
            gBMethod = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            cBSkip = new CheckBox();
            btnTitle = new Button();
            btnName = new Button();
            btnAll = new Button();
            btnClear = new Button();
            oFD = new OpenFileDialog();
            gBPendingFiles.SuspendLayout();
            gBProcessedFiles.SuspendLayout();
            gBMethod.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // gBPendingFiles
            // 
            gBPendingFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gBPendingFiles.Controls.Add(btnAddFiles);
            gBPendingFiles.Controls.Add(lVPendingFiles);
            gBPendingFiles.Location = new Point(12, 12);
            gBPendingFiles.Name = "gBPendingFiles";
            gBPendingFiles.Size = new Size(200, 504);
            gBPendingFiles.TabIndex = 0;
            gBPendingFiles.TabStop = false;
            gBPendingFiles.Text = "待处理文件";
            // 
            // btnAddFiles
            // 
            btnAddFiles.Location = new Point(7, 21);
            btnAddFiles.Name = "btnAddFiles";
            btnAddFiles.Size = new Size(75, 23);
            btnAddFiles.TabIndex = 1;
            btnAddFiles.Text = "添加文件";
            btnAddFiles.UseVisualStyleBackColor = true;
            btnAddFiles.Click += btnAddFiles_Click;
            // 
            // lVPendingFiles
            // 
            lVPendingFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lVPendingFiles.Location = new Point(0, 51);
            lVPendingFiles.Name = "lVPendingFiles";
            lVPendingFiles.RightToLeftLayout = true;
            lVPendingFiles.Size = new Size(200, 431);
            lVPendingFiles.TabIndex = 0;
            lVPendingFiles.TileSize = new Size(200, 38);
            lVPendingFiles.UseCompatibleStateImageBehavior = false;
            lVPendingFiles.View = View.Tile;
            // 
            // gBProcessedFiles
            // 
            gBProcessedFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gBProcessedFiles.Controls.Add(lbMessage);
            gBProcessedFiles.Controls.Add(lVProcessedFiles);
            gBProcessedFiles.Location = new Point(218, 12);
            gBProcessedFiles.Name = "gBProcessedFiles";
            gBProcessedFiles.Size = new Size(200, 482);
            gBProcessedFiles.TabIndex = 1;
            gBProcessedFiles.TabStop = false;
            gBProcessedFiles.Text = "已处理文件";
            // 
            // lbMessage
            // 
            lbMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbMessage.AutoSize = true;
            lbMessage.Location = new Point(0, 25);
            lbMessage.Name = "lbMessage";
            lbMessage.Size = new Size(0, 17);
            lbMessage.TabIndex = 2;
            // 
            // lVProcessedFiles
            // 
            lVProcessedFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lVProcessedFiles.Location = new Point(0, 51);
            lVProcessedFiles.Name = "lVProcessedFiles";
            lVProcessedFiles.Size = new Size(200, 431);
            lVProcessedFiles.TabIndex = 1;
            lVProcessedFiles.UseCompatibleStateImageBehavior = false;
            lVProcessedFiles.View = View.List;
            // 
            // gBMethod
            // 
            gBMethod.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gBMethod.Controls.Add(tableLayoutPanel1);
            gBMethod.Location = new Point(424, 12);
            gBMethod.Name = "gBMethod";
            gBMethod.Size = new Size(386, 482);
            gBMethod.TabIndex = 1;
            gBMethod.TabStop = false;
            gBMethod.Text = "处理方式";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(cBSkip, 0, 0);
            tableLayoutPanel1.Controls.Add(btnTitle, 0, 3);
            tableLayoutPanel1.Controls.Add(btnName, 0, 2);
            tableLayoutPanel1.Controls.Add(btnAll, 0, 1);
            tableLayoutPanel1.Controls.Add(btnClear, 0, 4);
            tableLayoutPanel1.Location = new Point(3, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(380, 460);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // cBSkip
            // 
            cBSkip.AutoSize = true;
            cBSkip.Checked = true;
            cBSkip.CheckState = CheckState.Checked;
            cBSkip.Dock = DockStyle.Fill;
            cBSkip.ImeMode = ImeMode.NoControl;
            cBSkip.Location = new Point(3, 3);
            cBSkip.Name = "cBSkip";
            cBSkip.Size = new Size(374, 40);
            cBSkip.TabIndex = 4;
            cBSkip.Text = "跳过已有tag的mp3";
            cBSkip.UseVisualStyleBackColor = true;
            // 
            // btnTitle
            // 
            btnTitle.Dock = DockStyle.Fill;
            btnTitle.ImeMode = ImeMode.NoControl;
            btnTitle.Location = new Point(3, 141);
            btnTitle.Name = "btnTitle";
            btnTitle.Size = new Size(374, 40);
            btnTitle.TabIndex = 2;
            btnTitle.Text = "文件名格式：歌曲名-演唱者";
            btnTitle.UseVisualStyleBackColor = true;
            btnTitle.Click += btnTitle_Click;
            // 
            // btnName
            // 
            btnName.Dock = DockStyle.Fill;
            btnName.ImeMode = ImeMode.NoControl;
            btnName.Location = new Point(3, 95);
            btnName.Name = "btnName";
            btnName.Size = new Size(374, 40);
            btnName.TabIndex = 1;
            btnName.Text = "文件名格式：演唱者-歌曲名";
            btnName.UseVisualStyleBackColor = true;
            btnName.Click += btnName_Click;
            // 
            // btnAll
            // 
            btnAll.Dock = DockStyle.Fill;
            btnAll.ImeMode = ImeMode.NoControl;
            btnAll.Location = new Point(3, 49);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(374, 40);
            btnAll.TabIndex = 0;
            btnAll.Text = "全部文件名作为标题";
            btnAll.UseVisualStyleBackColor = true;
            btnAll.Click += btnAll_Click;
            // 
            // btnClear
            // 
            btnClear.Dock = DockStyle.Fill;
            btnClear.Location = new Point(3, 187);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(374, 40);
            btnClear.TabIndex = 5;
            btnClear.Text = "清空已处理文件记录";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // oFD
            // 
            oFD.Filter = "mp3文件|*.mp3";
            oFD.Multiselect = true;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 506);
            Controls.Add(gBMethod);
            Controls.Add(gBProcessedFiles);
            Controls.Add(gBPendingFiles);
            Name = "mainForm";
            Text = "MP3信息修改";
            gBPendingFiles.ResumeLayout(false);
            gBProcessedFiles.ResumeLayout(false);
            gBProcessedFiles.PerformLayout();
            gBMethod.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gBPendingFiles;
        private GroupBox gBProcessedFiles;
        private GroupBox gBMethod;
        private ListView lVPendingFiles;
        private Button btnAddFiles;
        private OpenFileDialog oFD;
        private ListView lVProcessedFiles;
        private Label lbMessage;
        private CheckBox cBSkip;
        private Button btnAll;
        private Button btnName;
        private Button btnTitle;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnClear;
    }
}