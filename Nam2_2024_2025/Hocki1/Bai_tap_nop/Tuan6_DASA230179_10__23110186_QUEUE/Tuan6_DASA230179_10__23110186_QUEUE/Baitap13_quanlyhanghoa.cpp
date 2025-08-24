#include <iostream>
#include <string>
using namespace std;
#define element_type hanghoa

struct hanghoa{
	string name;
	int soluong;
	float giatien;
	
	void nhap()
	{
		cout <<"Ten hang hoa :";
		cin.ignore();
		getline(cin, name);
		cout <<"So luong hang hoa : ";
		cin >> soluong;
		cout << "Nhap gia tien : ";
		cin >> giatien;
	}
	
	void xuat()
	{
		cout <<"Ten hang hoa :" << name << endl;
		cout <<"So luong hang hoa : " << soluong << endl;
		cout << "Nhap gia tien : " << giatien << endl;
	}
};

struct Node{
	element_type info;
	Node *pnext;
};

struct queue{
	Node *pfront;
	Node *prear;
};

Node *create_hanghoa( element_type hanghoabatki)
{
	Node *temp = new Node;
	if(temp == NULL)
	{
		cout << "Khong hang doi qua tai!" << endl;
		return NULL;
	}
	temp->info = hanghoabatki;
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


void addEnd(queue &hangdoi, element_type hanghoabatki)
{
	Node *temp = create_hanghoa(hanghoabatki);
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
        cout << "Hang doi rong, khong co hang hoa de lay ra!" << endl;
        return NULL;
    }
    Node* temp = hangdoi.pfront; 
    hangdoi.pfront = hangdoi.pfront->pnext; 
    
    if (hangdoi.pfront == NULL) 
        hangdoi.prear = NULL;
    return temp;
}

void hienthi_next_hanghoa(queue hangdoi) 
{
    if ( isEmpty(hangdoi) ) 
	{
        cout << "Kho hang rong, khong co mat hang nao chuan bi xuat!" << endl;
        return;
    }
    cout << "Mat hang chuan bi xuat:\n";
    hangdoi.pfront->info.xuat();
}

void xuatkho(queue &hangdoi) 
{
    Node *item = popFirst(hangdoi);
    if (item != NULL) 
	{
        cout << "Xuat kho hang hoa, hang hoa do la :\n";
        item->info.xuat();
        delete item;
    }
}

void hienthi_new_hanghoa(queue hangdoi) 
{
    if (isEmpty(hangdoi) ) 
	{
        cout << "Kho hang rong, khong co mat hang nao!" << endl;
        return;
    }
    Node *hanghoa_current = hangdoi.pfront;
    while (hanghoa_current->pnext != NULL) 
        hanghoa_current = hanghoa_current->pnext; 
        
    cout << "Mat hang moi vua nhap:\n";
    hanghoa_current->info.xuat();
}

void findItem(queue hangdoi, string name) 
{
    Node *hanghoa_current = hangdoi.pfront;
    while (hanghoa_current != NULL) 
	{
        if (hanghoa_current->info.name == name) 
		{
            cout << "Thong tin mat hang:\n";
            hanghoa_current->info.xuat();
            return;
        }
        hanghoa_current = hanghoa_current->pnext;
    }
    cout << "Khong tim thay mat hang: " << name << endl;
}

void xuat_all_hanghoa(queue &hangdoi) 
{
	if (isEmpty(hangdoi) ) 
	{
        cout << "Kho hang rong, khong co mat hang nao !" << endl;
        return;
    }
    while (!isEmpty(hangdoi)) 
	{
        Node *item = popFirst(hangdoi);
        if (item != NULL) 
		{
            cout << "Xuat kho mat hang:\n";
            item->info.xuat();
            delete item; 
        }
    }
}


void input(queue &hangdoi) 
{
    int n;
    cout << "Nhap so luong hang hoa can them vao hang doi: ";
    cin >> n;
    while(n <= 0)
    {
    	cout << "So luong khong hop le, vui long nhap lai : ";
    	cin >> n;
	}

    for (int i = 0; i < n; i++) 
	{
        element_type hanghoa_new;
		hanghoa_new.nhap();        
        
        addEnd(hangdoi, hanghoa_new);
        
    }
}

void output(queue hangdoi) 
{
	if (isEmpty(hangdoi) ) 
	{
        cout << "Kho hang rong, khong co mat hang nao moi nhap!" << endl;
        return;
    }
    cout << "Hang doi: ";
    Node *hanghoa_current = hangdoi.pfront;
    while ( hanghoa_current != NULL) 
	{
        hanghoa_current->info.xuat();
        hanghoa_current = hanghoa_current->pnext;
    }
    cout << endl;
    delete hanghoa_current;
}

int main()
{
	queue hangdoi;
	init(hangdoi);
	
	cout << "Menu :\n";
    cout << "1. Nhap danh sach hang hoa vao kho\n";
    cout << "2. Xem thong tin tat ca hang hoa trong kho\n";
    cout << "3. Xem thong tin mat hang chuan bi xuat kho\n";
    cout << "4. Xuat kho mot mat hang\n";
    cout << "5. Xem thong tin mat hang moi vua nhap vao kho\n";
    cout << "6. Tim va xem thong tin cua mot mat hang\n";
    cout << "7. Xuat toan bo hang hoa trong kho\n";
    
    cout << "Lua chon: ";
    
    int choice;
    cin >> choice;
    while(choice > 7 || choice <=0 )
	{
		cout << "Lua chon khong hop le, vui long nhap lai : ";
		cin >> choice;
	}
	while ( !( choice > 7 || choice <=0) )
	{
        switch (choice) 
		{
            case 1:
                input(hangdoi);
                break;
            case 2:
                output(hangdoi);
                break;
            case 3:
                hienthi_next_hanghoa(hangdoi);
                break;
            case 4:
                xuatkho(hangdoi);
                break;
            case 5:
                hienthi_new_hanghoa(hangdoi);
                break;
            case 6: 
			{
                string name;
                cout << "Nhap ten mat hang can tim: ";
                cin.ignore(); 
                getline(cin, name);
                findItem(hangdoi, name);
                break;
            }
            case 7:
                xuat_all_hanghoa(hangdoi);
                break;
        }
        cout << "Lua chon(nhap cac so khac 1 -> 7 de ket thuc ) : ";
    	cin >> choice;
    } 
	
	return 0;
}
