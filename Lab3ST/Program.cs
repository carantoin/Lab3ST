using System;

class TreeNode
{
    public int Value;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int value)
    {
        Value = value;
    }
}

class Program
{
    static int SumTree(TreeNode root)
    {
        if (root == null)
            return 0;

        return root.Value + SumTree(root.Left) + SumTree(root.Right);
    }
    static void PrintTree(TreeNode root, string indent = "", bool isLeft = true, bool isRoot = true)
    {
        if (root == null) return;

        if (isRoot)
            Console.WriteLine(root.Value);
        else
            Console.WriteLine($"{indent}{(isLeft ? "├──" : "└──")} {root.Value}");

        string newIndent = isRoot ? "" : indent + (isLeft ? "│   " : "    ");
        PrintTree(root.Left, newIndent, true, false);
        PrintTree(root.Right, newIndent, false, false);
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var p1 = new TreeNode(10);
        p1.Left = new TreeNode(5);
        p1.Right = new TreeNode(15);
        p1.Left.Left = new TreeNode(3);
        p1.Left.Right = new TreeNode(7);
        p1.Right.Right = new TreeNode(20);
        p1.Left.Left.Left = new TreeNode(1);

        Console.WriteLine("Структура дерева:");
        PrintTree(p1);

        int sum = SumTree(p1);
        Console.WriteLine($"\nСумма значений всех вершин: {sum}");

        Console.ReadLine();
    }
}