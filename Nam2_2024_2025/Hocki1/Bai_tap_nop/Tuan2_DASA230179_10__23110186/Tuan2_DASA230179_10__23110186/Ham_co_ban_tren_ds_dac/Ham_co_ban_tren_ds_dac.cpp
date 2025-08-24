#include <iostream>
using namespace std;
#define Maxlen 100
#define element_type int

struct List {
	element_type ds[Maxlen];
	int len;
};

void input(List &L)
{
	cout << "Nhap so luong phan tu cho danh sach :";
	cin >> L.len;
	for (int i = 0; i < L.len; i++)
		cin >> L.ds[i];
}

void printlist(List& L)
{
	for (int i = 0; i < L.len; i++)
		cout << L.ds[i] << "  ";
	cout << endl;
}

bool isemptylist(List L)
{
	return L.len == 0;
}

bool isfulllist(List L)
{
	return L.len > Maxlen;
}

void init_list(List &L)
{
	L.len = 0;
}

void addfirst(List &L)
{
	element_type value;
	cout << "Nhap vao gia tri muon chen vao dau danh sach : ";
	cin >> value;
	if (isfulllist(L))
	{
		cout << "Danh sach da day, khong the chen them !";
		return;
	}
	else
	{
		if (L.len > 0)
		{
			L.len++;
			for (int i = L.len - 1; i > 0; i--)
			{
				L.ds[i] = L.ds[i-1];
			}
			L.ds[0] = value;
		}
		if (L.len == 0)
			L.len++;
			L.ds[0] = value;
	}
}

void add_end(List &L)
{
	element_type value;
	cout << "Nhap vao gia tri muon chen vao cuoi danh sach : ";
	cin >> value;
	if (isfulllist(L))
	{
		cout << "Danh sach da day, khong the chen them !";
		return;
	}
	else
	{
		if (L.len > 0)
		{
			L.len++;
			L.ds[ L.len - 1] = value;
		}
		if (L.len == 0)
		{
			L.len++;
			L.ds[0] = value;
		}
	}
}

void removefirst(List &L)
{
	if (isemptylist(L))
		cout << "Danh sach chua co phan tu de xoa !";
	for (int i = 0; i < L.len - 1; i++)
		L.ds[i] = L.ds[i + 1];
	L.len--;
}

void remove_end(List& L)
{
	if (isemptylist(L))
		cout << "Danh sach chua co phan tu de xoa !";
	L.len--;
}

element_type find_value_linear(List L, element_type value)
{
	for (int i = 0; i < L.len; i++)
	{
		if (L.ds[i] == value)
			return i + 1;
	}
	return -1;
}

void swap(List &L, int num1, int num2)
{
	int temp = num1;
	num1 = num2;
	num2 = temp;
}

void sort(List &L)
{
	for (int i = 0; i < L.len -1; i++)
	{
		for (int j = i + 1; j < L.len; j++)
		{
			if (L.ds[i] > L.ds[j])
				swap(L.ds[i], L.ds[j]);
		}
	}
}

element_type find_value_binary(List L, element_type value)
{
	sort(L);
	int left = 0, right = L.len - 1;
	int pos = (left + right) / 2;   // vi tri mid
	while (left <= right)
	{
		if (L.ds[pos] == value)
			return pos + 1;
		else
		{
			if (L.ds[pos] < value)
			{
				left = pos +1;
				pos++;
			}
			else
			{
				right = pos -1;
				pos--;
			}
		}
	}
	return -1;
}


int main()
{
	List L;
	init_list(L);
	input(L);
	

	int choose;
	cout << "Menu : \n";
	cout << "1. Chen 1 phan tu vao dau danh sach : \n";
	cout << "2. Chen 1 phan tu vao cuoi danh sach : \n";
	cout << "3. Xoa phan tu o dau danh sach : \n";
	cout << "4. Xoa phan tu o cuoi danh sach : \n";
	cout << "5. Tim kiem mot phan tu : \n";
	cout << "6. Liet ke danh sach : \n";
	cout << "7. Kiem tra danh sach rong hay day : \n";
	cout << "8. Sap xep danh sach : \n";
	cin >> choose;

	switch (choose)
	{
	case(1):
		addfirst(L);
		printlist(L);
		break;
	case(2):
		add_end(L);
		printlist(L);
		break;
	case(3):
		removefirst(L);
		printlist(L);
		break;
	case(4):
		remove_end(L);
		printlist(L);
		break;
	case(5):
	{
		int temp_choose;
		cout << "Lua chon kieu tim kiem : \n";
		cout << "1. Tim kiem theo tuyen tinh : \n";
		cout << "2. Tim kiem theo nhi phan : \n";
		cin >> temp_choose;

		element_type value;
		cout << "Nhap vao gia tri muon tim kiem trong danh sach : ";
		cin >> value;

		switch (temp_choose)
		{
		case(1):
			if (find_value_linear(L, value) != -1)
				cout << "Vi tri gia tri can tim trong danh sach la : " << find_value_linear(L, value) << endl;
			else
				cout << "Gia tri can tim khong co trong danh sach !\n";
		case(2):
			if (find_value_binary(L, value) != -1)
			{
				printlist(L);
				cout << "Vi tri gia tri can tim trong danh sach la : " << find_value_binary(L, value) << endl;
			}
			else
				cout << "Gia tri can tim khong co trong danh sach !\n";
		}
		break;
	}
	case(6):
	{
		cout << "Danh sach : ";
		printlist(L);
		break;
	}
	case(7):
	{
		int temp_choose;
		cout << "1.Kiem tra danh sach rong\n";
		cout << "2 Kiem tra danh sach day\n";
		cin >> temp_choose;
		if (temp_choose == 1 && isemptylist(L))
			cout << "Danh sach rong !\n";
		else
			cout << "Danh sach khong rong!\n";
		if (temp_choose == 2 && isfulllist(L))
			cout << "Danh sach da day !\n";
		else
			cout << "Danh sach khong day!\n";

		break;
	}
	case(8):
		sort(L);
		cout << "Danh sach sau khi sap xep : ";
		printlist(L);
		break;
	}
	return 0;
}
