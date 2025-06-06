#include <iostream>
#include <memory> 

using namespace std;

int main() 
{
    // Tạo một shared_ptr quản lý vùng nhớ heap chứa giá trị 100
    shared_ptr<int> p1(new int(100));

    // Tạo một weak_ptr trỏ tới cùng vùng nhớ mà p1 quản lý
    weak_ptr<int> p2(p1);

    // In reference count của shared_ptr
    cout << "Reference count of p1: " << p1.use_count() << endl;  // Kết quả vẫn là 1

    return 0;
}
