#include <iostream>
#include <string>
#include <vector>
#include <list>
#include <fstream>
using namespace std;

const int Table_Size = 1000;

struct HashNode {
	string key;
	string value;

	HashNode( string k, string v) : key( k ), value( v ) {}
};

class HashTable {
private:
	vector< list<HashNode> > table;
	
	int hashFunction(const string& key)
	{
		int hash = 0;
		for (char character : key)
		{
			hash = (hash * 31 + character) % Table_Size;
		}
		return hash;
	}

public:
	HashTable()
	{
		table.resize(Table_Size);
	}

	void insert(const string& key, const string& value)
	{
		int index = hashFunction(key);

		for (auto& node : table[index])
		{
			if (node.key == key)
			{
				node.value = value;
				return;
			}
		}
		table[index].emplace_back(key, value);
	}

	string search(const string& key)
	{
		int index = hashFunction(key);
		for (const auto& node : table[index])
		{
			if (node.key == key)
				return node.value;
		}
		return "Khong tim thay tu nay trong tu dien !";
	}

	void remove(const string& key)
	{
		int index = hashFunction(key);
		auto& chain = table[index];

		for (auto it = chain.begin(); it != chain.end(); ++it)
		{
			if (it->key == key)
			{
				chain.erase(it);
				cout << "Da xoa tu '" << key << "' khoi tu dien\n";
				return;
			}
		}
		cout << "Tu '" << key << "' khong ton tai trong tu dien !\n";
	}

	void printDictionary()
	{
		for (int i = 0; i < Table_Size; ++i)
		{
			if (!table[i].empty())
			{
				for (const auto& node : table[i] )
					cout << "	" << node.key << ": " << node.value << endl;
			}
		}
	}

	void save(const string& filename)
	{
		ofstream file(filename, ios::binary);
		if (!file)
		{
			cerr << "Khong the mo tep de ghi !\n";
			return;
		}
		for (const auto& chain : table)
		{
			for (const auto& node : chain)
			{
				int keyLen = node.key.size();
				int valueLen = node.value.size();

				file.write( (char*)&keyLen, sizeof(keyLen) );
				file.write(node.key.c_str(), keyLen);

				file.write((char*)&valueLen, sizeof(valueLen));
				file.write(node.value.c_str(), valueLen);
			}
		}

		file.close();
		cout << "Da luu du lieu vao tep" << filename << " \n";
	}

	void load(const string& filename)
	{
		ifstream file(filename, ios::binary);
		if (!file)
		{
			cerr << "Khong the mo tep !";
			return;
		}
		
		while (file)
		{
			int keyLen, valueLen;

			file.read((char*)&keyLen, sizeof(keyLen));
			if (!file)
				break;

			string key(keyLen, ' ');
			file.read(&key[0], keyLen);

			file.read((char*)&valueLen, sizeof(valueLen));

			string value(valueLen, ' ');
			file.read(&value[0], valueLen);

			insert(key, value);
		}
		file.close();
		cout << "Da load du lieu tu tep " << filename << " \n";
	}

};

int main()
{
	HashTable dictionary;
	const string filename = "dictionary.bin";
	dictionary.load(filename);

	int choice;

	do
	{
		cout << "Menu : \n";
		cout << "1. Them tu\n";
		cout << "2. Tra cuu tu\n";
		cout << "3. Xoa tu\n";
		cout << "4. Hien thi tu dien\n";
		cout << "5. Luu va thoat\n";
		cout << "Lua chon : ";
		cin >> choice;


		switch (choice)
		{
		case 1:
		{
			string key, value;
			cout << "Nhap tu tieng Anh : ";
			cin >> key;
			cin.ignore();

			cout << "Nhap nghia tieng Viet : ";
			getline(cin, value);
			dictionary.insert(key, value);
			cout << "Da them vao tu dien.\n";
			break;
		}
		case 2:
		{
			string key;
			cout << "Nhap tu tieng anh can tra cuu : ";
			cin >> key;
			cout << "Nghia : " << dictionary.search(key) << endl;
			break;
		}
		case 3:
		{
			string key;
			cout << "Nhap tu can xoa : ";
			cin >> key;
			dictionary.remove(key);
			break;
		}
		case 4:
		{
			cout << "Tu dien : \n";
			dictionary.printDictionary();
			break;
		}
		case 5:
			dictionary.save(filename);
			cout << "Thoat chuong trinh.\n";
			break;
		default:
			cout << "Lua chon khong hop le. Xin nhap lai.\n";
		}

	} while (choice != 5);

	return 0;
}
