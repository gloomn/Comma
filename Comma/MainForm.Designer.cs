using System.Diagnostics.Tracing;

namespace Comma
{
    partial class Comma
    {

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Comma));
            this.navBar = new System.Windows.Forms.Panel();
            this.navBarMainTitle = new System.Windows.Forms.Label();
            this.sideBar = new System.Windows.Forms.Panel();
            this.languageList = new System.Windows.Forms.Panel();
            this.directoryList = new System.Windows.Forms.Panel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.bottomBar = new System.Windows.Forms.Panel();
            this.progressBar = new MaterialSkin.Controls.MaterialProgressBar();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.resetDatabase = new System.Windows.Forms.Button();
            this.addFolders = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.maximizeButton = new System.Windows.Forms.Button();
            this.restoreButton = new System.Windows.Forms.Button();
            this.cc = new System.Windows.Forms.Label();
            this.navBar.SuspendLayout();
            this.sideBar.SuspendLayout();
            this.directoryList.SuspendLayout();
            this.bottomBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // navBar
            // 
            this.navBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.navBar.Controls.Add(this.cc);
            this.navBar.Controls.Add(this.minimizeButton);
            this.navBar.Controls.Add(this.exitButton);
            this.navBar.Controls.Add(this.pictureBox1);
            this.navBar.Controls.Add(this.navBarMainTitle);
            this.navBar.Controls.Add(this.maximizeButton);
            this.navBar.Controls.Add(this.restoreButton);
            this.navBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.navBar.Location = new System.Drawing.Point(0, 0);
            this.navBar.Name = "navBar";
            this.navBar.Size = new System.Drawing.Size(1280, 30);
            this.navBar.TabIndex = 0;
            this.navBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainForm_MouseDown);
            this.navBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainForm_MouseMove);
            this.navBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainForm_MouseUp);
            // 
            // navBarMainTitle
            // 
            this.navBarMainTitle.AutoSize = true;
            this.navBarMainTitle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarMainTitle.ForeColor = System.Drawing.Color.White;
            this.navBarMainTitle.Location = new System.Drawing.Point(26, 6);
            this.navBarMainTitle.Name = "navBarMainTitle";
            this.navBarMainTitle.Size = new System.Drawing.Size(192, 18);
            this.navBarMainTitle.TabIndex = 0;
            this.navBarMainTitle.Text = "Comma (Version: Beta 1.0)";
            // 
            // sideBar
            // 
            this.sideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.sideBar.Controls.Add(this.button5);
            this.sideBar.Controls.Add(this.button4);
            this.sideBar.Controls.Add(this.button3);
            this.sideBar.Controls.Add(this.button2);
            this.sideBar.Controls.Add(this.button1);
            this.sideBar.Controls.Add(this.resetDatabase);
            this.sideBar.Controls.Add(this.addFolders);
            this.sideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBar.Location = new System.Drawing.Point(0, 30);
            this.sideBar.Name = "sideBar";
            this.sideBar.Size = new System.Drawing.Size(70, 690);
            this.sideBar.TabIndex = 1;
            // 
            // languageList
            // 
            this.languageList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.languageList.Dock = System.Windows.Forms.DockStyle.Left;
            this.languageList.Location = new System.Drawing.Point(70, 30);
            this.languageList.Name = "languageList";
            this.languageList.Size = new System.Drawing.Size(170, 690);
            this.languageList.TabIndex = 2;
            // 
            // directoryList
            // 
            this.directoryList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(225)))), ((int)(((byte)(232)))));
            this.directoryList.Controls.Add(this.treeView);
            this.directoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.directoryList.Location = new System.Drawing.Point(240, 30);
            this.directoryList.Name = "directoryList";
            this.directoryList.Size = new System.Drawing.Size(1040, 685);
            this.directoryList.TabIndex = 4;
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.ForeColor = System.Drawing.Color.White;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.ShowLines = false;
            this.treeView.ShowPlusMinus = false;
            this.treeView.ShowRootLines = false;
            this.treeView.Size = new System.Drawing.Size(1040, 685);
            this.treeView.TabIndex = 0;
            this.treeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView_DrawNode);
            // 
            // bottomBar
            // 
            this.bottomBar.Controls.Add(this.progressBar);
            this.bottomBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomBar.Location = new System.Drawing.Point(240, 715);
            this.bottomBar.Name = "bottomBar";
            this.bottomBar.Size = new System.Drawing.Size(1040, 5);
            this.bottomBar.TabIndex = 3;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.progressBar.Depth = 0;
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1040, 5);
            this.progressBar.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(9, 637);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 50);
            this.button5.TabIndex = 9;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(9, 55);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 50);
            this.button4.TabIndex = 8;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(9, 188);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 50);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(9, 255);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(9, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // resetDatabase
            // 
            this.resetDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetDatabase.FlatAppearance.BorderSize = 0;
            this.resetDatabase.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.resetDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetDatabase.Image = ((System.Drawing.Image)(resources.GetObject("resetDatabase.Image")));
            this.resetDatabase.Location = new System.Drawing.Point(9, 581);
            this.resetDatabase.Name = "resetDatabase";
            this.resetDatabase.Size = new System.Drawing.Size(50, 50);
            this.resetDatabase.TabIndex = 4;
            this.resetDatabase.UseVisualStyleBackColor = true;
            this.resetDatabase.Click += new System.EventHandler(this.resetDatabase_Click);
            // 
            // addFolders
            // 
            this.addFolders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addFolders.FlatAppearance.BorderSize = 0;
            this.addFolders.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.addFolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addFolders.Image = ((System.Drawing.Image)(resources.GetObject("addFolders.Image")));
            this.addFolders.Location = new System.Drawing.Point(9, 2);
            this.addFolders.Name = "addFolders";
            this.addFolders.Size = new System.Drawing.Size(50, 50);
            this.addFolders.TabIndex = 3;
            this.addFolders.UseVisualStyleBackColor = true;
            this.addFolders.Click += new System.EventHandler(this.addFolders_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("minimizeButton.Image")));
            this.minimizeButton.Location = new System.Drawing.Point(1196, 3);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(25, 25);
            this.minimizeButton.TabIndex = 3;
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
            this.exitButton.Location = new System.Drawing.Point(1252, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(25, 25);
            this.exitButton.TabIndex = 2;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // maximizeButton
            // 
            this.maximizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maximizeButton.FlatAppearance.BorderSize = 0;
            this.maximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeButton.Image = ((System.Drawing.Image)(resources.GetObject("maximizeButton.Image")));
            this.maximizeButton.Location = new System.Drawing.Point(1225, 3);
            this.maximizeButton.Name = "maximizeButton";
            this.maximizeButton.Size = new System.Drawing.Size(25, 25);
            this.maximizeButton.TabIndex = 4;
            this.maximizeButton.UseVisualStyleBackColor = true;
            this.maximizeButton.Click += new System.EventHandler(this.maximizeButton_Click);
            // 
            // restoreButton
            // 
            this.restoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.restoreButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.restoreButton.FlatAppearance.BorderSize = 0;
            this.restoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restoreButton.Image = ((System.Drawing.Image)(resources.GetObject("restoreButton.Image")));
            this.restoreButton.Location = new System.Drawing.Point(1225, 3);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(25, 25);
            this.restoreButton.TabIndex = 5;
            this.restoreButton.UseVisualStyleBackColor = true;
            this.restoreButton.Click += new System.EventHandler(this.restoreButton_Click);
            // 
            // cc
            // 
            this.cc.AutoSize = true;
            this.cc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.cc.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cc.ForeColor = System.Drawing.Color.White;
            this.cc.Location = new System.Drawing.Point(214, 9);
            this.cc.Name = "cc";
            this.cc.Size = new System.Drawing.Size(95, 15);
            this.cc.TabIndex = 6;
            this.cc.Text = "© Gloomn 2023";
            // 
            // Comma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.directoryList);
            this.Controls.Add(this.bottomBar);
            this.Controls.Add(this.languageList);
            this.Controls.Add(this.sideBar);
            this.Controls.Add(this.navBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Comma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comma";
            this.Load += new System.EventHandler(this.Comma_Load);
            this.navBar.ResumeLayout(false);
            this.navBar.PerformLayout();
            this.sideBar.ResumeLayout(false);
            this.directoryList.ResumeLayout(false);
            this.bottomBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel navBar;
        private System.Windows.Forms.Panel bottomBar;
        private System.Windows.Forms.Label navBarMainTitle;
        private System.Windows.Forms.Panel sideBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button addFolders;
        private System.Windows.Forms.Button resetDatabase;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Panel languageList;
        private System.Windows.Forms.Button maximizeButton;
        private System.Windows.Forms.Button restoreButton;
        public System.Windows.Forms.Panel directoryList;
        public System.Windows.Forms.TreeView treeView;
        public MaterialSkin.Controls.MaterialProgressBar progressBar;
        private System.Windows.Forms.Label cc;
    }
}

