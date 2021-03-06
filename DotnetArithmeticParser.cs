﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace DataStructBackend
{
    public class DotnetArithmeticParser : DotnetPriorityQueue<char>
    {
        private int top;
        public DotnetArithmeticParser(int size) : base(size)
        {
            maxSize = size;
            instanceArray = new char[maxSize];
            nItems = 0;
            top = -1;
        }

        //put item on top of the array
        public new void Push(char value)
        {
            instanceArray[++top] = value;
            nItems++;
        }

        //take item from top of the stack
        public new char Pop()
        {
            return instanceArray[top--];
        }

        public char Peek()
        {
            return instanceArray[top];
        }

        //return an item at index N
        public char PeekAtIndex(int n)
        {
            return instanceArray[n];
        }

        public void DisplayStack(string value)
        {
            for (int j = 0; j < Size(); j++) Console.WriteLine(PeekAtIndex(j));
            Console.ReadKey();
        }
    }
    
    public class EvaluationExpressionConverter {
        private DotnetArithmeticParser Parser;
        private string Input;
        private string Output;

        public EvaluationExpressionConverter(string input)
        {
            Input = input;
            int stackSize = Input.Length;
            Parser = new DotnetArithmeticParser(stackSize);
        }

        // do translation to postfix
        public string ToPostFix()
        {
            for(int j=0; j<Input.Length; j++)
            {
                char[] chArray = Input.ToCharArray();
                char charAtj = chArray[j];
                switch(charAtj)
                {
                    case '+':
                    case '-':
                        GetOperator(charAtj, 1);
                        break;

                    case '*':
                    case '/':
                        GetOperator(charAtj, 2);
                        break;

                    case '(':
                        Parser.Push(charAtj);
                        break;

                    case ')':
                        GetParent(charAtj);
                        break;

                    default:
                        Output += charAtj;
                        break;
                }

            }
            while (!Parser.IsEmpty())
            {
                Output += Parser.Pop();
            }
            return Output;
        }

        public void GetOperator(char currentChar, int precedence)
        {
            while(!Parser.IsEmpty())
            {
                char operationOnTop = Parser.Pop();
                if(operationOnTop =='(')
                {
                    Parser.Push(operationOnTop); //restore
                    break;
                } else
                {
                    int precedence2;
                    if (operationOnTop =='+' || operationOnTop =='-')
                    {
                        precedence2 = 1;
                    } else
                    {
                        precedence2 = 2;
                    }
                    if (precedence2<precedence)
                    {
                        Parser.Push(operationOnTop);
                        break;
                    } else
                    {
                        Output += operationOnTop;
                    }
                }
            }
            Parser.Push(currentChar);
        }

        public void GetParent(char currentChar)
        {
            while (!Parser.IsEmpty())
            {
                char charPoped = Parser.Pop();
                if (charPoped !='(')
                {
                    Output += charPoped;
                } else
                {
                    break;
                }
            }
        }
        
        // evaluate post fix expression
        public decimal EvaluatePostFix(string postfixString)
        {
            string character;
            int j;
            int num1, num2;
            decimal interAns = 0;
            string[] postfixStringArray = postfixString.Split("");
            var myqueue = new DotnetQueue<int>(postfixStringArray.Length);

            for (j=0; j< postfixStringArray.Length;j++)
            {
                character = postfixStringArray[j];
                if (Int32.Parse(character) >= 0 && Int32.Parse(character) <= 9)
                {
                    myqueue.Push(Int32.Parse(character));
                } else
                {
                    num2 = myqueue.Pop();
                    num1= myqueue.Pop();
                    switch(character)
                    {
                        case "+":
                            interAns = num1 + num2;
                            break;
                        case "-":
                            interAns = num1 - num2;
                            break;
                        case "*":
                            interAns = num1 * num2;
                            break;
                        case "/":
                            interAns = num1 / num2;
                            break;
                        default:
                            interAns = 0;
                            break;
                    }
                }
            }
            return interAns;
        }
    }
}
