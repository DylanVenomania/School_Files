#include <iostream>
#define MAX 1000
using namespace std;

int hashtable[MAX]; 
int tableSize;      
int dem = 0;

void init() 
{
    for (int i = 0; i < MAX; i++) 
        hashtable[i] = -1; 
    
}

int hashFunction(int key) 
{
    return key % tableSize; 
}

void AddItem(int hashtable[MAX], int value) 
{
    if (dem >= tableSize) 
    {
        cout << "Bang bam da day, khong the them phan tu " << value << "\n";
        return;
    }

    int index = hashFunction(value);
    int vitribandau = index;

    while (hashtable[index] != -1 && hashtable[index] != -2) 
    { 
        index = (index + 1) % tableSize;
        if (index == vitribandau)
        {
            cout << "Bang bam da day, khong the them phan tu " << value << "\n";
            return;
        }

    }

    hashtable[index] = value;
    dem++;
    cout << "Them phan tu " << value << " vao vi tri " << index << "\n";
}


void removeItem(int hashtable[MAX], int value) 
{
    int index = hashFunction(value);
    int vitribandau = index;

    while (hashtable[index] != -1) 
    {
        if (hashtable[index] == value) 
        {
            hashtable[index] = -2;
            dem--;
            cout << "Da xoa phan tu " << value << " khoi vi tri " << index << "\n";
            return;
        }

        index = (index + 1) % tableSize;
        if (index == vitribandau)
            break;
    }

    cout << "Khong tim thay " << value << " de xoa\n";

}


int SearchItem(int hashtable[MAX], int x) 
{
    int index = hashFunction(x); 
    int vitribandau = index;

    while (hashtable[index] != -1) 
    {
        if (hashtable[index] == x)  
            return index;
        
        index = (index + 1) % tableSize;
        if (index == vitribandau)  
            break;
    }

    return -1; 
}

void hienthi(int hashtable[MAX]) 
{
    for (int i = 0; i < tableSize; i++) 
    {
        cout << "Vi tri " << i << ": ";
        if (hashtable[i] == -1) 
            cout << "Trong";
        else if (hashtable[i] == -2) 
            cout << "Da xoa";
        else 
            cout << hashtable[i];
        cout << "\n";
    }
}


int main() 
{
    do {
        cout << "Nhap kich thuoc bang bam (1 <= kich thuoc <= " << MAX << "): ";
        cin >> tableSize;
    } while (tableSize <= 0 || tableSize > MAX);

    init();

    cout << "Menu: \n";
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
            AddItem(hashtable, value);
            break;
        }
        case 2: 
        {
            int value;
            cout << "Nhap gia tri can xoa: ";
            cin >> value;
            removeItem(hashtable, value);
            break;
        }
        case 3: 
        {
            int value;
            cout << "Nhap gia tri can tim: ";
            cin >> value;
            int result = SearchItem(hashtable, value);
            if (result != -1)
                cout << "Tim thay gia tri " << value << " tai vi tri " << result << "\n";
            else
                cout << "Khong tim thay gia tri " << value << " trong bang bam\n";
            break;
        }
        case 4: 
        {
            cout << "Bang bam hien tai:\n";
            hienthi(hashtable);
            break;
        }
        case 5: 
        {
            cout << "Thoat chuong trinh.\n";
            break;
        }
        default:
            cout << "Lua chon khong hop le. Vui long chon lai\n";
        }
    } while (choice != 5);

    return 0;
}
