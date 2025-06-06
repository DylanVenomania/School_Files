#include <iostream>
#include <vector>
using namespace std;

struct Node
{
    int Info;
    Node* pNext;
};

struct Stack
{
    Node* Top;
};
//Tao mot nut moi
Node* CreateNode(int x)
{
    Node* p = new (nothrow) Node;
    if (p == NULL) return NULL;
    p->Info = x;
    p->pNext = NULL;
    return p;
}
//Khoi tao ngan xep
void InitStack(Stack& s)
{
    s.Top = NULL;
}
//Lam rong ngan xep
int IsEmpty(Stack s)
{
    return s.Top == NULL;
}
//Them mot phan tu vao dinh ngan xep
int Push(Stack& s, int x)
{
    Node* p = CreateNode(x); //Goi ham CreareNode() de tao them mot nut moi
    if (p == NULL) return 0;
    p->pNext = s.Top; //Lien ket nut voi ngan xep
    s.Top = p; //Cap nhat dinh ngan xep
    return 1;
}
//Lay mot phan tu ra khoi ngan xep
int Pop(Stack& s, int& x)
{
    if (IsEmpty(s)) //kiem tra ngan xep co rong hay khong?
        return 0;
    //Luu phan tu o dinh ngan xep
    Node* p = s.Top;
    x = s.Top->Info;
    //cap nhat ngan xep
    s.Top = s.Top->pNext;
    delete p;	// giai phong bo nho cu
    return 1;
}
//Hien thi cac phan tu co trong ngan xep tu dinh xuong day
void DisplayStack(Stack s)
{
    //Kiem tra ngan xep rong
    if (IsEmpty(s)) {
        cout << "Stack rong.\n";
        return;
    }
    //Duyet qua tung phan tu co trong ngan xep
    cout << "Cac phan tu trong Stack: ";
    Node* temp = s.Top;
    //In ra gia tri tung phan tu
    while (temp != NULL) {
        cout << temp->Info << " ";
        temp = temp->pNext;
    }
    cout << endl;
}
//Duyet cac phan tu theo chieu sau
void DFS(Stack& stack, vector<vector<int>>& List, vector<bool>& visited) {

    /*Stack &stack: Dung de ngan xep luu cac dinh can duyet
    vector <vector <int>> &List: Danh sach ke do thi dang mang 2 chieu
    vector <bool> &visited: Mang danh dau cac dinh da duoc duyet*/
    while (!IsEmpty(stack))
    {
        int c;
        Pop(stack, c);// lay dinh c tu ngan xep
        //Kiem tra
        if (!visited[c])
        {
            cout << c << " ";
            visited[c] = true;
            //Duyet qua cac dinh ke cua c lay tu List[c]
            for (int neighbor : List[c])
            {
                if (!visited[neighbor])
                {
                    Push(stack, neighbor);
                }
            }
        }
    }
    cout << endl;
}

void Input(Stack& s)
{
    int n, x;
    cout << "Nhap so luong phan tu muon them vao Stack: ";
    cin >> n;
    for (int i = 0; i < n; i++) {
        cout << "Nhap phan tu thu " << i + 1 << ": ";
        cin >> x;
        Push(s, x);
    }
}

int main()
{
    Stack s;
    InitStack(s);
    int choice, x;
    vector<vector<int>> List;
    vector<bool> visited;

    do {
        cout << "----MENU----\n";
        cout << "1. Nhap cac phan tu vao Stack\n";
        cout << "2. Them phan tu vao Stack\n";
        cout << "3. Xoa phan tu dau Stack\n";
        cout << "4. Hien thi Stack\n";
        cout << "5. Duyet DFS tren do thi\n";
        cout << "0. Thoat\n";
        cout << "Nhap lua chon: ";
        cin >> choice;

        switch (choice)
        {
        case 1:
            Input(s);
            break;


        case 2:
            cout << "Nhap phan tu can them: ";
            cin >> x;
            if (Push(s, x))
                cout << "Them thanh cong.\n";
            else
                cout << "Them that bai.\n";
            break;



        case 3:
            if (Pop(s, x))
                cout << "Xoa thanh cong phan tu: " << x << endl;
            else
                cout << "Stack rong, khong the xoa.\n";
            break;


        case 4:
        {
            DisplayStack(s);
            break;
        }
        case 5: {
            int V, E;
            cout << "Nhap so dinh va so canh cua do thi: ";
            cin >> V >> E;

            List.assign(V + 1, vector<int>());
            visited.assign(V + 1, false);

            cout << "Nhap cac canh (dinh1 dinh2):\n";
            for (int i = 0; i < E; ++i)
            {
                int u, v;
                cin >> u >> v;
                List[u].push_back(v);
                List[v].push_back(u);
            }

            int start;
            cout << "Nhap dinh bat dau duyet DFS: ";
            cin >> start;

            Push(s, start);
            cout << "Duyet DFS: ";
            DFS(s, List, visited);
        } break;

        case 0:
            cout << "Thoat chuong trinh.\n";
            break;
        default:
            cout << "Lua chon khong hop le, vui long nhap lai.\n";
        }
    } while (choice != 0);

    return 0;
}

