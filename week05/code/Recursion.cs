using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        //"The base case is when n is less than or equal to zero. The recursive 
								// case adds n squared to the result of the same function with n minus one".

        // TODO Start Problem 1
								// Base case: if n is less than or equal to 0, return 0
        if (n <= 0)
            return 0; 
        //	Recursive case: add n squared to the result of the function with n - 1 
        return n * n + SumSquaresRecursive(n - 1); 
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {

	       //"First, I check the base case.If the word has reached the desired size, 
								// I add it to the results. Otherwise, I loop through the available letters. For each letter, 
								// I remove that letter from the remaining letters, add it to the current word, and make a recursive call."

								// TODO Start Problem 2
								// Base case: if the size of the word is equal to the desired size, add it to results
								if (word.Length == size)
								{
												results.Add(word);
												return;
        }
								//	Recursive case: for each letter, add it to the word and call the function with the remaining letters
								for	(int i = 0; i < letters.Length; i++)
								{
												//	Call the function with the current letter added to the word and the remaining letters
										  PermutationsChoose(results, letters.Remove(i, 1), size, word + letters[i]);
								}
				}

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        //"First, we have the base cases for zero, one, two, and three stairs. 
								// Then, we initialize the dictionary if it is null. Before calculating a 
								// result, we check if we already have it in the dictionary. If we do, we return the stored result. 
								// Otherwise, we use recursion with s - 1, s - 2, and s - 3. 
								// Finally, we store the result in the dictionary so we don't have to calculate it again."
       

        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // TODO Start Problem 3
       	// Initialize the remember dictionary if it is null  
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        // Check if the result is already computed
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Solve using recursion
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {

        //“For the base case, I check if there are no more wildcards.
								// If there are no wildcards, I add the pattern to the results. 
								// Otherwise, I find the first wildcard and create two new patterns: 
								// one replacing it with zero and another replacing it with one. 
								// Then I recursively process both patterns.”
        

        // TODO Start Problem 4
        //	Base case: if there are no wildcards, add the pattern to results
        if (!pattern.Contains('*'))
        {
            results.Add(pattern);
            return;
        }

        // Find the first wildcard
        int index = pattern.IndexOf('*');

        // Replace the wildcard with '0' and '1' and recursively call the function
        string pattern0 = pattern.Substring(0, index) + '0' + pattern.Substring(index + 1);
        string pattern1 = pattern.Substring(0, index) + '1' + pattern.Substring(index + 1);

        WildcardBinary(pattern0, results);
        WildcardBinary(pattern1, results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        //	"The base case is when the current position is the end of the maze."

        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) 
								{
								 //	Initialize the current path list if it is null
          currPath = new List<ValueTuple<int, int>>();
        }
								  //	Add the current position to the current path
          currPath.Add((x, y));

        // TODO Start Problem 5
        // ADD CODE HERE
								//	Base case: if the current position is the end, add the current path to results
        if (maze.IsEnd(x, y))
        {   //	Add the current path to results as a string
            results.Add(currPath.AsString());
            return;
        }

								// Left
								if (maze.IsValidMove(currPath, x - 1, y))
								{
								 //	Create a new path list to avoid modifying the current path
									var newPath = new List<ValueTuple<int, int>>(currPath);
         SolveMaze(results, maze, x - 1, y, newPath);
								}

								// Right
								if (maze.IsValidMove(currPath, x + 1, y))
								{
								 //	Create a new path list to avoid modifying the current path
								 var newPath = new List<ValueTuple<int, int>>(currPath);
									SolveMaze(results, maze, x + 1, y, newPath);
								}

								// Up
								if (maze.IsValidMove(currPath, x, y - 1))
								{
								 //	Create a new path list to avoid modifying the current path
									var newPath = new List<ValueTuple<int, int>>(currPath);
									SolveMaze(results, maze, x, y - 1, newPath);
								}

								// Down
								if (maze.IsValidMove(currPath, x, y + 1))
								{
									//	Create a new path list to avoid modifying the current path
									var newPath = new List<ValueTuple<int, int>>(currPath);
									SolveMaze(results, maze, x, y + 1, newPath);
								}
	}
}