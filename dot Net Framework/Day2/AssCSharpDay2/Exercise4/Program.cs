using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] matrix = new int[,] { { 1, 2, 3 }, { 5, 6, 7 }, { 9, 8, 7 } };
            int[,] matrix = new int[,] { { 1, 2, 3,4,5,6 }, { 20,21,22,23,24,7 }, { 19,32,33,34,25,8 },{18,31,36,35,26,9 }, { 17,30,29,28,27,10 } , { 16,15,14,13,12,11 } };
          
            Spiral s = new Spiral();
            s.Matrix = matrix;
            s.DisplayMatrix();
            s.WalkSpirally();
           

            int[,] matrix2 = new int[,] { { 1, 2, 3 }, { 5, 6, 7 }, { 9, 8, 7 } };
           
            
            Spiral s2 = new Spiral();
            s2.Matrix = matrix2;
            s2.DisplayMatrix();
            s2.WalkSpirally();
            Console.ReadLine();
        }
       
    }

    class Spiral
    {
        public int[,] Matrix;
        
        
       
        public void WalkSpirally()
        {
            int count = 0;
            int direction = 0;
            int loopCount = 0;
            int col = 0;
            int row = 0;
            int width = Matrix.GetLength(1);
            int height = Matrix.GetLength(0);
            while (count < Matrix.Length)
            {
                switch ((direction++) % 4)
                {
                    case 0://top side
                        for (; col < width - loopCount; ++col)
                        {
                            Console.Write(Matrix[row, col] + " ");
                            count++;
                        }
                        row++;
                        col--;
                        break;
                    case 1://right side

                        for (; row < height - loopCount; ++row)
                        {
                            Console.Write(Matrix[row, col] + " ");
                            count++;
                        }
                        col--;
                        row--;
                        break;
                    case 2://bottom side
                        for (; col > loopCount - 1; --col)
                        {
                            Console.Write(Matrix[row, col] + " ");
                            count++;
                        }
                        row--;
                        col++;
                        break;
                    case 3://left side

                        for (; row > loopCount; --row)
                        {
                            Console.Write(Matrix[row, col] + " ");
                            count++;
                        }

                        loopCount++;
                        col++;
                        row++;

                        break;

                }
            }
            Console.WriteLine();


        }

        public void DisplayMatrix()
        {
            for (int r = 0; r < Matrix.GetLength(1); r++)
            {
                for (int c = 0; c < Matrix.GetLength(0); c++)
                {
                    Console.Write("{0,6}", Matrix[r, c]);
                }
                Console.WriteLine();

            }
            Console.WriteLine();
        }
    }
}
