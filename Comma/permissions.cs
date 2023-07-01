using System.IO;
using System.Security.AccessControl;

namespace Comma
{
    internal class permissions
    {
        public void SetFilePermissions(string filePath, string user, FileSystemRights rights, AccessControlType controlType)
        {
            FileSecurity fileSecurity = File.GetAccessControl(filePath);
            fileSecurity.AddAccessRule(new FileSystemAccessRule(user, rights, controlType));
            File.SetAccessControl(filePath, fileSecurity);
        }

        public void SetFolderPermissions(string folderPath, string user, FileSystemRights rights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType controlType)
        {
            DirectorySecurity directorySecurity = Directory.GetAccessControl(folderPath);
            directorySecurity.AddAccessRule(new FileSystemAccessRule(user, rights, inheritanceFlags, propagationFlags, controlType));
            Directory.SetAccessControl(folderPath, directorySecurity);
        }
    }
}
