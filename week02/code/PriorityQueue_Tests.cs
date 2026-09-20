using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
	[TestMethod]
	// Scenario: Add several values with different priorities, including two
	// values with the same highest priority.
	// Expected Result: The highest priority value is returned first. When
	// priorities are equal, the value added first is returned first.
	// Defect(s) Found: The last item was not checked when finding the highest
	// priority, and Dequeue did not remove the item from the queue.
	public void TestPriorityQueue_1()
	{
		var priorityQueue = new PriorityQueue();

		priorityQueue.Enqueue("A", 1);
		priorityQueue.Enqueue("B", 5);
		priorityQueue.Enqueue("C", 3);
		priorityQueue.Enqueue("D", 5);

		Assert.AreEqual("B", priorityQueue.Dequeue());
		Assert.AreEqual("D", priorityQueue.Dequeue());
		Assert.AreEqual("C", priorityQueue.Dequeue());
		Assert.AreEqual("A", priorityQueue.Dequeue());
	}

	[TestMethod]
	// Scenario: Attempt to dequeue from an empty priority queue.
	// Expected Result: InvalidOperationException with the message
	// "The queue is empty."
	// Defect(s) Found: None.
	public void TestPriorityQueue_2()
	{
		var priorityQueue = new PriorityQueue();

		var exception = Assert.ThrowsException<InvalidOperationException>(
						() => priorityQueue.Dequeue()
		);

		Assert.AreEqual("The queue is empty.", exception.Message);
	}

	// Add more test cases as needed below.
}