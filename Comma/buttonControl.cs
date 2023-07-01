using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Comma
{
    internal class buttonControl
    {
        string dbName = "database.db";
        private string buttonDataFile = "button_data.txt"; // 버튼 정보를 저장할 파일 이름

        public void CreateButtonDataFile()
        {
            try
            {
                // 버튼 정보 파일이 이미 존재하는지 확인
                if (!File.Exists(buttonDataFile))
                {
                    // 버튼 정보 파일 생성
                    using (StreamWriter writer = File.CreateText(buttonDataFile))
                    {
                        // 파일 내용 없음
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"버튼 정보 파일을 생성하는 중 오류 발생: {ex.Message}");
            }
        }

        public void createNewButton()
        {
            // 데이터베이스에서 mainlanguage 값들을 가져온다.
            List<string> languages = GetMainLanguagesFromDatabase();

            List<ButtonData> buttonDataList = LoadButtonData(); // 버튼 정보를 로드한다

            foreach (string language in languages)
            {
                // 빈 문자열이 아닌 경우에만 버튼을 생성한다.
                if (!string.IsNullOrWhiteSpace(language))
                {
                    // 같은 이름을 가진 버튼이 이미 존재하는지 확인한다.
                    bool isDuplicateButton = IsDuplicateButton(language);

                    // 중복되는 버튼이 없을 경우 새로운 버튼을 생성한다.
                    if (!isDuplicateButton)
                    {
                        Button newButton = new Button();
                        newButton.Name = language;
                        newButton.Text = language;

                        // 버튼의 기타 속성 및 이벤트 핸들러 설정
                        Comma.comma.languageList.VerticalScroll.Maximum = 0;
                        Comma.comma.languageList.AutoScroll = false;
                        Comma.comma.languageList.VerticalScroll.Visible = false;
                        Comma.comma.languageList.AutoScroll = true;
                        newButton.Height = 45;
                        newButton.Dock = DockStyle.Top;
                        newButton.ForeColor = System.Drawing.Color.White;
                        newButton.Font = new Font("Arial", 15, FontStyle.Bold);

                        newButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
                        newButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(89, 90, 92);
                        newButton.BackColor = Color.Transparent;
                        newButton.FlatStyle = FlatStyle.Flat;
                        newButton.FlatAppearance.BorderSize = 0;
                        newButton.Cursor = Cursors.Hand;
                        newButton.TextAlign = ContentAlignment.MiddleLeft;
                        newButton.Click += LanguageButton_Click;

                        // 저장된 버튼 정보를 확인하여 위치 및 선택 상태를 복원한다
                        foreach (ButtonData buttonData in buttonDataList)
                        {
                            if (buttonData.Name == language)
                            {
                                newButton.Top = buttonData.Top;
                                newButton.BackColor = buttonData.IsSelected ? System.Drawing.Color.Blue : System.Drawing.Color.Transparent;
                                newButton.ForeColor = buttonData.IsSelected ? System.Drawing.Color.White : System.Drawing.Color.White;
                                break;
                            }
                        }

                        Comma.comma.languageList.Controls.Add(newButton);
                    }
                }
            }
        }

        public void LanguageButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            // 버튼의 이름과 데이터베이스에 저장된 언어 이름 비교
            string languageName = clickedButton.Name;

            // 데이터베이스에서 해당 언어의 maindirectorypath 폴더들을 가져온다.
            List<string> directoryPaths = GetDirectoryPathsFromDatabase(languageName);

            // ProgressBar 초기화 및 설정
            Comma.comma.progressBar.Minimum = 0;
            Comma.comma.progressBar.Maximum = directoryPaths.Count;
            Comma.comma.progressBar.Value = 0;
            Comma.comma.progressBar.Visible = true;

            // directoryList 패널의 TreeView를 초기화한다.
            Comma.comma.treeView.Nodes.Clear();

            // 가져온 폴더 경로들을 TreeView에 추가한다.
            foreach (string directoryPath in directoryPaths)
            {
                PopulateTreeView(directoryPath);

                // ProgressBar 값 업데이트
                Comma.comma.progressBar.Value++;
                Comma.comma.progressBar.Refresh();
            }
            // ProgressBar 초기화
            Comma.comma.progressBar.Value = 0;

            // 선택된 버튼의 배경색과 선택 상태를 변경
            List<Button> buttons = Comma.comma.languageList.Controls.OfType<Button>().ToList();

            foreach (Button button in buttons)
            {
                if (button == clickedButton)
                {
                    button.BackColor = System.Drawing.Color.FromArgb(40, 44, 55);
                    button.ForeColor = System.Drawing.Color.White;
                    SetButtonSelectedStatus(button, true);
                }
                else
                {
                    button.BackColor = System.Drawing.Color.Transparent;
                    button.ForeColor = System.Drawing.Color.White;
                    SetButtonSelectedStatus(button, false);
                }
            }

            // 버튼 정보 저장
            List<ButtonData> buttonDataList = LoadButtonData();
            foreach (ButtonData buttonData in buttonDataList)
            {
                buttonData.IsSelected = (buttonData.Name == clickedButton.Name);
            }
            SaveButtonData(buttonDataList);
        }


        private void AddSubdirectoriesToNode(TreeNode parentNode, string directoryPath)
        {
            try
            {
                // 주어진 디렉토리의 하위 디렉토리들을 가져온다.
                string[] subdirectories = Directory.GetDirectories(directoryPath);

                foreach (string subdirectory in subdirectories)
                {
                    // 하위 디렉토리의 이름을 추출한다.
                    string[] pathParts = subdirectory.Split('\\');
                    string directoryName = pathParts[pathParts.Length - 1];

                    // 하위 디렉토리의 노드를 생성한다.
                    TreeNode subdirectoryNode = new TreeNode(directoryName);
                    subdirectoryNode.Tag = subdirectory; // 디렉토리 경로를 Tag 속성에 저장한다.
                    parentNode.Nodes.Add(subdirectoryNode);

                    // 하위 디렉토리의 하위 디렉토리들과 파일들을 재귀적으로 추가한다.
                    AddSubdirectoriesToNode(subdirectoryNode, subdirectory);
                    AddFilesToNode(subdirectoryNode, subdirectory);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"하위 디렉토리를 추가하는 중 오류 발생: {ex.Message}");
            }
        }

        private void PopulateTreeView(string directoryPath)
        {
            try
            {
                // 루트 노드 생성
                string rootDirectoryName = Path.GetFileName(directoryPath);
                TreeNode rootNode = new TreeNode(rootDirectoryName);
                rootNode.Tag = directoryPath; // 디렉토리 경로를 루트 노드의 Tag 속성에 저장
                Comma.comma.treeView.Nodes.Add(rootNode);

                // 디렉토리의 하위 디렉토리와 파일들을 추가
                AddSubdirectoriesToNode(rootNode, directoryPath);
                AddFilesToNode(rootNode, directoryPath);

                // 우클릭 이벤트 핸들러 등록
                Comma.comma.treeView.NodeMouseClick += treeView_NodeMouseClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"트리 뷰를 채우는 중 오류 발생: {ex.Message}");
            }
        }


        

        private void AddFilesToNode(TreeNode parentNode, string directoryPath)
        {
            try
            {
                // 주어진 디렉토리의 파일들을 가져온다.
                string[] files = Directory.GetFiles(directoryPath);

                foreach (string file in files)
                {
                    // 파일의 이름을 추출한다.
                    string fileName = Path.GetFileName(file);

                    // 파일의 노드를 생성한다.
                    TreeNode fileNode = new TreeNode(fileName);
                    fileNode.Tag = file; // 파일 경로를 Tag 속성에 저장한다.
                    fileNode.ImageIndex = 1; // 이미지 인덱스 설정
                    fileNode.SelectedImageIndex = 1; // 선택된 이미지 인덱스 설정
                    parentNode.Nodes.Add(fileNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"파일을 추가하는 중 오류 발생: {ex.Message}");
            }
        }









        private List<string> GetDirectoryPathsFromDatabase(string languageName)
        {
            List<string> directoryPaths = new List<string>();

            try
            {
                // SQLite 데이터베이스 연결 문자열
                string dbFilePath = AppDomain.CurrentDomain.BaseDirectory + dbName;
                string connectionString = $"Data Source={dbFilePath};Version=3;";

                // 데이터베이스 연결
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // 데이터베이스에서 해당 언어의 maindirectorypath 값을 가져온다.
                    string selectQuery = $"SELECT maindirectorypath FROM DirectoryManage WHERE mainlanguage = '{languageName}'";

                    using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            // 가져온 maindirectorypath 값을 directoryPaths 리스트에 추가한다.
                            while (reader.Read())
                            {
                                string directoryPath = reader.GetString(0);
                                directoryPaths.Add(directoryPath);
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터베이스에서 디렉토리 경로를 가져오는 중 오류 발생: {ex.Message}");
            }

            return directoryPaths;
        }


        public void SaveButtonData(List<ButtonData> buttonDataList)
        {
            try
            {
                // 버튼 정보를 파일에 저장한다
                using (StreamWriter writer = new StreamWriter(buttonDataFile))
                {
                    foreach (ButtonData buttonData in buttonDataList)
                    {
                        writer.WriteLine($"{buttonData.Name},{buttonData.Top},{buttonData.IsSelected}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"버튼 정보를 저장하는 중 오류 발생: {ex.Message}");
            }
        }

        public List<ButtonData> LoadButtonData()
        {
            List<ButtonData> buttonDataList = new List<ButtonData>();

            try
            {
                // 파일에서 버튼 정보를 로드한다
                if (File.Exists(buttonDataFile))
                {
                    using (StreamReader reader = new StreamReader(buttonDataFile))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            if (parts.Length >= 3)
                            {
                                string name = parts[0];
                                int top = int.Parse(parts[1]);
                                bool isSelected = bool.Parse(parts[2]);

                                ButtonData buttonData = new ButtonData(name, top, isSelected);
                                buttonDataList.Add(buttonData);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"버튼 정보를 로드하는 중 오류 발생: {ex.Message}");
            }

            return buttonDataList;
        }

        public class ButtonData
        {
            public string Name { get; set; }
            public int Top { get; set; }
            public bool IsSelected { get; set; }

            public ButtonData(string name, int top, bool isSelected)
            {
                Name = name;
                Top = top;
                IsSelected = isSelected;
            }
        }

        private List<string> GetMainLanguagesFromDatabase()
        {
            List<string> languages = new List<string>();

            try
            {
                // SQLite 데이터베이스 연결 문자열
                string dbFilePath = AppDomain.CurrentDomain.BaseDirectory + dbName;
                string connectionString = $"Data Source={dbFilePath};Version=3;";

                // 데이터베이스 연결
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SELECT DISTINCT 쿼리문을 사용하여 중복을 제거한 mainlanguage 값들을 가져온다.
                    string selectQuery = "SELECT DISTINCT mainlanguage FROM DirectoryManage";

                    using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            // 가져온 mainlanguage 값을 languages 리스트에 추가한다.
                            while (reader.Read())
                            {
                                string language = reader.GetString(0);
                                languages.Add(language);
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터베이스에서 mainlanguage 값을 가져오는 중 오류 발생: {ex.Message}");
            }

            return languages;
        }

        private bool IsDuplicateButton(string buttonName)
        {
            // languageList 패널에 같은 이름을 가진 버튼이 이미 존재하는지 확인하는 로직을 구현한다.
            // 패널 내의 모든 버튼을 순회하며 버튼의 Name 속성과 비교하여 중복 여부를 확인한다.
            foreach (Control control in Comma.comma.languageList.Controls)
            {
                if (control is Button button && button.Name == buttonName)
                {
                    return true; // 같은 이름을 가진 버튼이 이미 존재하는 경우
                }
            }

            return false; // 중복되는 버튼이 없는 경우
        }


        private void SetButtonSelectedStatus(Button button, bool isSelected)
        {
            // 버튼의 선택 상태를 설정한다.
            // 버튼 정보는 버튼의 Tag 속성을 통해 저장하도록 한다.
            button.Tag = isSelected;
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // 우클릭한 노드를 선택한다.
                Comma.comma.treeView.SelectedNode = e.Node;

                // 폴더 경로를 복사한다.
                string nodePath = e.Node.Tag as string;
                if (!string.IsNullOrEmpty(nodePath))
                {
                    Clipboard.SetText(nodePath);
                }
            }
        }
    }
}
