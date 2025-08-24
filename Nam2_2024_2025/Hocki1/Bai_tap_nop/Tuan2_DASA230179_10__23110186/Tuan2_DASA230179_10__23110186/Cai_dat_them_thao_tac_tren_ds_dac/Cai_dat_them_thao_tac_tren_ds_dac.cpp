#include <iostream>
#include <string>
using namespace std;
#define element_type Sinhvien
#define Maxlen 100

struct Sinhvien 
{
	int mssv = 0;
	string hoten;
	float dtb = 0.0;


	void input()
	{
		cout << "	Ma so sinh vien :";
		cin >> mssv;
		cin.ignore();
		cout << "	Ho ten :";
		getline(cin, hoten);
		cout << "	Diem trung binh :";
		cin >> dtb;
	}

};

struct List {
	element_type ds[Maxlen];
	int ds_int[Maxlen] = {0};
	int len;
};

void init_list(List &L)
{
	L.len = 0;
}

void input_list_sv(List  &List_sv)
{
	cout << "Nhap so luong phan tu cho danh sach :";
	cin >> List_sv.len;
	for (int i = 0; i < List_sv.len; i++)
	{
		cout << "Sinh vien thu " << i << " :\n";
		List_sv.ds[i].input();
	}
}

void input_list_int(List& List_int)
{
	cout << "Nhap so luong phan tu cho danh sach :";
	cin >> List_int.len;
	cout << "Nhap cac gia tri cho danh sach : ";
	for (int i = 0; i < List_int.len; i++)
		cin >> List_int.ds_int[i];
}

void printlist(List List_sv)
{
	for (int i = 0; i < List_sv.len; i++)
	{
		cout << "Sinh vien thu " << i << " :\n";
		cout << "	Ma so sinh vien :" << List_sv.ds[i].mssv << "\n";
		cout << "	Ho ten :" << List_sv.ds[i].hoten << "\n";
		cout << "	Diem trung binh :" << List_sv.ds[i].dtb << endl;
	}
}

void layds(List List_int)
{
	int x;
	cout << "Nhap vao gia tri x ma ban muon lay danh sach co phan tu >= x :";
	cin >> x;
	int mang[Maxlen];
	int len_mang = 0;
	for (int i = 0; i < List_int.len; i++)
	{
		if (List_int.ds_int[i] >= x)
		{
			mang[len_mang] = List_int.ds_int[i];
			len_mang++;
		}
	}
	for (int i = 0; i < len_mang; i++)
		cout << mang[i] << "  ";
}

void xoads(List List_int)
{
	int x;
	cout << "Nhap vao gia tri x ma ban muon xoa cac phan tu >= x:";
	cin >> x;
	int mang[Maxlen];
	int len_mang = 0;
	for (int i = 0; i < List_int.len; i++)
	{
		if (List_int.ds_int[i] < x)
		{
			mang[len_mang] = List_int.ds_int[i];
			len_mang++;
		}
	}
	for (int i = 0; i < len_mang; i++)
		cout << mang[i] << "  ";
}

int max_int(int arr[Maxlen], int n)
{
	int max = arr[0];
	for (int i = 1; i < n; i++)
	{
		if (arr[i] > max)
			max = arr[i];
	}
	return max;
}

void layds_max(List List_int)
{
	int mang[Maxlen];
	int len_mang = 0;
	for (int i = 0; i < List_int.len; i++)
	{
		if (List_int.ds_int[i] == max_int(List_int.ds_int, List_int.len))
		{
			mang[len_mang] = List_int.ds_int[i];
			len_mang++;
		}
	}
	for (int i = 0; i < len_mang; i++)
		cout << mang[i] << "  ";
}

int quantity_nega(List List_int)
{
	int dem = 0;
	for (int i = 0; i < List_int.len; i++)
		if (List_int.ds_int[i] < 0)
			dem++;
	return dem;
}

bool check_nega(int mang[Maxlen], int n)
{
	for (int i = 0; i < n; i++)
		if (mang[i] < 0)
			return true;
	return false;
}

bool check_posi(int mang[Maxlen], int n)
{
	for (int i = 0; i < n; i++)
		if (mang[i] > 0)
			return true;
	return false;
}

int nega_max(List List_int)
{
	int max = 0;
	if (check_nega(List_int.ds_int, List_int.len))
	{
		for (int i = 0; i < List_int.len; i++)
			if (List_int.ds_int[i] < 0)
			{
				max = List_int.ds_int[i];
				break;
			}
		for (int i = 0; i < List_int.len; i++)
		{
			if (List_int.ds_int[i] > max && List_int.ds_int[i] < 0)
				max = List_int.ds_int[i];
		}
		return max;
	}
	else
		return max;
}

int posi_min(List List_int)
{
	int min = 0;
	if ( check_posi(List_int.ds_int, List_int.len) )
	{
		for (int i = 0; i < List_int.len; i++)
			if (List_int.ds_int[i] > 0)
			{
				min = List_int.ds_int[i];
				break;
			}
		for (int i = 0; i < List_int.len; i++)
		{
			if (List_int.ds_int[i] < min && List_int.ds_int[i] > 0)
				min = List_int.ds_int[i];
		}
		return min;
	}
	return min;
}

int count_samevalue(List List_int, int x)
{
	int count = 0;
	for (int i = 0; i < List_int.len; i++)
		if (List_int.ds_int[i] == x)
			count++;
	return count;
}

bool isemptylist(List L)
{
	return L.len == 0;
}

bool isfulllist(List L)
{
	return L.len > Maxlen;
}

void sort_ascending(List& L)
{
	for (int i = 0; i < L.len - 1; i++)
		for (int j = i + 1; j < L.len; j++)
		{
			if (L.ds[i].dtb > L.ds[j].dtb)
			{
				element_type temp = L.ds[i];
				L.ds[i] = L.ds[j];
				L.ds[j] = temp;
			}
		}
}

void add(List& L)
{
	element_type a;
	cout << "Nhap thong tin sinh vien muon chen : ";
	a.input();
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
			L.ds[L.len - 1] = a;
		}
		if (L.len == 0)
		{
			L.len++;
			L.ds[0] = a;
		}
	}
	sort_ascending(L);
}

void layds_sv(List L)
{
	float x;
	cout << "Nhap vao diem trung binh x ma ban muon lay danh sach sinh vien co diem trung binh >= x :";
	cin >> x;
	List mang;
	for (int i = 0; i < L.len; i++)
	{
		if (L.ds[i].dtb >= x)
		{
			mang.ds[i] = L.ds[i];
			mang.len++;
		}
	}
	if (mang.len == 0)
		cout << "Khong co sinh vien nao co diem trung binh >= " << x << endl;
	else
		printlist(mang);
}

void xoads_sv(List L)
{
	float x;
	cout << "Nhap vao diem trung binh x ma ban muon xoa cac sinh vien co diem trung binh >= x :";
	cin >> x;
	List mang;
	for (int i = 0; i < L.len; i++)
	{
		if (L.ds[i].dtb < x)
		{
			mang.ds[i] = L.ds[i];
			mang.len++;
		}
	}
	if (mang.len == L.len)
		cout << "Khong co sinh vien nao co diem trung binh >= " << x << endl;
	else
		printlist(mang);
}

void ds_dtb_max(List L)
{
	sort_ascending(L);
	int k;
	cout << "Nhap vao so luong sinh vien ma ban muon tim co diem trung binh cao nhat";
	cin >> k;

	List mang;
	int count = 0;
	for (int i = L.len -1; i >= 0; i--)
		if (count < k)
		{
			mang.ds[count] = L.ds[i];
			count++;
		}
	if (mang.len < k)
		cout << "Khong co du sinh vien co diem trung binh cao dap ung so luong " << k << " cua ban!";
	printlist(mang);
}


int main()
{
	List List_sv;
	List List_int;
	int choose;
	cout << "Chon du lieu ban muon lap danh sach :\n";
	cout << "1. Sinh vien\n";
	cout << "2. So nguyen\n";
	cin >> choose;
	switch (choose)
	{
	case(1):
	{
		init_list(List_sv);
		input_list_sv(List_sv);
		cout << endl;
		printlist(List_sv);
		int choose1;
		cout << "Menu :\n";
		cout << "1. Chen 1 sinh vien vao lop hoc \n";
		cout << "2. Lay danh sach sinh vien co diem trung binh >= x\n";
		cout << "3. Xoa tat ca cac sinh vien co diem trung binh >=x\n";
		cout << "4. Tim so luong sinh vien co diem trung binh cao nhat \n";
		cin >> choose1;
		switch (choose1)
		{
		case(1):
			add(List_sv );
			printlist(List_sv);
			break;
		case(2):
			layds_sv(List_sv);
			break;
		case(3):
			xoads_sv(List_sv);
			break;
		case(4):
			ds_dtb_max(List_sv) ;
			break;
		}
		break;
	}
		
	case(2):
	{
		init_list(List_int);
		input_list_int(List_int);
		int choose2;
		cout << "Menu :\n";
		cout << "1. Lay danh sach phan tu >= x\n";
		cout << "2. Xoa cac phan tu >= x\n";
		cout << "3. Lay danh sach phan tu lon nhat \n";
		cout << "4. Dem so luong so am trong danh sach \n";
		cout << "5. Cho biet gia tri am lon nhat trong danh sach \n";
		cout << "6. Cho biet gia tri duong nho nhat trong danh sach \n";
		cout << "7. Dem so phan tu trong danh sach = x \n";
		cin >> choose2;
		switch (choose2)
		{
		case(1):
			layds(List_int);
			break;
		case(2):
			xoads(List_int);
			break;
		case(3):
			layds_max(List_int);
			break;
		case(4):
			cout << "So luong so am trong danh sach la : " << quantity_nega(List_int);
			break;
		case(5):
			if (nega_max(List_int) != 0)
				cout << "So am lon nhat trong danh sach : " << nega_max(List_int);
			else
				cout << "Khong co so am trong danh sach!";
			break;
		case(6):
			if (posi_min(List_int) != 0)
				cout << "So duong nho nhat trong danh sach : " << posi_min(List_int);
			else
				cout << "Khong co so duong trong danh sach!";
			break;
		case(7):
		{
			int x;
			cout << "Nhap vao gia tri x muon dem so lan xuat hien trong danh sach :";
			cin >> x;
			if (count_samevalue(List_int, x) != 0)
				cout << "So lan " << x << " xuat hien trong danh sach la: " << count_samevalue(List_int,x);
			else
				cout << x << " khong xuat hien trong danh sach!";
			break;
		}
		}
	}
	}

	return 0;
}