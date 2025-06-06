/*Ton Hoang Cam
23110186 */
#include <iostream> 
#include <limits>
#include <string>
#include <algorithm>
using namespace std;


struct Node{
	int info;
	Node* pnext;
};

struct Stack{
	Node* ptop;
	Node* ptail;
};

void initStack(Stack &s)
{
	s.ptop = NULL;
	s.ptail = NULL;
}

Node *createNode(int value)
{
	Node *newnode = new Node;
	newnode->info = value;
	newnode->pnext = NULL;
	return newnode;
}

bool isEmpty(Stack s)
{
	return s.ptop == NULL;
}

void push(Stack &s, Node *newnode)
{
	if(newnode == NULL)
		return;
	newnode->pnext = s.ptop;
	s.ptop = newnode;
}

Node *pop(Stack &s)
{
	if ( isEmpty(s) )
		return NULL;
	Node *temp = s.ptop;
	s.ptop = s.ptop -> pnext;
	return temp;
}


void deci_bina(int value)
{
	Stack s;
	initStack(s);
	while( value > 0)
	{
		push(s, createNode( value % 2 ) );
		value /= 2;
	}
	cout << "So nhi phan la : ";
	while( !isEmpty(s) )
	{
		Node *temp = pop(s);
		cout << temp->info;
		delete temp;
	}
	cout << endl;
} 

int bina_deci(string bina)
{
	int deci = 0;
	int base = 1;
	for (int i = bina.length() - 1; i >= 0; i--) 
	{
        if (bina[i] == '1') 
		{
            deci += base;
        }
        base *= 2;
    }
    return deci;
}

string deci_hexa(int deci) 
{
    string hex;
    if (deci == 0) 
        hex.push_back('0');
	else 
	{
        while (deci > 0) 
		{
            int remember = deci % 16; 
            deci /= 16; 

            char hexchar; 
            if (remember < 10) 
                hexchar = remember + '0'; 
			else 
                hexchar = remember - 10 + 'A';
            
            hex.push_back( hexchar ); 
        }
    }

    reverse( hex.begin(), hex.end() );
    return hex;
}

int hexa_deci(const string &hex)
{
	int deci = 0;
    int base = 1; 
    int len = hex.length();

    for (int i = len - 1; i >= 0; i--) 
	{
        char kitu = hex[i];
        int value;

        if (kitu >= '0' && kitu <= '9') 
            value = kitu - '0'; 
		else if (kitu >= 'A' && kitu <= 'F') 
            value = kitu - 'A' + 10; 
		else 
		{
			cout << "Ky tu khong hop le: " << kitu << endl;
            return -1;
		} 

        deci += value * base; 
        base *= 16; 
    }
    
    return deci;
}

int main()
{
	
	cout << "Menu:\n";
    cout << "1. Chuyen doi tu thap phan sang nhi phan\n";
    cout << "2. Chuyen doi tu nhi phan sang thap phan\n";
    cout << "3. Chuyen doi tu thap phan sang he 16\n";
    cout << "4. Chuyen doi tu he 16 sang thap phan\n";

    int choose;
    while (true) 
	{
        cout << "Lua chon cua ban: ";
        cin >> choose;
        if ( choose >= 5 || choose <= 0) 
			break;

        switch (choose) 
		{
            case 1: 
			{
                int deci;
                cout << "Nhap so thap phan: ";
                cin >> deci;
                deci_bina(deci);
                break;
            }
            case 2: 
			{
                string bina;
                cout << "Nhap so nhi phan: ";
                cin >> bina;
                int deci = bina_deci(bina);
                cout << "So thap phan la : " << deci << endl;
                break;
            }
            case 3: 
			{
                int deci;
			    cout << "Nhap gia tri thap phan: ";
			    cin >> deci;
			
			    string chuoihex = deci_hexa(deci);
			    cout << "Gia tri thap luc phan: " << chuoihex << endl;
                break;
            }
            case 4: 
			{
                string chuoihex;
				cout << "Nhap gia tri thap luc phan : ";
				cin.ignore();
				getline(cin, chuoihex);
			
				int deci = hexa_deci(chuoihex);
				if (deci != -1) 
				    cout << "So thap phan tu so thap luc phan " << chuoihex << " la: " << deci << endl;
                break;
            }
           
        }
    }
    
	return 0;
}
