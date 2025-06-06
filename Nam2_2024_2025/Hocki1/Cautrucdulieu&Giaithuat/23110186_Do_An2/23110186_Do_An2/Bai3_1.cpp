/*Ton Hoang Cam 
23110186 */
#include <iostream>
#include <string>
#include <stdexcept>
using namespace std;

struct hanghoa{
	string name;
	int soluong; 
	
	void nhap()
	{
		cout << "Nhap ten hang hoa : ";
		cin.ignore();
		getline(cin, name);
		cout << "Nhap so luong : ";
		cin >> soluong;
	}
	
	void display() const
	{
		cout << "Ten hang hoa : " << name << "		|So luong :" << soluong << endl;
	}
	
};

#define element_type hanghoa

struct node{
	element_type data;
	node *next;
	node *prev;
};

node *createNode( const hanghoa &item)
{
	node *newnode = new node;
	newnode->data = item;
	newnode->next = NULL;
	newnode->prev = NULL;
	return newnode;
}

struct danhsach{
	node *head;
	node *tail;
	int size;
	
	void init()
	{
		head = NULL;
		tail = NULL;
		size = 0;
	}
	
	bool isEmpty() const
	{
		return size == 0;
	}
	
	void insertFirst(const element_type &item)
	{
		node *newnode = createNode( item );
		if (isEmpty())
			head = tail = newnode;
		else
		{
			newnode->next = head;
			head->prev = newnode;
			head = newnode;
		}
		size++;
	}
	
	void insertEnd(const element_type &item)
	{
		node *newnode = createNode( item );
		if (isEmpty())
			head = tail = newnode;
		else
		{
			tail->next = newnode;
			newnode->prev = tail;
			tail = newnode;
		}
		size++;
	}
	
	void deleteFirst()
	{
		if( isEmpty())
		{
			cout <<"Danh sach rong! \n";
			return;
		}
		node *temp = head;
		head = head->next;
		
		if (head )
			head->prev = NULL;
		else
			tail = NULL;
		
		delete temp;
		size--;
	}
	
	void deleteEnd()
	{
		if( isEmpty())
		{
			cout <<"Danh sach rong! \n";
			return;
		}
		else
		{
			node *temp = tail;
			tail = tail->prev;
			
			if(tail)
				tail->next = NULL;
			else
				head = NULL;
			
			delete temp;
			size--;
		}
	}
	
	node *find(const string &tenhang) const 
	{
		node *temp = head;
		while( temp )
		{
			if (temp->data.name == tenhang )
				return temp;
			
			temp = temp->next;
		}
		return NULL;
	}
	
	void display() const
	{
		if( isEmpty())
		{
			cout <<"Danh sach rong! \n";
			return;
		}
		node *temp = head;
		while(temp)
		{
			temp->data.display();
			temp = temp->next;
		}
	}
	
	void selectionSort()
	{
		if( isEmpty())
		{
			cout <<"Danh sach rong! \n";
			return;
		}
		for (node *i = head; i->next != NULL; i = i->next)
		{
			node *min = i;
			for (node *j = i->next; j; j = j->next)
				if( j->data.soluong < min->data.soluong)
					min = j;
			
			swap(i->data, min->data);
		}
	}
	
	void updateSoluong( const string &tenhang, int soluong_new )
	{
		node *foundNode = find(tenhang);
		if (foundNode ) 
		{
            foundNode->data.soluong = soluong_new;
            cout << "Da cap nhat thanh cong so luong cho hang hoa " << tenhang << endl;
        } 
		else 
            cout << "Khong tim thay hang hoa " << tenhang << " trong danh sach!\n";
	}
	
	int Tong_soluong() const 
	{
        int sum = 0;
        node* temp = head;
        while (temp) 
		{
            sum += temp->data.soluong;
            temp = temp->next;
        }
        return sum;
    }
    
    node* findMaxSoluong() const 
	{
	    if (isEmpty()) 
	    {
	        cout << "Danh sach rong!\n";
	        return NULL;
	    }
	
	    node* maxNode = head;
	    node* temp = head->next;
	
	    while (temp) 
	    {
	        if (temp->data.soluong > maxNode->data.soluong) 
	        {
	            maxNode = temp;
	        }
	        temp = temp->next;
	    }
	
	    return maxNode;
	}
    
    void nhapds() 
	{
        int n;
        cout << "Nhap so luong hang hoa: ";
        cin >> n;
        cout << "Nhap thong tin hang hoa:\n";
        for (int i = 0; i < n; ++i) 
		{
            hanghoa item;
            item.nhap();
            insertEnd(item);
        }
    }
    
};


void menu(danhsach &ds) 
{
    cout << "Menu:\n";
    cout << "1. Kiem tra danh sach rong\n";
    cout << "2. Chen 1 hang hoa vao dau danh sach\n";
    cout << "3. Chen 1 hang hoa vao cuoi danh sach\n";
    cout << "4. Huy 1 hang hoa dau danh sach\n";
    cout << "5. Huy 1 hang hoa cuoi danh sach\n";
    cout << "6. Tim 1 hang hoa theo ten\n";
    cout << "7. Liet ke danh sach\n";
    cout << "8. Sap xep danh sach (Selection Sort)\n";
    cout << "9. Cap nhat so luong cho hang hoa\n";
    cout << "10. Tinh tong so luong\n";
	cout << "11. Tim hang hoa co so luong lon nhat\n";
	
    int choice;
    cout << "Lua chon : ";
    cin >> choice;
    while( true)
    {
    	if (cin.fail() || choice <=0 || choice >11)
    	{
    		cout << "Lua chon khong hop le !";
    		cin.clear();
    		cin.ignore(1000, '\n');
    		continue;
		}
		else
			break;
	}
	
	
    while (true) 
	{
       
        switch (choice) 
		{
            case 1:
                cout << (ds.isEmpty() ? "Danh sach rong!\n" : "Danh sach khong rong!\n");
                break;
            case 2: 
			{
                hanghoa item;
                item.nhap();
                ds.insertFirst(item);
                break;
            }
            case 3: 
			{
                hanghoa item;
                item.nhap();
                ds.insertEnd(item);
                break;
            }
            case 4:
                ds.deleteFirst();
                break;
            case 5:
                ds.deleteEnd();
                break;
            case 6: 
			{
                string tenhang;
                cout << "Nhap ten hang hoa: ";
                cin.ignore();
                getline(cin, tenhang);
                
                node* result = ds.find(tenhang);
                
                if (result) 
					result->data.display();
                else 
					cout << "Khong tim thay hang hoa!\n";
                break;
            }
            case 7:
                ds.display();
                break;
            case 8:
                ds.selectionSort();
                cout << "Danh sach sau khi sap xep:\n";
                ds.display();
                break;
            case 9: 
			{
                string tenhang;
                int soluong_moi;
                cout << "Nhap ten hang hoa can cap nhat: ";
                cin.ignore();
                getline(cin, tenhang);
                
                cout << "Nhap so luong moi: ";
                cin >> soluong_moi;
                
                ds.updateSoluong(tenhang, soluong_moi);
                break;
            }
            case 10:
                cout << "Tong so luong: " << ds.Tong_soluong() << endl;
                break;
            
            case 11:
            {
            	node* maxNode = ds.findMaxSoluong();
				if (maxNode) 
				{
				    cout << "Hang hoa co so luong lon nhat:\n";
				    maxNode->data.display();
				}
				break;
			}
        }
        
        cout << "Lua chon (chon bat ki ki tu khac menu de thoat) : ";
    	cin >> choice;
    	if (cin.fail() || choice <=0 || choice >11)
    		break;
        
    }
}
	
int main()
{
	danhsach ds;
	ds.init();
	ds.nhapds();
	ds.display();
	
	menu(ds);
	
	return 0;
}
