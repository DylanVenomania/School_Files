#include <iostream>
#include <vector>
#include <list>
using namespace std;

int tablesize;

struct Node {
	int key;
	Node* pnext;
};

struct linkedList {
	Node* phead;
	Node* ptail;
};

vector <linkedList> hashtable;

int hashFunction(int key)
{
	return key % tablesize;
}

Node* createNode(int value)
{
	Node* newNode = new Node;
	newNode->key = value;
	newNode->pnext = nullptr;
	return newNode;
}

void add_in_list(linkedList& list, int value)
{
	Node* newNode = createNode(value);
	if (list.phead == nullptr)
		list.phead = list.ptail = newNode;
	else
	{
		list.ptail->pnext = newNode;
		list.ptail = newNode;
	}
}

bool remove_from_list(linkedList& list, int value)
{
	Node* current = list.phead;
	Node* previous = nullptr;

	while (current != nullptr)
	{
		if (current->key == value)
		{
			if (previous == nullptr)
				list.phead = current->pnext;
			else
				previous->pnext = current->pnext;

			if (current == list.ptail)
				list.ptail = previous;

			delete current;
			return true;
		}
		previous = current;
		current = current->pnext;
	}
	return false;
}

bool search_in_list(const linkedList &list, int value)
{
	Node* current = list.phead;
	while (current != nullptr)
	{
		if (current->key == value)
			return true;
		current = current->pnext;
	}
	return false;
}

void addItem(vector <linkedList> &hashtable, int value)
{
	int index = hashFunction(value);
	add_in_list(hashtable[index], value);
}

bool removeItem(vector <linkedList> &hashtable, int value)
{
	int index = hashFunction (value);
	return remove_from_list(hashtable[index], value);
}

bool searchItem(const vector <linkedList> &hashtable, int value)
{
	int index = hashFunction(value);
	return search_in_list(hashtable[index], value);
}

void hienthi(const vector <linkedList> &hashtable)
{
	for (int i = 0; i < tablesize; i++)
	{
		cout << "Gia tri " << i << " : ";
		Node* current = hashtable[i].phead;
		while (current != nullptr)
		{
			cout << current->key << " --> ";
			current = current->pnext;
		}
		cout << "NULL\n";
	}
}

void input(vector <linkedList> &hashtable)
{
	int n;
	cout << "Nhap so luong phan tu muon them : ";
	cin >> n;

	for (int i = 0; i < n; i++) 
	{
		int value;
		cout << "Nhap gia tri thu " << i + 1 << ": ";
		cin >> value;
		addItem(hashtable, value);
	}
}

int main() 
{
	cout << "Nhap kich thuoc bang bam ( hash table ) : ";
	cin >> tablesize;

	hashtable.resize(tablesize);
	
	for (int i = 0; i < tablesize; i++) 
	{
		hashtable[i].phead = nullptr;
		hashtable[i].ptail = nullptr;
	}
	cout << "Menu :\n";
	cout << "1. Them phan tu vao bang bam\n";
	cout << "2. Xoa phan tu khoi bang bam\n";
	cout << "3. Tim kiem phan tu trong bang bam\n";
	cout << "4. Hien thi bang bam\n";
	cout << "5. Thoat\n";
	cout << "Lua chon : ";
	int choice;
	cin >> choice;

	
	do {
		

		switch (choice) 
		{
		case 1: 
		{ 
			int value;
			cout << "Nhap gia tri can them: ";
			cin >> value;
			addItem(hashtable, value);
			cout << "Da them gia tri " << value << " vao bang bam.\n";
			break;
		}
		case 2: 
		{ 
			int value;
			cout << "Nhap gia tri can xoa: ";
			cin >> value;
			if (removeItem(hashtable, value)) 
				cout << "Da xoa gia tri " << value << " khoi bang bam.\n";
			else 
				cout << "Khong tim thay gia tri " << value << " de xoa.\n";
			break;
		}
		case 3: 
		{ 
			int value;
			cout << "Nhap gia tri can tim: ";
			cin >> value;
			if ( searchItem(hashtable, value) ) 
				cout << "Tim thay gia tri " << value << " trong bang bam.\n";
			else 
				cout << "Khong tim thay gia tri " << value << " trong bang bam.\n";

			break;
		}
		case 4: 
		{ 
			cout << "Bang bam hien tai:\n";
			hienthi(hashtable);
			break;
		}
		case 5:  
			cout << "Thoat chuong trinh.\n";
			break;
		
		default:
			cout << "Lua chon khong hop le. Vui long chon lai.\n";
		}

	cout << "Lua chon : ";
	cin >> choice;
	} while (choice != 5);

	return 0;
}
