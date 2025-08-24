#include <iostream>
#include <vector>
#include <list>
#include <string>
#include <cmath>
using namespace std;

struct Student {
	int mssv;
	string name;

    Student() : mssv(0), name("") {}

	Student(int mssv, string name) {
		this->mssv = mssv;
		this->name = name;
	}
};

vector<list <Student> > init_chaining(int size) {
	return vector < list<Student> >(size);
}

void insert_chaining(vector<list <Student> >& hashtable, int size, Student student) {
	int index = student.mssv % size;
	hashtable[index].push_back(student);
}
string search_chaining(vector<list <Student> >& hashtable, int size, int MSSV) {
	int index = MSSV % size;

	for (const auto& student : hashtable[index]) {
		if (student.mssv == MSSV) {
			return student.name;
		}
	}
	return "Khong tim thay !";
}

void display(vector<list<Student>>& hashtable, int size) {
    for (int i = 0; i < size; ++i) {
        cout << "Chi so " << i << " : ";
        for (const auto& student : hashtable[i])
            cout << "(" << student.mssv << "," << student.name << ") -> ";
        cout << "NULL\n";
    }
}

vector <Student> init_linear(int size) {
	return vector<Student>(size);
}

void insert_linear(vector<Student>& hashtable, int size, Student student) {
	int index = student.mssv % size;
	while (hashtable[index].mssv % size)
		index = (index + 1) % size;
	hashtable[index] = student;
}

string search_linear(vector<Student>& hashtable, int size, int MSSV) {
	int index = MSSV % size;
	int start = index;
	while (hashtable[index].mssv != 0) {
		if (hashtable[index].mssv == MSSV)
			return hashtable[index].name;

		index = (index + 1) % size;
		if (index == start)
			break;
	}
	return "Khong tim thay !";

}

void insert_bac2(vector<Student>& hashtable, int size, Student student) {
	int index = student.mssv % size;
	int i = 1;

	while (hashtable[index].mssv != 0)
	{
		index = (index + i * i) % size;
		i++;
	}
	hashtable[index] = student;
}

string search_bac2(vector<Student>& hashtable, int size, int MSSV) {
	int index = MSSV % size;
	int i = 1;
	while (hashtable[index].mssv != 0) {
		if (hashtable[index].mssv == MSSV)
			return hashtable[index].name;
		index = (index + i * i) % size;
		i++;
		if (i > size)
			break;
	}
	return "Khong tim thay !";
	
}

int bam_kep(int key, int size) {
	return 1 + (key % (size - 1));
}

void insert_bamkep(vector<Student>& hashtable, int size, Student student) {
	int index = student.mssv % size;
	int step = bam_kep(student.mssv, size);

	while (hashtable[index].mssv != 0)
		index = (index + step) % size;
	hashtable[index] = student;
}

string search_bamkep(vector<Student>& hashtable, int size, int MSSV)
{
	int index = MSSV % size;
	int step = bam_kep(MSSV, size);
	int start = index;

	while (hashtable[index].mssv != 0)
	{
		if (hashtable[index].mssv == MSSV)
			return hashtable[index].name;

		index = (index + step) % size;
		if (index == start)
			break;
	}
	return "Khong tim thay !";
}

int main()
{
    const int SIZE = 13;
    int method, choice;

    vector<list<Student>> hashtableChaining;
    vector<Student> hashtableLinear;

    cout << "Chon phuong phap xu ly xung dot:\n";
    cout << "1. Noi ket truc tiep (Chaining)\n";
    cout << "2. Dia chi mo - Do tuyen tinh (Linear Probing)\n";
    cout << "3. Dia chi mo - Do bac 2 (Quadratic Probing)\n";
    cout << "4. Dia chi mo - Bam kep (Double Hashing)\n";
    cout << "Lua chon :  ";
    cin >> method;

    if (method == 1)
        hashtableChaining = init_chaining(SIZE);
    else
        hashtableLinear = init_linear(SIZE);

    while (true) {
        cout << "\Menu: ";
        cout << "1. Them sinh vien\n";
        cout << "2. Tra cuu sinh vien\n";
        cout << "3. Hien thi bang bam\n";
        cout << "4. Thoat\n";
        cout << "Nhap lua chon cua ban: ";
        cin >> choice;

        if (choice == 4) break;

        switch (choice) {
        case 1: {
            int MSSV;
            string name;
            cout << "Nhap MSSV: ";
            cin >> MSSV;
            cout << "Nhap ten sinh vien: ";
            cin.ignore();
            getline(cin, name);
            Student student(MSSV, name);

            if (method == 1) insert_chaining(hashtableChaining, SIZE, student);
            else if (method == 2) insert_linear(hashtableLinear, SIZE, student);
            else if (method == 3) insert_bac2(hashtableLinear, SIZE, student);
            else if (method == 4) insert_bamkep(hashtableLinear, SIZE, student);

            cout << "Them sinh vien thanh cong.\n";
            break;
        }
        case 2: {
            int MSSV;
            cout << "Nhap MSSV can tra cuu: ";
            cin >> MSSV;

            string result;
            if (method == 1) result = search_chaining(hashtableChaining, SIZE, MSSV);
            else if (method == 2) result = search_linear(hashtableLinear, SIZE, MSSV);
            else if (method == 3) result = search_bac2(hashtableLinear, SIZE, MSSV);
            else if (method == 4) result = search_bamkep(hashtableLinear, SIZE, MSSV);

            cout << (result != "Khong tim thay !" ? "Ten sinh vien: " + result : result) << endl;
            break;
        }
        case 3: {
            if (method == 1) display(hashtableChaining, SIZE);
            else {
                cout << "Bang bam:\n";
                for (int i = 0; i < SIZE; ++i) {
                    if (hashtableLinear[i].mssv != 0) {
                        cout << "Chi so " << i << ": (" << hashtableLinear[i].mssv << ", "
                            << hashtableLinear[i].name << ")\n";
                    }
                    else {
                        cout << "Chi so " << i << ": NULL\n";
                    }
                }
            }
            break;
        }
        default:
            cout << "Lua chon khong hop le.\n";
            break;
        }
    }

    return 0;

}