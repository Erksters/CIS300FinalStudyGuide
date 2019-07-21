using ConsoleApp1;
using FinalStudyGuideCIS300;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalstudyCis300
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Test #2
            Console.WriteLine("********* Begin Test 2 *********");
            string Name = "Erick";
            List<double> Scores = new List<double>() { 100, 80, 100, 100 };
            Dictionary<string, List<double>> StudentDict = new Dictionary<string, List<double>>();

            StudentDict.Add(Name, Scores);
            Console.WriteLine(CalculateFinalGrades(StudentDict)[Name]);

            //Test #4
            Console.WriteLine("********* Begin Test 4 *********");
            Console.WriteLine("Linked List test not created");
            
            //Test #5
            Console.WriteLine("********* Begin Test 5 *********");
            Console.WriteLine("UndirectedGraph test not created");

            //Test #6
            Console.WriteLine("********* Begin Test 6 *********");
            int[] myList = new int[5] { 2,1,3,2,5};
            Sort(myList);
            foreach(int num in myList)
            {
                Console.WriteLine(num);
            }
            



            Console.ReadKey();
        }

        //#1 
        //Given a HuffmanTreeNode and two plain text strings, finish the methods below to calculate whether or
        //not the encoding of first string (string a) is larger than the encoding of the second string (string b). You may
        //assume that the tree has at least one node.The recursive BuildTable method should populate the given
        //dictionary with the encoding of all characters contained in the tree.The Key of the dictionary should be a
        //character and the Value should be the binary encoding for that character. The GetEncoding method uses the
        //given dictionary and returns the encoded string of the plain text.The HuffmanTreeNode class can be found on
        //the last page.You may assume that the given tree contains all of the characters of the given text.

        public string GetEncoding(Dictionary<char, string> table, string plainText)
        {
            string temp = plainText;
            StringBuilder theEncoding = new StringBuilder();
            for (int i = 0; i < plainText.Length; i++)
            {
                string mydictVal;
                if(table.TryGetValue(plainText[i], out mydictVal))
                {
                    theEncoding.Append(mydictVal);
                }
                
            }
            return (theEncoding.ToString());
        }

        /// <summary>
        /// If string a.Length is less than string b.Length , then return true.
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool CheckLengths(HuffmanTreeNode tree, string a, string b) //
        {
            Dictionary<char, string> table = new Dictionary<char, string>();
            BuildTable(tree, new StringBuilder(), table);

            if(GetEncoding(table,a).Length < GetEncoding(table, b).Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Not returning anything. just add onto the dictionary as you go. 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="code"></param>
        /// <param name="table"></param>
        public void BuildTable(HuffmanTreeNode root, StringBuilder code, Dictionary<char, string> table)
        {
            if(root.leftChild != null) //Check if the node has children
            {

                BuildTable(root.LeftChild, code.Append('0'), table); //maybe create a temporary value for stringBuilder Code to combat globally udating "code" stringBuilder.
                BuildTable(root.RightChild, code.Append('1'), table);
                     
            }
            else //We're at a character
            {
                table.Add(root.Data, code);
            }
        }

            //#2
            //(40 pts) The method below takes a linked list of integers. The LinkedListCell class is defined on the last page.
            //You may assume that list initially refers to the beginning of a linked list containing at least one int. Additionally,
            //the last cell of the linked list Next property contains a pointer to the first cell of the list, causing the list to loop
            //on itself.Complete the method below to reverse the linked list.This should work for any linked list of size n > 0.
            //Your algorithm cannot move the Data property from one cell to another.
            public void Reverse(LinkedListCell<int> list)
        {
            List<LinkedListCell<int>> myList = new List<LinkedListCell<int>>();
            LinkedListCell<int> Result = new LinkedListCell<int>();
            LinkedListCell<int> first = list;
            while (first.Next != first)
            {
                myList.Add(first); //Add all the values except the last LinkedListCell to the list
            }
            myList.Add(first); //Add the last LinkedListCell to the list

            for (int i = myList.Count; i > 1; i--) //for every LinkedListCell in the list
            {
                Result = myList[i - 1]; //find the last one
                Result.Next = myList[i - 2]; //set its "Next" to the preceeding LinkedListCell
                myList[i - 1] = Result; //Return the new Linked List Cell to myList
            }
            Result = myList[0]; //find the first item from the list parameter
            Result.Next = myList[myList.Count - 1]; //set its ".Next" to the last LinkedListCell in the list

        }


        //#3 
        //(35 pts) Complete the recursive method below that returns the number of odd nodes(i.e.the data contained at
        //the node is odd) divided by the total number of nodes in the tree.This tree is a BinaryTreeNode that contains at
        //least one node.
        int FindOddRatio(BinaryTreeNode<int> root)
        {
            Tuple<int, int> Ratio = FindOddRatio(root);


        }

        Tuple<int, int> FindOddRatioR(BinaryTreeNode<int> root)
        {
            Tuple<int, int> Result = new Tuple<int, int>(0, 0);
            int Odd = 0;
            int Total = 0;

            if (root.LeftChild != null) //If LeftChild exists traverse it
            {
                Result = FindOddRatio(root.LeftChild);
            }
            else if (root.RightChild != null) //If RightChild exists traverse it
            {
                Result = FindOddRatio(root.RightChild);
            }

            if (root.Data % 2 == 1) //Check the data

                Odd = Result.Item1 + 1;


            Total = Result.Item2 + 1; //Always add one to total

            Result = new Tuple<int, int>(Odd, Total);
            return Result;

        }



        //#4 
        //(40 pts) Complete the method below to calculate the final grade of every given student. The given student data
        //is a dictionary where the Key is the student identifier and the Value is a list of student scores.You may assume
        //that all scores are out of 100 points and that the grading scale for final grades is based off of a normal
        //90 / 80 / 70 / 60 scale.

        public static Dictionary<string, char> CalculateFinalGrades(Dictionary<string, List<double>> givenDict)
        {
            Dictionary<string, char> Results = new Dictionary<string, char>();
            double Total = 0;
            int numGrades = 0;
            foreach (KeyValuePair<string, List<double>> student in givenDict)
            {
                foreach (double score in givenDict[student.Key])
                {
                    Total += score;
                    numGrades++;
                }
                double letterGrade = Total / numGrades;
                if (letterGrade >= 90)
                {
                    Results.Add(student.Key, 'A');
                }
                else if (letterGrade >= 80)
                {
                    Results.Add(student.Key, 'B');
                }
                else if (letterGrade >= 70)
                {
                    Results.Add(student.Key, 'C');
                }
                else if (letterGrade >= 60)
                {
                    Results.Add(student.Key, 'D');
                }
                else
                {
                    Results.Add(student.Key, 'F');
                }
                Total = 0;
                numGrades = 0;
            }
            return Results;
        }


        //#6
        //Complete the given methods below to sort the given array using selection sort.The array given should
        //be sorted in descending order(i.e.largest to smallest). You will need to complete both the Swap and the Sort
        //functions.No additional functions may be used.

        public static void Swap(int indexA, int indexB, int[] arr)
        {
            int temp = arr[indexA];
            arr[indexA] = arr[indexB];
            arr[indexB] = temp;
        }


        private static void Sort(int[] data)
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = i + 1; j < data.Length; j++)
                {
                    if (data[j] > data[i])
                    {
                        Swap(i, j, data);
                    }
                }
            }
        }

        //#5
        //Finish the method below to do a depth-first search on an undirected graph. Depth-first search is
        //different compared breadth-first search.Depth-first will traverse as far into the graph as it can first whereas
        //breadth-first will traverse in a shallow, wide pattern. The starting graph node (class is defined on the last page)
        //is given, as well as the value(Data property of the node) you are searching for. The method should return true if
        //the goal is found and false otherwise.You may assume that all nodes of the graph have the Visited property
        //initialized to false. Your method should be recursive.

        bool DepthFirstSearch(UndirectedGraphNode<int> start, int goal)
        {
            if(start.Data == goal)
            {
                return true;
            }
            else
            {
                foreach (UndirectedGraphNode<int> edge in start.Edges)
                {
                    return DepthFirstSearch(edge, goal);
                }
            }
            return false;
        }


        }//End Class
}//End NameSpace
