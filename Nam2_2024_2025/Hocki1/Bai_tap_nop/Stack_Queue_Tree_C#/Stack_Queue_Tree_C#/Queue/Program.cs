namespace QueueProgram
{
    class Program
    {
        public class Node
        {
            public float Info; // Thay thế element_type = float
            public Node Next;
        }

        public class Queue
        {
            public Node Front;
            public Node Rear;

            public Queue()
            {
                Front = null;
                Rear = null;
            }

            public bool IsEmpty()
            {
                return (Front == null && Rear == null);
            }

            public Node CreateNode(float value)
            {
                Node temp = new Node();
                temp.Info = value;
                temp.Next = null;
                return temp;
            }

            public void AddEnd(float value)
            {
                Node temp = CreateNode(value);
                if (temp == null)
                {
                    Console.WriteLine("Khong du bo nho de cap phat");
                    return;
                }

                if (IsEmpty())
                {
                    Front = Rear = temp;
                }
                else
                {
                    Rear.Next = temp;
                    Rear = temp;
                }
            }

            public Node PopFirst()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Hang doi rong, khong co phan tu de lay ra!");
                    return null;
                }

                Node temp = Front;
                Front = Front.Next;

                if (Front == null)
                    Rear = null;

                return temp;
            }

            public float GetFront()
            {
                if (Front != null)
                {
                    return Front.Info;
                }
                else
                {
                    Console.WriteLine("Hang doi rong!");
                    return -1;
                }
            }

            public void Input()
            {
                Console.Write("Nhap so luong phan tu can them vao hang doi: ");
                int n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Nhap gia tri phan tu thu {i + 1}: ");
                    float value = float.Parse(Console.ReadLine());
                    AddEnd(value);
                }
            }

            public void Print()
            {
                Console.Write("Hang doi: ");
                Node temp = Front;

                while (temp != null)
                {
                    Console.Write(temp.Info + " ");
                    temp = temp.Next;
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Queue Q = new Queue();
            Q.Input();
            Q.Print();

            Console.WriteLine("Menu");
            Console.WriteLine("1. Them phan tu vao cuoi hang doi");
            Console.WriteLine("2. Xoa phan tu dau tien cua hang doi");
            Console.WriteLine("3. Xem thong tin phan tu dau tien o hang doi");

            Console.Write("Lua chon: ");
            int choice = int.Parse(Console.ReadLine());

            while (choice > 3 || choice <= 0)
            {
                Console.Write("Lua chon khong hop le, vui long nhap lai: ");
                choice = int.Parse(Console.ReadLine());
            }

            while (choice > 0 && choice <= 3)
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Nhap gia tri phan tu muon them vao: ");
                        float value = float.Parse(Console.ReadLine());
                        Q.AddEnd(value);
                        Q.Print();
                        break;

                    case 2:
                        Q.PopFirst();
                        Q.Print();
                        break;

                    case 3:
                        Console.WriteLine("Phan tu dau hang doi la: " + Q.GetFront());
                        break;
                }

                Console.Write("Lua chon (nhap cac so khac 1 -> 3 de ket thuc): ");
                choice = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Chuong trinh ket thuc.");
        }
    }
}