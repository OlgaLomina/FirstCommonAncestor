using System;
/*Design an algorithm and write code to find the first common ancestor of two nodes in a binary tree. 
         * Avoid storing additional nodes in a data structure. 
         * NOTE: This is not necessarily a BST
         * */
namespace Tree2_2
{
    public class Node<T>
    {
        public Node<T> left;
        public Node<T> right;
        public T data;

        public Node()
        {
            left = null;
            right = null;
        }

        public Node(T value)
        {
            left = null;
            right = null;
            data = value;
        }
    }

    public class BinaryTree<T>
    {
        public Node<T> root;

        public BinaryTree()
        {
            root = null;
        }

        
        public Node<int> FirstCommAnc(Node<int> root, Node<int> one, Node<int> two)
        {
            if (root == null) return null;

            if (root == one || root == two)
                return root;
            else
            {
                Node<int> left, right;
                left = FirstCommAnc(root.left, one, two);
                right = FirstCommAnc(root.right, one, two);

                if (left != null && right != null)
                    return root;
                else if (left != null && right == null)
                    return left;
                else if (left == null && right != null)
                    return right;
                else
                    return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node<int> node = new Node<int>(50);
            Node<int> one, two;
            node.left = new Node<int>(30);
            node.left.left = new Node<int>(10);
            node.left.right = new Node<int>(60);
            node.left.right.right = new Node<int>(70);

            node.right = new Node<int>(15);
            node.right.left = new Node<int>(20);
            one = node.right.right = new Node<int>(40);
            two = node.right.right.right = new Node<int>(80);

            /*int one, two;
            string userInput;
            Console.Write("Enter 1st value of node: ");
            userInput = Console.ReadLine();
            one = Convert.ToInt32(userInput);
            Console.Write("Enter 2nd value of node: ");
            userInput = Console.ReadLine();
            two = Convert.ToInt32(userInput);
            */
            BinaryTree<int> bt = new BinaryTree<int>();
            bt.root = node;
            node = bt.FirstCommAnc(bt.root, one, two);
            if (node != null)
                Console.WriteLine(one.data + ", " + two.data + " => " + node.data);
            else
                Console.WriteLine("Nodes are not listed correctly");

        }
    }
}
