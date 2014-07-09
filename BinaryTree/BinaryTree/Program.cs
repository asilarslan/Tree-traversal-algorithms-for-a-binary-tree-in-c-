using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//txt write: http://msdn.microsoft.com/tr-tr/library/8bh11f1k.aspx
namespace BinaryTree
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Random random = new Random();
            string fileName = "../../" + "hw" + ".txt";
            //creating the file
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            Console.WriteLine("hw.txt created");
            fs.Close();

            StreamWriter sw = new StreamWriter(fileName);
            List<int> list = new List<int>();
            int val;
            Random r;
            int IntialCount = 1;
            int count = 300;
            int maxRandomValue = 1000;

            BinaryTree<int> bt = new BinaryTree<int>();
            while (IntialCount <= count)
            {
                r = new Random();
                val = r.Next(maxRandomValue);
                if (!list.Contains(val))
                {
                    bt.recursiveInsert(val);
                    list.Add(val);
                    sw.Write(val + " ");
                    IntialCount++;
                }

            }
            sw.Close();
            string[] the_array = list.Select(i => i.ToString()).ToArray();

            string[] lines2 = System.IO.File.ReadAllLines("../../hw.txt");
            // Display the file contents by using a foreach loop.
            System.Console.Write("\n\n\nIN-ORDER of hw.txt = ");


            foreach (string line2 in the_array)
            {
                // Use a tab to indent each line of the file.
                bt.inOrderTraversal(bt.root);
                break;
            }

            System.Console.Write("\n\n\nPRE-ORDER of hw.txt = ");


            foreach (string line2 in the_array)
            {
                // Use a tab to indent each line of the file.
                bt.preOrderTraversal(bt.root);
                break;
            }

            System.Console.Write("\n\n\nPOST-ORDER of hw.txt = ");


            foreach (string line2 in the_array)
            {
                // Use a tab to indent each line of the file.
                bt.postOrderTraversal(bt.root);
                break;
            }
            System.Console.ReadKey();
        }
    }

}
