using System;
using System.Collections;
using System.Collections.Generic;

namespace Valid_Sudoku
{
    class Program
    {


        //        Determine if a 9 x 9 Sudoku board is valid.Only the filled cells need to be validated according to the following rules:
        //        Each row must contain the digits 1-9 without repetition.
        //        Each column must contain the digits 1-9 without repetition.
        //        Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.


        //Input: board = 
        //[["5","3",".",".","7",".",".",".","."]
        //,["6",".",".","1","9","5",".",".","."]
        //,[".","9","8",".",".",".",".","6","."]
        //,["8",".",".",".","6",".",".",".","3"]
        //,["4",".",".","8",".","3",".",".","1"]
        //,["7",".",".",".","2",".",".",".","6"]
        //,[".","6",".",".",".",".","2","8","."]
        //,[".",".",".","4","1","9",".",".","5"]
        //,[".",".",".",".","8",".",".","7","9"]

        //Output: true

        //https://leetcode.com/problems/valid-sudoku/


        //  0 1 2[0]      int i = ii=0;  i < ii+3 ; i ++  while -->  { i++  h--  等等}    時間序 -->O(n^2) 一樣
        //  0 1 2[1]
        //  0 1 2[2]
        //-------------   ii += 3; return 自己
        //  0 1 2[3]      int i = ii  <= 3;
        //  0 1 2[4]
        //  0 1 2[5]
        //--------------   ii += 3; return 自己
        //  0 1 2[6]
        //  0 1 2[7]
        //  0 1 2[8]
        //--------------   ii += 3; return 答案

        static void Main(string[] args)
        {
            char[][] a = new char[9][]  {new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                                         new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                                         new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                                         new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                                         new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                                         new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                                         new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                                         new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                                         new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9'}};



            bool IsValidSudoku1(char[][] board)
            {
                for (int i = 0; i < 9; i++)
                {
                    HashSet<char> ckrow = new HashSet<char>();
                    HashSet<char> ckcol = new HashSet<char>();
                    for (int j = 0; j < 9; j++)
                    {
                        if (ckrow.Contains(board[i][j]))
                        {
                            return false;
                        }
                        else if (board[i][j] != '.')
                        {
                            ckrow.Add(board[i][j]);
                        }
                        if (ckcol.Contains(board[j][i]))
                        {
                            return false;
                        }
                        else if (board[j][i] != '.')
                        {
                            ckcol.Add(board[j][i]);
                        }
                    }
                }
                int row = -1;
                int col = -1;
                while (col != 8)
                {
                    HashSet<char> ckrow = new HashSet<char>();
                    for (int relrow = row + 1; relrow <= row + 3; relrow++)
                    {
                        for (int relcol = col + 1; relcol <= col + 3; relcol++)
                        {
                            if (ckrow.Contains(board[relrow][relcol]))
                            {
                                return false;
                            }
                            else if (board[relrow][relcol] != '.')
                            {
                                ckrow.Add(board[relrow][relcol]);
                            }
                        }
                    }
                    row += 3;
                    if (row == 8 && col != 8)
                    {
                        row = -1;
                        col += 3;
                    }
                    ckrow.Clear();
                }
                return true;
            }



            //----------------思穎

            bool IsValidSudoku2(char[][] board)
            {
                char[] temp1 = new char[9];
                char[] temp2 = new char[9];

                for (int y = 0; y < 9; y++)
                {
                    for (int x = 0; x < 9; x++)
                    {
                        temp1[x] = board[x][y];
                        temp2[x] = board[y][x];
                    }
                    if (!IsRepeat(temp1) || !IsRepeat(temp2))
                    {
                        return false;
                    }
                }
                for (int a = 0; a < 9; a += 3)
                {
                    for (int b = 0; b < 9; b += 3)
                    {
                        if (!IsRepeat(GetBlock(board, a, b)))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            bool IsRepeat(char[] arr)
            {
                List<char> nums = new List<char>();
                for (int i = 0; i < 9; i++)
                {
                    if (arr[i].Equals('.'))
                    {
                        continue;
                    }
                    if (!nums.Contains(arr[i]))
                    {
                        nums.Add(arr[i]);
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }

            char[] GetBlock(char[][] board, int a, int b)
            {
                int count = 0;
                char[] temp = new char[9];
                int x = a;
                while (x < a + 3)
                {
                    int y = b;
                    while (y < b + 3)
                    {
                        temp[count] = board[x][y];
                        count++;
                        y++;
                    }
                    x++;
                }
                return temp;
            }







            //----------------茗棟

            bool IsValidSudoku3(char[][] board)
            {
                for (int i = 0; i < 9; i++)
                {
                    List<char> digits = new List<char>();
                    digits.Add('1');
                    digits.Add('2');
                    digits.Add('3');
                    digits.Add('4');
                    digits.Add('5');
                    digits.Add('6');
                    digits.Add('7');
                    digits.Add('8');
                    digits.Add('9');
                    for (int x = 0; x < 9; x++)
                    {
                        if (board[i][x] == '.')
                        {
                            continue;
                        }
                        if (digits.Contains(board[i][x]))
                        {
                            digits.Remove(board[i][x]);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                for (int i = 0; i < 9; i++)
                {
                    List<char> digits = new List<char>();
                    digits.Add('1');
                    digits.Add('2');
                    digits.Add('3');
                    digits.Add('4');
                    digits.Add('5');
                    digits.Add('6');
                    digits.Add('7');
                    digits.Add('8');
                    digits.Add('9');
                    for (int x = 0; x < 9; x++)
                    {
                        if (board[x][i] == '.')
                        {
                            continue;
                        }
                        if (digits.Contains(board[x][i]))
                        {
                            digits.Remove(board[x][i]);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                List<char> newdigits = new List<char>();
                newdigits.Add('1');
                newdigits.Add('2');
                newdigits.Add('3');
                newdigits.Add('4');
                newdigits.Add('5');
                newdigits.Add('6');
                newdigits.Add('7');
                newdigits.Add('8');
                newdigits.Add('9');
                int ii = 0;
                int xx = 0;

                for (int i = ii; i < ii + 3; i++)
                {
                    for (int x = xx; x < xx + 3; x++)
                    {
                        if (board[i][x] == '.')
                        {
                            continue;
                        }
                        if (newdigits.Contains(board[i][x]))
                        {
                            newdigits.Remove(board[i][x]);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (i == 2 || i == 5 || i == 8)
                    {
                        if (i == 8)
                        {
                            xx += 3;
                            ii = 0;
                            i = -1;
                        }
                        ii += 3;
                        newdigits.Clear();
                        newdigits.Add('1');
                        newdigits.Add('2');
                        newdigits.Add('3');
                        newdigits.Add('4');
                        newdigits.Add('5');
                        newdigits.Add('6');
                        newdigits.Add('7');
                        newdigits.Add('8');
                        newdigits.Add('9');
                    }
                    if (xx == 9)
                        break;
                }
                return true;
            }
        }
    }
}
