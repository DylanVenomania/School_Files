/*Ton Hoang Cam 
23110186 */
#include <iostream>
#include <limits>
using namespace std;

#define ElementType float
#define MAXLEN 1000

struct STACK{
	ElementType M[MAXLEN];
	int top;
};

void InitStack( STACK &s)
{
	s.top = 0;
}

int IsEmptyStack(STACK s)
{
	return s.top == 0;
}

int IsFullStack(STACK s)
{
	return s.top >= MAXLEN;
}

void Push(STACK &s, ElementType value)
{
	if( !IsFullStack(s) )
	{
		s.M[s.top] = value;
		s.top++;
	}
	else
	{
		cout << "Khong the them vao STACK!\n";
		return;
	}
}

void input(STACK &s)
{
	cout << "Nhap cac gia tri phan tu (nhap mot ky tu chu cai bat ki de ket thuc nhap) :\n";
	while(true)
	{
		ElementType value;
		cin >> value;
		if( cin.fail() ) 
		{
			cin.clear();
			cin.ignore( numeric_limits<streamsize>::max(), '\n');
			break;
		}
		else
			Push(s, value);
	}
}


void print(STACK s)
{
	for (int i = 0; i < s.top; i++)
		cout << s.M[i] << "  ";
}

ElementType Pop(STACK &s)
{
	ElementType value;
	if( IsEmptyStack(s) )
		return -1;
	else
	{
		value = s.M[s.top-1];
		s.top--;
	}
	return value;
}

ElementType Top(STACK s)
{
	if( IsEmptyStack(s) )
		return -1;
	else
		return s.M[s.top - 1 ];
}

	

int main()
{
	STACK lst;
	InitStack(lst);
	input(lst);
	cout << "Stack hien tai : ";
	print(lst);
	cout << endl;
	
	cout << "Menu : \n";
	cout << "1. Them mot phan tu vao ngan xep\n";
	cout << "2. Trich va huy phan o dinh ngan xep\n";
	cout << "3. Lay thong tin phan tu o dinh ngan xep\n";
	cout << "4. Kiem tra ngan xep rong\n";
	cout << "5. Kiem tra ngan xep day\n";
	
	

	while(true)
	{
		int choose;
		cout << "\nNhap lua chon ( nhap ngoai lua chon de ket thuc ) ";
		cin >> choose;
		if(choose <=0 || choose > 5)
			break;
			
			
		switch(choose)
		{
			case 1:
				{
					ElementType value;
					cout << "Nhap vao gia tri muon them vao :";
					cin >> value;
					Push(lst,value);
					print(lst);
					break;
				}
			case 2:
				{
					ElementType giatri_pop = Pop(lst);
					if(giatri_pop == -1)
						cout << "Stack rong ! Khong the trich huy phan tu!\n";
					else
					{
						cout << "Phan tu o dinh bi xoa : "  << giatri_pop << endl;
						print(lst);
					}
					break;
				}
			case 3:
				{
					if( Top(lst) == -1)
					cout << "Stack rong ! Khong the lay thong tin phan tu o dinh!\n";
					else
					{
						cout << "Thong tin phan tu o dinh : " << Top(lst) << endl;
						print(lst);
					}
					break;
				}
			case 4:
				{
					if(IsEmptyStack(lst))
						cout << "Ngan xep rong!\n";
					else
						cout << "Ngan xep khong rong! \n";
					break;
				}
			case 5:
				{
					if(IsFullStack(lst))
						cout << "Ngan xep day!\n";
					else
						cout << "Ngan xep khong day! \n";
					break;
				}
		
		}
	}
	return 0;
}

