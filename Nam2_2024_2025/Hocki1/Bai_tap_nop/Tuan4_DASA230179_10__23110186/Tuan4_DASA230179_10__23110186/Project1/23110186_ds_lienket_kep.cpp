#include <iostream>
#include <string>
using namespace std;
#define element_type sinhvien


struct sinhvien {
	int id = 0 ;
	string name ;
	float avgScore =0.0 ;

	void input()
	{
		cout << "Nhap ten : ";
		getline(cin, name);
		if (name == "")
			return;
		cout << "Nhap mssv : ";
		cin >> id;
		cout << "Nhap diem trung binh : ";
		cin >> avgScore;
		cin.ignore();
	}

	void print()
	{
		cout << "Mssv : " << id << "\n";
		cout << "Ten: " << name << "\n";
		cout << "Diem trung binh = " << avgScore;
		cout << endl;
	}
};


struct Node {
	element_type data;
	Node* prev;
	Node* next;

	Node()
	{
		this->prev = NULL;
		this->next = NULL;
	}
};

struct List {
	Node* phead;
	Node* ptail;
};

List lst;

void initList(List& lst)
{
	lst.phead = NULL;
	lst.ptail = NULL;
}

Node* createNode(element_type value)
{
	Node* temp = new Node;
	temp->data = value;
	temp->prev = NULL;
	temp->next = NULL;
	return temp;
}

int isEmpty(List lst)
{
	return (lst.phead == NULL);
}


void addFirst(List& lst, element_type value)
{
	Node* temp = createNode(value);
	if (isEmpty(lst))
	{
		lst.phead = lst.ptail = temp;
	}
	else
	{
		temp->next = lst.phead;
		lst.phead->prev = temp;
		lst.phead = temp;
	}
}

void addLast(List& lst, element_type value)
{
	Node* temp = createNode(value);
	if (isEmpty(lst))
	{
		lst.phead = lst.ptail = temp;
	}
	else
	{
		temp->prev = lst.ptail;
		lst.ptail->next = temp;
		lst.ptail = temp;
	}
}

void removeFirst(List& lst)
{
	Node* temp = lst.phead;
	if (isEmpty(lst))
		return;
	else
	{
		if (lst.phead == lst.ptail)
		{
			lst.phead = lst.ptail = NULL;
		}
		else
		{
			lst.phead = lst.phead->next;
			lst.phead->prev = NULL;
		}
		delete temp;
	}
}

void removeLast(List& lst)
{
	Node* temp = lst.ptail;
	if (isEmpty(lst))
		return;
	else
	{
		if (lst.phead == lst.ptail)
		{
			lst.phead = lst.ptail = NULL;
		}
		else
		{
			lst.ptail = lst.ptail->prev;
			lst.ptail->next = NULL;
		}
		delete temp;
	}
}

bool compare_sv(element_type a, element_type b)
{
	if (a.id == b.id && a.name == b.name && a.avgScore == b.avgScore)
		return true;
	return false;
}

Node *searchNode(List lst, element_type value)
{
	Node* i = lst.phead;
	while (i != lst.ptail)
	{
		if (compare_sv(i->data, value))
			return i;
	}
	return NULL;
}

void inputList(List& lst)
{
	element_type value;
	value.input();
	while (value.name != "")
	{
		addFirst(lst, value);
		value.input();
	}
	return;
}

void printList(List lst)
{
	Node* i = lst.phead;
	while (i != NULL)
	{
		i->data.print();
		cout << endl;
		i = i->next;
	}
}

bool compare_id(element_type a, element_type b)
{
	return (a.id == b.id);
}

void remove(List& lst, int value)
{
	Node* temp = lst.phead; 
	while (temp != NULL)
	{
		if (temp->data.id == value)
		{
			if (temp == lst.phead && temp == lst.ptail)
			{
				lst.phead = lst.ptail = NULL; 
			}
			else if (temp == lst.phead) 
			{
				lst.phead = temp->next;
				lst.phead->prev = NULL;
			}
			else if (temp == lst.ptail) 
			{
				lst.ptail = temp->prev;
				lst.ptail->next = NULL;
			}
			else 
			{
				temp->prev->next = temp->next;
				temp->next->prev = temp->prev;
			}
			delete temp; 
			printList(lst);
			return;
		}
		temp = temp->next;
	}
	cout << "Sinh vien ban can tim khong co trong danh sach \n";
}

void svtren5(List lst)
{
	Node* i = lst.phead;
	while (i != NULL)
	{
		if(i->data.avgScore >= 5)
			i->data.print();
		cout << endl;
		i = i->next;
	}
}

void printXeploai(List lst, Node *i)
{
	if (i->data.avgScore <= 4.9)
	{
		i->data.print();
		cout << "Loai yeu \n";
	}
	if (i->data.avgScore >= 5 && i->data.avgScore < 6.5)
	{
		i->data.print();
		cout << "Loai trung binh\n";
	}
	if (i->data.avgScore >= 6.5 && i->data.avgScore < 7)
	{
		i->data.print();
		cout << "Loai trung binh kha\n";
	}
	if (i->data.avgScore >= 7 && i->data.avgScore < 8)
	{
		i->data.print();
		cout << "Loai kha\n";
	}
	if (i->data.avgScore >= 8 && i->data.avgScore < 9)
	{
		i->data.print();
		cout << "Loai gioi\n";
	}
	if (i->data.avgScore >= 9)
	{
		i->data.print();
		cout << "Loai xuat sac\n";
	}
}

void xeploai(List lst)
{
	Node* i = lst.phead;
	while (i != NULL)
	{
		printXeploai(lst, i);
		i = i->next;
	}
}

void interface()
{
	cout << "Menu :\n";
	cout << "1. Kiem tra danh sach rong :\n";
	cout << "2. Tim mot sinh vien trong danh sach\n";
	cout << "3. Xoa mot sinh vien co ma so x trong danh sach\n";
	cout << "4. Liet ke thong tin sinh vien co diem trung binh >= 5\n";
	cout << "5. Xep loai sinh vien va thong bao\n";
	cout << "6. Liet ke danh sach\n";
	
}
void sortList(List & lst) 
{
		if (isEmpty(lst) || lst.phead == lst.ptail) 
		{
			return; 
		}

		bool swapped;
		do 
		{
			swapped = false;
			Node* current = lst.phead;

			while (current->next != NULL) 
			{
				if (current->data.avgScore > current->next->data.avgScore) 
				{
					swap(current->data, current->next->data);
					swapped = true;
				}
				current = current->next;
			}
		} while (swapped);
}



int main()
{
	cout << "Nhap danh sach cac sinh vien (dung lai thi nhap ten rong ) :\n";
	inputList(lst);

	interface();
	int choose;
	cin >> choose;
	switch (choose)
	{
	case(1):
		if (isEmpty(lst))
			cout << "Danh sach rong\n";
		else
			cout << "Danh sach khong rong\n";
		break;
	case(2):
	{
		cout << "Nhap thong tin sinh vien muon tim trong danh sach : \n";
		element_type a;
		a.input();
		if (searchNode(lst, a) != NULL)
			cout << searchNode(lst, a);
		else
			cout << "Sinh vien ban can tim khong co trong danh sach \n";
		break;
	}
	case(3):
	{
		int mssv;
		cout << "Nhap vao mssv cua sinh vien muon xoa : ";
		cin >> mssv;
		(remove(lst, mssv));
		break;
	}
	case(4):
		svtren5(lst);
		break;
	case(5):
		xeploai(lst);
		break;

	case(6):
		printList(lst);
		break;
	}
	return 0;
}
