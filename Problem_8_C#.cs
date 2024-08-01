/*
 Problem 8:
The four adjacent digits in the 1000-digit number that have the greatest product are 
9 * 9 * 8 * 9 = 5832.

------------
73167176531330624919225119674426574742355349194934
96983520312774506326239578318016984801869478851843
85861560789112949495459501737958331952853208805511
12540698747158523863050715693290963295227443043557
66896648950445244523161731856403098711121722383113
62229893423380308135336276614282806444486645238749
30358907296290491560440772390713810515859307960866
70172427121883998797908792274921901699720888093776
65727333001053367881220235421809751254540594752243
52584907711670556013604839586446706324415722155397
53697817977846174064955149290862569321978468622482
83972241375657056057490261407972968652414535100474
82166370484403199890008895243450658541227588666881
16427171479924442928230863465674813919123162824586
17866458359124566529476545682848912883142607690042
24219022671055626321111109370544217506941658960408
07198403850962455444362981230987879927244284909188
84580156166097919133875499200524063689912560717606
05886116467109405077541002256983155200055935729725
71636269561882670428252483600823257530420752963450
---------------

Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?

 */

namespace Problem_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
// paste the number in a file
            string wholeNumber = ReadStringOfFile("numberInProblem8.txt");

         // cut the number into numbers of 13 digits
            List<string> sequencesOf13s = SubTo13sList(wholeNumber);

// no need for 0 containing sequences since we are multiplying (num * 0 = 0)
            EliminateSequencesContaining0(ref sequencesOf13s);

//  multiplying and associating each product to its seqence
            Dictionary<string, ulong> sequencesAndProducts = new Dictionary<string, ulong>();
            foreach (string sequence in sequencesOf13s)
            {
                ulong product = MultipleDigitsOfSequence(sequence);
                sequencesAndProducts.Add(sequence, product);
            }
         
            // i had enough so i decided to use linq 
            ulong highestValue = sequencesAndProducts.MaxBy(entry => entry.Value).Value;
            Console.WriteLine(highestValue);

        }


        static ulong MultiplyDigitsOfSequence(string sequence)
        {
            ulong product = 1;
            for (int i = 0; i < sequence.Length; i++)
            {
                product = product * (ulong)char.GetNumericValue( sequence[i]);
            }
            return product;
        }
      
        static void EliminateSequencesContaining0(ref List<string> sequences)
        {
            foreach (string sequence in sequences.ToList())
            {
                if (SequenceHas0Digit(sequence))
                {
                    sequences.Remove(sequence);
                }
            }
        }
        static bool SequenceHas0Digit(string sequence)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == '0')
                {
                    return true;
                }
            }
            return false;
        }
        static List<string> SubTo13sList(string s)
        {
            List<string> sequencesOf13s = new List<string>();
            for (int i = 0; i < s.Length - 12; i++)
            {
                string sequenceof13s = s.Substring(i, 13);
                sequencesOf13s.Add(sequenceof13s);
            }
            return sequencesOf13s;
        }
        static string ReadStringOfFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            return sr.ReadToEnd();
        }
    }
}
