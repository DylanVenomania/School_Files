#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
using namespace std;

#define ElementType SINHVIEN

struct SINHVIEN {
    int maSo;
    string ten;
    float diemTrungBinh;

    friend ostream& operator<<(ostream& os, const SINHVIEN& sv) 
    {
        os << "Ma so: " << sv.maSo << ", Ten: " << sv.ten << ", Diem TB: " << sv.diemTrungBinh;
        return os;
    }
};

struct Node {
    ElementType info;
    Node* pNext;
};

struct LIST {
    Node* pHead;
    Node* pTail;
};

void InitList(LIST& list) 
{
    list.pHead = nullptr;
    list.pTail = nullptr;
}


Node* CreateNode(ElementType x) 
{
    Node* newNode = new Node;
    newNode->info = x;
    newNode->pNext = nullptr;
    return newNode;
}


bool IsEmptyList(LIST& list) 
{
    return list.pHead == nullptr;
}

void AddFirst(LIST& list, ElementType x) 
{
    Node* newNode = CreateNode(x);
    newNode->pNext = list.pHead;
    list.pHead = newNode;
    if (list.pTail == nullptr) {
        list.pTail = newNode;
    }
}


void PrintList(LIST& list) 
{
    Node* current = list.pHead;
    while (current != nullptr) 
    {
        cout << current->info << endl;
        current = current->pNext;
    }
}

void InputStudent(SINHVIEN& sv) 
{
    cout << "Nhap ma so sinh vien: ";
    cin >> sv.maSo;
    cin.ignore();
    cout << "Nhap ten sinh vien: ";
    getline(cin, sv.ten);
    cout << "Nhap diem trung binh: ";
    cin >> sv.diemTrungBinh;
}


LIST GetStudentsWithScoreGreaterEqual(LIST& list, float x) 
{
    LIST newList;
    InitList(newList);
    Node* current = list.pHead;

    while (current != nullptr) {
        if (current->info.diemTrungBinh >= x) 
        {
            AddFirst(newList, current->info);
        }
        current = current->pNext;
    }

    return newList;
}


void RemoveStudentsWithScoreGreaterEqual(LIST& list, float x) 
{
    Node* current = list.pHead;
    Node* previous = nullptr;

    while (current != nullptr) 
    {
        if (current->info.diemTrungBinh >= x) 
        {
            Node* temp = current;
            if (previous) 
            {
                previous->pNext = current->pNext;
            }
            else 
            {
                list.pHead = current->pNext; 
            }
            current = current->pNext; 
            delete temp;
        }
        else 
        {
            previous = current;
            current = current->pNext;
        }
    }
}


LIST FindTopKStudents(LIST& list, int k) 
{
    vector<SINHVIEN> students;
    Node* current = list.pHead;

    while (current != nullptr) 
    {
        students.push_back(current->info);
        current = current->pNext;
    }

    sort(students.begin(), students.end(), [](SINHVIEN a, SINHVIEN b) 
        {
        return a.diemTrungBinh > b.diemTrungBinh;
        });

    LIST topKList;
    InitList(topKList);
    for (int i = 0; i < k && i < students.size(); i++) 
    {
        AddFirst(topKList, students[i]);
    }

    return topKList;
}


int main() 
{
    LIST studentList;
    InitList(studentList);


    SINHVIEN sv;
    while (true) 
    {
        InputStudent(sv);
        AddFirst(studentList, sv);

        cout << "Nhap them sinh vien? (y/n): ";
        char ch;
        cin >> ch;
        if (ch != 'y' && ch != 'Y') break;
    }


    cout << "Danh sach sinh vien: " << endl;
    PrintList(studentList);


    float x;
    cout << "Nhap diem trung binh x: ";
    cin >> x;
    LIST studentsWithScore = GetStudentsWithScoreGreaterEqual(studentList, x);
    cout << "Danh sach sinh vien co diem trung binh >= " << x << ": " << endl;
    PrintList(studentsWithScore);


    RemoveStudentsWithScoreGreaterEqual(studentList, x);
    cout << "Danh sach sinh vien sau khi xoa sinh vien co diem trung binh >= " << x << ": " << endl;
    PrintList(studentList);

    int k;
    cout << "Nhap k: ";
    cin >> k;
    LIST topKStudents = FindTopKStudents(studentList, k);
    cout << "Top " << k << " sinh vien co diem trung binh cao nhat: " << endl;
    PrintList(topKStudents);

    return 0;
}