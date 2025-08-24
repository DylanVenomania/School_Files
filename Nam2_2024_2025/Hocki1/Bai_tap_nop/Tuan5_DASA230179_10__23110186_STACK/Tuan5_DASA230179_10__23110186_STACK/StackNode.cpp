/*Ton Hoang Cam 
23110186 */
#include <iostream>
#include <limits>
using namespace std;
#define ElementType float

struct Node{
	ElementType info;
	Node *pnext;
};

struct STACK{
	Node *ptop;
	Node *ptail;
};

Node *CreateNode(ElementType value)
{
	Node *newnode = new Node;
	newnode->info = value;
	newnode->pnext = NULL;
	return newnode;
}


void InitStack(STACK& s) 
{
    s.ptop = NULL;
    s.ptail = NULL;
}

int IsEmptyStack(STACK s)
{
	return s.ptop == NULL;
}

void Push(STACK &s, Node *newnode)
{
	if(newnode == NULL)
		return;
	newnode->pnext = s.ptop;
	s.ptop = newnode;
}

void input(STACK &s)
{
	cout << "Nhap cac gia tri cho ngan xep( Nhap ki tu chu de ket thuc nhap ): ";
	while(true)
	{
		ElementType value;
		cin >> value;
		if(cin.fail() )
		{
			cin.clear();
			cin.ignore( numeric_limits<streamsize>::max(), '\n');
			break;
		}	 
		Node *newnode = CreateNode(value);
		Push(s, newnode);
	}
}

void print(STACK s)
{
	for(Node* i = s.ptop; i != NULL; i = i->pnext)
	{
		cout << i->info << "   ";
	}
}

Node* Pop(STACK &s)
{
	if( IsEmptyStack(s) )
		return NULL;
	Node *temp = s.ptop;
	s.ptop = s.ptop->pnext;
	return temp;
}

Node *Top(STACK s)
{
	return s.ptop;
}


int main()
{
	STACK lst;
	InitStack(lst);
	input(lst);
	print(lst);
	
	cout << "Menu : \n";
	cout << "1. Them mot phan tu vao ngan xep\n";
	cout << "2. Trich va huy phan o dinh ngan xep\n";
	cout << "3. Lay thong tin phan tu o dinh ngan xep\n";
	cout << "4. Kiem tra ngan xep rong\n";
	
	int choose;
	while( true)
	{
		cout << "Nhap lua chon:";
		cin >> choose;
		if(choose <= 0 || choose > 5)
			break;
		switch(choose)
		{
			case 1:
			{
				ElementType value;
				cout <<"Nhap gia tri muon them vao ngan xep :";
				cin >> value;
				Node* newnode = CreateNode(value);
				Push(lst, newnode);
				cout << "Stack hien tai : ";
				print(lst);
				break;
			}
			case 2:
			{
				Node* temp = Pop(lst);
				if(temp)
				{
					cout << "Phan tu bi xoa : " << temp->info << endl;
					cout << "Stack hien tai : ";
					print(lst);
					cout << endl;
				}
				else
					cout << "Stack rong, khong trich va huy phan tu dich duoc !\n";
				break;
			}
			case 3:
			{
				if(Top(lst))
				{
					cout << "Thong tin phan tu dinh stack : " << Top(lst)->info << endl;
				}
				else
					cout << "Stack rong, khong lay duoc thong tin phan tu dinh!\n";
				break;
			}
			case 4: 
			{
				if(IsEmptyStack(lst))
				{
					cout << "Stack rong ! \n";
				}
				else
					cout << "Stack khong rong! \n";
				break;
			}
		}
	}
	
	
	
	return 0;
}
