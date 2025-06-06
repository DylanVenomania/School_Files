#include <iostream>
using namespace std;

class intArray {
	private:
		int* arr;
		int size;

	public:
		intArray()
		{
			this->size = 0;
			this->arr = NULL;
		}
		
		intArray(int otherArr[], int other_size)
		{
			if(other_size > 0)
			{
				this->size = other_size;
				this->arr = new int[this->size];
				for(int i =0; i < other_size; i++)
					this->arr[i] = otherArr[i];
			}
			else
			{
				this->arr= NULL;
				this->size = 0;
			}
		}
		
		intArray(const intArray& other)
		{
			this->size = other.size;
			this->arr = new int[this->size];
		}
	
		void input(intArray& a, int size)
		{
			if(this->arr != NULL)
			{
				delete[] this->arr;  //tranh that thoat bo nho
			}
			else
			{
				this->size = size;
				this->arr = new int[this->size];
		
				for(int i =0; i< this->size; i++)
				{
					cin >> this->arr[i];
				}
			}
		}
	
		void print()
		{
			for(int i =0 ;i < this->size; i++)
				cout << this->arr[i] << "  ";
			cout << endl;
		}
};

int main()
{
	
	intArray lst;
	lst.input(lst, 7);
	lst.print();
	return 0;
}
