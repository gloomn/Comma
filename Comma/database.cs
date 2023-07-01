using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;
namespace Comma
{
    internal class database
    {
        string dbName = "database.db";
        permissions permission = new permissions();

        Dictionary<string, List<string>> extensionLanguageMap = new Dictionary<string, List<string>>()
        {
            { "C#", new List<string> { ".cs" } },
            { "Python", new List<string> { ".py" } },
            { "Java", new List<string> { ".java" } },
            { "HTML", new List<string> { ".html", ".htm" } },
            { "CSS", new List<string> { ".css" } },
            { "PHP", new List<string> { ".php" } },
            { "JavaScript", new List<string> { ".js" } },
            { "C", new List<string> { ".c" } },
            { "C++", new List<string> { ".cpp" } },
            { "Assembly", new List<string> { ".asm" } },
            { "Kotlin", new List<string> { ".kt" } },
            { "Go", new List<string> { ".go" } },
            { "Perl", new List<string> { ".pl" } },
            { "ASP", new List<string> { ".asp" } },
            { "Swift", new List<string> { ".swift" } },
            { "Delphi", new List<string> { ".dpr", ".dpg", ".pas", ".dfm", ".dsk", ".dpk", ".dcu" } },
            { "Pascal", new List<string> { ".pascal" } },
            { "Ruby", new List<string> { ".rb" } },
            { "SQL", new List<string> { ".sql" } },
            { "Matlab", new List<string> { ".mat", ".m" } },
            { "Rust", new List<string> { ".rs" } },
            { "TypeScript", new List<string> { ".ts" } },
            { "R", new List<string> { ".r" } },
            { "Scala", new List<string> { ".scala" } },
            { "Lua", new List<string> { ".lua" } },
            { "Shell Script", new List<string> { ".sh" } },
            { "Groovy", new List<string> { ".groovy" } },
            { "Haskell", new List<string> { ".hs" } },
            { "Visual Basic", new List<string> { ".vb" } },
            { "Dart", new List<string> { ".dart" } }
        };



        public void CreateDatabase()
        {
            // 데이터베이스 파일 경로 생성
            string dbFilePath = AppDomain.CurrentDomain.BaseDirectory + dbName;

            // 이미 데이터베이스 파일이 존재하는 경우 종료
            if (File.Exists(dbFilePath))
            {
                return;
            }
            else
            {
                try
                {
                    // SQLite 데이터베이스 연결 문자열 생성
                    string connectionString = $"Data Source={dbFilePath};Version=3;";

                    // SQLite 데이터베이스 연결
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        // 데이터베이스 생성
                        connection.Open();

                        string tableQuery = @"CREATE TABLE IF NOT EXISTS DirectoryManage (
				              id INTEGER PRIMARY KEY AUTOINCREMENT,
				              maindirectorypath TEXT,
				              mainlanguage TEXT);";
                        using (SQLiteCommand command = new SQLiteCommand(tableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        connection.Close();
                    }

                    MessageBox.Show("데이터베이스 파일 및 테이블이 생성되었습니다.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"데이터베이스 파일 생성 중 오류 발생: {ex.Message}");
                }
            }
        }

        public void saveMainFolder(string selectedFolder)
        {
            permission.SetFolderPermissions(selectedFolder,
                                  "Everyone",
                                  FileSystemRights.FullControl,
                                  InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                                  PropagationFlags.None,
                                  AccessControlType.Allow);

            // SQLite 데이터베이스 연결 문자열 생성
            string dbFilePath = AppDomain.CurrentDomain.BaseDirectory + dbName;
            string connectionString = $"Data Source={dbFilePath};Version=3;";
            string[] selectedFiles = Directory.GetFiles(selectedFolder, "*", SearchOption.AllDirectories);

            // 확장자 빈도를 저장할 딕셔너리
            Dictionary<string, int> extensionCountMap = new Dictionary<string, int>();

            foreach (string filePath in selectedFiles)
            {
                permission.SetFilePermissions(filePath,
                                    "Everyone",
                                    FileSystemRights.FullControl,
                                    AccessControlType.Allow);

                string fileExtension = Path.GetExtension(filePath).ToLower();
                foreach (var pair in extensionLanguageMap)
                {
                    if (pair.Value.Contains(fileExtension))
                    {
                        string language = pair.Key;
                        Console.WriteLine(language);

                        // 확장자 빈도 계산
                        if (extensionCountMap.ContainsKey(fileExtension))
                            extensionCountMap[fileExtension]++;
                        else
                            extensionCountMap[fileExtension] = 1;
                        break;
                    }
                }
            }

            // 가장 빈도가 높은 확장자와 해당 언어 찾기
            string mostFrequentExtension = string.Empty;
            int maxCount = 0;

            foreach (var pair in extensionCountMap)
            {
                if (pair.Value > maxCount)
                {
                    mostFrequentExtension = pair.Key;
                    maxCount = pair.Value;
                }
            }

            // 가장 빈도가 높은 확장자에 대한 언어 리스트 가져오기
            List<string> languages = new List<string>();

            foreach (var pair in extensionLanguageMap)
            {
                if (pair.Value.Contains(mostFrequentExtension))
                {
                    languages.Add(pair.Key);
                }
            }

            // 중복 폴더인지 확인
            bool isDuplicateFolder;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // 폴더가 이미 존재하는지 확인하는 쿼리 실행
                using (SQLiteCommand checkCommand = connection.CreateCommand())
                {
                    checkCommand.CommandText = "SELECT COUNT(*) FROM DirectoryManage WHERE maindirectorypath = @mainFolder";
                    checkCommand.Parameters.AddWithValue("@mainFolder", selectedFolder);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    // 이미 폴더가 존재하면 중복 처리
                    isDuplicateFolder = count > 0;
                }

                // 중복 폴더가 아니라면 데이터베이스에 언어와 폴더 경로 저장
                if (!isDuplicateFolder && languages.Count > 0)
                {
                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        foreach (string language in languages)
                        {
                            command.CommandText = "INSERT INTO DirectoryManage (maindirectorypath, mainlanguage) VALUES (@mainFolder, @Language)";
                            command.Parameters.AddWithValue("@mainFolder", selectedFolder);
                            command.Parameters.AddWithValue("@Language", language);
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
