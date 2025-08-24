#include <iostream>
using namespace std;
#define element_type float
#define MAX_size 1000

struct queue{
	element_type arr[MAX_size];
	int front;
	int rear;
};

void init(queue &hangdoi)
{
	hangdoi.front = -1;
	hangdoi.rear = -1;
}

bool isEmpty(queue hangdoi) 
{
    return (hangdoi.front == -1);
}

bool isFull(queue hangdoi) 
{
    return (hangdoi.rear == MAX_size - 1);
}

void addEnd(queue &hangdoi, element_type value) 
{
    if (isFull(hangdoi) )
	{
        cout << "Hang doi da day!" << endl;
        return;
    }
    if (isEmpty(hangdoi) ) 
        hangdoi.front = 0;
        
    hangdoi.rear++;
    hangdoi.arr[hangdoi.rear] = value; 
}

element_type popFirst(queue &hangdoi) 
{
    if (isEmpty(hangdoi) ) 
	{
        cout << "Hang doi rong, khong the lay ra!" << endl;
        return -1; 
    }
    
    element_type value = hangdoi.arr[hangdoi.front];
    if (hangdoi.front == hangdoi.rear) 
        hangdoi.front = hangdoi.rear = -1;
    else 
        hangdoi.front++;
    return value;
}

element_type getFront(queue hangdoi) 
{
    if (!isEmpty(hangdoi) ) 
        return hangdoi.arr[hangdoi.front]; 
	else 
	{
        cout << "Hang doi rong!" << endl;
        return -1; 
    }
}

void input(queue &hangdoi) 
{
    int n;
    cout << "Nhap so luong phan tu hang doi : ";
    cin >> n;

    for (int i = 0; i < n; i++) 
	{
        element_type value;
        cout << "Nhap gia tri thu " << i + 1 << ": ";
        cin >> value;
        addEnd(hangdoi, value);
    }
}

void xuat(queue hangdoi) 
{
    if (isEmpty(hangdoi)) 
	{
        cout << "Hang doi rong!" << endl;
        return;
    }
    cout << "Hang doi: ";
    for (int i = hangdoi.front; i <= hangdoi.rear; i++) 
	{
        cout << hangdoi.arr[i] << " ";
    }
    cout << endl;
}

int main()
{
	queue Q;
	init(Q);
	input(Q);
	xuat(Q);
	
	cout << "Menu : \n";
    cout << "1. Them phan tu vao cuoi hang doi\n";
    cout << "2. Xoa phan tu dau tien cua hang doi\n";
    cout << "3. Xem thong tin phan tu dau tien o hang doi\n";
    
    cout << "Lua chon : ";
	int choice;
	cin >> choice;
	while(choice > 3 || choice <=0 )
	{
		cout << "Lua chon khong hop le, vui long nhap lai : ";
		cin >> choice;
	}
	
	while (!(choice >3 || choice <= 0) )
	{
		switch (choice) 
		{
	            case 1:
	            {
	            	element_type value;
	                cout << "Nhap gia tri phan tu muon them vao : ";
	                cin >> value;
	                addEnd(Q, value);
	                xuat(Q);
	                break;
				}
	            case 2:
	                popFirst(Q); 
	                xuat(Q);
	                break;
	            case 3:
	                cout << "Phan tu dau hang doi la : " << getFront(Q) << endl; 
	                break;
	    }
	    cout << "Lua chon (nhap cac so khac 1 -> 3 de ket thuc ) : )";
	    cin >> choice;
    } 
	return 0;
}
