using System;
using System.IO;

namespace base_project
{
    class Program
    {
        static void Main(string[] args)
        {
            //List information of all drives on your PC
            DriveInfo [] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if(drive.IsReady) {
                    System.Console.WriteLine($"Drive Name: {drive.Name}");
                    System.Console.WriteLine($"Format: {drive.DriveFormat}");
                    System.Console.WriteLine($"Type: {drive.DriveType}");
                    System.Console.WriteLine("Root Directory: {0}", drive.RootDirectory);
                    System.Console.WriteLine("Volume Label: {0}", drive.VolumeLabel);
                    System.Console.WriteLine($"Free Space: {drive.TotalFreeSpace}");
                    System.Console.WriteLine($"Available Space: {drive.AvailableFreeSpace}");
                    System.Console.WriteLine($"Total size: {drive.TotalSize}");
                }
            }
        }
    }
}
