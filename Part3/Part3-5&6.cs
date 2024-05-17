// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System.Globalization;
using System.Security.Cryptography;

public class Node{
    public Node(Node next, int num = 0){
        this.node = num;
        this.next = next; 
    }
    public int node;
    public Node next;
}

public class LinkedList{
    LinkedList(){
        head = null!;
        bottom = head;
        this.list =  new List<Node>();
    }
    private Node head;
    private Node bottom;
    private List<Node> list; //Ihn  made this in order to achieve O(1) in GetMaxNode() and GetMinNode() 

    public void append(int num){
        if(head == null){
            head = new Node(null!, num);
            bottom = head;
            list.Add(head);
            list = list.OrderBy(o=>o.node).ToList();
            return;
        }
        bottom.next = new Node(null!, num);
        bottom = bottom.next;
        list.Add(bottom);
        list = list.OrderBy(o=>o.node).ToList();
    }

    public void prepend(int num){
        head = new Node(head, num);
        list.Insert(0, head);
        list = list.OrderBy(o=>o.node).ToList();
    }

    public int Pop(){
        list.Remove(bottom);
        Node curr = head;
        int to_return = bottom.node;
        while(curr.next != bottom){
            curr = curr.next;
        }
        bottom = curr;
        bottom.next = null!;
        return to_return;
    }

    public int Unqueue(){
        list.Remove(head);
        int to_return = head.node;
        head = head.next;
        return to_return;
    }

    public IEnumerable<int> ToList()
    {
        /*List<int> list =  new List<int>();
        Node curr = head;
        while(curr.next != bottom){
            list.Add(curr.node);
            curr = curr.next;
        }*/ 
        //this one above would have been necessary if i wouldnt already made 
        //a list var which tracks the linked list an List<Node>

        //instead, the next code only converts List<Node> to List<int>
        List<int> num_list = new List<int>();;
        Node curr = head;
        while(curr != null){
            num_list.Add(curr.node);
            curr = curr.next;
        }
        return num_list;
    }

    public bool IsCircular(){
        Node curr = head;
        while(curr.next != null){
            if(curr.next == head){
                return true; 
            }
            curr = curr.next;
        }
        return false;
    } 

    public void Sort(){
        Node curr = head;
        IEnumerable<int> linked_nums = ToList();
        IEnumerable<int> sorted_nums = linked_nums.OrderBy(num => num);

        foreach(int num in sorted_nums){
            curr.node = num;
            curr = curr.next;
        }
        list = list.OrderBy(o=>o.node).ToList();  
    } 

    public Node GetMaxNode(){ 
        return list.ElementAt(list.Count - 1);
    }

    public Node GetMinNode(){
        return list.ElementAt(0);
    }

    public void Print_linked(){
        Node curr = head;
        while(curr != null){
            Console.WriteLine(curr.node);
            curr = curr.next;
        }
    }

    // static void Main(string[] args){
    //     LinkedList yo = new LinkedList(); 
    //     yo.append(5);
    //     yo.prepend(7);
    //     yo.append(10);
    //     yo.append(8);
    //     yo.prepend(11);
    //     //yo.Print_linked();
    //     yo.Sort();
    //     yo.Unqueue();
    //     Console.WriteLine("after sort: ");
    //     yo.Print_linked();
    //     IEnumerable<int> num_list = yo.ToList();
    //     Console.WriteLine(yo.IsCircular().ToString());
        
    //     Console.WriteLine(" " +  yo.head.next.node);  
    // }
}