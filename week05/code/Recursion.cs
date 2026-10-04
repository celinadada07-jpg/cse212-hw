using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case
        if (n <= 0)
            return 0;

        // Recursive case
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.
    /// </summary>
    public static void PermutationsChoose(
        List<string> results,
        string letters,
        int size,
        string word = "")
    {
        // Base case
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Try each letter
        for (int i = 0; i < letters.Length; i++)
        {
            char letter = letters[i];

            // Remove the selected letter from the remaining letters
            string remainingLetters =
                letters[..i] + letters[(i + 1)..];

            // Recursively build the word
            PermutationsChoose(
                results,
                remainingLetters,
                size,
                word + letter);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count the number of ways to climb a staircase when
    /// 1, 2, or 3 stairs can be climbed at a time.
    /// </summary>
    public static decimal CountWaysToClimb(
        int s,
        Dictionary<int, decimal>? remember = null)
    {
        // Create the dictionary the first time the function runs
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        // Base cases
        if (s == 0)
            return 0;

        if (s == 1)
            return 1;

        if (s == 2)
            return 2;

        if (s == 3)
            return 4;

        // Check if we already calculated this value
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Recursive calculation
        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        // Store the answer for later use
        remember[s] = ways;

        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.
    /// A '*' represents a wildcard that can be either 0 or 1.
    /// </summary>
    public static void WildcardBinary(
        string pattern,
        List<string> results)
    {
        // Find the first wildcard
        int wildcardIndex = pattern.IndexOf('*');

        // Base case: no more wildcards
        if (wildcardIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace wildcard with 0
        string zeroPattern =
            pattern[..wildcardIndex] +
            "0" +
            pattern[(wildcardIndex + 1)..];

        WildcardBinary(zeroPattern, results);

        // Replace wildcard with 1
        string onePattern =
            pattern[..wildcardIndex] +
            "1" +
            pattern[(wildcardIndex + 1)..];

        WildcardBinary(onePattern, results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize the path the first time the function runs
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Add the current position to the path
        currPath.Add((x, y));

        // If we reached the end, save this path
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());

            // Backtrack
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Move right
        if (maze.IsValidMove(currPath, x + 1, y))
        {
            SolveMaze(
                results,
                maze,
                x + 1,
                y,
                currPath);
        }

        // Move left
        if (maze.IsValidMove(currPath, x - 1, y))
        {
            SolveMaze(
                results,
                maze,
                x - 1,
                y,
                currPath);
        }

        // Move down
        if (maze.IsValidMove(currPath, x, y + 1))
        {
            SolveMaze(
                results,
                maze,
                x,
                y + 1,
                currPath);
        }

        // Move up
        if (maze.IsValidMove(currPath, x, y - 1))
        {
            SolveMaze(
                results,
                maze,
                x,
                y - 1,
                currPath);
        }

        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }
}