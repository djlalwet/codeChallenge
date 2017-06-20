using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    class Program
    {
        public static Cell[,] spreadSheet;

        static void Main(string[] args)
        {
            int cols = 0;
            int rows = 0;

            Program.GetDimensions(out cols, out rows);

            spreadSheet = null;

            Program.GetCellValues(cols, rows);
            Program.PrintCellValues(cols, rows);
        }

        private static void PrintCellValues(int cols, int rows)
        {

            printColHeaders(cols);
            printRows(cols, rows);
        }

        private static void printRows(int cols, int rows)
        {

            for (int i = 0; i < rows; i++)
            {
                Console.Write(i + 1);
                for (int y = 0; y < cols; y++)
                {
                    Console.Write(" " + getValue(spreadSheet[y, i].content));
                }
                Console.WriteLine("");
            }
        }

        private static int getValue(string content)
        {
            content.Trim();
            int value = 0;
            int leftOperator = 0;
            int rightOperator = 0;
            if (Int32.TryParse(content, out value))
            {
                return value;
            }
            else if (content.IndexOf("+") > -1)
            {
                getOperators(content, "+", out leftOperator, out rightOperator);
                value = leftOperator + rightOperator;
            }
            else if (content.IndexOf("-") > -1)
            {
                getOperators(content, "-", out leftOperator, out rightOperator);
                value = leftOperator - rightOperator;
            }
            else if (content.IndexOf("*") > -1)
            {
                getOperators(content, "*", out leftOperator, out rightOperator);
                value = leftOperator * rightOperator;
            }
            else if (content.IndexOf("/") > -1)
            {
                getOperators(content, "/", out leftOperator, out rightOperator);
                value = leftOperator / rightOperator;
            }
            else if (content.IndexOf("%") > -1)
            {
                getOperators(content, "%", out leftOperator, out rightOperator);
                value = leftOperator % rightOperator;
            }
            else if(content.Length > 1)
            {
                int col = (int)content[0] - 97;
                int row = 0;
                Int32.TryParse(content.Substring(1,1), out row);
                return getValue(spreadSheet[col, row-1].content);
            }
            return value;
        }

        private static void getOperators(string content, string operand, out int leftOperator, out int rightOperator)
        {
            int opIndex = content.IndexOf(operand);
            leftOperator = getValue(content.Substring(0, opIndex));
            rightOperator = getValue(content.Substring(opIndex + 1, content.Length - opIndex - 1));
        }

        private static void printColHeaders(int cols)
        {
            Console.Write("  ");

            for (int i = 0; i < cols; i++)
            {
                Console.Write(Convert.ToChar(i + 97) + " ");
            }

            Console.WriteLine("");
        }

        private static void GetCellValues(int cols, int rows)
        {
            spreadSheet = new Cell[cols, rows];
            for (int i = 0; i < cols; i++)
            {
                for (int y = 0; y < rows; y++)
                {
                    Console.Write("{0}{1}= ", Convert.ToChar(i + 97), y+1);
                    string content = Console.ReadLine();
                    spreadSheet[i, y] = new Cell(i, y, content);
                }
            }
        }

        private static void GetDimensions(out int cols, out int rows)
        {
            string dimensions = Console.ReadLine();
            int opIndex = dimensions.IndexOf("*");
            cols = Int32.Parse(dimensions.Substring(0, opIndex));
            rows = Int32.Parse(dimensions.Substring(opIndex + 1, dimensions.Length - opIndex - 1));
        }

    }
}
