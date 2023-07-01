namespace Comma
{
    partial class releaseNote
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(releaseNote));
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.mainTitle = new System.Windows.Forms.Label();
            this.versionTitle = new System.Windows.Forms.Label();
            this.noteBox = new System.Windows.Forms.ListBox();
            this.maixText = new System.Windows.Forms.Label();
            this.githubText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logoBox
            // 
            this.logoBox.Image = ((System.Drawing.Image)(resources.GetObject("logoBox.Image")));
            this.logoBox.Location = new System.Drawing.Point(22, 18);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(119, 123);
            this.logoBox.TabIndex = 0;
            this.logoBox.TabStop = false;
            // 
            // mainTitle
            // 
            this.mainTitle.AutoSize = true;
            this.mainTitle.BackColor = System.Drawing.Color.Transparent;
            this.mainTitle.Font = new System.Drawing.Font("Segoe UI", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTitle.ForeColor = System.Drawing.Color.White;
            this.mainTitle.Location = new System.Drawing.Point(147, 18);
            this.mainTitle.Name = "mainTitle";
            this.mainTitle.Size = new System.Drawing.Size(222, 71);
            this.mainTitle.TabIndex = 7;
            this.mainTitle.Text = "Comma";
            // 
            // versionTitle
            // 
            this.versionTitle.AutoSize = true;
            this.versionTitle.BackColor = System.Drawing.Color.Transparent;
            this.versionTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionTitle.ForeColor = System.Drawing.Color.Silver;
            this.versionTitle.Location = new System.Drawing.Point(159, 77);
            this.versionTitle.Name = "versionTitle";
            this.versionTitle.Size = new System.Drawing.Size(194, 54);
            this.versionTitle.TabIndex = 8;
            this.versionTitle.Text = "V.Beta 1.0";
            // 
            // noteBox
            // 
            this.noteBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.noteBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.noteBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteBox.ForeColor = System.Drawing.Color.White;
            this.noteBox.FormattingEnabled = true;
            this.noteBox.ItemHeight = 25;
            this.noteBox.Items.AddRange(new object[] {
            "Comma는 프로젝트 폴더 관리 프로그램입니다.",
            "이 버전은 Beta 버전으로 프로그램이 불안정 할 수 있습니다.",
            "",
            "기능:",
            "프로젝트 폴더 선택 시 자동으로 언어를 분류하여 프로젝트 폴더들을 나눠줍니다.",
            "자동으로 언어 별 버튼을 생성하여 폴더들을 관리하기 쉽게 TreeView로 보여줍니다.",
            "",
            "주의할 점:",
            "이 프로그램은 로컬 PC에서 작동하며, 외장하드에 있는 프로젝트 폴더를 추가하면 오류가 ",
            "날 수 있으니 로컬 PC에 있는 프로젝트 폴더들만 선택하세요.",
            "예기치 못한 버그 발생 시 아래에 있는 메일 주소나 Github Issue 탭에 버그 신고해주시면",
            "감사하겠습니다."});
            this.noteBox.Location = new System.Drawing.Point(22, 162);
            this.noteBox.Name = "noteBox";
            this.noteBox.Size = new System.Drawing.Size(989, 300);
            this.noteBox.TabIndex = 9;
            // 
            // maixText
            // 
            this.maixText.AutoSize = true;
            this.maixText.BackColor = System.Drawing.Color.Transparent;
            this.maixText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maixText.ForeColor = System.Drawing.Color.White;
            this.maixText.Location = new System.Drawing.Point(17, 536);
            this.maixText.Name = "maixText";
            this.maixText.Size = new System.Drawing.Size(301, 25);
            this.maixText.TabIndex = 10;
            this.maixText.Text = "메일 주소: ithan0704@naver.com";
            // 
            // githubText
            // 
            this.githubText.AutoSize = true;
            this.githubText.BackColor = System.Drawing.Color.Transparent;
            this.githubText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.githubText.ForeColor = System.Drawing.Color.White;
            this.githubText.Location = new System.Drawing.Point(17, 561);
            this.githubText.Name = "githubText";
            this.githubText.Size = new System.Drawing.Size(409, 25);
            this.githubText.TabIndex = 11;
            this.githubText.Text = "GitHub: https://github.com/gloomn/Comma";
            this.githubText.Click += new System.EventHandler(this.githubText_Click);
            // 
            // releaseNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.githubText);
            this.Controls.Add(this.maixText);
            this.Controls.Add(this.noteBox);
            this.Controls.Add(this.versionTitle);
            this.Controls.Add(this.mainTitle);
            this.Controls.Add(this.logoBox);
            this.Name = "releaseNote";
            this.Size = new System.Drawing.Size(1040, 685);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Label mainTitle;
        private System.Windows.Forms.Label versionTitle;
        private System.Windows.Forms.ListBox noteBox;
        private System.Windows.Forms.Label maixText;
        private System.Windows.Forms.Label githubText;
    }
}
