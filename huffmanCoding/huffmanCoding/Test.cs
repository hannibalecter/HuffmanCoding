using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffmanCoding
{
    class Test
    {
        static string alfabet = "ABCDE";
        List<Node> values = new List<Node>(); // All node list
        public Node root { get; set; }
        string textTemp = null;
        double compression_rate = 0.0;
        double entropy_value = 0.0;

        int count = 1; // Step size
        public void buildTree()
        {
            while (values.Count > 1)
            {
                List<Node> orderedNodes = values.OrderBy(node => node.rate).ToList<Node>(); // Used function order by List<>
                Console.WriteLine("\n---Step: " + count++);
                display(orderedNodes);


                Node lastNode0 = null;
                Node lastNode1 = null;
                int size = values.Count;
                if (size > 1)
                {
                    lastNode0 = orderedNodes[0];
                    lastNode1 = orderedNodes[1];

                    Node newNode = new Node() // New node create with sum of min rates
                    {
                        rate = lastNode0.rate + lastNode1.rate,
                        symbol = lastNode1.symbol + lastNode0.symbol,
                        left = lastNode0,
                        right = lastNode1
                    };

                    values.Remove(orderedNodes[0]);
                    values.Remove(orderedNodes[1]);
                    values.Add(newNode);

                }

                this.root = values.FirstOrDefault();  // Last element is tree root in List<> value
            }

            root.setCodeTree(this.root, ""); // Codes is added in Nodes

            Console.WriteLine("\n---HUFFMAN TREE AND CODE");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--> Right");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--> Left \n");

            PrintTree(root, 3);

            Console.WriteLine("\nCompression Rate: " + compression_rate);
            Console.WriteLine("Entropy: " + entropy_value);

            createCode(lastNodes);
        }

        public void createCode(List<Node> list) // Text converter byte 
        {
            Console.Write("Code: ");
            for (int i = 0; i < textTemp.Count(); i++)
            {
                for (int j = 0; j < list.Count(); j++)
                {
                    if (textTemp[i].ToString() == list[j].symbol)
                    {
                        Console.Write(list[j].code + " ");

                    }
                }

            }

        }


        public void PrintTree(Node root, int padding) // Print the screen
        {
            Node temp = root;
            if (temp == null)
                return;
            for (int i = 0; i < padding; i++)
            {
                Console.Write("\t");
            }
            Console.Write("[" + temp.symbol + "]");
            Console.Write("(" + temp.rate + ")");
            Console.WriteLine("--> " + temp.code);
            compressionRate(temp); // For calculating necessary bits,

            Console.ForegroundColor = ConsoleColor.Cyan; // For Right Nodes.
            PrintTree(temp.right, padding + 1);
            Console.ForegroundColor = ConsoleColor.White; // For Left Nodes.
            PrintTree(temp.left, padding + 1);
        }
        List<Node> lastNodes = new List<Node>();

        public void compressionRate(Node node) // Calculate compression rate.
        {
            if (node.code != null)
            {
                compression_rate += node.rate * node.code.Count(); // This is Formula
                lastNodes.Add(node);
            }

        }

        public int findNumberOfSymbol(string text)  // Each number of symbol find 
        {
            textTemp = text;
            Console.WriteLine("Alfabet:  " + alfabet + "\n");
            int numberOfSymbol = 0;
            for (int i = 0; i < alfabet.Length; i++)
            {
                numberOfSymbol = 0;
                for (int j = 0; j < text.Length; j++)
                {
                    if (text[j] == alfabet[i])
                        numberOfSymbol += 1;
                }
                double rate1 = (double)numberOfSymbol / (double)text.Length; // Frequency
                Node root = new Node() { rate = rate1, symbol = alfabet[i].ToString(), left = null, right = null }; // Creating nodes
                values.Add(root);

                Console.WriteLine("symbol: " + alfabet[i] + " -> " + numberOfSymbol);

            }
            display(values);
            entropy_value = entropy();
            return numberOfSymbol;
        }


        public double entropy() // For calculating entropy
        {
            double resultEntropy = 0.0;
            for (int i = 0; i < values.Count; i++)
            {
                if ((double)values[i].rate != 0)
                    resultEntropy = resultEntropy + ((double)values[i].rate * (Math.Log(1 / (double)values[i].rate, 2)));

            }
            Console.WriteLine();
            return resultEntropy;
        }


        public void display(List<Node> values) // For symbol and Rate print on screen
        {
            Console.WriteLine();
            for (int i = 0; i < values.Count; i++)
                Console.WriteLine("symbol: " + values[i].symbol + ", rate: " + values[i].rate);
        }


    }
}
