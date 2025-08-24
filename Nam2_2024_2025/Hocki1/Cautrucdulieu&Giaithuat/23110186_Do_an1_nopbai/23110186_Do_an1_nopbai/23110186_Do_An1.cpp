/*	Mssv : 23110186
	Ton Hoang Cam
*/
#include <iostream>
#include <string>
#include <algorithm>

using namespace std;
#define max_len 100
#define element_type product

struct product {
	int id ;
	string ten;
	int gia;

};

element_type phantu;

void nhap(int& phantu)
{
	cin >> phantu;
}

void nhap(product& phantu)
{
	cout << "Id : ";
	cin >> phantu.id;
	cout << "Nhap ten san pham : ";
	cin.ignore();
	getline(cin, phantu.ten);
	cout << "Nhap gia : ";
	cin >> phantu.gia;
}

void print(int ds[], int n)
{
	for (int i = 0; i < n; i++)
		cout << ds[i] << "  ";
}

void print(product ds[], int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << "ID : " << ds[i].id << "   " << "' " << ds[i].ten << " '    " << ds[i].gia << " dong" << endl;
	}
}

bool sosanh(product a, product b)
{
	return a.gia > b.gia;
}

bool sosanh(int a, int b)
{
	return a > b;
}

void selection_sort(element_type ds[], int n)
{
	for (int i = 0; i < n - 1; i++)
	{
		int min_index = i + 1;
		for (int j = i + 1; j < n; j++)
		{
			if (sosanh(ds[min_index], ds[j]))
				min_index = j;
		}
		if (sosanh(ds[i], ds[min_index]))
			swap(ds[min_index], ds[i]);
	}
}

void insertion_sort(element_type ds[], int n)
{
	for (int i = 0; i < n; i++)
	{
		element_type key = ds[i];
		int j = i - 1;
		while (j >= 0 && sosanh(ds[j], key))
		{
			ds[j + 1] = ds[j];
			j--;
		}
		ds[j + 1] = key;
	}
}

void shake_sort(element_type ds[], int n)
{
	bool doicho = true;
	while (doicho)
	{
		doicho = false;
		for (int j = 0; j < n - 1; j++)
		{
			if (sosanh(ds[j], ds[j + 1]))
			{
				swap(ds[j], ds[j + 1]);
				doicho = true;
			}
		}
		if (!doicho)
			break;

		for (int j = n - 2; j >= 0; j--)
		{
			if (sosanh(ds[j], ds[j + 1]))
			{
				swap(ds[j], ds[j + 1]);
				doicho = true;
			}
		}
	}
}

void bubble_sort(element_type ds[], int n)
{
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = 0; j < n - 1 - i; j++)
		{
			if (sosanh(ds[j], ds[j + 1]))
				swap(ds[j], ds[j + 1]);
		}
	}
}

int partition(element_type ds[], int l, int r)
{
	int mid = l + (r - l) / 2;
	element_type pivot = ds[mid];
	int i = l - 1;
	int j = r + 1;
	while (true)
	{
		do
		{
			++i;
		} while (sosanh(pivot, ds[i]));

		do
		{
			--j;
		} while (sosanh(ds[j], pivot));
		if (i < j)
		{
			swap(ds[i], ds[j]);
		}
		else
			return j;
	}
}

void quick_sort(element_type ds[], int l, int r)
{
	if (l >= r)
		return;
	int p = partition(ds, l, r);
	quick_sort(ds, l, p);
	quick_sort(ds, p + 1, r);
}

void insertion_sort_binary(element_type ds[], int n)
{
	int l, r, mid;
	element_type x;
	for (int i = 1; i < n; i++)
	{
		x = ds[i];
		l = 0;
		r = i - 1;
		while (l <= r)
		{
			mid = (l + r) / 2;
			if (sosanh(ds[mid], x))
				r = mid - 1;
			else
				l = mid + 1;
		}
		for (int j = i - 1; j >= l; j--)
			ds[j + 1] = ds[j];

		ds[l] = x;
	}
}

int partition2(element_type ds[], int l, int r)
{
	element_type pivot = ds[l];
	int i = l - 1;
	int j = r + 1;
	while (true)
	{
		do
		{
			i++;
		} while (sosanh(pivot, ds[i]));

		do
		{
			j--;
		} while (sosanh(ds[j], pivot));
		if (i < j)
		{
			swap(ds[i], ds[j]);
		}
		else
			return j;
	}
}

void quick_sort2(element_type ds[], int l, int r)
{
	if (l >= r)
		return;
	int p = partition2(ds, l, r);
	quick_sort2(ds, l, p);
	quick_sort2(ds, p + 1, r);
}

int main()
{
	int n;
	element_type ds[max_len];
	cout << "Nhap vao so luong cho danh sach :";
	cin >> n;

	cout << "Nhap cac gia tri phan tu : \n";
	for (int i = 0; i < n; i++)
		nhap(ds[i]);
	print(ds, n);

	cout << "\nMenu : \n";
	cout << "1. Selection sort\n";
	cout << "2. Insertion sort\n";
	cout << "3. Bubble sort\n";
	cout << "4. Shake sort\n";
	cout << "5. Quick sort\n";
	cout << "6. Insertion sort (binary ) \n";
	cout << "7. Quick sort 2 \n";
	int choose1;
	cin >> choose1;
	switch (choose1)
	{
	case(1):
		selection_sort(ds, n);
		print(ds, n);
		break;
	case(2):
		insertion_sort(ds, n);
		print(ds, n);
		break;
	case(3):
		bubble_sort(ds, n);
		print(ds, n);
		break;

	case(4):
		shake_sort(ds, n);
		print(ds, n);
		break;
	case(5):
		quick_sort(ds, 0, n - 1);
		print(ds, n);
		break;
	case(6):
		insertion_sort_binary(ds, n);
		print(ds, n);
		break;
	case(7):
		quick_sort2(ds, 0, n - 1);
		print(ds, n);
		break;
	}

	return 0;
}
