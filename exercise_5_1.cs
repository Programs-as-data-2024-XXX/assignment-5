// THIS IS EXERCISE 5.1

using System;
class exercise_5_1
    {
        static void Main(string[] args)
        {
            int[] xs = { 3, 5, 12 };
            int[] ys = { 2, 3, 4, 7 };

            int[] merged_array = merge(xs, ys);

            Console.WriteLine("Merged Array: " + string.Join(", ", merged_array));
        }
    
        static int[] merge(int[] xs, int[] ys)
        {
            int total_length = xs.Length + ys.Length;
            int[] result = new int[total_length];
            int i = 0, j = 0, k = 0;

            while (xs.Length > i && j < ys.Length)
            {
                if (xs[i] < ys[j])
                {
                    result[k++] = xs[i++];
                }
                else
                {
                    result[k++] = ys[j++];
                }
            }

            while (i < xs.Length)
            {
                result[k++] = xs[i++];
            }

            while (j < ys.Length)
            {
                result[k++] = ys[j++];
            }
            

            return result;
        }
    }