/*Ton Hoang Cam 
23110186 */
#include <iostream>
#include <string>
#include <stdexcept>
using namespace std;
#define max_line 1000
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

struct danhsach{
	
	hanghoa data[max_line];
	int size; 
	
	danhsach() : size(0) {}
	
	bool isEmpty() const 
	{
		return size == 0;
	}
	
	bool isFull() const
	{
		return size == max_line;
	}
	
	void insertFirst(const element_type &item)
	{
		if (isFull())
		{
			cout << "Danh sach da day !\n";
			return;
		}
		for (int i = size; i>0; i--)
		{
			data[i] = data[i-1];
		}
		data[0] = item;
		size++;
	}
	
	void insertEnd(const element_type &item)
	{
		if(isFull())
		{
			cout << "Danh sach da day !\n";
			return;
		}
		data[size] = item;
		size++;
	}
	
	void deleteFirst()
	{
		if(isEmpty())
		{
			cout << "Danh sach rong! \n";
			return;
		}
		for (int i = 0;i < size -1; i++)
			data[i] = data[i+1];
		
		size--;
	}
	
	void deleteEnd()
	{
		if(isEmpty())
		{
			cout << "Danh sach rong! \n";
			return;
		}
		size--;
	}
	
	int find(const string &tenhang) const
	{
		 if (isEmpty())
		 	return -1;
		 
		 for (int i = 0; i< size; i++)
		 {
		 	 if (data[i].name == tenhang)
		 	 	return i;
		 }
		 return -2;
	}
	
	void display() const
	{
		if(isEmpty())
		{
			cout << "Danh sach rong! \n";
			return;
		}
		for (int i = 0; i< size; i++)
		{
			data[i].display();
		}
	}
	
	void selectionSort()
	{
		for(int i = 0; i< size -1; i++)
		{
			int min_index = i;
			for (int j = i + 1; j < size; j++)
			{
				if ( data[j].soluong < data[min_index].soluong)
					min_index = j;		
			}
			swap( data[i], data[min_index]);
		}
	}
	
	void quickSort(int left, int right)
	{
		if (left >= right)
			return;
		int pivot = data[ (left + right) /2 ].soluong;
		
		int l = left;
		int r = right;
	
		while( l <= r)
		{
			while( data[l].soluong < pivot) 
				l++;
			while( data[r].soluong > pivot)
				r--;
			if( l <= r)
			{
				swap(data[l], data[r]);
				l++;
				r--;
			}
		}
		
		if( left < r) 
			quickSort( left,r );
		if (l < right)
			quickSort(l , right);
		
	}
	
	element_type findMax_soluong() const
	{
	 	if( isEmpty() )throw runtime_error ( "Danh sach rong !");
		
		element_type hanghoa_max = data[0];
		
		for (int i = 1; i< size; i++)
		{
			if( data[i].soluong > hanghoa_max.soluong)
				hanghoa_max = data[i];
		}
		return hanghoa_max;
	}
	
	void updateSoluong( const string &tenhang, int newsoluong)
	{
		bool found = false;
		for (int i = 0; i< size; i++)
			if( data[i].name == tenhang)
			{
				data[i].soluong = newsoluong;
				cout << "Da cap nhat thanh cong so luong cho hang hoa " << tenhang << endl;
				found = true;
				break;
			}
		if( !found )
			cout << "Khong tim thay hang hoa " << tenhang << " trong danh sach !\n" << endl;
	}
	
	int Tong_soluong()
	{
		if( isEmpty() )
	 	{
	 		cout << "Danh sach rong !\n";
	 		return 0;	
		}
		else
		{
			int sum = 0;
			for (int i = 0; i< size; i++)
	 			sum += data[i].soluong;
	 			
	 		return sum;
		}
	}
	
	void nhapds()
	{
		int n;
		cout << "Nhap so luong hang hoa : ";
		cin >> n;
		
		cout << "Nhap thong tin hang hoa : \n";
		for (int i =0 ;i < n; i++)
		{
			hanghoa item;
			
			item.nhap();
			insertEnd( item );
			
		}
	}
};

void menu( danhsach &ds)
{
	cout << "Menu : \n";
    cout << "1. Kiem tra danh sach rong\n";
    cout << "2. Kiem tra danh sach day\n";
    cout << "3. Chen 1 hang hoa vao dau danh sach\n";
    cout << "4. Chen 1 hang hoa vao cuoi danh sach\n";
    cout << "5. Huy 1 hang hoa dau danh sach\n";
    cout << "6. Huy 1 hang hoa cuoi danh sach\n";
    cout << "7. Tim 1 hang hoa trong danh sach theo ten\n";
    cout << "8. Liet ke danh sach\n";
    cout << "9. Sap xep danh sach\n";
    cout << "10. Tim hang hoa co so luong lon nhat\n";
    cout << "11. Cap nhat so luong cho hang hoa\n";
    cout << "12. Tinh tong so luong cua tat ca cac hang hoa\n";
    
    int choice;
    cout << "Lua chon : ";
    cin >> choice;
    while( true)
    {
    	if (cin.fail() || choice <=0 || choice >12)
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
    	switch( choice)
    	{
    		case 1:
    			{
    				if ( ds.isEmpty())
    					cout << "Danh sach rong !\n";
    				else
    					cout << "Danh sach khong rong!\n";
    				break;
				}
			case 2:
    			{
    				if ( ds.isFull() )
    					cout << "Danh sach day !\n";
    				else
    					cout << "Danh sach khong day!\n";
    				break;
				}
			case 3:
				{
					element_type temp_item;
					temp_item.nhap();
					ds.insertFirst(temp_item);
					break;
				}
			case 4:
				{
					element_type temp_item;
					temp_item.nhap();
					ds.insertEnd(temp_item);
					break;
				}
			case 5:
				{
					ds.deleteFirst();
					break;
				}
			case 6:
				{
					ds.deleteEnd();
					break;
				}
			case 7:
				{
					string item_name;
					cin.ignore();
					getline(cin, item_name);
					
					if (ds.find( item_name ) == -1)
						cout << "Danh sach rong! Khong the tim !\n";
					else if (ds.find( item_name ) == -2)
						cout << "Danh sach khong co hang hoa nay !\n";
					else 
					{
						cout << "Da tim thay hang hoa : \n";
						ds.data[ ds.find(item_name ) ].display();
					}
					break;
				}
			case 8:
				{
					ds.display();
					break;
				}
			case 9:
				{
					cout << "Menu : \n";
					cout << "1. Selection Sort\n";
					cout << "2. Quick Sort\n";
					
					int choice;
					cin >> choice;
					while( true)
				    {
				    	if (cin.fail() || choice <=0 || choice >2)
				    	{
				    		cout << "Lua chon khong hop le !";
				    		cin.clear();
				    		cin.ignore(1000, '\n');
				    		continue;
						}
						else
							break;
					}
					
					
					switch (choice)
					{
						case 1:
							{
								ds.selectionSort();
								cout << "Danh sach sau khi sap xep : \n" << endl;
								ds.display();
								break;
							}
						case 2:
							{
								ds.quickSort(0, ds.size -1);
								cout << "Danh sach sau khi sap xep : \n" << endl;
								ds.display();
								break;
							}
					}
					
					break;
				}
			case 10:
				{
					element_type max_item;
					max_item = ds.findMax_soluong();
					cout << "Hang hoa co so luong lon nhat la : " << max_item.name << endl;
					break;
				}
			case 11:
				{
					int soluong_moi;
					string item_name;
					cout << "Nhap vao ten hang hoa muon tim de cap nhat so luong : ";
					cin.ignore();
					getline(cin, item_name);
					
					cout << "Nhap vao so luong muon cap nhat : ";
					cin >> soluong_moi;
					
					ds.updateSoluong( item_name, soluong_moi);
					cout << endl;
					break;
				}
			case 12:
				{
					if (ds.Tong_soluong() == 0)
						break; 
					cout << "Tong so luong cua tat ca cac hang hoa la : " << ds.Tong_soluong() << endl;
				}
		}
		
		cout << "Lua chon (chon bat ki ki tu khac menu de thoat) : ";
    	cin >> choice;
    	if (cin.fail() || choice <=0 || choice >12)
    		break;
	}
}


int main()
{
	danhsach ds;
   	ds.nhapds();

    cout << "Danh sach hang hoa:" << endl;
    ds.display();
    
    menu(ds);
    
    
	return 0;
}
