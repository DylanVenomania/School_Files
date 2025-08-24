#include <iostream>
#include <string>
using namespace std;

struct Sinhvien {
    string mssv;
    string hoten;
    float dtb = 0.0;
};

struct SV {
    Sinhvien data;
    SV* next;
};

typedef struct SV* sv;

sv makenode() 
{
    Sinhvien s;
    cout << "Nhap thong tin sinh vien :\n";
    cout << "Nhap ma so sinh vien : ";
        cin >> s.mssv;
    cin.ignore();
    cout << "Nhap ho ten sinh vien: ";
        getline(cin, s.hoten);
    cout << "Nhap diem trung binh: ";
        cin >> s.dtb;

    sv temp = new SV();
    temp->data = s;
    temp->next = NULL;
    return temp;
}

bool empty(sv a) 
{
    return a == NULL;
}

void insertfirst(sv& a) 
{
    sv temp = makenode();
    if (a == NULL) 
    {
        a = temp;
    }
    else 
    {
        temp->next = a;
        a = temp;
    }
}
sv findstudent(sv a, string mssv) 
{
    while (a != NULL) 
    {
        if (a->data.mssv == mssv)
            return a;
        a = a->next;
    }
    return NULL;
}

void deletestudent(sv& a, string mssv) 
{
    if (a == NULL) return;

    if (a->data.mssv == mssv) 
    {
        sv temp = a;
        a = a->next;
        delete temp;
        return;
    }

    sv p = a;
    while (p->next != NULL && p->next->data.mssv != mssv) 
        p = p->next;

    if (p->next != NULL) 
    {
        sv temp = p->next;
        p->next = temp->next;
        delete temp;
    }
}

void print(Sinhvien s) 
{
    cout << "Ma so sinh vien: " << s.mssv << endl;
    cout << "Ho ten: " << s.hoten << endl;
    cout << "Diem trung binh: " << s.dtb << endl;
}
void printlist_dtb5(sv a) 
{
    while (a != NULL) 
    {
        if (a->data.dtb >= 5) 
            print(a->data);
        a = a->next;
    }
}

void xep_loai(Sinhvien s) 
{
    cout << "Ma so sinh vien: " << s.mssv << endl;
    cout << "Ho ten: " << s.hoten << endl;
    cout << "Diem trung binh: " << s.dtb << endl;
    cout << "Xep loai: ";
    if (s.dtb <= 3.6)
        cout << "Yeu";
    else if (s.dtb >= 5.0 && s.dtb < 6.5)
        cout << "Trung binh";
    else if (s.dtb >= 6.5 && s.dtb < 7.0)
        cout << "Trung binh kha";
    else if (s.dtb >= 7.0 && s.dtb < 8.0)
        cout << "Kha";
    else if (s.dtb >= 8.0 && s.dtb < 9.0)
        cout << "Gioi";
    else if (s.dtb >= 9.0)
        cout << "Xuat sac";
    cout << endl;
}

void printlist_xeploai(sv a) 
{
    while (a != NULL) 
    {
        xep_loai(a->data);
        a = a->next;
    }
}

void sapxep(sv& a) 
{
    for (sv p = a; p != NULL; p = p->next) 
    {
        for (sv q = p->next; q != NULL; q = q->next) 
        {
            if (q->data.dtb < p->data.dtb) 
            {
                Sinhvien temp = p->data;
                p->data = q->data;
                q->data = temp;
            }
        }
    }
}

void insert_sorted(sv& a) 
{
    sv temp = makenode();
    if (a == NULL || temp->data.dtb <= a->data.dtb) 
    {
        temp->next = a;
        a = temp;
        return;
    }

    sv p = a;
    while (p->next != NULL && p->next->data.dtb < temp->data.dtb) 
        p = p->next;

    temp->next = p->next;
    p->next = temp;
}

int main() 
{
    sv head = NULL;

    while (true) 
    {
        cout << "Nhap sinh vien moi (nhap ten rong de dung):" << endl;
        sv temp = makenode();
        if (temp->data.hoten == "")
            break;
        insertfirst(head);
    }
    string mssv;
    cout << "Nhap ma so sinh vien de tim kiem: ";
    cin >> mssv;
    sv found = findstudent(head, mssv);
    if (found != NULL)
        print(found->data);
    else
        cout << "Sinh vien khong co trong danh sach." << endl;

    cout << "Nhap ma so sinh vien de xoa: ";
    cin >> mssv;
    deletestudent(head, mssv);

    cout << "Danh sach sinh vien co diem trung binh >= 5:" << endl;
    printlist_dtb5(head);

    cout << "Danh sach sinh vien va xep loai:" << endl;
    printlist_xeploai(head);

    sapxep(head);
    cout << "Danh sach sinh vien sau khi sap xep theo diem trung binh:" << endl;
    printlist_xeploai(head);

    insert_sorted(head);
    cout << "Danh sach sinh vien sau khi chen va van tang theo diem trung binh:" << endl;
    printlist_xeploai(head);

    return 0;
}