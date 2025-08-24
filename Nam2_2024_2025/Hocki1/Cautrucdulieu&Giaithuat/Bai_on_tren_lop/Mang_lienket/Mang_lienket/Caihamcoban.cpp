#include <iostream>
using namespace std;
#define element_type int
struct node {
	element_type info;
	node* pnext;
};

struct List {
	node* pHead;
	node* pTail;
};

void initList(List &list)
{
	list.pHead = NULL;
	list.pTail = NULL;
}

node* createNode(element_type x)
{
	node* temp = new node();
	temp->info = x;
	temp->pnext = NULL;
	return temp;
}

bool empty(List list)
{
	return list.pHead == NULL;
}

void add_first(List &list)
{
	element_type x;
	cout << "Nhap so nguyen x muon them vao dau danh sach :";
	cin >> x;
	node* temp = createNode(x);
	if (empty(list))
		list.pHead = list.pTail = temp;
	else
	{
		temp->pnext = list.pHead;
		list.pHead = temp;
	}
}

void add_end(List& list, element_type x)
{
	node* temp = createNode(x);
	if( empty(list) )
		list.pHead = list.pTail = temp;
	else
	{
		list.pTail->pnext = temp;
		list.pTail = temp;
	}
}

void input(List &list)
{
	int n, x;
	cout << "Nhap so luong phan tu cho danh sach :";
	cin >> n;
	if (n == 0)
		return;
	while (n < 0)
	{
		cout << "Khong hop le, vui long nhap lai !";
		cin >> n;
	}
	cout << "Nhap cac gia tri cho danh sach :\n";
	for (int i = 0; i < n; i++)
	{
		cin >> x;
		add_end(list,x);
	}
}

void remove_first(List &list)
{
	if (empty(list))
		return;
	if (list.pHead == list.pTail)
	{
		delete list.pHead;
		list.pHead = list.pTail = NULL;
		return;
	}
	else 
	{
		node* temp = list.pHead;
		list.pHead = list.pHead->pnext;
		delete temp;
		if (list.pHead == NULL)
			list.pTail = NULL;
	}
	
}

void remove_end(List &list)
{
	if (empty(list))
		return;
	if (list.pHead == list.pTail)
	{
		delete list.pHead;
		list.pHead = list.pTail = NULL;
		return;
	}

	node* pos = list.pHead;
	while (pos->pnext != list.pTail)
		pos = pos->pnext;

	delete list.pTail;
	list.pTail = pos;
	list.pTail->pnext = NULL;
}

int find_element(List list, element_type num)
{
	int count = 1;
	node* temp = list.pHead;
	while (temp->pnext != list.pTail)
	{
		if (temp->info == num)
			return count;
		temp = temp->pnext;
		count++;
	}
	return NULL;
}

void print(List list)
{
	node* temp = list.pHead;
	while (temp != NULL)
	{
		cout << temp->info << " ";
		temp = temp->pnext;
	}
	cout << endl;
}

void selectionsort(List &L) 
{
	for (node* temp = L.pHead; temp!= NULL; temp = temp->pnext) 
	{
		node* minNode = temp;
		for (node* i = temp->pnext; i != NULL; i = i->pnext) 
			if (i->info < minNode->info) 
				minNode = i;
		if (minNode != temp) 
		{
			swap(temp->info, minNode->info);
		}
	}
}

node* phanvung(node* head, node* tail) 
{
	element_type pivot = head->info;
	node* p = head;
	node* q = head->pnext;

	while (q != tail->pnext) 
	{
		if (q->info < pivot) 
		{
			p = p->pnext;
			swap(p->info, q->info);
		}
		q = q->pnext;
	}
	swap(head->info, p->info);
	return p;
}

void quicksort(node* head, node* tail) 
{
	if (head != tail && head != NULL && tail != NULL) 
	{
		node* p = phanvung(head, tail);
		if(p!=head)
			quicksort( head, p);
		if (p->pnext != NULL && p->pnext != tail)
			quicksort(p->pnext, tail);
	}
}


int main()
{
	List L;
	initList(L);
	input(L);
	cout << "Menu :";
	cout << "1. Kiem tra danh sach rong :\n";
	cout << "2. Chen mot phan tu vao dau danh sach: \n";
	cout << "3. Chen mot phan tu vao cuoi danh sach: \n";
	cout << "4. Huy mot phan tu o dau danh sach: \n";
	cout << "5. Huy mot phan tu o cuoi danh sach: \n";
	cout << "6. Tim mot phan tu trong danh sach: \n";
	cout << "7. Liet ke danh sach :\n";
	cout << "8. Sap xep danh sach :\n";

	int choose;
	cin >> choose;
	switch (choose)
	{
	case(1):
		if (empty(L))
			cout << "Danh sach rong!\n";
		else
			cout << "Danh sach khong rong!\n";
		break;
	case(2):
		add_first(L);
		print(L);
		break;
	case(3):
	{
		element_type x;
		cout << "Nhap vao so nguyen x muon them vao cuoi danh sach: ";
		cin >> x;

		add_end(L,x);
		print(L);
		break;
	}
	case(4):
		remove_first(L);
		print(L);
		break;
	case(5):
		remove_end(L);
		print(L);
		break;
	case(6):
	{
		element_type x;
		cout << "Nhap vao so nguyen x muon tim trong danh sach :";
		cin >> x;
		if (find_element(L, x) == NULL )
			cout << "Khong co " << x << " trong danh sach";
		else
			cout << x << " nam o vi tri thu " << find_element(L, x);
		break;
	}
	case(7):
		print(L);
		break;
	case(8):
		{
		int choose;
		cout << "1.Selection_sort\n";
		cout << "2.Quick_sort\n";
		cin >> choose;
		if (choose == 1)
			selectionsort(L);
		else
			quicksort(L.pHead, L.pTail);
		print(L);
		break;
		}
	}
	return 0;
}