#include <iostream>
#include <limits>
using namespace std;
#define element_type int

struct tnode{
	element_type key;
	tnode *pright;
	tnode *pleft;
};

tnode *createNew( element_type value)
{
	tnode *newnode = new tnode;
	newnode->key = value;
	newnode->pright = newnode->pleft = NULL;
	return newnode;
}

void initTree(tnode *&root)
{
	root = NULL;
}
int emptyTree( tnode* root)
{
	return root == NULL;
}

void insertNode(tnode *&root, element_type value)
{
	if( root == NULL)
		root = createNew(value);
	else if (value < root->key)
		insertNode( root->pleft, value);
	else if (value > root->key )
		insertNode( root->pright, value);
}

tnode *findmax( tnode *root)
{
	while (root && root->pright)
		root = root->pright;
	return root;
}


tnode *search(tnode *root, element_type value)
{
	if( root == NULL || root->key == value)
		return root;
	else
	{
		if( value < root->key )
			return search(root ->pleft, value);
		if( value > root->key )
			return search(root ->pright, value);
	}
}

void deleteNode(tnode *&root, element_type value)
{
	tnode *key = search(root, value);
	if( !key )
	{
		cout << "Gia tri khong co trong tree !";
		return;
	}
	if( root == NULL)
		return;
	else if( value < root->key)
		deleteNode( root->pleft, value);
	else if( value > root->key)
		deleteNode( root->pright, value);
	else
	{
		if ( root->pleft == NULL)
		{
			tnode *temp = root;
			root = root->pright;
			delete temp;
		}
		else if(root->pright == NULL)
		{
			tnode *temp = root;
			root = root->pleft;
			delete temp;
		}	
		else 
		{
			tnode *tempmax = findmax(root->pleft);
			root->key = tempmax->key;
			deleteNode( root->pleft, tempmax->key);
		}
	}
}


void print_preOrder(tnode *root)
{
	if (root)
	{
		cout << root->key << "	";
		print_preOrder( root->pleft);
		
		print_preOrder(root->pright);
	}
}


void print_inOrder(tnode *root)
{
	if (root)
	{
		print_inOrder( root->pleft);
		
		cout << root->key << "	";
		
		print_inOrder(root->pright);
	}
}

void print_postOrder(tnode *root)
{
	if (root)
	{
		print_postOrder( root->pleft);
		
		print_postOrder(root->pright);
		cout << root->key << "	";
	}
}

int lengthTree( tnode *root)
{
	if (root == NULL)
		return 0;
	int count_left = lengthTree(root->pleft);
	int count_right = lengthTree (root->pright);
	
	return max(count_left, count_right) + 1;
}

int nhanhTree( tnode *root)
{
	if( root == NULL || (root->pleft == NULL || root->pright == NULL ))
		return 0;
	return 1 + nhanhTree( root->pleft) + nhanhTree( root-> pright);
}

int laTree ( tnode *root )
{
	if( root == NULL)
		return 0;
	if (root->pleft == NULL && root->pright == NULL)
		return 1;
	return laTree( root->pleft ) + laTree( root->pright );
}

void insert_kodequy( tnode *&root, element_type value)
{
	tnode* newnode = createNew(value);
    if (root == NULL) 
	{ 
        root = newnode; 
        return;
    }
    tnode* current = root; 
    tnode* parent = NULL; 

    while (current) 
	{
        parent = current; 
        if (value < current->key) 
            current = current->pleft; 
		else 
            current = current->pright; 
    }
    
    if (value < parent->key) 
        parent->pleft = newnode; 
    else 
        parent->pright = newnode;
    
}

tnode *search_kodequy( tnode *root, element_type value)
{
	tnode *current = root;
	while( current && current->key != value)
	{
		if( value < current->key )
			current = current->pleft;
		else
			current = current->pright;
	}
	
	return current;
}

void xoa_kodequy(tnode*& root, element_type value) 
{
    tnode* parent = NULL; 
    tnode* current = root; 

    while (current && current->key != value) 
	{
        parent = current; // 
        if ( value < current->key ) 
            current = current->pleft; 
        else 
            current = current->pright; 
    }

    if (!current) 
		return; 

    if (current->pleft && current->pright) 
	{
        tnode* max = current->pleft; 
        tnode* maxparent = current; 
        while ( max->pright ) 
		{
            maxparent = max; 
            max = max->pright; 
        }
        current->key = max->key;
        current = max; 
        parent = maxparent; 
    }
    
    tnode* child = (current->pleft) ? current->pleft : current->pright; 
    if (!parent) 
	{
        root = child; 
    } 
	else if (parent->pleft == current) 
        parent->pleft = child; 
	else 
        parent->pright = child; 
    delete current; 
}


void nhapTree(tnode *&root)
{
	element_type value;
	cout << "Nhap cac gia tri cho nut cua tree : \n";
	while(true)
	{
		cout << "Nhap gia tri : ";
		cin >> value;
		
		if (cin.fail())
		{
			cin.clear();
			cin.ignore(1000, '\n');
			break;
		}
		insertNode (root, value);
	}
}

int main()
{
	tnode *tree;
	initTree( tree );
	nhapTree( tree );
	
	cout << "Menu : \n";
	cout << "1. Kiem tra cay rong\n";
	cout << "2. Them mot phan tu vao cay\n";
	cout << "3. Xoa mot phan tu trong cay\n";
	cout << "4. Tim mot phan tu trong cay\n";
	cout << "5. Xuat cay\n";
	
	cout << "6. Chieu cao cua cay\n";
	cout << "7. Dem so nhanh cua cay\n";
	cout << "8. Dem so la cua cay\n";
	cout << "9. Them mot phan tu vao cay ma khong dung de quy\n";
	cout << "10. Xoa mot phan tu trong cay ma khong dung de quy\n";
	cout << "11. Tim mot phan tu trong cay ma khong dung de quy\n";
	
	int choice;
	cout << "Lua chon : ";
	cin >> choice;
	while(true)
	{
		switch(choice)
		{
			case 1:
				{
					if( emptyTree( tree) )
						cout << "Cay rong !";
					else 
						cout << "Cay khong rong!";
					break;
				}
			case 2:
				{
					element_type value;
					cout << "Nhap gia tri muon them :";
					cin >> value;
					insertNode(tree, value);
					break;
				}
			case 3:
				{
					element_type value;
					cout << "Nhap gia tri muon xoa :";
					cin >> value;
					deleteNode(tree, value);
					break;
				}
			case 4:
				{
					element_type key_search;
					cout << "Nhap gia tri nut muon tim trong tree : ";
					cin >> key_search;
					tnode *key = search( tree, key_search);
					if( key )
						cout << "Tim thay nut(key) trong tree co gia tri " << key_search << endl;
					else
						cout << "Khong tim thay nut(key) trong tree co gia tri " << key_search << endl;
						
					break;
				}
			case 5:
				{
					cout <<"1. Xuat theo kieu tien tu \n";
					cout <<"2. Xuat theo kieu trung tu \n";
					cout <<"3. Xuat theo kieu hau tu \n";
					int choice;
					cout << "Chon kieu xuat :";
					cin >> choice;
					switch(choice)
					{
						case 1: 
						{
							cout <<"Duyet tien tu : \n";
							print_preOrder(tree);
							cout << endl;
							break;
						}
						case 2:
						{
							cout << "Duyen trung tu : \n";
							print_inOrder(tree);
							cout<< endl;
							break;
						}
						case 3:
						{
							cout << "Duyet hau tu : \n";
							print_postOrder( tree);
							cout <<endl;
						}
					}
				}
			case 6:
				{
					cout <<"Chieu cao cua cay la : " << lengthTree(tree) << endl;
					break;
				}
			case 7:
				{
					cout << "So nhanh cua cay la : " << nhanhTree(tree) << endl;
					break;
				}
			case 8:
				{
					cout << "So la cua cay la : " << laTree (tree) << endl;
					break;
				}
			
			case 9:
				{
					element_type value;
					cout << "Nhap gia tri muon them :";
					cin >> value;
					insert_kodequy(tree, value);
					break;
				}	
			case 10:
				{
					element_type value;
					cout << "Nhap gia tri muon xoa :";
					cin >> value;
					xoa_kodequy(tree, value);
					break;
				}
			case 11:
				{
					element_type key_search;
					cout << "Nhap gia tri nut muon tim trong tree : ";
					cin >> key_search;
					tnode *key = search_kodequy( tree, key_search);
					if( key )
						cout << "Tim thay nut(key) trong tree co gia tri " << key_search << endl;
					else
						cout << "Khong tim thay nut(key) trong tree co gia tri " << key_search << endl;
						
					break;
				}
		}
		cout << "\nLua chon : ";
		cin >> choice;
		if (cin.fail())
		{
			cin.clear();
			cin.ignore(1000, '\n');
			break;
		}
	}
	
	return 0;
}
