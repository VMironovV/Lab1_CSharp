using System.IO;

namespace Lab1
{
    public static class FileWriter
    {
        private static StreamWriter _file;
        
        public static void WriteCoordinatesToFile(string name, int vitality, int x, int y)
        {
            _file.WriteLine("Worms:[" + name + vitality + "(" + x + "," + y + ")]");
        }

        public static void OpenFile()
        {
            _file = new StreamWriter("C:/Users/Vladimir/RiderProjects/Lab1_CSharp/Lab1/coordinates.txt", false);
        }
        
        public static void CloseFile()
        {
            _file.Close();
        }
    }
}