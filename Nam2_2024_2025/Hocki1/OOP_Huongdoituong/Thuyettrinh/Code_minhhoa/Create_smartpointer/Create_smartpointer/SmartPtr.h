//SmartPtr.h
#ifndef SMARTPTR_H
#define SMARTPTR_H

#include <iostream>
class SmartPtr {
private:
	// Actual Pointer (con trỏ thực tế ) được wrap bởi object
	int* ptr = nullptr;
public:// Tai constructor, nhận con trỏ tới vùng nhớ đã cấp phát
	SmartPtr(int* p)
	{
		ptr = p;
	}

	~SmartPtr()
	{
		if (ptr)
		{
			delete ptr; // Tại Destructor, giải phóng bộ nhớ
		}
	}

	int& operator*() const   //// OverLoading toán tử dereference * để sử dụng object như 1 con trỏ bình thường
	{
		return *ptr;
	}
};

#endif // SMARTPTR_H