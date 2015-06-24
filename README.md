Maze Solver
Written in C#, solves mazes.

Created by Jesse Morgutia. Version 1.1

I chose to implement a version of BFS with Nodes representing every pixel of the image. In order to help efficiency, I decided to read from the image and convert it into an 2D array prior to traversing and finding a solution.

In attempts to create a solution that would use less memory (a Dictionary of nodes along the path) I noticed a dramatic decrease in performance. 

Since the majority of pixels on the image are traversable towards a solution (blank), using 
a Dictionary would not make too significant a difference, memory wise when compared to an array.
I decided to use an array as the best solution for this problem.


