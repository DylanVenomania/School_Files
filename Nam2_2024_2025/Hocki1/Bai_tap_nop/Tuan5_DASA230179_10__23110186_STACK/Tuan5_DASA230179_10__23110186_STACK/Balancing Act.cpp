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

bool is_matching_pair(char open, char close) 
{
	return ( open == '('  &&  close  ==  ')' )  
			||  ( open == '{' && close == '}') 
			||  ( open == '[' && close == ']' );
}


bool is_valid_braket(string mathStr) 
{
    Stack s;
    initStack(s);

    for (int i = 0; i < mathStr.length(); i++) 
	{
        char current = mathStr[i];
        
        if ( current == '(' || current == '{' || current == '[' ) 
            push(s, createNode(current) );

        else if ( current == ')' || current == '}' || current == ']' ) 
		{
            if ( IsEmptyStack(s) ) 
                return false; 
            else 
			{
                Node* temp = pop(s); 
                if ( !is_matching_pair( temp->info, current)  ) 
                {
                    delete temp;
                    return false; 
                }
                delete temp;
            }
        }
    }

    return IsEmptyStack(s); 
}

int main()
{
    string mathStr;
    cout << "Nhap 1 bai toan de xet tinh hop le cua dau ngoac : ";
    getline(cin, mathStr);

    if ( is_valid_braket (mathStr) ) 
        cout << "Chuoi hop le: cac cap dau ngoac khop nhau!" << endl;
	else 
        cout << "Chuoi khong hop le: cac cap dau ngoac khong khop nhau!" << endl;

	return 0;
}
