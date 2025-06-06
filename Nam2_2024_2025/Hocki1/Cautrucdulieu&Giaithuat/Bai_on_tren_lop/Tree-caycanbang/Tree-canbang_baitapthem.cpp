#include <iostream>
#include <set>
#include <map>
#include <algorithm>
#include <climits>
using namespace std;
#define element_type int

struct treeNode{
	element_type value;
	treeNode *left;
	treeNode *right;
	int height;
};

int nodeHeight(treeNode *node)
{
	return ( !node ) ? 0 : node->height;
}

treeNode *createNode(element_type value)
{
	treeNode *newNode = new treeNode();
	
	newNode->value = value;
	newNode->right = NULL;
	newNode->left = NULL;
	newNode->height = 1;
	
	return newNode;
}

element_type getMax(element_type a, element_type b)
{
	return (a > b) ? a : b;
}

int balance(treeNode *node)
{
	return ( !node ) ? 0 : nodeHeight( node->left ) - nodeHeight(node->right);
}

treeNode *quayphai(treeNode *nodegoc)
{
	treeNode *x = nodegoc->left;
	treeNode *t1 = x->right;
	
	x->right = nodegoc;
	nodegoc->left = t1;
	
	nodegoc->height = getMax( nodeHeight(nodegoc->left) , nodeHeight(nodegoc->right)) + 1;
	x->height = getMax( nodeHeight(x->left) , nodeHeight(x->right)) + 1;
	
	return x;
}

treeNode *quaytrai( treeNode *nodegoc)
{
	treeNode *x = nodegoc->right;
	treeNode *t1 = x->left;
	
	x->left = nodegoc;
	nodegoc->right = t1;
	
	nodegoc->height = getMax( nodeHeight(nodegoc->left) , nodeHeight(nodegoc->right)) + 1;
	x->height = getMax( nodeHeight(x->left) , nodeHeight(x->right)) + 1;
	
	return x;
}

treeNode *insertNode( treeNode *root, element_type value)
{
	if ( !root )
		return createNode( value );
		
	if( value < root->value)
		root->left = insertNode( root->left, value);
	else if (value > root->value)
		root->right = insertNode(root->right, value);
	else
		return root;
		
	
	int balance_level = balance( root );
	
	if (balance_level > 1 && value < root->left->value)
		return quayphai(root);
	if (balance_level < -1 && value > root->right->value)
		return quaytrai(root);
		
	if (balance_level > 1 && value > root->left->value)
	{
		root->left = quaytrai(root->left);
		return quayphai(root);
	}
	if (balance_level < -1 && value < root->right->value)
	{
		root->right = quayphai(root->right);
		return quaytrai(root);
	}
	
	return root;
}


int treeHeight( treeNode *root)
{
	return ( !root ) ? 0 : 1 + getMax( nodeHeight(root->left), nodeHeight(root->right) );
}

int dem_nodeBranch( treeNode *&root)
{
	if ( !root || (root->left == NULL && root->right == NULL))
		return 0;
	return 1 + dem_nodeBranch(root->left) + dem_nodeBranch(root->right);
}

int dem_nodeLeaf(  treeNode *root)
{
	if (!root)
		return 0;
	if (root->left == NULL && root->right == NULL)
		return 1;
	
	return dem_nodeLeaf(root->left) + dem_nodeLeaf(root->right);
}

int dem_giatri_chan(treeNode *root)
{
	if (!root)
		return 0;
	
	int count = (root->value % 2 == 0) ? 1 : 0;
	
	return count + dem_giatri_chan(root->left) + dem_giatri_chan(root->right);
}

element_type sumTree( treeNode *root)
{
	if (!root)
		return 0;
	
	return root->value + sumTree(root->left) + sumTree(root->right);
}

element_type find_max(treeNode* root) 
{
    if ( !root )
        return INT_MIN;
        
    element_type max_value = root->value;
    
    element_type left_max = find_max(root->left);
    element_type right_max = find_max(root->right);
    
    return getMax( max_value , getMax(left_max, right_max) );
}

element_type find_min(treeNode* root) 
{
    if ( !root )
        return INT_MAX;
        
    element_type min_value = root->value;
    
    element_type left_min = find_min(root->left);
    element_type right_min = find_min(root->right);
    
    return min( min_value , min(left_min, right_min) );
}

element_type so_am_max(treeNode* root, bool &foundNega) 
{
    if ( !root )
        return INT_MIN;
    
    element_type so_am_max_left = so_am_max( root->left, foundNega );
    element_type so_am_max_right = so_am_max(root->right, foundNega );
    
    
    if (root->value < 0) 
	{
        foundNega = true; 
        return getMax(root->value, getMax(so_am_max_left , so_am_max_right)); 
    } 
	else 
        return getMax(so_am_max_left, so_am_max_right);

}


int soluong_giatri_phanbiet(const treeNode *root, set<element_type> &giatri_phanbiet)
{
	if( !root)
		return 0;
	giatri_phanbiet.insert(root->value);
	
	soluong_giatri_phanbiet(root->left, giatri_phanbiet);
	soluong_giatri_phanbiet(root->right, giatri_phanbiet);
	
	return giatri_phanbiet.size();
}

void solan_xuat_hien(const treeNode *root, map<element_type, int> &lst_solanxuathien )
{
	if(!root)
		return;
	
	lst_solanxuathien[ root->value ] ++;
	
	solan_xuat_hien(root->left, lst_solanxuathien);
	solan_xuat_hien(root->right, lst_solanxuathien);
	
}

void display_solanxuathien(const map<element_type, int> &lst_solanxuathien)
{
	for ( map< element_type, int >::const_iterator i = lst_solanxuathien.begin(); i != lst_solanxuathien.end(); ++i ) 
	    cout << "Gia tri: " << i->first << " xuat hien: " << i->second << " lan.\n";
	
}

int main()
{
	treeNode *root = NULL;
	bool foundNegative = false;
	
	element_type value;
	int n;
	
    cout << "Nhap so luong phan tu de tao cay: ";
    cin >> n;
    
    cout << "Nhap cac gia tri de them vao cay:\n";
    for (int i = 0; i < n; ++i) 
	{
        cout << "Phan tu thu " << i + 1 << " : ";
		cin >> value;
		root = insertNode(root, value);
    }

    int choice;
    do {
        cout << "Menu : \n";
        cout << "1. Tinh chieu cao cua cay\n";
        cout << "2. Dem so node nhanh\n";
        cout << "3. Dem so node la\n";
        cout << "4. Dem so phan tu chan\n";
        cout << "5. Tinh tong gia tri cac nut\n";
        cout << "6. Tim gia tri lon nhat va nho nhat\n";
        cout << "7. Tim phan tu am lon nhat\n";
        cout << "8. Dem so luong gia tri phan biet\n";
        cout << "9. Dem so lan xuat hien cua tung gia tri phan biet\n";
        cout << "0. Thoat\n";
        cout << "Nhap lua chon : ";
        cin >> choice;

        switch (choice) 
		{
            case 1: 
			{
                int chieucao = treeHeight(root);
                cout << "Chieu cao cua cay: " << chieucao << endl;
                break;
            }
            case 2: 
			{
                int soluongnodeNhanh = dem_nodeBranch(root);
                cout << "So node nhanh trong cay: " << soluongnodeNhanh << endl;
                break;
            }
            case 3: 
			{
                int soluongleaf = dem_nodeLeaf(root);
                cout << "So node la trong cay: " << soluongleaf << endl;
                break;
            }
            case 4: 
			{
                int soluong_giatrichan = dem_giatri_chan(root);
                cout << "So phan tu chan trong cay: " << soluong_giatrichan << endl;
                break;
            }
            case 5: 
			{
                int sum = sumTree(root);
                cout << "Tong gia tri cac nut trong cay: " << sum << endl;
                break;
            }
            case 6: 
			{
                int max_value = find_max(root);
                int min_value = find_min(root);
                cout << "Gia tri lon nhat trong cay: " << max_value << endl;
                cout << "Gia tri nho nhat trong cay: " << min_value << endl;
                break;
            }
            case 7: 
			{
                int max_nega = so_am_max(root, foundNegative);
                if (foundNegative) {
                    cout << "So am lon nhat trong cay: " << max_nega << endl;
                } 
				else 
                    cout << "Khong co so am trong cay." << endl;
                break;
            }
            case 8: 
			{
                set<element_type> lst_phanbiet;
                int uniqueCount = soluong_giatri_phanbiet(root, lst_phanbiet);
                cout << "So luong gia tri phan biet trong cay: " << uniqueCount << endl;
                break;
            }
            case 9: 
			{
                map<element_type, int> lst_solanxuathien;
                solan_xuat_hien(root, lst_solanxuathien);
                cout << "So lan xuat hien cua tung gia tri phan biet trong cay:\n";
                display_solanxuathien(lst_solanxuathien);
                break;
            }
            case 0:
                cout << "Thoat chuong trinh.\n";
                break;
            default:
                cout << "Lua chon khong hop le. Vui long thu lai.\n";
                break;
        }
    } while (choice != 0);
	return 0;
}
