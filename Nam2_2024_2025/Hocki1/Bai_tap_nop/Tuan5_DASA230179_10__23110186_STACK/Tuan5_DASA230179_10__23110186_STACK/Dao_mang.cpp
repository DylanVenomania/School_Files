/*Ton Hoang Cam
23110186 */
#include <iostream> 
#include <limits>
using namespace std;
#define element_type float
#define MAX 1000

struct Node{
	element_type info;
	Node *pnext;
};

struct Stack{
	Node *ptop;
	Node *ptail;
};

Node *createNode(element_type value)
{
	Node *newnode = new Node;
	newnode->info = value;
	newnode->pnext = NULL;
	return newnode;
}


void initStack(Stack& s) 
{
    s.ptop = NULL;
    s.ptail = NULL;
}

int IsEmptyStack(Stack s)
{
	return s.ptop == NULL;
}

void push(Stack &s, Node *newnode)
{
	if(newnode == NULL)
		return;
	newnode->pnext = s.ptop;
	s.ptop = newnode;
}

Node* pop(Stack &s)
{
	if( IsEmptyStack(s) )
		return NULL;
	Node *temp = s.ptop;
	s.ptop = s.ptop->pnext;
	return temp;
}

void print_array(element_type arr[MAX], int size)
{
	for (int i = 0; i < size; i++) 
        cout << arr[i] << "  ";
    cout << endl;
}

void reverse_array(element_type arr[], int size) 
{
    Stack s;
    initStack(s);

    for (int i = 0; i < size; i++) 
        push(s, createNode( arr[i]) );
 
    for (int i = 0; i < size; i++) 
	{
        Node* temp = pop(s);
        if (temp != NULL) 
		{
            arr[i] = temp->info;  
            delete temp;         
        }
    }
}

int main()
{
	element_type arr[MAX];
	int size = 0;
	cout << "Nhap phan tu cho mang (nhap ki tu chu de ket thuc nhap) : ";
	
	while(true)
	{
		element_type value;
		cin >> value;
		if( cin.fail() )
		{
			cin.clear();
			cin.ignore( numeric_limits<streamsize>::max(), '\n');
			break;
		}
		else
		{
			arr[size] = value;
			size++;
		}
	}
    
    cout << "Mang truoc khi dao : ";
    	print_array(arr, size);
    
    reverse_array(arr, size);
    cout << "Mang sau khi dao nguoc: ";
    print_array(arr, size);

	return 0;
}

