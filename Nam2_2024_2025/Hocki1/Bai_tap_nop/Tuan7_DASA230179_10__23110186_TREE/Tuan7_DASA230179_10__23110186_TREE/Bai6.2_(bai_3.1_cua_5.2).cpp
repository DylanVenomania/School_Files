/*23110186 Ton Hoang Cam */
#include <iostream>
#include <string>
#include <limits>
#include <set>
#include <map>
using namespace std;

struct Node {
    char key;
    int count;  
    Node* left;
    Node* right;

    Node(char k) : key(k), count(1), left(NULL), right(NULL) {}
};


Node* insert(Node* root, char key) 
{
    if (root == NULL) 
        return new Node(key); 
    

    if (key < root->key) 
        root->left = insert(root->left, key);
    else if (key > root->key) 
        root->right = insert(root->right, key);
    else 
        root->count++; 
    
    return root;
}


int search(Node* root, char key) 
{
    if (root == NULL) 
        return 0;
    

    if (key < root->key) 
        return search(root->left, key);
    else if (key > root->key) 
        return search(root->right, key);
    else 
        return root->count; 
    
}

Node* buildTree(const string& text) 
{
    Node* root = NULL;
    for (size_t i = 0; i < text.size(); ++i)  
    {
        char ch = text[i];
        if (isalpha(ch)) 
        {
            ch = tolower(ch); 
            root = insert(root, ch); 
        }
    }
    return root;
}


void deleteTree(Node* root) 
{
    if (root == NULL) 
		return;
		
    deleteTree(root->left);
    deleteTree(root->right);
    
    delete root;
}


int main() 
{
    string text;
    cout << "Nhap van ban: ";
    getline(cin, text); 

    Node* root = buildTree(text); 

    char ch;
    cout << "Nhap ky tu can kiem tra: ";
    cin >> ch;
    ch = tolower(ch); 

    int count = search(root, ch);
    if (count > 0) 
        cout << "Ky tu '" << ch << "' xuat hien " << count << " lan trong van ban." << endl;
    else 
        cout << "Ky tu '" << ch << "' khong xuat hien trong van ban." << endl;
    

    deleteTree(root); 

    return 0;
}
