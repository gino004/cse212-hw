public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
{
    // The base case is when the value already exists in the tree.
    if (value == Data)
        return;

    if (value < Data)
    {
        if (Left is null)
            Left = new Node(value);
        else
            Left.Insert(value);
    }
    else
    {
        if (Right is null)
            Right = new Node(value);
        else
            Right.Insert(value);
    }
}

    public bool Contains(int value)
    {
        // TODO Start Problem 2
								//	The base case is when the current node's data matches the value being searched for.
        if (value == Data)
            return true;

        if (value < Data)
        {
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        else
        {
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
								//	The base case is when the current node is a leaf node (no children), 
								// in which case the height is 1.
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}