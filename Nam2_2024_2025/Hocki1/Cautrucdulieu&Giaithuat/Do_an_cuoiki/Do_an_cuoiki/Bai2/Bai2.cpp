#include <iostream>
#include <string>
#include <algorithm>
using namespace std;

struct Sach 
{
    int maSach;        
    string tenSach;     
    string tacGia;      
    float giaBan;     



    bool operator<(const Sach& other) const 
    {
        return maSach < other.maSach;
    }
    bool operator>(const Sach& other) const 
    {
        return maSach > other.maSach;
    }
    bool operator==(const Sach& other) const 
    {
        return maSach == other.maSach;
    }
};


struct TNode 
{
    Sach key;           
    TNode* pLeft;       
    TNode* pRight;     

    TNode() : pLeft(nullptr), pRight(nullptr) {}
   
};


TNode* CreateNode(Sach x) 
{
    TNode* p = new TNode;
    if (p == NULL)
        exit(1);
    else {
        p->key = x;
        p->pLeft = NULL;
        p->pRight = NULL;
    }
    return p;
}


TNode* InsertNode_DeQuy(TNode* root, Sach x) 
{
    if (root == NULL)
        return CreateNode(x);
    if (x < root->key)
        root->pLeft = InsertNode_DeQuy(root->pLeft, x);
    else if (x > root->key)
        root->pRight = InsertNode_DeQuy(root->pRight, x);
    return root;
}


void InsertNode_KhongDeQuy(TNode*& root, Sach x) 
{
    TNode* newNode = CreateNode(x);
    if (root == NULL) {
        root = newNode;
        return;
    }
    TNode* p = NULL;
    TNode* q = root;
    while (q != NULL) 
    {
        p = q;
        if (x < q->key)
            q = q->pLeft;
        else if (x > q->key)
            q = q->pRight;
        else
            return;
    }
    if (x < p->key)
        p->pLeft = newNode;
    else
        p->pRight = newNode;
}


TNode* DeleteNode_DeQuy(TNode* root, Sach x) 
{
    if (root == NULL)
        return root;
    if (x < root->key)
        root->pLeft = DeleteNode_DeQuy(root->pLeft, x);
    else if (x > root->key)
        root->pRight = DeleteNode_DeQuy(root->pRight, x);
    else {
        if (root->pLeft == NULL) 
        {
            TNode* p = root->pRight;
            delete root;
            return p;
        }
        else if (root->pRight == NULL) 
        {
            TNode* p = root->pLeft;
            delete root;
            return p;
        }
        TNode* p = root->pRight;
        while (p && p->pLeft != NULL)
            p = p->pLeft;
        root->key = p->key;
        root->pRight = DeleteNode_DeQuy(root->pRight, p->key);
    }
    return root;
}


void DeleteNode_KhongDeQuy(TNode*& root, Sach x) 
{
    TNode* p = NULL;
    TNode* q = root;
    while (q != NULL && !(q->key == x)) 
    {
        p = q;
        if (x < q->key)
            q = q->pLeft;
        else
            q = q->pRight;
    }
    if (q == NULL)
        return;
    if (q->pLeft == NULL || q->pRight == NULL) 
    {
        TNode* m = (q->pLeft) ? q->pLeft : q->pRight;
        if (p == NULL)
            root = m;
        else if (p->pLeft == q)
            p->pLeft = m;
        else
            p->pRight = m;
        delete q;
    }
    else 
    {
        TNode* n = q;
        TNode* o = q->pRight;
        while (o->pLeft != NULL) 
        {
            n = o;
            o = o->pLeft;
        }
        q->key = o->key;
        if (n->pLeft == o)
            n->pLeft = o->pRight;
        else
            n->pRight = o->pRight;
        delete o;
    }
}


void InOrder(TNode* root) 
{
    if (root != NULL) 
    {
        InOrder(root->pLeft);
        cout << "Ma Sach: " << root->key.maSach << ", "
            << "Ten Sach: " << root->key.tenSach << ", "
            << "Tac Gia: " << root->key.tacGia << ", "
            << "Gia Ban: " << root->key.giaBan << endl;
        InOrder(root->pRight);
    }
}

int Height(TNode* root) 
{
    if (root == NULL)
        return 0;
    int leftHeight = Height(root->pLeft);
    int rightHeight = Height(root->pRight);
    return max(leftHeight, rightHeight) + 1;
}


void ShowMenu() 
{
    cout << "\nMenu: " << endl;
    cout << "1. Them sach vao cay (De quy)" << endl;
    cout << "2. Them sach vao cay (Khong de quy)" << endl;
    cout << "3. Xoa sach khoi cay (De quy)" << endl;
    cout << "4. Xoa sach khoi cay (Khong de quy)" << endl;
    cout << "5. Hien thi danh sach sach" << endl;
    cout << "6. Tinh chieu cao cua cay" << endl;
    cout << "7. Thoat chuong trinh" << endl;
}

int main() 
{
    TNode* root = NULL;
    int choice;

    do {
        ShowMenu();
        cout << "Nhap lua chon cua ban: ";
        cin >> choice;

        switch (choice) 
        {
        case 1: 
        {
            Sach s;
            cout << "Nhap ma sach: ";
            cin >> s.maSach;
            cin.ignore(); 
            cout << "Nhap ten sach: ";
            getline(cin, s.tenSach);
            cout << "Nhap tac gia: ";
            getline(cin, s.tacGia);
            cout << "Nhap gia ban: ";
            cin >> s.giaBan;

            root = InsertNode_DeQuy(root, s);
            cout << "Da them sach vao cay (de quy)." << endl;
            break;
        }
        case 2: 
        {
            Sach s;
            cout << "Nhap ma sach: ";
            cin >> s.maSach;
            cin.ignore();
            cout << "Nhap ten sach: ";
            getline(cin, s.tenSach);
            cout << "Nhap tac gia: ";
            getline(cin, s.tacGia);
            cout << "Nhap gia ban: ";
            cin >> s.giaBan;

            InsertNode_KhongDeQuy(root, s);
            cout << "Da them sach vao cay (khong de quy)." << endl;
            break;
        }
        case 3: 
        {
            int maXoa;
            cout << "Nhap ma sach can xoa: ";
            cin >> maXoa;
            Sach sXoa = { maXoa, "", "", 0 };

            root = DeleteNode_DeQuy(root, sXoa);
            cout << "Da xoa sach khoi cay (de quy)." << endl;
            break;
        }
        case 4: 
        {
            int maXoa;
            cout << "Nhap ma sach can xoa: ";
            cin >> maXoa;
            Sach sXoa = { maXoa, "", "", 0 };  

            DeleteNode_KhongDeQuy(root, sXoa);
            cout << "Da xoa sach khoi cay (khong de quy)." << endl;
            break;
        }
        case 5:
            cout << "Danh sach sach (In-order Traversal):" << endl;
            InOrder(root);
            break;
        case 6:
            cout << "Chieu cao cua cay: " << Height(root) << endl;
            break;
        case 7:
            cout << "Thoat chuong trinh." << endl;
            break;
        default:
            cout << "Lua chon khong hop le. Vui long chon lai!" << endl;
        }
    } while (choice != 7);

    return 0;
}
