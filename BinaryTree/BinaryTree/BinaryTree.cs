using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BinaryTree<Type> where Type : IComparable<Type>
    {
        public Node<Type> root;

        internal BinaryTree()
        {
            root = null;
        }

        public virtual bool recursiveInsert(Type value)
        {
            try
            {
                return recursiveInsertNode(value, root);
            }
            catch (Exception)
            {
                return false;
            }
        }
        protected virtual bool recursiveInsertNode(Type value, Node<Type> curNode = null, Node<Type> parentNode = null)
        {
            try
            {
                if (curNode == null)
                {
                    if (curNode == root)
                        root = new Node<Type>(value);
                    else
                    {
                        curNode = new Node<Type>(value);
                        curNode.parent = parentNode;
                        if (parentNode != null)
                        {
                            if (parentNode.value.CompareTo(value) > 0) parentNode.left = curNode;
                            else parentNode.right = curNode;
                        }
                    }
                }
                else if (curNode.value.CompareTo(value) > 0) recursiveInsertNode(value, curNode.left, curNode);
                else if (curNode.value.CompareTo(value) == 0) return false;
                else recursiveInsertNode(value, curNode.right, curNode);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public StringBuilder str = new StringBuilder();
        public virtual string preOrderTraversal(Node<Type> node)
        {
            if (node != null)
            {
                Console.Write( node + ",");
                preOrderTraversal(node.left);
                preOrderTraversal(node.right);
            }
            return str.ToString();
        }
        public virtual string inOrderTraversal(Node<Type> node)
        {
            if (node != null)
            {
                
                inOrderTraversal(node.left);
                Console.Write(node + ",");
                inOrderTraversal(node.right);
            }
            return str.ToString();
        }
        public virtual string postOrderTraversal(Node<Type> node)
        {
            if (node != null)
            {
                postOrderTraversal(node.left);
                postOrderTraversal(node.right);
                Console.Write(node + ",");
            }
            return str.ToString();
        }
    }
}
