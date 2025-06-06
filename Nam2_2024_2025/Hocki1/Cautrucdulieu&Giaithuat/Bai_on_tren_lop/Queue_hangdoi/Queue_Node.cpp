#include <iostream>
#include <limits>
using namespace std;
#define element_type float

struct Node{
	element_type info;
	Node *pnext;
};

struct queue{
	Node *pfront;
	Node *prear;
};

Node *createNode( element_type value)
{
	Node *temp = new Node;
	if(temp == NULL)
	{
		cout << "Khong du bo nho de cap phat !" << endl;
		return NULL;
	}
	temp->info = value;
	temp->pnext = NULL;
	return temp;
}

void init(queue &hangdoi)
{
	hangdoi.pfront = NULL;
	hangdoi.prear = NULL;
}

bool isEmpty(queue hangdoi)
{
	return ( hangdoi.pfront == NULL && hangdoi.prear == NULL );
}

void addEnd(queue &hangdoi, element_type value)
{
	Node *temp = createNode(value);
	if(temp == NULL)
		return;
	if ( ( isEmpty(hangdoi) ) )
		hangdoi.pfront = hangdoi.prear = temp;
	else
	{
		hangdoi.prear->pnext = temp;
		hangdoi.prear = temp;
	}
	
}

Node *popFirst(queue &hangdoi)
{
	if ( isEmpty(hangdoi) ) 
	{ 
        cout << "Hang doi rong, khong co phan tu de lay ra!" << endl;
        return NULL;
    }
    Node* temp = hangdoi.pfront; 
    hangdoi.pfront = hangdoi.pfront->pnext; 
    if (hangdoi.pfront == NULL) 
        hangdoi.prear = NULL;
    return temp;
}

element_type getFront(queue hangdoi) 
{
    if (hangdoi.pfront != NULL)
        return hangdoi.pfront->info;
    else 
	{
        cout << "Hang doi rong!" << endl;
        return -1; 
    }
}

void input(queue &hangdoi) 
{
    int n;
    cout << "Nhap so luong phan tu can them vao hang doi: ";
    cin >> n;

    for (int i = 0; i < n; i++) 
	{
        element_type value;
        cout << "Nhap gia tri phan tu thu " << i + 1 << ": ";
        cin >> value;
        addEnd(hangdoi, value);
    }
}

void xuat(queue hangdoi) 
{
    cout << "Hang doi: ";
    Node *n = hangdoi.pfront;
    while ( n != NULL) 
	{
        cout << n->info << " ";
        n = n->pnext;
    }
    cout << endl;
    delete n;
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
