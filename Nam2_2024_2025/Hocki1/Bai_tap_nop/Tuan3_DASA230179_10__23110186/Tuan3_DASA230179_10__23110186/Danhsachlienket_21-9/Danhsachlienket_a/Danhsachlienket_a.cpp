#include <iostream>
using namespace std;
#define element_type int

struct Node {
	element_type info;
	Node* pnext;
};

struct List {
	Node* phead;
	Node* ptail;
};

List lst;

void initlist(List &lst)
{
	lst.phead = NULL;
	lst.ptail = NULL;
}

Node* create(element_type value)
{
	Node* temp = new Node;
	temp->info = value;
	temp->pnext = NULL;
	return temp;
}

int isEmpty(List lst)
{
	return lst.phead == NULL;
}

int isFull(List lst)
{
	Node* temp = new Node;
	if (temp == NULL)
		return 1;
	delete temp;
	return 0;
}

void addFirst(List& lst, element_type value)
{
	Node* temp = create(value);
	if (isEmpty(lst) == 1)
		lst.phead = lst.ptail = temp;
	else
	{
		temp->pnext = lst.phead;
		lst.phead = temp;
	}
}

void addLast(List& lst, element_type value)
{
	Node* temp = create(value);
	if (isEmpty(lst) == 1)
		lst.phead = lst.ptail = temp;
	else
	{
		lst.ptail->pnext = temp;
		lst.ptail = temp;
	}
}

void input(List& lst)
{
	int n; 
	cout << "Nhap so luong phan tu cho danh sach : ";
	cin >> n;

	element_type value;
	int i = 0;
	cout << "Nhap cac gia tri phan tu cho danh sach : ";
	while (i < n)
	{
		cin >> value;

		Node* temp = create(value);
		addLast(lst, value);
		i++;
	}
}

void removeFirst(List& lst)
{
	if (isEmpty(lst) == 1)
		return;
	else
	{
		Node* temp = lst.phead;
		lst.phead = lst.phead->pnext;
		if (lst.phead == NULL)
			lst.ptail = NULL;
		delete temp;
	}
}

void removeLast(List& lst)
{
	if (isEmpty(lst) == 1)
		return;
	else
	{
		if (lst.phead == lst.ptail)
		{
			delete lst.phead;
			lst.phead = lst.ptail = NULL;
		}
		else
		{
			Node* temp = lst.phead;
			while (temp->pnext != lst.ptail)
			{
				temp = temp->pnext;
			}
			delete lst.ptail;
			lst.ptail = temp;
			lst.ptail->pnext = NULL;
		}
		
	}
}

element_type searchNode(List lst, element_type value)
{
	Node* temp = lst.phead;
	element_type count = 0;
	while (temp != NULL)
	{
		if (temp->info == value)
			return count;
		count++;
		temp = temp->pnext;
	}
	return NULL;
}

void printList(List lst)
{
	Node* temp = lst.phead;
	while (temp != NULL)
	{
		cout << temp->info << "  ";
		temp = temp->pnext;
	}
	cout << endl;
}


void selection_sort(List lst)
{
	for (Node* i = lst.phead; i != NULL; i = i->pnext)
	{
		Node* min = i;
		for (Node* j = i->pnext; j != NULL; j = j->pnext)
		{
			if (j->info < min->info)
				min = j;
		}
		swap( min->info, i->info);
	}
}



void dosort(List& lst)
{
	if (isEmpty(lst) != 1)
	{
		selection_sort(lst);
		printList(lst);
	}
}

int main()
{
	input(lst);
	
	cout << "Menu : \n";
	cout << "1. Chen 1 phan tu vao dau danh sach\n";
	cout << "2. Chen 1 phan tu vao cuoi danh sach\n";
	cout << "3. Xoa 1 phan tu o dau danh sach\n";
	cout << "4. Xoa 1 phan tu o cuoi danh sach\n";
	cout << "5. Tim 1 phan tu trong danh sach\n";
	cout << "6. In danh sach\n";
	cout << "7. Kiem tra danh sach rong\n";
	cout << "8. Kiem tra danh sach day\n";
	cout << "9. Sap xep danh sach\n";
	int choose;
	cin >> choose;
	switch (choose)
	{
	case(1):
	{
		cout << "Nhap gia tri : ";
		element_type a;
		cin >> a;
		addFirst(lst, a);
		printList(lst);
		break;
	}
	case(2):
	{
		cout << "Nhap gia tri : ";
		element_type a;
		cin >> a;
		addLast(lst, a);
		printList(lst);
		break;
	}
	case(3):
	{
		removeFirst(lst);
		printList(lst);
		break;
	}
	case(4):
	{
		removeLast(lst);
		printList(lst);
		break;
	}
	case(5):
	{
		cout << "Nhap gia tri : ";
		element_type a;
		cin >> a;
		if (searchNode(lst, a) == NULL)
			cout << "Khong tim thay " << a << " trong danh sach !";
		else
			cout << a << " nam o vi tri " << searchNode(lst, a) << " trong danh sach!";
		break;
	}
	case(6):
		printList(lst);
		break;
	case(7):
		if (isEmpty(lst) == 1)
			cout << "Danh sach rong !";
		else
			cout << "Danh sach khong rong !";
		break;
	case(8):
		if (isFull(lst) == 1)
			cout << "Danh sach day !";
		else
			cout << "Danh sach khong day !";
		break;
	case(9):
	{
		dosort(lst);
	}
	}
	return 0;
}