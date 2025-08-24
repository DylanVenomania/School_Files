using System;

namespace StackProgram
{
    class Program
    {
        const int MAXLEN = 1000;
        const float EMPTY_VALUE = -1; 

        public class Stack
        {
            private float[] M;
            private int top;   

            public Stack()
            {
                M = new float[MAXLEN];
                top = 0;
            }

            public bool IsEmpty()
            {
                return top == 0;
            }

            public bool IsFull()
            {
                return top >= MAXLEN;
            }

            public void Push(float value)
            {
                if (!IsFull())
                {
                    M[top] = value;
                    top++;
                }
                else
                {
                    Console.WriteLine("Khong them them vao ngan xep. Ngan xep da day !");
                }
            }

            public float Pop()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Ngan xep rong! Khong the trich xuat phan tu.");
                    return EMPTY_VALUE;
                }
                else
                {
                    float value = M[top - 1];
                    top--;
                    return value;
                }
            }

            public float Top()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Ngan xep rong! Khong có phan tu o dinh");
                    return EMPTY_VALUE;
                }
                else
                {
                    return M[top - 1];
                }
            }

            public void Print()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Ngan xep rong!");
                }
                else
                {
                    Console.Write("Ngan xep hien tai : ");
                    for (int i = 0; i < top; i++)
                    {
                        Console.Write(M[i] + " ");
                    }
                    Console.WriteLine();
                }
            }

            public void Input()
            {
                Console.WriteLine("Nhap cac gia tri cho phan tu ( nhap 1 ki tu chu bat ki de thoat ) :");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (float.TryParse(input, out float value))
                    {
                        Push(value);
                    }
                    else
                    {
                        break; 
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Stack lst = new Stack();
            lst.Input();
            lst.Print();

            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Them mot phan tu vao ngan xep");
            Console.WriteLine("2. Trich va huy phan tu o dinh ngan xep");
            Console.WriteLine("3. Lay thong tin phan tu o dinh ngan xep");
            Console.WriteLine("4. Kiem tra ngan xep rong");
            Console.WriteLine("5. Kiem tra ngan xep day");

            while (true)
            {
                Console.Write("\nLua chon ( nhap ngoai lua chon de thoat ) : ");
                if (!int.TryParse(Console.ReadLine(), out int choose) || choose <= 0 || choose > 5)
                {
                    break; 
                }

                switch (choose)
                {
                    case 1:
                        Console.Write("Nhap gia tri muon them vao: ");
                        if (float.TryParse(Console.ReadLine(), out float value))
                        {
                            lst.Push(value);
                            lst.Print();
                        }
                        else
                        {
                            Console.WriteLine("Gia tri khong hop le.");
                        }
                        break;

                    case 2:
                        float poppedValue = lst.Pop();
                        if (poppedValue != EMPTY_VALUE)
                        {
                            Console.WriteLine($"Phan tu o dinh bi xoa: {poppedValue}");
                            lst.Print();
                        }
                        break;

                    case 3:
                        float topValue = lst.Top();
                        if (topValue != EMPTY_VALUE)
                        {
                            Console.WriteLine($"Thong tin phan tu o dinh: {topValue}");
                            lst.Print();
                        }
                        break;

                    case 4:
                        Console.WriteLine(lst.IsEmpty() ? "Ngan xep rong!" : "Ngan xep khong rong!");
                        break;

                    case 5:
                        Console.WriteLine(lst.IsFull() ? "Ngan xep day!" : "Ngan xep chua day!");
                        break;

                    default:
                        Console.WriteLine("Lua chon chua hop le.");
                        break;
                }
            }

            Console.WriteLine("Chuong trinh ket thuc.");
        }
    }
}