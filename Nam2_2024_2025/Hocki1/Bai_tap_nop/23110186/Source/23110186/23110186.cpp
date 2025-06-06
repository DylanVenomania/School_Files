#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include <algorithm>
using namespace std;

struct treeNode {
    string english;
    string vietnamese;

    treeNode* left;
    treeNode* right;

    int height;

    treeNode(string eng, string viet) : english(eng), vietnamese(viet), left(NULL), right(NULL), height(1) {}
};

int height(treeNode* node)
{
    return !node ? 0 : node->height;
}

void updateHeight(treeNode* node)
{
    node->height = 1 + max(height(node->left), height(node->right));
}

treeNode* quayphai(treeNode* node_goc)
{
    treeNode* x = node_goc->left;
    treeNode* T2 = x->right;

    x->right = node_goc;
    node_goc->left = T2;

    updateHeight(node_goc);
    updateHeight(x);

    return x;
}

treeNode* quaytrai(treeNode* node_goc)
{
    treeNode* x = node_goc->right;
    treeNode* T2 = x->left;

    x->left = node_goc;
    node_goc->right = T2;

    updateHeight(node_goc);
    updateHeight(x);

    return x;
}

treeNode* insertNode(treeNode* root, const string& english, const string& vietnamese)
{
    if (!root)
        return new treeNode(english, vietnamese);

    if (english < root->english)
        root->left = insertNode(root->left, english, vietnamese);

    else if (english > root->english)
        root->right = insertNode(root->right, english, vietnamese);

    else
        return root;


    root->height = 1 + max(height(root->left), height(root->right));

    int balance_level = height(root->left) - height(root->right);


    if (balance_level > 1 && english < root->left->english)
        return quayphai(root);

    if (balance_level < -1 && english > root->right->english)
        return quaytrai(root);

    if (balance_level > 1 && english > root->left->english)
    {
        root->left = quaytrai(root->left);
        return quayphai(root);
    }

    if (balance_level < -1 && english < root->right->english)
    {
        root->right = quayphai(root->right);
        return quaytrai(root);
    }

    return root;
}

treeNode* minValueNode(treeNode* node)
{
    treeNode* current = node;

    while (current->left)
        current = current->left;

    return current;
}

treeNode* deleteNode(treeNode* root, const string& english)
{
    if (!root)
        return root;

    if (english < root->english)
        root->left = deleteNode(root->left, english);
    else if (english > root->english)
        root->right = deleteNode(root->right, english);
    else
    {
        if (!root->left || !root->right)
        {
            treeNode* temp = root->left ? root->left : root->right;
            delete root;
            return temp;
        }
        else
        {
            treeNode* temp = minValueNode(root->right);
            root->english = temp->english;
            root->vietnamese = temp->vietnamese;
            root->right = deleteNode(root->right, temp->english);
        }
    }

    updateHeight(root);

    int balance_level = height(root->left) - height(root->right);

    if (balance_level > 1 && height(root->left->left) >= height(root->left->right))
        return quayphai(root);

    if (balance_level > 1 && height(root->left->left) < height(root->left->right))
    {
        root->left = quaytrai(root->left);
        return quayphai(root);
    }

    if (balance_level < -1 && height(root->right->right) >= height(root->right->left))
        return quaytrai(root);

    if (balance_level < -1 && height(root->right->right) < height(root->right->left))
    {
        root->right = quayphai(root->right);
        return quaytrai(root);
    }

    return root;
}


treeNode* searchNode(treeNode* root, const string& english)
{
    if (!root || root->english == english)
        return root;


    if (english < root->english)
        return searchNode(root->left, english);
    else
        return searchNode(root->right, english);
}

void print_tudien(treeNode* node, ofstream& outfile)
{
    if (!node)
        return;

    outfile << node->english << "," << node->vietnamese << ",";

    outfile << (node->left ? node->left->english : "NULL") << ",";
    outfile << (node->right ? node->right->english : "NULL") << endl;

    print_tudien(node->left, outfile);
    print_tudien(node->right, outfile);
}

void readCommands(treeNode*& root, const string& inputFile, const string& outputFile)
{
    ifstream infile(inputFile.c_str());
    ofstream outfile(outputFile.c_str());

    string line;

    while (getline(infile, line))
    {
        stringstream ss(line);
        int command;
        ss >> command;

        if (command == 0)
        {
            int numWords;
            ss >> numWords;
            string wordLine;
            for (int i = 0; i < numWords; ++i)
            {
                getline(infile, wordLine);

                size_t commaPos = wordLine.find(",");

                string english = wordLine.substr(0, commaPos);
                string vietnamese = wordLine.substr(commaPos + 1);

                root = insertNode(root, english, vietnamese);
            }
        }
        else if (command == 1)
        {
            string wordToDelete;
            ss >> wordToDelete;
            root = deleteNode(root, wordToDelete);
        }
        else if (command == 2)
        {
            string wordToFind;
            ss >> wordToFind;
            treeNode* result = searchNode(root, wordToFind);

            if (result)
                outfile << result->english << "," << result->vietnamese << endl;
            else
                outfile << "NULL" << endl;

        }
        else if (command == 3)
        {
            if (root)
            {
                outfile << "goc: " << root->english << endl;
                outfile << "{" << endl;
                print_tudien(root, outfile);
                outfile << "}" << endl;
            }
            else
                outfile << "goc:NULL" << endl;

        }
    }

    infile.close();
    outfile.close();
}


int main()
{
    treeNode* root = NULL;
    string inputFile = "../../Release/input.txt";
    string outputFile = "../../Release/23110186.txt";

    readCommands(root, inputFile, outputFile);

    cout << "Du lieu trong input.txt da duoc lay ! " << outputFile << " da xem ket qua." << endl;

    return 0;
}

