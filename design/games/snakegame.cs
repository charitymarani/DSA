/*
Design a Snake game that is played on a device with screen size = width x height. Play the game online if you are not familiar with the game.

The snake is initially positioned at the top left corner (0,0) with length = 1 unit.

You are given a list of food's positions in row-column order. When a snake eats the food, its length and the game's score both increase by 1.

Each food appears one by one on the screen. For example, the second food will not appear until the first food was eaten by the snake.

When a food does appear on the screen, it is guaranteed that it will not appear on a block occupied by the snake.

*/

// Time: o(1)
// Space : o(N) for food list and o(W * H) for snake and hashset=> at most a big snake ocupies W*H cells => O(W *H + N)
using System;
using System.Collections.Generic;

public class SnakeGame
{

  /** Initialize your data structure here.
      @param width - screen width
      @param height - screen height 
      @param food - A list of food positions
      E.g food = [[1,1], [1,0]] means the first food is positioned at [1,1], the second is at [1,0]. */
  int mwidth, mheight, foodIndex;
  int[][] mfood;
  LinkedList<(int, int)> snake = new LinkedList<(int, int)>();
  Dictionary<string, int[]> movement = new Dictionary<string, int[]>()
    {
        {"L", new int[]{0, -1}},
        {"R", new int[]{0, 1}},
        {"U", new int[]{-1, 0}},
        {"D", new int[]{1, 0}}
    };
  HashSet<(int, int)> snake_set = new HashSet<(int, int)>();


  public SnakeGame(int width, int height, int[][] food)
  {
    mwidth = width;
    mheight = height;
    mfood = food;
    foodIndex = 0;
    snake.AddFirst((0, 0));
    snake_set.Add((0, 0));


  }


  /** Moves the snake.
      @param direction - 'U' = Up, 'L' = Left, 'R' = Right, 'D' = Down 
      @return The game's score after the move. Return -1 if game over. 
      Game over when snake crosses the screen boundary or bites its body. */
  public int Move(string direction)
  {
    var head = snake.First.Value;
    var newHead = (head.Item1 + movement[direction][0], head.Item2 + movement[direction][1]);
    // Boundary conditions.
    bool crosses_boundary1 = newHead.Item1 < 0 || newHead.Item1 >= mheight;
    bool crosses_boundary2 = newHead.Item2 < 0 || newHead.Item2 >= mwidth;
    // Checking if the snake bites itself.
    bool bites_itself = snake_set.Contains(newHead) && !(newHead.Item1 == snake.Last.Value.Item1 && newHead.Item2 == snake.Last.Value.Item2);
    // If any of the terminal conditions are satisfied, then we exit with rcode -1.
    if (crosses_boundary1 || crosses_boundary2 || bites_itself)
    {
      return -1;
    }
    var next_food_item = foodIndex < mfood.Length ? mfood[foodIndex] : null;
    // If there's an available food item and it is on the cell occupied by the snake after the move, eat it
    if (next_food_item != null && next_food_item[0] == newHead.Item1 && next_food_item[1] == newHead.Item2)
    {
      // eat food
      foodIndex++;

    }
    else
    {    // not eating food: delete tail                 
      var tail = snake.Last;
      snake.RemoveLast();
      snake_set.Remove(tail.Value);
    }
    //A new head always gets added
    snake.AddFirst(newHead);
    //Also add the head to the set
    snake_set.Add(newHead);

    return snake.Count - 1;


  }
  public static void Main(string[] args){

  }
}


