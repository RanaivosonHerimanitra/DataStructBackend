# DataStructBackend

Data Structure made easy, inspired by the book of Robert Lafore "data structures and algorithms in java".
Using C# as backend, and angular as frontend, I try to illustrate algorithms like the author did.

## In progress

* Linear search: loop until a match is found. In worst case scenario, could be the last item in the array so complexity is `O(N)`.

* Binary search: applicable to an ordered array, `O(logN)` because at each iteration, search space length is divided by two, so number of step involved at finding a search key is proportional to logarithm of N.

* Bubble sort: consists of swapping values in an array until entire array is ordered.

* Stack: you are only allowed to access the last inserted item. If you remove this item, you can access the next to last item inserted.

* Queue: 02 operations insertion takes place at the rear (bottom) and removal at the front (top). A variant is deque where one can insert/remove both on the right and left sides.

* Priority queue: a variant of queue where items are ordered. The minimum key item is always at the top of the array.

* Linked Lists: insertion is N independent so O(1), because either one inserts at the beginning or at the end. find and deletion are `O(N)` because algorithm loops through list but still faster than array implementation of those methods.

### Ordered array:

 Pros: Fast search because one can use binary search. Ordered array is useful in an application where search are frequent.
 Cons: insertion (write) takes longer because all data items with higher key value must be moved up to make room.

## RoadMap:

* Binary Search
* Sorting Algorithms (bubble, selection, insertion)
* Stacks and queues
* Linked Lists
* Recursion
* MergeSort
* Tree structures
