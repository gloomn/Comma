using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WK.Libraries.BetterFolderBrowserNS;

namespace Comma
{
    public partial class Comma : Form
    {
        int mov;
        int movX;
        int movY;
        string dbName = "database.db";
        public static Comma comma;
        string[] folders;
        buttonControl createButton = new buttonControl();
        permissions permission = new permissions();
        database databaseControl = new database();

        public Comma()
        {
            ImageList imageList = new ImageList();
            imageList.Images.Add("folder", Properties.Resources.folder);
            imageList.Images.Add("file", Properties.Resources.file);
            // TreeView에 ImageList 설정


            StartPosition = FormStartPosition.CenterScreen;
            Thread t = new Thread(new ThreadStart(startSplashScreen));
            t.Start();
            Thread.Sleep(3000);

            InitializeComponent();
            comma = this;
            t.Abort();
            treeView.ImageList = imageList;
            releaseNote1.Hide();
            information1.Hide();
            license1.Hide();
            treeView.Show();
        }

        public void startSplashScreen()
        {
            Application.Run(new splashScreen());
        }

        //Borderless Form Drop Shadow
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }

        }

        private void Comma_Load(object sender, EventArgs e)
        {
            maximizeButton.Show();
            restoreButton.Hide();
            languageList.VerticalScroll.Visible = false;
            databaseControl.CreateDatabase();
            createButton.CreateButtonDataFile();
            createButton.createNewButton();
        }

        public void mainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        public void mainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                Comma.comma.SetDesktopLocation(splashScreen.MousePosition.X - movX, splashScreen.MousePosition.Y - movY);
            }
        }

        public void mainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }


        private async void addFolders_Click(object sender, EventArgs e)
        {
            addFolders.Enabled = false;
            var folderDialog = new BetterFolderBrowser();
            folderDialog.Title = "Select your project folders.";
            folderDialog.RootFolder = "C:\\";
            folderDialog.Multiselect = true;

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                folders = folderDialog.SelectedFolders;
                progressBar.Visible = true;
                progressBar.Value = 0;  // 프로그레스 바 초기화

                // 비동기 작업 시작
                await Task.Run(() =>
                {
                    for (int i = 0; i < folders.Length; i++)
                    {
                        string folderPath = folders[i];

                        // 작업 수행
                        databaseControl.saveMainFolder(folderPath);

                        // UI 스레드로 진행 상황 업데이트
                        int progress = (i + 1) * 100 / folders.Length;
                        Invoke((MethodInvoker)(() => UpdateProgressBar(progress)));
                        Invoke((MethodInvoker)(createButton.createNewButton));
                    }
                });

                // 작업 완료 후 UI 업데이트
                MessageBox.Show("Folders added successfully.");
                progressBar.Value = 0;
                addFolders.Enabled = true;

            }
            else
            {
                addFolders.Enabled = true;
            }
        }

        private void UpdateProgressBar(int value)
        {
            progressBar.Value = value;
        }


        public void exitButton_Click(object sender, EventArgs e)
        {
            List<buttonControl.ButtonData> buttonDataList = new List<buttonControl.ButtonData>();

            // 현재 버튼 상태를 저장한다
            foreach (Control control in Comma.comma.languageList.Controls)
            {
                if (control is System.Windows.Forms.Button button)
                {
                    buttonControl.ButtonData buttonData = new buttonControl.ButtonData(button.Name, button.Top, button.BackColor == System.Drawing.Color.Blue);
                    buttonDataList.Add(buttonData);
                }
            }

            createButton.SaveButtonData(buttonDataList);
            Application.Exit();
        }

        //Program Minimize Button Function
        public void minimizeButton_Click(object sender, EventArgs e)
        {
            Comma.comma.WindowState = FormWindowState.Minimized;
        }

        

        public void resetDatabase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Comma program will be reset!\nDo you really want to reset the program?",
                "Reset Comma", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // SQLite 데이터베이스 연결 문자열
                string dbFilePath = AppDomain.CurrentDomain.BaseDirectory + dbName;
                string connectionString = $"Data Source={dbFilePath};Version=3;";

                // 데이터베이스 연결
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // DELETE 쿼리문
                    string deleteQuery = "DELETE FROM DirectoryManage";

                    using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // AUTOINCREMENT된 id 초기화
                    string resetIdQuery = "DELETE FROM sqlite_sequence WHERE name='DirectoryManage'";

                    using (SQLiteCommand command = new SQLiteCommand(resetIdQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("데이터베이스 내용과 id가 초기화되었습니다.");

                    connection.Close();
                }
                string filePath = AppDomain.CurrentDomain.BaseDirectory + "button_data.txt";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine("button_data.txt 파일이 삭제되었습니다.");
                    Console.WriteLine(filePath);
                }
                languageList.Controls.Clear();
                treeView.Nodes.Clear();
            }
            else
            {
                return;
            }
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            restoreButton.Show();
            maximizeButton.Hide();
            this.WindowState = FormWindowState.Maximized;
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            maximizeButton.Show();
            restoreButton.Hide();
            this.WindowState = FormWindowState.Normal;
        }

        //버그 나중에 고침
        private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            // 선택된 노드가 아닌 경우 배경색을 투명하게 설정
            if ((e.State & TreeNodeStates.Selected) == 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Transparent), e.Bounds);
            }

            // 텍스트 그리기
            TextRenderer.DrawText(e.Graphics, e.Node.Text, e.Node.NodeFont, e.Bounds, e.Node.ForeColor, TextFormatFlags.VerticalCenter);
        }

        private void releaseNoteButton_Click(object sender, EventArgs e)
        {
            releaseNote1.Show();
            treeView.Hide();
            information1.Hide();
        }

        private void directoryButton_Click(object sender, EventArgs e)
        {
            treeView.Show();
            releaseNote1.Hide();
            information1.Hide();
            license1.Hide();
        }

        private void informationButton_Click(object sender, EventArgs e)
        {
            information1.Show();
            releaseNote1.Hide();
            treeView.Hide();
            license1.Hide();
        }

        private void licenseButton_Click(object sender, EventArgs e)
        {
            license1.Show();
            information1.Hide();
            releaseNote1.Hide();
            treeView.Hide();
        }
    }
}