/*23110186 Ton Hoang Cam */
#include <iostream>
#include <limits>
#include <set>
#include <map>
using namespace std;

#define element_type int 

struct Node 
{
    element_type value; 
    Node* left; 
    Node* right;
};


Node* createNode(element_type value) 
{
    Node* newNode = new Node();
    newNode->value = value;
    newNode->left = newNode->right = NULL;
    return newNode;
}


bool empty(Node* tree) 
{
    return tree == NULL;
}


Node* insertNode(Node* tree, element_type value) 
{
    if (empty(tree)) 
        return createNode(value);
    
    if (value < tree->value) 
        tree->left = insertNode(tree->left, value);
    else if (value > tree->value) 
        tree->right = insertNode(tree->right, value);

    return tree;
}


Node* inputTree( Node* tree )
{
	element_type value;
	cout << "Nhap cac gia tri cho cay : \n";
	cout << "Nhap gia tri : ";
	while(true)
	{
		cin >> value;
    	if (cin.fail())
    	{
    		cin.clear();
    		cin.ignore(1000, '\n');
    		break;
		}
    	tree = insertNode(tree, value);
	}
	
	return tree; 
}


Node* FindNode(Node* tree, element_type value) 
{
    if (empty(tree) || tree->value == value) 
        return tree;
    
    if (value < tree->value) 
        return FindNode(tree->left, value);
    
    return FindNode(tree->right, value);
}


void PreOrder(Node* tree) 
{
    if (!empty(tree)) 
	{
        cout << tree->value << " ";
        PreOrder(tree->left);
        PreOrder(tree->right);
    }
}


void InOrder(Node* tree) 
{
    if (!empty(tree)) 
	{
        InOrder(tree->left);
        cout << tree->value << " ";
        InOrder(tree->right);
    }
}


void PostOrder(Node* tree) 
{
    if (!empty(tree)) 
	{
        PostOrder(tree->left);
        PostOrder(tree->right);
        cout << tree->value << " ";
    }
}


int chieucao(Node* tree) 
{
    if (empty(tree)) 
        return 0;
    return 1 + max(chieucao(tree->left), chieucao(tree->right));
}


int nhanh_tree(Node* tree) 
{
    if (empty(tree)) 
        return 0;
    
    if (empty(tree->left) && empty(tree->right)) 
        return 0;
    
    return 1 + nhanh_tree(tree->left) + nhanh_tree(tree->right);
}


int la_tree(Node* tree) 
{
    if (empty(tree)) 
        return 0;
    
    if (empty(tree->left) && empty(tree->right)) 
        return 1;
    
    return la_tree(tree->left) + la_tree(tree->right);
}

int node_chan(Node* tree) 
{
    if (empty(tree)) 
        return 0;
        
    return (tree->value % 2 == 0 ? 1 : 0) + node_chan(tree->left) + node_chan(tree->right);
}


int sum_tree(Node* tree) 
{
    if (empty(tree)) 
        return 0;
    
    return tree->value + sum_tree(tree->left) + sum_tree(tree->right);
}

element_type tim_max(Node* tree) 
{
    while (tree->right != NULL) 
        tree = tree->right;

    return tree->value;
}


element_type tim_min(Node* tree) 
{
    while (tree->left != NULL) 
        tree = tree->left;
    
    return tree->value;
}


element_type tim_max_am(Node* tree) 
{
	bool found_nega = false;
    element_type max_am = numeric_limits<element_type>::min();
    
    if (empty(tree)) 
		return 0;
    
    if (tree->value < 0) 
    {
    	max_am = max(max_am, tree->value);
    	found_nega = true;
	}
    
    
    element_type max_am_left = max(max_am, tim_max_am(tree->left) );
    element_type max_am_right = max(max_am, tim_max_am(tree->right) );
    
    if (max_am_left < 0) 
	{
		if (found_nega)
			max_am = max(max_am, max_am_left);
		else
			max_am = max_am_left;
    }
    
    if (max_am_right < 0) 
	{
		if (found_nega)
			max_am = max(max_am, max_am_right);
		else
			max_am = max_am_right;
    }
    
    return found_nega ? max_am : 0;
}


int soluong_giatri_phanbiet(Node* tree, set<element_type>& giatri_phanbiet) 
{
    if (empty(tree)) return 0;
    giatri_phanbiet.insert(tree->value);
    
    soluong_giatri_phanbiet(tree->left, giatri_phanbiet);
    soluong_giatri_phanbiet(tree->right, giatri_phanbiet);
    
    return giatri_phanbiet.size();
}

void soluong_moiphantu(Node *tree, map<element_type, int> &ds_soluong)
{
	if (empty(tree))
		return;
	
	ds_soluong [tree->value]++;
	soluong_moiphantu( tree->left, ds_soluong);
	soluong_moiphantu( tree->right, ds_soluong);
}

int main() 
{
	Node* tree = NULL;
	tree = inputTree(tree);
	
	
	element_type choice, value;

    cout << "Menu:\n";
    cout << "1. Them gia tri vao cay\n";
    cout << "2. Tim mot gia tri trong cay\n";
    cout << "3. Xuat theo kieu tien tu\n";
    cout << "4. Xuat theo kieu trung tu\n";
    cout << "5. Xuat theo kieu hau tu\n";
    cout << "6. Chieu cao cay\n";
    cout << "7. So nut nhanh cay\n";
    cout << "8. So nut la cay\n";
    cout << "9. So gia tri chan tren cay\n";
    cout << "10. Tong tat ca cac gia tri tren cay\n";
    cout << "11. Gia tri lon nhat tren cay\n";
    cout << "12. Gia tri nho nhat tren cay\n";
    cout << "13. Gia tri am lon nhat tren cay\n";
    cout << "14. So luong gia tri phan biet tren cay\n";
    cout << "15. So luong phan tu cho tung gia tri phan biet\n";
    
    
    cout << "Lua chon : ";
    cin >> choice;
    while( true)
    {
    	if (cin.fail() || choice <=0 || choice >11)
    	{
    		cout << "Lua chon khong hop le !";
    		cin.clear();
    		cin.ignore(1000, '\n');
    		continue;
		}
		else
			break;
	}
	
	while (true) 
	{
		switch (choice) 
		{
            case 1:
                cout << "Nhap gia tri muon them: ";
                cin >> value;
                tree = insertNode(tree, value);
                break;
            case 2:
                cout << "Nhap gia tri muon tim: ";
                cin >> value;
                if (FindNode(tree, value) == NULL) 
                    cout << "Khong tim thay gia tri " << value <<" trong cay !" << endl;
                else 
                	cout << "Tim thay gia tri " << value << " trong cay !" <<endl;
                break;
            case 3:
                PreOrder(tree);
                cout << endl;
                break;
            case 4:
                InOrder(tree);
                cout << endl;
                break;
            case 5:
                PostOrder(tree);
                cout << endl;
                break;
            case 6:
                cout << "Chieu cao cua cay: " << chieucao(tree) << endl;
                break;
            case 7:
                cout << "So nut nhanh cay: " << nhanh_tree(tree) << endl;
                break;
            case 8:
                cout << "So nut la cay: " << la_tree(tree) << endl;
                break;
            case 9:
                cout << "So luong gia tri chan tren cay: " << node_chan(tree) << endl;
                break;
            case 10:
                cout << "Tong tat ca gia tri tren cay: " << sum_tree(tree) << endl;
                break;
            case 11:
                cout << "Gia tri lon nhat tren cay: " << tim_max(tree) << endl;
                break;
            case 12:
                cout << "Gia tri nho nhat tren cay: " << tim_min(tree) << endl;
                break;
            case 13:
            	if (tim_max_am(tree) == 0)
            		cout << "Khong co gia tri am tren cay !";
            	else
                	cout << "Gia tri am lon nhat tren cay: " << tim_max_am(tree) << endl;
                break;
            case 14: 
			{
                set<element_type> giatri_phanbiet;
                cout << "So luong gia tri phan biet trong cay: " << soluong_giatri_phanbiet(tree, giatri_phanbiet) << endl;
                break;
            }
            case 15:
            {
                map< element_type, int> ds_soluong;
                soluong_moiphantu(tree, ds_soluong);
                cout << "So luong phan tu cho moi gia tri phan biet: " << endl;
                for (map< element_type, int> :: iterator it = ds_soluong.begin(); it != ds_soluong.end(); ++it) 
                    cout << "Gia tri: " << it->first << "	,So luong: " << it->second << endl;
            
                break;
            }
        }
        cout << "Lua chon (chon bat ki ki tu khac menu de thoat) : ";
    	cin >> choice;
    	if (cin.fail() || choice <=0 || choice >15)
    		break;
	}
        
    return 0;
}
