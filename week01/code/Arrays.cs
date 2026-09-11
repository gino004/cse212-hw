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
		// TODO Problem 1 Start:

		// Create an array of doubles with exactly `length` positions to store the results.
		// Iterate through each position of the array using a `for` loop.
		// For each position, calculate the corresponding multiple of `number`, starting with number × 1.
		// Store the calculated multiple in the current position of the array.
		// Once all positions are filled, return the array. 

		var results = new double[length];
		for (int i = 0; i < length; i++)
		{
			results[i] = number * (i + 1);
		}
		return results; // replace this return statement with your own
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
		// TODO Problem 2 Start:

		// 1. Calculate the starting index of the last `amount` elements.
		// 2. Get the last `amount` elements and store them in a temporary list.
		// 3. Get the elements before those last elements and store them in another list.
		// 4. Clear the original `data` list.
		// 5. Add the last elements to `data` first.
		// 6. Add the remaining elements to `data`.

		int startIndex = data.Count - amount;
		var lastElements = data.GetRange(startIndex, amount);
		var remainingElements = data.GetRange(0, startIndex);
		data.Clear();
		data.AddRange(lastElements);
		data.AddRange(remainingElements);

	}
}
