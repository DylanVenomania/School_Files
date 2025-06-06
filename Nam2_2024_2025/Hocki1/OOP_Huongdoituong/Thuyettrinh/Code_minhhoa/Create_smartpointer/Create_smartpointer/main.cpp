#include <iostream>
#include "SmartPtr.h"

using namespace std;

// Hàm function sử dụng SmartPtr thay vì con trỏ thông thường
void function() {
    SmartPtr ptr(new int(100)); // SmartPtr wrap con trỏ new int(100)
    *ptr = 200;                 // Nhờ overload toán tử *, sử dụng như con trỏ thường
    cout << "Value inside function: " << *ptr << endl;

    // Destructor sẽ tự động được gọi khi ra khỏi scope, giải phóng bộ nhớ
}

int main() {
    while (1) {
        function(); // Gọi hàm liên tục để kiểm tra tự động giải phóng bộ nhớ
    }
    return 0;
}
