/*
Ton Hoang Cam 
23110186 
*/
#include <iostream>
#include <string>
using namespace std;

struct Student 
{
    string ID;
    string name;
    float dtb;
};


void nhapMangSoNguyen(int a[], int n) 
{
    for (int i = 0; i < n; i++) {
        cin >> a[i];
    }
}

void nhapMangSinhVien(Student a[], int n) 
{
    for (int i = 0; i < n; i++) {
        cin.ignore();
        getline(cin, a[i].ID);
        getline(cin, a[i].name);
        cin >> a[i].dtb;
    }
}


void hienThiMangSoNguyen(int a[], int n) 
{
    for (int i = 0; i < n; i++) {
        cout << a[i] << " ";
    }
    cout << endl;
}


void hienThiMangSinhVien(Student a[], int n) 
{
    for (int i = 0; i < n; i++) {
        cout << a[i].ID << " " << a[i].name << " " << a[i].dtb << endl;
    }
}


bool soSanhSoNguyen(int a, int b) {
    return a < b;
}


bool soSanhSinhVien(Student a, Student b) 
{
    return a.ID < b.ID;
}

void selectionSort(int a[], int n) {
    for (int i = 0; i < n - 1; i++) {
        int minPos = i;
        for (int j = i + 1; j < n; j++) {
            if (soSanhSoNguyen(a[j], a[minPos])) 
            {
                minPos = j;
            }
        }
        if (minPos != i) {
            swap(a[i], a[minPos]);
        }
    }
}


void insertionSort(int a[], int n) 
{
    for (int i = 1; i < n; i++) 
    {
        int x = a[i];
        int pos = i;
        while (pos > 0 && soSanhSoNguyen(x, a[pos - 1])) 
        {
            a[pos] = a[pos - 1];
            pos--;
        }
        a[pos] = x;
    }
}


void bubbleSort(int a[], int n) 
{
    for (int i = 0; i < n - 1; i++) 
    {
        for (int j = n - 1; j > i; j--) 
        {
            if (soSanhSoNguyen(a[j], a[j - 1])) 
            {
                swap(a[j], a[j - 1]);
            }
        }
    }
}


void quickSort(int a[], int left, int right) 
{
    int i = left, j = right;
    int pivot = a[(left + right) / 2];

    while (i <= j) 
    {
        while (soSanhSoNguyen(a[i], pivot)) i++;
        while (soSanhSoNguyen(pivot, a[j])) j--;
        if (i <= j) 
        {
            swap(a[i], a[j]);
            i++;
            j--;
        }
    }
    if (left < j) quickSort(a, left, j);
    if (i < right) quickSort(a, i, right);
}


void hienThiMenu() {
    cout << "Chon loai sap xep:" << endl;
    cout << "1. Selection Sort" << endl;
    cout << "2. Insertion Sort" << endl;
    cout << "3. Bubble Sort" << endl;
    cout << "4. Quick Sort" << endl;
}

int main() 
{
    int n;
    cout << "Nhap so luong phan tu: ";
    cin >> n;

    int a[1000];


    nhapMangSoNguyen(a, n);

    hienThiMenu();

    int luaChon;
    cin >> luaChon;

    switch (luaChon) {
    case 1:
        selectionSort(a, n);
        break;
    case 2:
        insertionSort(a, n);
        break;
    case 3:
        bubbleSort(a, n);
        break;
    case 4:
        quickSort(a, 0, n - 1);
        break;
    default:
        cout << "Lua chon khong hop le!" << endl;
        return 1;
    }
    
    cout << "Mang sau khi sap xep: ";
    hienThiMangSoNguyen(a, n);

    return 0;
}