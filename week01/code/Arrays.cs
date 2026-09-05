public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create a new array that has the same size as the length provided.
        // 2. Use a loop to go through each position in the new array.
        // 3. For each position, multiply the given number by the position number.
        //    Since array indexes start at 0, add 1 to the index when calculating
        //    the multiple.
        // 4. Store each calculated multiple in the corresponding position in the array.
        // 5. After the loop is finished, return the completed array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Calculate the index where the list should be divided.
        //    The last 'amount' items will be moved to the beginning.
        // 2. Use GetRange to create a list containing the last 'amount' items.
        // 3. Use GetRange to create a list containing the items before those last items.
        // 4. Clear the original data list.
        // 5. Add the last section to the original list first.
        // 6. Add the beginning section to the original list after it.
        // 7. The original list is now rotated to the right by the requested amount.

        int splitIndex = data.Count - amount;

        List<int> endPart = data.GetRange(splitIndex, amount);
        List<int> beginningPart = data.GetRange(0, splitIndex);

        data.Clear();

        data.AddRange(endPart);
        data.AddRange(beginningPart);
    }
}