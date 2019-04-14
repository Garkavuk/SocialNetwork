# SocialNetwork
Hi! 


When performing this task, I encountered a number of problems.
The conditions of the problem could be reduced to a graph with edges of unit length.
The graph is not directed, without cycles, the values of the edges are positive. 
These conditions led me to the Dijkstra's algorithm. It is quite fast and easy to implement.
https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm

For parsing and saving data in the program, 
I first tried to use a matrix (two-dimensional bits array). 
Later the sparse matrix, but these options are not very suitable because of the large number of edges.


I decided to make all the decision on webApi with one endpoint.
Which should start automatically when you start the application in the visual studio.
After starting, the calculations take about 1 minute of time on my computer.
And in the browser it will be possible to see the result.
