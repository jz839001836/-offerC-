using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter2
{
    class Question12
    {
        /* 面试题12：矩阵中的路径
         */
        public static bool Exist(char[][] board, string word)
        {
            if (board.Length == 0 || board == null || word == null)
                return false;
            char[] words = word.ToCharArray();
            for (int i = 0; i < board.Length; i++)
                for (int j = 0; j < board[i].Length; j++)
                    if (Dfs(board, words, i, j, 0))
                        return true;
            return false;
        }
        private static bool Dfs(char[][] board, char[] words, int i, int j, int k)
        {
            if (i < 0 || j < 0 || board[i][j] != words[k] || i >= board.Length || j >= board[i].Length)
                return false;
            if (k == words.Length - 1)
                return true;
            char temp = board[i][j];
            board[i][j] = '/';
            bool ret = Dfs(board, words, i + 1, j, k + 1) ||
                       Dfs(board, words, i - 1, j, k + 1) ||
                       Dfs(board, words, i, j - 1, k + 1) ||
                       Dfs(board, words, i, j + 1, k + 1);
            board[i][j] = temp;
            return ret;
        }
    }
}
