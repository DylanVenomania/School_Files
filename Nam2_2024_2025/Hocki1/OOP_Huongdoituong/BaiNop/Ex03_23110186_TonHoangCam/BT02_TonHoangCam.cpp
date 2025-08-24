/* Ton Hoang Cam
23110186 */
#include <iostream>
using namespace std;

class ClntArray{
	private:
		int *array;
		int size;
		
	public:
		//Ton Hoang Cam
		ClntArray()
		{
			this->array = NULL;
			this->size = 0;
		}
		
		
		ClntArray(int n)
		{
			this->size = n;
			this->array = new int[n]();
		}
		
		//Ton Hoang Cam
		ClntArray( const ClntArray &other)   
		{
			this->size = other.size;
			this->array = new int[size];
        	for (int i = 0; i < size; i++)
            	this->array[i] = other.array[i];
		}
		
		
		//Ton Hoang Cam
		~ClntArray()
		{
			delete[] array;
		}
		
		
		void input()
		{
			cout << "Nhap vao so luong phan tu cho mang : ";
			cin >> size;
			
			this->array = new int[size];
			cout << "Nhap vao cac phan tu : ";
			for(int i = 0; i < size; i++)
				cin >> array[i];
		}
		
		void print()
		{
			cout << "So luong phan tu : ";
			cout << size;
			cout << "\nMang : ";
			for(int i = 0; i < size; i++)
				cout << 
				array[i] << "  ";
			cout << endl;
			
		}
		//Ton Hoang Cam
		ClntArray &operator=(const ClntArray &other) 
		{
		    if (this == &other)
		        return *this;
		    delete[] array; 
		    this->size = other.size;
		    this->array = new int[size];
		    for (int i = 0; i < size; i++)
		        this->array[i] = other.array[i];
		    return *this;
		}
		
		//Ton Hoang Cam
		ClntArray operator+(const ClntArray &other)
		{
		    ClntArray result;
		    result.size = this->size + other.size;
		    result.array = new int[result.size];
		    for (int i = 0; i < this->size; i++)
		        result.array[i] = this->array[i];
		    for (int i = 0; i < other.size; i++)
		        result.array[this->size + i] = other.array[i];
		    return result;
		}
		
		//Ton Hoang Cam  
		ClntArray &operator++() 
		{
		    int *newArray = new int[size + 1];
		    for (int i = 0; i < size; i++)
		        newArray[i] = array[i];
		    newArray[size] = 0; 
		    delete[] array;
		    array = newArray;
		    size++;
		    return *this;
		}
		
		//Ton Hoang Cam  
		ClntArray &operator--() 
		{
		    if (size > 0) 
			{
		    	int *newArray = new int[size - 1];
		        for (int i = 0; i < size - 1; i++)
		            newArray[i] = array[i];
		        delete[] array;
		        array = newArray;
		        size--;
		    }
		    return *this;
		}
		//Ton Hoang Cam
		bool operator>(const ClntArray &other) const 
		{
		    for (int i = 0; i < min(size, other.size); i++) 
			{
		        if (array[i] != other.array[i])
		            return array[i] > other.array[i];
		    }
		    return size > other.size; 
		}
		
		//Ton Hoang Cam
		bool operator<(const ClntArray &other) const 
		{
		    for (int i = 0; i < min(size, other.size); i++) 
			{
		    	if (array[i] != other.array[i])
		            return array[i] < other.array[i];
		    }
		    return size < other.size; 
		}
		
		//Ton Hoang Cam
		bool operator==(const ClntArray &other) const 
		{
		    if (size != other.size) 
				return false;
		    for (int i = 0; i < size; i++) 
			{
		            if (array[i] != other.array[i]) 
						return false;
			}
		    return true;
		}
		//Ton Hoang Cam
		friend istream& operator>>(istream &input, ClntArray &arr)
		{
		    arr.input();
		    return input;
		}
		//Ton Hoang Cam
		friend ostream& operator<<(ostream &output, const ClntArray &arr) 
		{
		    output << "So luong phan tu : " << arr.size << "\nMang : ";
		    for (int i = 0; i < arr.size; i++)
		        output << arr.array[i] << "  ";
		    return output;
		}
};

int main() {
    ClntArray arr1; 
    cout << "Mang 1:\n";
    arr1.input();
    cout << arr1;

    ClntArray arr2(3); 
    cout << "\nMang 2:\n";
    cout << arr2;

   
    ClntArray arr3 = arr1 + arr2;
    cout << "\nMang 3 (arr1 + arr2):\n";
    cout << arr3;

    
    ++arr1;
    cout << "\nMang 1 sau khi tang kich thuoc:\n";
    cout << arr1;

    
    --arr1;
    cout << "\nMang 1 sau khi giam kich thuoc:\n";
    cout << arr1;

    
    cout << "\nMang 1 > Mang 2: " << (arr1 > arr2) << endl;
    cout << "\nMang 1 < Mang 2: " << (arr1 < arr2) << endl;
    cout << "\nMang 1 == Mang 2: " << (arr1 == arr2) << endl;

    return 0;
}
