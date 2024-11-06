using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithFiles_Battleship
{
    public class Boards
    {
        public char[,] solutionsBoard = { { 'o', 'o', 'o', 'o', 'x', 'x', 'o', 'o', 'o', 'o' },
                                          { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' },
                                          { 'x', 'o', 'o', 'o', 'o', 'o', 'o', 'x', 'o', 'o' },
                                          { 'x', 'o', 'o', 'o', 'o', 'o', 'o', 'x', 'o', 'o' },
                                          { 'x', 'o', 'o', 'o', 'o', 'o', 'o', 'x', 'o', 'o' },
                                          { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' },
                                          { 'x', 'x', 'x', 'x', 'o', 'o', 'o', 'o', 'o', 'o' },
                                          { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' },
                                          { 'o', 'o', 'o', 'o', 'x', 'x', 'x', 'x', 'x', 'o' },
                                          { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' }};

        public char[,] playerBoard = {    { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' },
                                          { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' },
                                          { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' },
                                          { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' },
                                          { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' },
                                          { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' },
                                          { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' },
                                          { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' },
                                          { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' },
                                          { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' }};
        
    }
}
