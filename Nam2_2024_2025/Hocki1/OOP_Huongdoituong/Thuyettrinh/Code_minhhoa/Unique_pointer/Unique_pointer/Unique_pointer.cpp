#include <iostream>
#include <memory>
using namespace std;
int main()
{
	unique_ptr<int> ptr1(new int(100));
	unique_ptr<int> ptr2 = move(ptr1);  // Khong loi vi co the transfer unnique pointer
	unique_ptr<int> ptr3 = ptr2;  		 // Loi vi khong the copy unique pointer
	return 0;
}

