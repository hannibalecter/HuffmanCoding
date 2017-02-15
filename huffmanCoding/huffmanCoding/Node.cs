using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffmanCoding
{
    public class Node
    {
        public double rate { get; set; }
        public string symbol { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
        public string code { get; set; }

        

        public void setCodeTree(Node root, string sym) // Search the tree
        {

            if (root == null)
                return;
            if (root.left == null && root.right == null)
            {
                root.code = sym;
                return;
            }
            setCodeTree(root.left, sym + "0");
            setCodeTree(root.right, sym + "1");
        }



    }
}
