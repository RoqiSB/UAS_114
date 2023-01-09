using System;
using System.Xml.Linq;

namespace UAS_114
{
    class node
    {
        public int NoMurid;
        public string Nama;
        public string Kelas;
        public node next;
        public node prev;
    }
    class DoubleLinkedList
    {
        node START;
        public DoubleLinkedList()
        {
            START = null;
        }
        public void addNode()
        {
            int Nim;
            string nm;
            string kls;
            Console.Write("\nMasukkan Nomor Induk Murid : ");
            Nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nama Murid :");
            nm = Console.ReadLine();
            Console.Write("\nMasukkan Kelas Murid :");
            kls = Console.ReadLine();
            node newNode = new node();
            newNode.NoMurid = Nim;
            newNode.Nama = nm;
            newNode.Kelas = kls;

            if (START == null || Nim <= START.NoMurid)
            {
                if ((START != null) && (Nim == START.NoMurid))
                {
                    Console.WriteLine("\nList empty ");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.prev = null;
                START = newNode;
                return;
            }
            //if the node is to be inserted at between two node
            node previous, current;
            for (current = previous = START;
                current != null && Nim >= current.NoMurid;
                previous = current, current = current.next)
            {
                if (Nim == current.NoMurid)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
            }
            newNode.next = current;
            newNode.prev = previous;

            //if the node is to be insarted at the end of the list
            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public bool search(int rollNo, ref node previous, ref node current)
        {
            for (previous = current = START; current != null &&
                rollNo != current.NoMurid; previous = current,
                current = current.next) { }
            return (current != null);
        }
        public bool dellNode(int rollno)
        {
            node previous, current;
            previous = current = null;
            if (search(rollno, ref previous, ref current) == false)
                return false;
            //the begining of data
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            // if the to be deleted is in between the list then the following lines of is executed

            previous.next = current.next;
            current.next.prev = previous;
            return true;

        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        public void ascending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of" + "roll number are:\n");
                node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.NoMurid + "" + currentNode.Nama + "\n");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all records of roll numbers");
                    Console.WriteLine("4. Search for a record in the list");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter your choice (1-5): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of the student" + "whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.dellNode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number " + rollNo + "deleted\n");
                            }
                            break;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                node prev, curr;
                                prev = curr = null;
                                Console.WriteLine("\nEnter the roll number of the student whose record you want to search: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.NoMurid);
                                    Console.WriteLine("\nName : " + curr.Nama);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the value entered.");
                }
            }
        }
    }
}




// 2. double linked list
// 3. data yang bisa ditambahkan dan dihapus hanya melalui 1 jalur terakhir
// 4. REAR , FRONT
// 5.a. level 4
// 5.b. preorder 50.48.30.20.15.25.32.31.35.70.65.67.66.69.90.98.94.99