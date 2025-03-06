using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _3Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = [-1, 0, 1, 2, -1, -4];


            ThreeSum(nums);

            Console.ReadLine();
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Ordenar(nums);
            List<IList<int>> list = new List<IList<int>>();

            for (int j = 0; j < nums.Length - 2; j++) 
            {
                if (j != 0 && nums[j] == nums[j - 1]) continue;

                int n = j + 1;
                int m = nums.Length - 1;

                while (n < m)
                {
                    int resultado = nums[j] + nums[n] + nums[m];
                   
                    if (resultado == 0)
                    {
                        List<int> r = [nums[j], nums[n], nums[m]];
                        list.Add(r.ToList());
                        n++;
                        m--;
                    }
                    if (resultado < 0)
                    {
                        n++;
                    }
                    if (resultado > 0)
                    {
                        m--;
                    }
                    if (n - 1 != -1 && nums[n] == nums[n - 1]) continue;
                    if (m + 1 != nums.Length && nums[m] == nums[m + 1]) continue;
                }

            }

            HashSet<IList<int>> set = new HashSet<IList<int>>(list, EqualityComparer<IList<int>>.Create((x, y) => x.SequenceEqual(y), obj => obj.Aggregate(0, (hash, item) => hash * 31 + item.GetHashCode())));
            
            return set.ToList();
        }

        public static void Ordenar(int[] nums)
        {
            if (nums.Length <= 1) return;

            int[] array = new int[nums.Length];

            int Mitad = nums.Length / 2;
            int[] bottomHalf = new int[Mitad];
            int Mitad2 = nums.Length - Mitad;
            int[] TopHalf = new int[Mitad2];

            Array.Copy(nums, Mitad, TopHalf, 0, Mitad2);
            Array.Copy(nums, 0, bottomHalf, 0, Mitad);

            Ordenar(bottomHalf);
            Ordenar(TopHalf);

            int n = 0;
            int m = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (n >= bottomHalf.Length)
                {
                    for (int j = m; j < TopHalf.Length; j++)
                    {
                        array[j + n] = TopHalf[j];
                    }
                    break;
                }
                if (m >= TopHalf.Length)
                {
                    for (int j = n; j < bottomHalf.Length; j++)
                    {
                        array[j + m] = bottomHalf[j];
                    }
                    break;
                }

                if (bottomHalf[n] < TopHalf[m])
                {
                    array[i] = bottomHalf[n];
                    n++;
                }
                else
                {
                    array[i] = TopHalf[m];
                    m++;
                }



            }

            Array.Copy(array, 0, nums, 0, nums.Length);


        }
    }
}

/*  public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Ordenar(nums);
            List<IList<int>> list = new List<IList<int>>();
            int j = 0;
            int n = j+1;
            int m = nums.Length - 1;

            while (j < nums.Length - 2) 
            { 
                
                if (m <= n)
                {
                    j++;
                    n = j + 1;
                    m = nums.Length - 1;
                }

                int resultado = nums[j] + nums[n] + nums[m];

                {
                    Console.Write(nums[j]);
                    Console.Write("+");
                    Console.Write(nums[n]);
                    Console.Write("+");
                    Console.Write(nums[m]);
                    Console.Write("=");
                    Console.Write(resultado);
                    Console.WriteLine();
                }
                if (resultado == 0)
                {
                    // la forma de actualizar la lista no da errores
                    List<int> r = [nums[j], nums[n], nums[m]];
                    list.Add(r);
                    n++;
                    m--;
                }
                if(resultado < 0)
                {
                    n++;
                }
                if(resultado > 0)
                {
                    m--;
                }
            }

           
            for (int i = 0; i < list.Count; i++)
            {
                for (int k = i + 1; k < list.Count; k++)
                {
                    if (list[i].SequenceEqual(list[k]))
                    {
                        list.Remove(list[k]);
                        k--;
                    }
                }
            }

            /*foreach(List<int> k in list)
            {
                Console.WriteLine();
                foreach (int i in k)
                {
                    Console.Write(i);
                }
            }

return list;
        }*/