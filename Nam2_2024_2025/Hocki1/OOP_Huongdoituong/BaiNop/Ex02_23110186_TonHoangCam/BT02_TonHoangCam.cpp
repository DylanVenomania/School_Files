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
		//Ton Hoang Cam
		ClntArray( const ClntArray &other)   // tao lap sao chep
		{
			this->size = other.size;
			this->array = other.array;
		}
		//Ton Hoang Cam
		ClntArray(int *otherArray)
		{
			this->size = sizeof(otherArray) / sizeof(otherArray[0]);
			this->array = new int[size];
			for(int i = 0; i< size; i++)
				array[i] = otherArray[i];
		}
		//Ton Hoang Cam
		~ClntArray()
		{
			delete[] array;
		}
		//Ton Hoang Cam
		void input()
		{
			cout << "Nhap vao so luong phan tu cho mang : ";
			cin >> size;
			
			this->array = new int[size];
			cout << "Nhap vao cac phan tu : ";
			for(int i = 0; i < size; i++)
				cin >> array[i];
		}
		//Ton Hoang Cam
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
		void addElement(int val)
		{
			int *newArray = new int[size+1];
			for(int i = 0; i < size; i++)
				newArray[i] = array[i];
				
			newArray[size] = val;
			delete[] array;
			array = newArray;
			size++;
		}
		//Ton Hoang Cam
		void addElement(int *p, int n)
		{
			int *newArray = new int[size + n];
			for(int i = 0; i < size; i++)
				newArray[i] = array[i];
			for(int i = 0; i< n; i++)
				newArray[size + i] = p[i];
			
			delete[] array;
			array = newArray;
			size = size + n;
		}
		//Ton Hoang Cam
		int getElement(int idx)
		{
			for(int i = 0; i< size; i++)
				if(i == idx)
					return array[i-1];
			return -1;
		}
		//Ton Hoang Cam
		int getSize()
		{
			return size;
		}
		//Ton Hoang Cam
		int getSum()
		{
			int sum = 0;
			for(int i = 0; i< size; i++)
				sum += array[i];
			return sum;
		}
		//Ton Hoang Cam
		int getMax()
		{
			int max = array[0];
			for(int i = 1; i < size; i++)
				if( array[i] > max )
					max = array[i];
			return max;
		}
		
		bool isEven(int num)
		{
			if(num % 2 == 0)
				return true;
			return false;
		}
		//Ton Hoang Cam
		ClntArray getEven()
		{
			ClntArray even;
			for(int i =0; i< size; i++)
				if( isEven(array[i]) )
					even.addElement(array[i]);
			return even;
		}
		//Ton Hoang Cam
		void erase(int idx)
		{
			int *new_array = new int[size -1];
			int dem = 0;
			for(int i = 0; i< size; i++)
				if( i != idx - 1 )
				{
					new_array[dem] = array[i];
					dem++;
				}
			delete[] array;
			array = new_array;
			size--;
		}
		//Ton Hoang Cam
		void insert(int idx, int val)
		{
			if (idx < 0 || idx > size) 
			{
            	cout << "Khon hop le !" << endl;
            	return;
        	}
        	int* newArray = new int[size + 1];
        	for (int i = 0, j = 0; i < size + 1; i++) 
			{
            if (i == idx) 
			{
                newArray[i] = val;
            } 
			else 
			{
                newArray[i] = array[j++];
            }
        }
        delete[] array;
        array = newArray;
        size++;
		}
		
		ClntArray &operator=(const ClntArray &other)
		{
			if(this == &other)
				return *this;
			if(other.size > 0)
			{
				this->size = other.size;
				if(this->array != NULL)
					delete[] this->array;
				this->array = new int[this->size];
				for(int i =0; i< this->size; i++)
					this->array[i] = other.array[i];
				return *this;
			}
			this->size =0;
			if( this->array != NULL)
				delete[] this->array;
			this->array = NULL;
			return *this;
		}
		
};

int main()
{
	ClntArray arr;
	arr.print();
	
	arr.input();
	arr.print();
	
	/*int num;
	cout << "Nhap vao gia tri muon chen vao mang : ";
	cin >> num;
	arr.addElement(num);
	arr.print();
	
	int *lst, n;
	cout << "Nhap so luong phan tu cho mang muon chen vao : ";
	cin >> n;
	
	cout << "Nhap phan tu mang muon chen vao : ";
	lst = new int[n];
	for(int i=0; i<n; i++)
		cin >> lst[i];
		
	arr.addElement(lst, n);
	arr.print();
	
	int index;
	cout << "Nhap vi tri ma ban muon lay gia tri trong mang :";
	cin >> index;
	
	if(arr.getElement(index) == -1)
		cout << "Vi tri khong hop le ! ";
	else	
		cout << "\nGia tri trong mang o vi tri " << index << " la: " << arr.getElement(index);
	
	cout << "\nSo luong phan tu trong mang la : " << arr.getSize(); 
	
	cout << "\nTong cac phan tu trong mang la : " << arr.getSum();
	
	cout << "\nGia tri lon nhat trong mang la : " << arr.getMax() << endl;
	
	cout << "\nMang so chan tu mang goc : ";
	arr.getEven().print();
	
	int vitri;
	cout << "Nhap vi tri muon xoa gia tri trong mang : ";
	cin >> vitri;
	arr.erase(vitri);
	arr.print();
	
	int vitrichen;
	int giatrichen;
	cout << "Nhap vao vi tri muon chen : ";
	cin >> vitrichen;
	cout << "Nhap vao gia tri muon chen vao mot vi tri trong mang : ";
	cin >> giatrichen;
	arr.insert(vitrichen, giatrichen);
	arr.print(); */
	
	ClntArray lst;
	cout << "Nhap gia tri : ";
	lst.input();
	arr = lst;
	arr.print();
	return 0;
}
