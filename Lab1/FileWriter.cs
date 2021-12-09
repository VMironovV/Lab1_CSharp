using System.IO;

namespace Lab1
{
    public class FileWriter
    {
        private StreamWriter _file;
        
        public void WriteCoordinatesToFile(string name, int vitality, int x, int y)
        {
            _file.WriteLine("Worms:[" + name + vitality + "(" + x + "," + y + ")]");
        }

        public void OpenFile()
        {
            _file = new StreamWriter("C:/Users/Vladimir/RiderProjects/Lab1_CSharp/Lab1/coordinates.txt", false);
        }
        
        public void CloseFile()
        {
            _file.Close();
        }
    }
}