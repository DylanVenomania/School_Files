using System;

namespace BinaryTreeProgram
{
    public class TreeNode
    {
        public int Key;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int value)
        {
            Key = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree
    {
        private TreeNode Root;

        public BinaryTree()
        {
            Root = null;
        }

        public bool IsEmpty()
        {
            return Root == null;
        }

        public void Insert(int value)
        {
            Root = InsertNode(Root, value);
        }

        private TreeNode InsertNode(TreeNode node, int value)
        {
            if (node == null)
                return new TreeNode(value);

            if (value < node.Key)
                node.Left = InsertNode(node.Left, value);
            else if (value > node.Key)
                node.Right = InsertNode(node.Right, value);

            return node;
        }

        public void Delete(int value)
        {
            Root = DeleteNode(Root, value);
        }

        private TreeNode DeleteNode(TreeNode node, int value)
        {
            if (node == null)
            {
                Console.WriteLine("Gia tri khong co trong tree!");
                return null;
            }

            if (value < node.Key)
                node.Left = DeleteNode(node.Left, value);
            else if (value > node.Key)
                node.Right = DeleteNode(node.Right, value);
            else
            {
                // Node with one child or no child
                if (node.Left == null)
                    return node.Right;
                if (node.Right == null)
                    return node.Left;

                // Node with two children: Get the inorder predecessor (max value in the left subtree)
                TreeNode temp = FindMax(node.Left);
                node.Key = temp.Key;
                node.Left = DeleteNode(node.Left, temp.Key);
            }

            return node;
        }

        private TreeNode FindMax(TreeNode node)
        {
            while (node.Right != null)
                node = node.Right;
            return node;
        }

        public TreeNode Search(int value)
        {
            return SearchNode(Root, value);
        }

        private TreeNode SearchNode(TreeNode node, int value)
        {
            if (node == null || node.Key == value)
                return node;

            if (value < node.Key)
                return SearchNode(node.Left, value);
            else
                return SearchNode(node.Right, value);
        }

        public void PreOrderTraversal()
        {
            Console.WriteLine("Duyet tien tu:");
            PreOrder(Root);
            Console.WriteLine();
        }

        private void PreOrder(TreeNode node)
        {
            if (node != null)
            {
                Console.Write(node.Key + " ");
                PreOrder(node.Left);
                PreOrder(node.Right);
            }
        }

        public void InOrderTraversal()
        {
            Console.WriteLine("Duyet trung tu:");
            InOrder(Root);
            Console.WriteLine();
        }

        private void InOrder(TreeNode node)
        {
            if (node != null)
            {
                InOrder(node.Left);
                Console.Write(node.Key + " ");
                InOrder(node.Right);
            }
        }

        public void PostOrderTraversal()
        {
            Console.WriteLine("Duyet hau tu:");
            PostOrder(Root);
            Console.WriteLine();
        }

        private void PostOrder(TreeNode node)
        {
            if (node != null)
            {
                PostOrder(node.Left);
                PostOrder(node.Right);
                Console.Write(node.Key + " ");
            }
        }

        public int Height()
        {
            return TreeHeight(Root);
        }

        private int TreeHeight(TreeNode node)
        {
            if (node == null)
                return 0;
            return Math.Max(TreeHeight(node.Left), TreeHeight(node.Right)) + 1;
        }

        public int CountBranches()
        {
            return CountBranchNodes(Root);
        }

        private int CountBranchNodes(TreeNode node)
        {
            if (node == null || (node.Left == null && node.Right == null))
                return 0;
            return 1 + CountBranchNodes(node.Left) + CountBranchNodes(node.Right);
        }

        public int CountLeaves()
        {
            return CountLeafNodes(Root);
        }

        private int CountLeafNodes(TreeNode node)
        {
            if (node == null)
                return 0;
            if (node.Left == null && node.Right == null)
                return 1;
            return CountLeafNodes(node.Left) + CountLeafNodes(node.Right);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            Console.WriteLine("Nhap cac gia tri cho nut cua tree (nhap ky tu de dung):");
            while (true)
            {
                Console.Write("Nhap gia tri: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int value))
                    break;
                tree.Insert(value);
            }

            Console.WriteLine("Menu");
            Console.WriteLine("1. Kiem tra cay rong");
            Console.WriteLine("2. Them mot phan tu vao cay");
            Console.WriteLine("3. Xoa mot phan tu trong cay");
            Console.WriteLine("4. Tim mot phan tu trong cay");
            Console.WriteLine("5. Xuat cay");
            Console.WriteLine("6. Chieu cao cua cay");
            Console.WriteLine("7. Dem so nhanh cua cay");
            Console.WriteLine("8. Dem so la cua cay");

            while (true)
            {
                Console.Write("\nLua chon: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                    break;

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(tree.IsEmpty() ? "Cay rong!" : "Cay khong rong!");
                        break;

                    case 2:
                        Console.Write("Nhap gia tri muon them: ");
                        if (int.TryParse(Console.ReadLine(), out int valueToAdd))
                            tree.Insert(valueToAdd);
                        break;

                    case 3:
                        Console.Write("Nhap gia tri muon xoa: ");
                        if (int.TryParse(Console.ReadLine(), out int valueToDelete))
                            tree.Delete(valueToDelete);
                        break;

                    case 4:
                        Console.Write("Nhap gia tri nut muon tim trong tree: ");
                        if (int.TryParse(Console.ReadLine(), out int valueToSearch))
                        {
                            TreeNode result = tree.Search(valueToSearch);
                            Console.WriteLine(result != null ? $"Tim thay nut voi gia tri {valueToSearch}" : $"Khong tim thay nut voi gia tri {valueToSearch}");
                        }
                        break;

                    case 5:
                        Console.WriteLine("1. Xuat theo kieu tien tu");
                        Console.WriteLine("2. Xuat theo kieu trung tu");
                        Console.WriteLine("3. Xuat theo kieu hau tu");
                        Console.Write("Chon kieu xuat: ");
                        if (int.TryParse(Console.ReadLine(), out int traversalChoice))
                        {
                            switch (traversalChoice)
                            {
                                case 1:
                                    tree.PreOrderTraversal();
                                    break;
                                case 2:
                                    tree.InOrderTraversal();
                                    break;
                                case 3:
                                    tree.PostOrderTraversal();
                                    break;
                            }
                        }
                        break;

                    case 6:
                        Console.WriteLine($"Chieu cao cua cay la: {tree.Height()}");
                        break;

                    case 7:
                        Console.WriteLine($"So nhanh cua cay la: {tree.CountBranches()}");
                        break;

                    case 8:
                        Console.WriteLine($"So la cua cay la: {tree.CountLeaves()}");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
            }
        }
    }
}