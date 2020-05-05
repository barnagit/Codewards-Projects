using System;
using System.Collections.Generic;
using System.Text;

namespace All_Balanced_Parentheses
{
    public class Balanced
    {
        static int maxPos,maxVal;
        public static List<string> BalancedParens(int n)
        {
            if (n == 0) return new List<string> { "" };

            List<Node> tree = new List<Node>();
            Node root = new Node{Val = 1, Pos = 1, Char = '('};
            tree.Add(root);
            
            Node pointer = root;
            maxPos =  n;
            maxVal = n;

            Recursion(root);
            Endpoints = new List<Node>();
            Next(root);
            StringBuilder sb;
            List<string> ret = new List<string>();
            foreach(Node node in Endpoints) {
                sb = new StringBuilder();
                Append(node,sb);
                char[] array = sb.ToString().ToCharArray();
                Array.Reverse(array);
                ret.Add(new String(array));
            }

            return ret;
        }

        static void Append(Node node, StringBuilder sb) {
            sb.Append(node.Char);
            if (node.Parent != null) Append(node.Parent, sb);
        }

        static List<Node> Endpoints = new List<Node>();
        private static void Next(Node node) {
                if(node.Add != null) {
                    Next(node.Add);
                    if (node.Sub != null) Next(node.Sub);
                }
                else if (node.Sub != null) Next(node.Sub);
                else Endpoints.Add(node);
                
        }

        private static void Recursion(Node pointer) {

                Node add = new Node{Val = pointer.Val + 1, Pos = pointer.Pos +1, Parent = pointer, Char = '('};
                Node sub = new Node{Val = pointer.Val -1, Pos = pointer.Pos, Parent = pointer, Char = ')'};

                if (add.Pos <= maxPos && add.Val <= maxVal) {
                    pointer.Add = add;
                    Recursion(add);
                }
                if (sub.Pos <= maxPos && sub.Val >= 0) {
                    pointer.Sub = sub;
                    Recursion(sub);
                }
        }
    }

    class Node
    {
        public Node Add {get;set;}
        public Node Sub {get;set;}
        public int Val {get;set;}
        public int Pos {get;set;}
        public Node Parent {get;set;}
        public char Char {get;set;}
    }
}
