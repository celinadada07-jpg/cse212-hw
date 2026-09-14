using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
[TestMethod]
// Scenario: Add several items with different priorities to the queue.
// Expected Result: The item with the highest priority should be removed first.
// Defect(s) Found: The original Dequeue method did not check the last item in the queue.
public void TestPriorityQueue_1()
{
var priorityQueue = new PriorityQueue();

    priorityQueue.Enqueue("First", 1);
    priorityQueue.Enqueue("Second", 3);
    priorityQueue.Enqueue("Third", 2);

    Assert.AreEqual("Second", priorityQueue.Dequeue());
}

[TestMethod]
// Scenario: Add multiple items with the same highest priority.
// Expected Result: The item closest to the front should be removed first (FIFO).
// Defect(s) Found: The original Dequeue method used >=, which caused the later item with the same priority to be selected instead of the first item.
public void TestPriorityQueue_2()
{
    var priorityQueue = new PriorityQueue();

    priorityQueue.Enqueue("First", 5);
    priorityQueue.Enqueue("Second", 5);
    priorityQueue.Enqueue("Third", 1);

    Assert.AreEqual("First", priorityQueue.Dequeue());
    Assert.AreEqual("Second", priorityQueue.Dequeue());
}

[TestMethod]
// Scenario: Add one item to the queue and then dequeue it.
// Expected Result: The item should be removed from the queue and returned.
// Defect(s) Found: The original Dequeue method returned the value but did not remove the item from the queue.
public void TestPriorityQueue_3()
{
    var priorityQueue = new PriorityQueue();

    priorityQueue.Enqueue("First", 10);

    Assert.AreEqual("First", priorityQueue.Dequeue());

    Assert.ThrowsException<InvalidOperationException>(
        () => priorityQueue.Dequeue());
}

[TestMethod]
// Scenario: Attempt to dequeue from an empty queue.
// Expected Result: An InvalidOperationException should be thrown with the message "The queue is empty."
// Defect(s) Found: No defect found; the original code correctly throws the required exception and message.
public void TestPriorityQueue_4()
{
    var priorityQueue = new PriorityQueue();

    var exception = Assert.ThrowsException<InvalidOperationException>(
        () => priorityQueue.Dequeue());

    Assert.AreEqual("The queue is empty.", exception.Message);
}

// Add more test cases as needed below.


}
