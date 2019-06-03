// - 8.5, 8.7, 8.8, 8.10


//1.7

class Solution
{
    enum SwapType
    {
        WithRight,
        WithBottom,
        WithLeft,
    }

    static int[][] Panic(int[][] matrix)
    {
        var n = matrix.Length;
        int x, y;

        for (int i = 0; i < (n / 2); i++)
        {
            x = i;
            y = n - 1 - i;

            SwapTop(x, y, SwapType.WithRight);
            SwapTop(x, y, SwapType.WithBottom);
            SwapTop(x, y, SwapType.WithLeft);
        }

        return matrix;

        void SwapTop(int start, int end, SwapType swapType)
        {
            int x2 = 0, y2 = 0;

            switch (swapType)
            {
                case SwapType.WithRight:
                    for (int i = start; i <= end-1; i++)
                    {
                        x2 = i;
                        y2 = end;
                        Swap(start, i, x2, y2);
                    }
                    break;
                case SwapType.WithBottom:
                    for (int i = start; i <= end - 1; i++)
                    {
                        x2 = end;
                        y2 = i;
                        Swap(start, i, x2, y2);
                    }
                    break;
                case SwapType.WithLeft:
                    break;
            }

        }

        void Swap(int x1, int y1, int x2, int y2)
        {
            var tmp = matrix[x1][y1];
            matrix[x1][y1] = matrix[x2][y2];
            matrix[x2][y2] = tmp;
        }
    }

    static void Main(string[] args)
    {
        while (true)
        {
            var n = Convert.ToInt32(Console.ReadLine());

            var matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                string[] a_temp = Console.ReadLine().Split(' ');
                int[] array = Array.ConvertAll(a_temp, int.Parse);

                matrix[i] = array;
            }

            matrix = Panic(matrix);

            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i][j]));
                }
                Console.WriteLine();
            }
        }
    }
}


// 4.2

class Solution
{
    class Node
    {
        public int Value { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public void InitChildren()
        {
            LeftChild = new Node();
            RightChild = new Node();
        }
    }

    static void Panic(int[] array)
    {
        var root = new Node();

        BuildNode(root, array, 0, array.Length);
    }

    static void BuildNode(Node node, int[] array, int start, int end)
    {
        var noMore = (end - start) == 1;

        var middle = (start + end) / 2;

        node.Value = array[middle];

        if (noMore) return;

        node.InitChildren();

        BuildNode(node.LeftChild, array, start, middle);
        BuildNode(node.RightChild, array, middle, end);
    }

    static void Main(string[] args)
    {
        while (true)
        {
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] array = Array.ConvertAll(a_temp, int.Parse);

            Panic(array);

            Console.WriteLine();
        }
    }
}

// shortest paths

class Graph
{
    private List<List<int>> edges;
    private List<int> shortestDistances;

    public Graph(int n)
    {
        edges = new List<List<int>>();
        shortestDistances = new List<int>();

        for (int i = 0; i < n + 1; i++)
        {
            shortestDistances.Add(-1);
            edges.Add(new List<int>());
        }
    }

    public void AddEdge(int u, int v)
    {
        if (edges[u] == null)
        {
            edges[u] = new List<int>();
        }

        edges[u].Add(v);

        if (edges[v] == null)
        {
            edges[v] = new List<int>();
        }

        edges[v].Add(u);
    }

    public List<int> ShortestReaches(int start)
    {
        Queue<int> workingList = new Queue<int>();
        workingList.Enqueue(start);

        shortestDistances[start] = 0;

        while (workingList.Any())
        {
            var vertex = workingList.Dequeue();

            foreach (var adj in edges[vertex]) // adjacent vertex
            {
                if (shortestDistances[adj] == -1)
                {
                    workingList.Enqueue(adj);
                    shortestDistances[adj] = shortestDistances[vertex] + 6;
                }
            }
        }

        return shortestDistances;
    }
}

class Program
{
    static void Main(string[] args)
    {
        while(true)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);

            Graph graph = new Graph(n);

            for (int i = 0; i < m; i++)
            {
                tokens_n = Console.ReadLine().Split(' ');
                int u = Convert.ToInt32(tokens_n[0]);
                int v = Convert.ToInt32(tokens_n[1]);

                graph.AddEdge(u, v);
            }

            int startId = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> distances = graph.ShortestReaches(startId);

            for (int i = 1; i < distances.Count; i++)
            {
                if (i != startId)
                {
                    Console.Write(distances[i] + " ");
                }
            }

            Console.WriteLine();
        }
    }
}

// 4.1

public class Node
{
    public Node(int id)
    {
        Id = id;
    }

    public int Id { get; }
    public Node ParentByFirstSearch { get; set; }
    public Node ParentBySecondSearch { get; set; }

    private readonly List<int> adjacents = new List<int>();
    public void AddAdjacentVertex(int vertex)
    {
        adjacents.Add(vertex);
    }
}

public class GraphForShortest
{
    private readonly int First;
    private readonly int Second;

    readonly Dictionary<int, Node> nodes = new Dictionary<int, Node>();

    public GraphForShortest(int firstVertex, int secondVertex)
    {
        First = firstVertex;
        Second = secondVertex;
    }

    public void AddEdge(int u, int v)
    {
        EnsureNodeExistance(u);
        EnsureNodeExistance(v);

        nodes[u].AddAdjacentVertex(v);
    }

    private void EnsureNodeExistance(int vertex)
    {
        if (nodes[vertex] == null)
        {
            nodes[vertex] = new Node(vertex);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int m = Convert.ToInt32(tokens_n[1]);
            int first = Convert.ToInt32(tokens_n[0]);
            int second = Convert.ToInt32(tokens_n[1]);

            var graph = new GraphForShortest(first,second);

            int u, v;

            for (int i = 0; i < m; i++)
            {
                tokens_n = Console.ReadLine().Split(' ');
                u = Convert.ToInt32(tokens_n[0]);
                v = Convert.ToInt32(tokens_n[1]);

                graph.AddEdge(u, v);
            }

            Console.WriteLine();
        }
    }
}


// 4.4

bool isTreeBalanced(Node root){

}

int GetChildrenCount(Node root){

}

// 4.7 Topological Sort

enum Mark
{
    Unmarked,
    Temporary,
    Permanent
}
class Edge
{
    public char X { get; }
    public char Y { get; }

    public Edge(char x, char y)
    {
        X = x; Y = y;
    }
}
class Vertex
{
    public char Id { get; }
    public HashSet<Edge> Edges { get; } = new HashSet<Edge>();

    public Mark Mark { get; set; } = Mark.Unmarked;

    public Vertex(char v)
    {
        Id = v;
    }
}

class Graph
{
    private readonly Dictionary<char, Vertex> vertexes = new Dictionary<char, Vertex>();

    public Graph()
    {
    }

    public void AddVertex(char v)
    {
        vertexes[v] = new Vertex(v);
    }

    public void AddEdge(char u, char v)
    {
        var vertex = vertexes[u];

        var edge = new Edge(u, v);
        vertex.Edges.Add(edge);
    }

    public Stack<char> TopologicalySorted()
    {
        var resultStack = new Stack<char>();

        foreach (var vertex in vertexes)
        {
            if (vertex.Value.Mark == Mark.Unmarked)
            {
                DFS(vertex.Value, resultStack);
            }
        }

        return resultStack;
    }

    private void DFS(Vertex vertex, Stack<char> resultStack)
    {
        vertex.Mark = Mark.Temporary;

        foreach (var edges in vertex.Edges)
        {
            var adjVertex = vertexes[edges.Y];

            if (adjVertex.Mark == Mark.Unmarked)
            {
                DFS(adjVertex, resultStack);
            }
            else if (adjVertex.Mark == Mark.Temporary)
            {
                throw new Exception("Graph Has Cycles");
            }
        }

        vertex.Mark = Mark.Permanent;

        resultStack.Push(vertex.Id);
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            string[] vertexes = Console.ReadLine().Split(' ');

            Graph graph = new Graph();

            for (int i = 0; i < vertexes.Length; i++)
            {
                graph.AddVertex(vertexes[i][0]);
            }

            int m = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                var tokens_n = Console.ReadLine().Split(' ');
                char u = Convert.ToChar(tokens_n[0].Trim());
                char v = Convert.ToChar(tokens_n[1].Trim());

                graph.AddEdge(u, v);
            }

            var result = graph.TopologicalySorted();

            while (result.Any())
            {
                Console.Write(result.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}

// 4.9

namespace ProblemSolving
{
    public static class Extensions
    {
        public static void AddAll(this LinkedList<int> result, LinkedList<int> prefix)
        {
            foreach (var item in prefix)
            {
                result.AddLast(item);
            }
        }

    }

    class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }

    class Program
    {
        List<LinkedList<int>> AllSequences(TreeNode node)
        {
            var result = new List<LinkedList<int>>();

            if (node == null)
            {
                result.Add(new LinkedList<int>());
                return result;
            }

            var prefix = new LinkedList<int>();
            prefix.AddFirst(node.Data);

            var leftSequences = AllSequences(node.Left);
            var rightSequences = AllSequences(node.Right);

            foreach (var left in leftSequences)
            {
                foreach (var right in rightSequences)
                {
                    var weaved = new List<LinkedList<int>>();

                    WeaveLists(left, right, weaved, prefix);

                    result.AddRange(weaved);
                }
            }

            return result;
        }

        /* Weave lists together in all possible ways. this algorithm works by removing the
         * head from one list, recursing, and then doing the same thing with the other 
         * list */
        private void WeaveLists(
            LinkedList<int> left,
            LinkedList<int> right,
            List<LinkedList<int>> weaved,
            LinkedList<int> prefix)
        {
            /* One List is empty. add remainder to [a cloned] prefix and store result */
            if (left.Count == 0 || right.Count == 0)
            {
                var result = new LinkedList<int>();

                result.AddAll(prefix);
                result.AddAll(left);
                result.AddAll(right);

                weaved.Add(result);

                return;
            }

            /* Recurse with head of first added to the prefix. Removing the head will damage 
             * first, so we'll need to put it back where we found it afterwards */

            int headLeft = left.First.Value;
            left.RemoveFirst();

            prefix.AddLast(headLeft);
            WeaveLists(left, right, weaved, prefix);
            prefix.RemoveLast();
            left.AddFirst(headLeft);

            /* Do the same thing with second, damaging and then restoring the list */

            int headRight = right.First.Value;
            right.RemoveFirst();

            prefix.AddLast(headRight);
            WeaveLists(left, right, weaved, prefix);
            prefix.RemoveLast();
            right.AddFirst(headRight);
        }


        static void Main(string[] args)
        {
            var root = new TreeNode(2)
            {
                Left = new TreeNode(1),
                Right = new TreeNode(3)
            };

            var result = AllSequences(root);

            foreach (var sequence in result)
            {
                foreach (var item in sequence)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}

// 4.10

namespace ProblemSolving
{
    class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public bool IsSubtree(TreeNode subtreeRoot)
        {
            var roots = GetTreeNodesInOrderly(this);

            foreach (var root in roots)
            {
                if (HaveIdenticalValues(root, subtreeRoot))
                {
                    return true;
                }
            }

            return false;
        }

        private bool HaveIdenticalValues(TreeNode root, TreeNode subtreeRoot)
        {
            if(root == null && subtreeRoot == null)
            {
                return true;
            }

            if (root == null ||
                subtreeRoot == null ||
                root.Data != subtreeRoot.Data ||
                !HaveIdenticalValues(root.Left, subtreeRoot.Left) ||
                !HaveIdenticalValues(root.Right, subtreeRoot.Right)
                )
            {
                return false;
            }

            return true;
        }

        private List<TreeNode> GetTreeNodesInOrderly(TreeNode root)
        {
            var result = new List<TreeNode>();

            InOrderSearch(root, result);

            return result;
        }

        private void InOrderSearch(TreeNode node, List<TreeNode> nodes)
        {
            if (node == null)
            {
                return;
            }

            InOrderSearch(node.Left, nodes);

            nodes.Add(node);

            InOrderSearch(node.Right, nodes);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

// 4.11

namespace ProblemSolving
{
    class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public int Size { get; set; } = 0;

        public TreeNode(int data)
        {
            this.Data = data;
            this.Size = 1;
        }

        public TreeNode GetRandomNode()
        {
            var leftSize = this.Left == null ? 0 : this.Left.Size;

            var random = new Random();

            var index = random.Next(this.Size);

            if (index < leftSize)
            {
                return this.Left.GetRandomNode();
            }

            if (index == leftSize)
            {
                return this;
            }

            return this.Right.GetRandomNode();
        }

        public void InsertInOrder(int data)
        {
            if (data < this.Data)
            {
                if (this.Left == null)
                {
                    this.Left = new TreeNode(data);
                }
                else
                {
                    this.Left.InsertInOrder(data);
                }
            }
            else
            {
                if (this.Right == null)
                {
                    this.Right = new TreeNode(data);
                }
                else
                {
                    this.Right.InsertInOrder(data);
                }
            }

            this.Size++;
        }

        public TreeNode Find(int data)
        {
            if (data == this.Data)
            {
                return this;
            }

            if (data < this.Data)
            {
                return this.Left != null ? this.Left.Find(data) : null;
            }

            return this.Right != null ? this.Right.Find(data) : null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

// 4.12 A

namespace ProblemSolving
{
    class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int data)
        {
            this.Data = data;
        }
    }

    class Tree
    {
        private readonly TreeNode _root;
        private int _count = 0;
        private int _value = 0;
        public Tree(TreeNode root, int value)
        {
            _root = root;
            _value = value;
        }

        public int GetPathCount()
        {
            CountPaths(_root);

            return _count;
        }

        private void CountPaths(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            CountPathsFromSpecificNode(node, _value);

            CountPaths(node.Left);
            CountPaths(node.Right);
        }

        private void CountPathsFromSpecificNode(TreeNode node, int remainder)
        {
            if (node == null)
            {
                return;
            }

            remainder -= node.Data;
            if (remainder == 0)
            {
                _count++;
            }

            CountPathsFromSpecificNode(node.Left, remainder);
            CountPathsFromSpecificNode(node.Right, remainder);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

// 4.12 B

namespace ProblemSolving
{
    class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int data)
        {
            this.Data = data;
        }
    }

    class Tree
    {
        private readonly TreeNode _root;
        private int _count = 0;
        public Tree(TreeNode root, int value)
        {
            _root = root;
        }

        public int GetCount(int value)
        {
            var count = 0;

            var leftSum = 0;
            var rightSum = 0;

            var listOfSums = GetSumsFromRoot();

            var sum = listOfSums.Sum();

            var lastIndex = listOfSums.Count - 2; // check for 1 element

            for (int i = 0; i <= lastIndex; i++)
            {
                leftSum += listOfSums[i];
                rightSum += listOfSums[lastIndex - i];

                if (sum - leftSum == value)
                {
                    count++;
                }

                if (sum - rightSum == value)
                {
                    count++;
                }
            }

            return count;
        }

        private List<int> GetSumsFromRoot()
        {
            var sums = new List<int>();

            GetSums(_root, 0, sums);

            return sums;
        }

        private void GetSums(TreeNode node, int parentSumFromRoot, List<int> sums)
        {
            if (node == null)
            {
                return;
            }

            var total = node.Data + parentSumFromRoot;
            sums.Add(total);

            GetSums(node.Left, total, sums);
            GetSums(node.Right, total, sums);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

// 8.2

namespace ProblemSolving
{
    class Point
    {
        public int Row { get; }
        public int Column { get; }
        public string Show => Row + " " + Column;

        public Point(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }

    class PointEqualityComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point x, Point y)
        {
            if (x == null && y == null)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            if (x.Show == y.Show)
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(Point obj)
        {
            return obj.Show.GetHashCode();
        }
    }

    class Program
    {
        List<Point> GetPath(bool[][] maze)
        {
            if (maze == null || maze.Length == 0)
            {
                return null;
            }

            var path = new List<Point>();
            var faildePoints = new HashSet<Point>(new PointEqualityComparer());

            if (GetPath(
                maze,
                maze.Length - 1,
                maze[0].Length - 1,
                path,
                faildePoints))
            {
                return path;
            }

            return null;
        }

        bool GetPath(
            bool[][] maze,
            int row,
            int column,
            List<Point> path,
            HashSet<Point> faildPoints)
        {
            // If out of bounds or not avaliable return.
            if (row < 0 || column < 0 || !maze[row][column])
            {
                return false;
            }

            var point = new Point(row, column);

            // If we've visited this cell, return.
            if (faildPoints.Contains(point))
            {
                return false;
            }

            var isAtOrigin = (row == 0) && (column == 0);

            // if there is a path from start to my current location, add my location
            if (isAtOrigin ||
                GetPath(maze, row, column - 1, path, faildPoints) ||
                GetPath(maze, row - 1, column, path, faildPoints))
            {
                path.Add(point);
                return true;
            }

            faildPoints.Add(point);
            return false;
        }

        static void Main(string[] args)
        {
            var set = new HashSet<Point>(new PointEqualityComparer());

            var pointA = new Point(1, 13);
            var pointB = new Point(1, 13);

            set.Add(pointA);
            set.Add(pointB);

            foreach (var item in set)
            {
                Console.WriteLine(item.Show);
            }

            Console.ReadLine();
        }
    }
}

// 8.3

namespace ProblemSolving
{
    class Program
    {
        int GetMagicIndex(List<int> list, int start, int end)
        {
            if (end < start)
            {
                return -1;
            }

            var middle = (start + end) / 2;

            if (middle == list[middle])
            {
                return middle;
            }

            if (middle < list[middle])
            {
                return GetMagicIndex(list, start, middle - 1);
            }

            return GetMagicIndex(list, middle, end + 1);
        }

        static void Main(string[] args)
        {

            Console.ReadLine();
        }
    }
}

// 8.4

namespace ProblemSolving
{
    public static class Extensions
    {
        public static void AddAll(this HashSet<int> result, HashSet<int> prefix)
        {
            foreach (var item in prefix)
            {
                result.Add(item);
            }
        }

        public static string Show(this HashSet<int> set)
        {
            var sb = new StringBuilder();

            foreach (var item in set)
            {
                sb.Append(item + " ");
            }

            return sb.ToString();
        }
    }

    class Program
    {
        public static List<HashSet<int>> GetAllSubsets(List<int> list)
        {
            var n = list.Count - 1;
            var result = new List<HashSet<int>>();

            AddAllSubsets(n, result, list);

            return result;
        }

        private static void AddAllSubsets(int index, List<HashSet<int>> result, List<int> list)
        {
            var element = list[index];

            if (index == 0)
            {
                var set = new HashSet<int>
                {
                    element
                };

                result.Add(new HashSet<int>());
                result.Add(set);

                return;
            }

            AddAllSubsets(index - 1, result, list);

            var tmpSet = new List<HashSet<int>>();

            foreach (var set in result)
            {
                var newSet = new HashSet<int>();
                newSet.AddAll(set);
                newSet.Add(element);

                tmpSet.Add(newSet);
            }

            foreach (var item in tmpSet)
            {
                result.Add(item);
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                var array = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);
                var list = array.ToList();

                var result = GetAllSubsets(list);

                Console.WriteLine();

                foreach (var set in result)
                {
                    Console.WriteLine(set.Show());
                }
                Console.WriteLine();
            }
        }
    }
}

// 8.6

namespace ProblemSolving
{
    class Program
    {
        public static void HanoisTower(Stack<int> stack)
        {
            var list = new List<Stack<int>>
            {
                stack,
                new Stack<int>(),
                new Stack<int>()
            };

            MoveAll(list, 0, 2, stack.Count);
        }

        public static void MoveAll(
            List<Stack<int>> stacks,
            int from,
            int to,
            int count)
        {
            if (count == 1)
            {
                MoveOne();
                return;
            }

            var other = from != 0 && to != 0 ? 0 : from != 1 && to != 1 ? 1 : 2;

            MoveAll(stacks, from, other, count - 1);

            MoveOne();

            MoveAll(stacks, other, to, count - 1);

            void MoveOne()
            {
                var poped = stacks[from].Pop();
                stacks[to].Push(poped);
            }

            void Show(string str)
            {
                Console.WriteLine($"*** Stack Iteration {str}. Params: From {from}, To {to}, Count {count}");

                foreach (var stack in stacks)
                {
                    Console.Write("  Stack: ");
                    var list = stack.ToList();
                    list.Reverse();
                    foreach (var item in list)
                    {
                        Console.Write(item + " ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("*** End");
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                var numbers = Array.ConvertAll(Console.ReadLine().Trim().Split(" "), Convert.ToInt32);
                var stack = new Stack<int>(numbers);

                HanoisTower(stack);
            }
        }
    }
}

// 8.7 A
namespace ProblemSolving
{
    public static class Extensions
    {
        public static void CopyValues(this StringBuilder result, StringBuilder source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                result.Append(source[i]);
            }
        }
    }

    class Program
    {
        static List<StringBuilder> Perms(StringBuilder str, int n)
        {
            if (n == 0)
            {
                var sb1 = new StringBuilder();
                sb1.Append(str[n]);

                return new List<StringBuilder>
                {
                    sb1
                };
            }

            var c = str[n];

            var shorterPerms = Perms(str, n - 1);

            var perms = new List<StringBuilder>();

            foreach (var item in shorterPerms)
            {
                Fill(item);
            }

            shorterPerms.AddRange(perms);

            return perms;

            void Fill(StringBuilder s)
            {
                for (int i = 0; i <= s.Length; i++)
                {
                    var newSB = new StringBuilder();
                    newSB.CopyValues(s);

                    newSB.Insert(i, c);

                    perms.Add(newSB);
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                var chars = Console.ReadLine().Trim().ToCharArray();
                var charSet = new HashSet<char>();

                foreach (var c in chars)
                {
                    charSet.Add(c);
                }

                var sb = new StringBuilder();

                foreach (var c in charSet)
                {
                    sb.Append(c);
                }

                var substrings = Perms(sb, sb.Length - 1);

                foreach (var str in substrings)
                {
                    Console.WriteLine(str.ToString());
                }

                Console.WriteLine();
            }
        }
    }
}

// B

        public static List<string> GetPerms(string remainder)
        {
            var length = remainder.Length;

            var result = new List<string>();

            // Base case.
            if (length == 0)
            {
                result.Add("");
                return result;
            }

            for (int i = 0; i < length; i++)
            {
                // Remove char i and find permutations of ramaining chars

                var before = remainder.Substring(0, i);
                var after = remainder.Substring(i + 1, length - i - 1);

                var partials = GetPerms(before + after);

                // prepend char i to each permutation
                foreach (var str in partials)
                {
                    result.Add(remainder[i] + str);
                }
            }

            return result;
        }

// 8.9

namespace ProblemSolving
{
    class Program
    {
        public static readonly string full = "()";
        public static readonly string left = "(";
        public static readonly string right = ")";

        public static List<string> Panic(int n)
        {
            var result = new List<string>();

            if (n == 1)
            {
                result.Add(full);

                return result;
            }

            var previous = Panic(n - 1);

            foreach (var item in previous)
            {
                Add(item);
            }

            return result;

            void Add(string item)
            {
                var new13 = left + item + right; // outside is alright for everything.
                result.Add(new13);

                if (HasBothFull(item))
                {
                    var new1 = full + item;
                    result.Add(new1);
                }
                else if (HasRightFull(item))
                {
                    var new1 = item + full;

                    result.Add(new1);
                }
                else // none is full or hasLeftFull
                {
                    var new1 = full + item;
                    var new2 = item + full;

                    result.Add(new1);
                    result.Add(new2);
                }
            }
        }

        public static bool HasBothFull(string str)
        {
            return HasLeftFull(str) && HasRightFull(str);
        }

        public static bool HasLeftFull(string str)
        {
            if (str.Length < 2) return false;

            return (str.Substring(0, 2) == full);
        }

        public static bool HasRightFull(string str)
        {
            if (str.Length < 2) return false;

            return (str.Substring(str.Length - 2, 2) == full);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                var n = Convert.ToInt32(Console.ReadLine());

                var result = Panic(n);

                foreach (var item in result)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

