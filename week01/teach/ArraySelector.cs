public static class ArraySelector
{
	public static void Run()
	{
		var l1 = new[] { 1, 2, 3, 4, 5 };
		var l2 = new[] { 2, 4, 6, 8, 10 };
		var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };
		var intResult = ListSelector(l1, l2, select);
		Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
	}

 //	Selects elements from two input arrays based on the values in a select array
	private static int[] ListSelector(int[] list1, int[] list2, int[] select)
	{
	 // Select elements from either list1 or list2 based on the values in the select array
		var results = new List<int>();

  //	Initialize indices for both input lists
		int array1Index = 0;
		int array2Index = 0;

  //	Iterate through the select array to determine which list to select from
		for (int i = 0; i < select.Length; i++)
		{
		 //	Check the value in the select array to determine which list to select from
			if (select[i] == 1)
			{
			//	Add the element from list1 to the results and increment the index for list1
				results.Add(list1[array1Index]);
				array1Index++;
			}
			else
			{
			//	Add the element from list2 to the results and increment the index for list2
				results.Add(list2[array2Index]);
				array2Index++;
			}
		}
		//	Convert the results list to an array and return it
		return results.ToArray();
	}
}