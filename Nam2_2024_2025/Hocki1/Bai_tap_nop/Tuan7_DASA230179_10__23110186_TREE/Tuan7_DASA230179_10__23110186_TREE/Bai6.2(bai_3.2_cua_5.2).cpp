/*23110186 Ton Hoang Cam */
#include <iostream>
#include <string>
#include <sstream>
#include <cctype>
using namespace std;


struct Node {
    string word;
    int count;
    Node* left;
    Node* right;
    Node(const string& w) : word(w), count(1), left(NULL), right(NULL) {}
};


Node* insert(Node* root, const string& word) 
{
    if (!root) 
        return new Node(word);
    
    if (word == root->word) 
        root->count++;  
    else if (word < root->word) 
        root->left = insert(root->left, word);
    else 
        root->right = insert(root->right, word);
    
    return root;
}


Node* buildTree(const string& text) 
{
    Node* root = NULL;
    istringstream iss(text);
    string word;
    while (iss >> word) 
	{
        for (size_t i = 0; i < word.length(); ++i) 
    		word[i] = tolower(word[i]);
        
        root = insert(root, word);
    }
    return root;
}


void printTree(Node* root) 
{
    if (!root) 
		return;
    
	printTree(root->left);
    	
    cout << root->word << ": " << root->count << endl;
    printTree(root->right);
}


void deleteTree(Node* root) 
{
    if (!root) 
		return;
		
    deleteTree(root->left);
    deleteTree(root->right);
    
    delete root;
}

int main() 
{
	string text;
    cout << "Nhap van ban can thong ke : ";
    getline(cin, text);  

    Node* root = buildTree(text);  
    
    cout << "Thong ke :" << endl;
    printTree(root); 
    
    deleteTree(root);
    return 0;
}
