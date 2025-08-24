//Ton Hoang Cam 23110186 
#include <iostream>
using namespace std;
#define element_type int

struct node{
	element_type key;
	node *left;
	node *right;
	int height;
};

int height(node *n)
{
	return (n == NULL) ? 0 : n->height;
}

node *newnode (element_type key)
{
	node *newnode =new node();
	newnode->key = key;
	newnode->left = NULL;
	newnode->right = NULL;
    newnode->height = 1;
	return newnode;
}

int is_empty(node *root)
{
	return (root == NULL);
}

int max(element_type a, element_type b)
{
	return (a > b) ?a : b;
}

int get_balance(node *n)
{
	return (n == NULL) ? 0 : height( n->left ) - height( n->right);
}

node *quayphai(node *y)
{
	node *x = y->left;
	node *t2 = x->right;
	
	x->right = y;
	y->left = t2;
	
	y->height = max(height(y->left), height(y->right)) + 1;
    x->height = max(height(x->left), height(x->right)) + 1;
	
	return x;
}

node *quaytrai( node *x)
{
	node *y = x->right;
	node *t2 = y->left;
	
	y->left = x;
	x->right = t2;
	
	y->height = max(height(y->left), height(y->right)) + 1;
    x->height = max(height(x->left), height(x->right)) + 1;
    
    return y;
}

node *insertnode(node *nut, element_type key)
{
	if (nut == NULL)
		return newnode(key);
		
		
	if (key < nut->key)
		nut->left =	insertnode(nut->left, key);
	else if (key >nut->key)
		nut->right = insertnode(nut->right, key);
	else
		return nut;
	
	nut->height = 1 + max( height(nut->left), height(nut->right));
	
	int balance = get_balance(nut);
	
	 if (balance > 1 && key < nut->left->key)
        return quayphai(nut);

    if (balance < -1 && key > nut->right->key)
        return quaytrai(nut);

    if (balance > 1 && key > nut->left->key) 
	{
        nut->left = quaytrai(nut->left);
        return quayphai(nut);
    }
    
    if (balance < -1 && key < nut->right->key) 
	{
        nut->right = quayphai(nut->right);
        return quaytrai(nut);
    }

    return nut;
}


node* min_node(node* root) 
{
    node* current = root;
    while (current && current->left != NULL) 
        current = current->left;
        
    return current;
}

node* deletenode( node* root, element_type key, bool deleted) 
{
    if (!root) 
	{
		deleted = false;
		return root;
	}


    if (key < root->key) 
        root->left = deletenode(root->left, key, deleted);
    else if (key > root->key) 
        root->right = deletenode(root->right, key, deleted);
    else 
	{
        if ((root->left == NULL) || (root->right == NULL)) 
		{
            node* temp = root->left ? root->left : root->right;
            if (temp == NULL) 
			{
                temp = root;
                root = NULL;
            } 
			else 
                *root = *temp; 
                
            delete temp;
        } 
		else 
		{
            node* temp = min_node(root->right);
            root->key = temp->key;
            root->right = deletenode(root->right, temp->key, deleted);
        }
    }

    if (!root) 
		return root;

   
    root->height = 1 + max(height(root->left), height(root->right));

    
    int balance = get_balance(root);

    
    if (balance > 1 && get_balance(root->left) >= 0) 
        return quayphai(root);
    

    if (balance > 1 && get_balance(root->left) < 0) 
	{
        root->left = quaytrai(root->left);
        return quayphai(root);
    }

    if (balance < -1 && get_balance(root->right) <= 0) 
        return quaytrai(root);
    

    if (balance < -1 && get_balance(root->right) > 0) 
	{
        root->right = quayphai(root->right);
        return quaytrai(root);
    }

    return root;
}


node *timkiem( node* root, element_type key) 
{
    if (!root || root->key == key) 
        return root;
    
    if (key < root->key) 
        return timkiem(root->left, key);
    
    return timkiem(root->right, key);
}

void xuat_tientu(node *root)
{
	if(root != NULL)
	{
		cout << root->key << " ";
		xuat_tientu( root->left );
		
		xuat_tientu(root->right);
	}
}

void xuat_trungtu(node *root)
{
	if(root != NULL)
	{
		xuat_trungtu( root->left );
		cout << root->key << " ";
		xuat_trungtu(root->right);
	}
}

void xuat_hautu(node *root)
{
	if(root != NULL)
	{
		xuat_hautu( root->left );
		
		xuat_hautu(root->right);
		
		cout << root->key << " ";
	}
}

void delete_tree(node *root)
{
	if(root)
	{
		delete_tree(root->left);
		delete_tree(root->right);
		delete root;
	}
}

int main()
{
	node *root = NULL;
	element_type value;
	int n;
	
	cout << "Nhap vao so luong phan tu de khoi tao cay !";
	cin >> n;
	
	cout << "Nhap cac phan tu nut cho cay : ";
	for (int i = 0 ; i < n ;i ++)
	{
		cout << "Phan tu thu " << i + 1 << " : ";
		cin >> value;
		root = insertnode(root, value);
	}
	
	
	int choice;
    element_type key;
    cout << "Menu\n";
        cout << "1. Them phan tu vao cay\n";
        cout << "2. Xoa phan tu khoi cay\n";
        cout << "3. Tim kiem phan tu trong cay\n";
        cout << "4. Xuat cay theo kieu tien tu (Pre-Order)\n";
        cout << "5. Xuat cay theo kieu trung tu (In-Order)\n";
        cout << "6. Xuat cay theo kieu hau tu (Post-Order)\n";
        cout << "0. Thoat\n";
    do 
    {
        cout << "Nhap lua chon cua ban: ";
        cin >> choice;

        switch (choice) 
		{
            case 1:
                cout << "Nhap gia tri can them: ";
                cin >> key;
                root = insertnode(root, key);
                break;
            case 2:
                {
                	cout << "Nhap gia tri can xoa: ";
	                cin >> key;
	                bool deleted = false;
	                root = deletenode(root, key, deleted);
	                if (deleted)
	                    cout << "Gia tri " << key << " da duoc xoa.\n";
	                else
	                    cout << "Gia tri " << key << " khong tim thay trong cay.\n";
                break;
                }
            case 3:
                cout << "Nhap gia tri can tim: ";
                cin >> key;
                
                if ( timkiem(root, key) != NULL) 
                    cout << "Da tim thay phan tu " << key << " trong cay.\n";
                else 
                    cout << "Khong tim thay phan tu " << key << " trong cay.\n";
                
                break;
            case 4:
                cout << "Cay can bang theo kieu tien tu: ";
                xuat_tientu(root);
                cout << endl;
                break;
            case 5:
                cout << "Cay can bang theo kieu trung tu: ";
                xuat_trungtu(root);
                cout << endl;
                break;
            case 6:
                cout << "Cay can bang theo kieu hau tu: ";
                xuat_hautu(root);
                cout << endl;
                break;
            case 0:
            	delete_tree(root);
                cout << "Thoat chuong trinh.\n";
                break;
            default:
                cout << "Lua chon khong hop le. Vui long thu lai.\n";
                break;
        }
    } while (choice != 0);
   
	
	return 0;
}
