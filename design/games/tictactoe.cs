using System;
public class TicTacToe
{
  private int num;
  private int[] rows;
  private int[] cols;
  private int d1 = 0;
  private int d2 = 0;
  private int[,] board;
  /** Initialize your data structure here. */
  public TicTacToe(int n)
  {
    num = n;
    rows = new int[n];
    cols = new int[n];
    board = new int[n, n];
  }

  /** Player {player} makes a move at ({row}, {col}).
      @param row The row of the board.
      @param col The column of the board.
      @param player The player, can be either 1 or 2.
      @return The current winning condition, can be either:
              0: No one wins.
              1: Player 1 wins.
              2: Player 2 wins. */
  // Time o(n)
  // space o(n^2)
  public int MoveNaive(int row, int col, int player)
  {
    if (board[row, col] > 0) return 0;

    else
    {
      board[row, col] = player;
    }
    int rowCount = num;
    int colCount = num;
    int diagCount = num;
    int reverseDiagCount = num;
    int reverseDiagRowItr = num - 1;
    for (int i = 0; i < num; i++)
    {
      if (board[row, i] == player)
      {
        rowCount--;
      }

      if (board[i, col] == player)
      {
        colCount--;
      }

      if (board[i, i] == player)
      {
        diagCount--;
      }

      if (board[reverseDiagRowItr, i] == player)
      {
        reverseDiagCount--;
      }
      reverseDiagRowItr--;
    }

    return rowCount == 0 || colCount == 0 || diagCount == 0 || reverseDiagCount == 0 ? player : 0;



  }
  // Time o(1)
  // space: o(n)
  public int Move(int row, int col, int player)
  {
    int val = player == 1 ? 1 : -1;

    rows[row] += val;
    cols[col] += val;
    if (row == col)
    {
      d1 += val;
    }
    if (row == num - col - 1)
    {
      d2 += val;
    }
    if (Math.Abs(rows[row]) == num || Math.Abs(cols[col]) == num || Math.Abs(d1) == num || Math.Abs(d2) == num)
    {
      return player;
    }
    return 0;


  }

  static void Main(string[] args){

  }
}

