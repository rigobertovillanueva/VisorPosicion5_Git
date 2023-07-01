using System;

internal class Program
{
    static void Main(string[] args)
    {
        int p = 2;
        int count = 1;
        int i = 1;
        bool aux = false;
        int count_prime = 0;

        while (aux == false)
        {
            p++;
            i = 2;
            count_prime = 0;


            while (i < p & count_prime == 0)
            {

                if (p % i != 0)
                {
                    count_prime++;
                }
                i++;
            }

            if (count_prime != 0) { 
            count++;
            Console.WriteLine("prime number nro " + count + " is " + p);
        }
        }
    }
}
  