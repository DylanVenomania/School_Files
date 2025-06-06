#include <iostream>
#include <memory> 
using namespace std;

int main() 
{
    shared_ptr<int> ptr1(new int(100)); // Tao mot shared_ptr tro toi vung nho heap chua gia tri 100

    shared_ptr<int> ptr2 = ptr1; // Sao chep ptr1 vao ptr2 (2 ptr cung tro vao 1 vung nho )

    cout << ptr1.use_count() << endl; // use_count la 2

    // Khi ptr2 ra khoi scope, use_count giam
    ptr2.reset();  // Giai phong ptr2
    cout << ptr1.use_count() << endl; // use_count giam con 1

    return 0;
}