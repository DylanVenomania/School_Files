/*Ton Hoang Cam
23110186 */
#include <iostream> 
#include <limits>
#include <string>
using namespace std;
#define element_type char

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

string reverse_string( string str) 
{
    Stack s;
    initStack(s);
    int size = str.length();

    for (int i = 0; i < size; i++) 
        push(s, createNode(str[i]));

    string reversedStr;
    while (!IsEmptyStack(s)) 
{
        Node* temp = pop(s);
        reversedStr += temp->info;  
        delete temp;              
    }

    return reversedStr;
}

int main()
{
	string str;
    cout << "Nhap chuoi: ";
    getline(cin, str);
    
    string reversedStr = reverse_string(str);
    cout << "Chuoi sau khi dao nguoc: " << reversedStr << endl;
	return 0;
}
