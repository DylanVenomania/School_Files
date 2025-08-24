#include <iostream>
#include <string>
#include <fstream>
using namespace std;

struct sinhvien {
    int id =0; 
    string ten; 
    float dtb = 0.0; 
};


struct Node {
    sinhvien info; 
    Node* pNext; 
};


struct LIST {
    Node* pHead; 
    Node* pTail; 
};


void InitList(LIST& lst) 
{
    lst.pHead = NULL;
    lst.pTail = NULL;
}


Node* CreateNode(sinhvien sv) 
{
    Node* newNode = new Node;
    newNode->info = sv;
    newNode->pNext = NULL;
    return newNode;
}


int IsEmptyList(LIST lst) 
{
    return (lst.pHead == NULL);
}


void AddFirst(LIST& lst, sinhvien sv) 
{
    Node* newNode = CreateNode(sv);
    if (IsEmptyList(lst)) {
        lst.pHead = newNode;
        lst.pTail = newNode;
    }
    else 
    {
        newNode->pNext = lst.pHead;
        lst.pHead = newNode;
    }
}



Node* SearchNode(LIST lst, int id) 
{
    Node* current = lst.pHead;
    while (current != NULL) {
        if (current->info.id == id) 
        {
            return current; 

        }
        current = current->pNext;
    }
    return NULL; 

}


void remove_by_id(LIST& lst, int id) 
{
    if (IsEmptyList(lst)) 
    {
        cout << "Danh sach rong!" << endl;
        return;
    }

    Node* current = lst.pHead;
    Node* previous = NULL;

    while (current != NULL) 
    {
        if (current->info.id == id) 
        {
            if (previous == NULL) 
            {
                lst.pHead = current->pNext;
            }
            else 
            {
                previous->pNext = current->pNext; 
            }
            if (current == lst.pTail) 
            {
                lst.pTail = previous; 
            }
            delete current;
            cout << "Da xoa sinh vien co ma so " << id << endl;
            return;
        }
        previous = current;
        current = current->pNext;
    }
    cout << "Khong tim thay sinh vien co ma so " << id << endl;
}


void PrintStudentsAboveAverage(LIST lst) 
{
    Node* current = lst.pHead;
    cout << "Danh sach sinh vien co diem trung binh >= 5:" << endl;
    while (current != NULL) 
    {
        if (current->info.dtb >= 5.0) 
        {
            cout << "Ma so: " << current->info.id << ", Ten: " << current->info.ten
                << ", Diem: " << current->info.dtb << endl;
        }
        current = current->pNext;
    }
}

void ClassifyStudents(LIST lst) {
    Node* current = lst.pHead;
    cout << "Xep loai sinh vien:" << endl;
    while (current != NULL) 
    {
        string xepLoai;
        if (current->info.dtb <= 3.6) 
        {
            xepLoai = "Yeu";
        }
        else if (current->info.dtb < 5.0) 
        {
            xepLoai = "Trung binh yeu";
        }
        else if (current->info.dtb < 6.5) 
        {
            xepLoai = "Trung binh";
        }
        else if (current->info.dtb < 7.0) 
        {
            xepLoai = "Trung bình kha";
        }
        else if (current->info.dtb < 8.0) 
        {
            xepLoai = "Kha";
        }
        else if (current->info.dtb < 9.0) 
        {
            xepLoai = "Gioi";
        }
        else {
            xepLoai = "Xuat sac";
        }
        cout << "Ma so: " << current->info.id << ", Ten: " << current->info.ten
            << ", Diem: " << current->info.dtb << " Xep loai: " << xepLoai << endl;
        current = current->pNext;
    }
}


bool CompareByAverage(sinhvien a, sinhvien b) 
{
    return a.dtb < b.dtb; 
}


void SortStudents(LIST& lst) {
    if (IsEmptyList(lst)) return;

    for (Node* i = lst.pHead; i != NULL; i = i->pNext) 
    {
        for (Node* j = i->pNext; j != NULL; j = j->pNext) 
        {
            if (CompareByAverage(j->info, i->info)) 
            {
                swap(i->info, j->info);
            }
        }
    }
}


void InsertStudentSorted(LIST& lst, sinhvien sv) 
{
    Node* newNode = CreateNode(sv);
    if (IsEmptyList(lst) || sv.dtb < lst.pHead->info.dtb) 
    {
        AddFirst(lst, sv); 
    }
    else {
        Node* current = lst.pHead;
        while (current->pNext != NULL && current->pNext->info.dtb < sv.dtb) 
        {
            current = current->pNext; 
        }
        newNode->pNext = current->pNext;
        current->pNext = newNode; 

        if (newNode->pNext == NULL) 
        {
            lst.pTail = newNode; 
        }
    }
}


void ReadStudentsFromFile(LIST& lst, const string& filename) 
{
    ifstream file(filename);
    if (!file.is_open()) 
    {
        cout << "Khong the mo file!" << endl;
        return;
    }

    sinhvien sv;
    while (file >> sv.id >> ws) 
    {
        getline(file, sv.ten);
        file >> sv.dtb;
        if (sv.ten.empty()) 
            break; 
        AddFirst(lst, sv); 
    }

    file.close();
}

void PrintStudentList(LIST lst) 
{
    Node* current = lst.pHead;
    cout << "Danh sach sinh vien:" << endl;
    while (current != NULL) 
    {
        cout << "Ma so: " << current->info.id << ", Ten: " << current->info.ten
            << ", Diem: " << current->info.dtb << endl;
        current = current->pNext;
    }
}

int main()
{
    LIST studentList;
    InitList(studentList);


    ReadStudentsFromFile(studentList, "sinhvien.txt");


    while (true) 
    {
        sinhvien sv;
        cout << "Nhap ma so sinh vien ( nhap 0 de dung ) ";
        cin >> sv.id;
        if (sv.id == 0) 
            break; 
        cin.ignore(); 
        cout << "Nhap ten : ";
        getline(cin, sv.ten);
    }
    return 0;
}