#include <iostream>
using namespace std;

class rectangle{
	protected:
		double width;
		double height;
	public :
		void input()
		{
			cout <<"Nhap chieu rong : ";
			cin >> width;
			cout << "Nhap chieu dai : ";
			cin >> height;
		}	
		
		void output()
		{
			cout << "Chieu dai : " << height << ",  chieu rong : " << width << endl;
		}
		
		double getarea()
		{
			return width * height;
		}
};

class square : public rectangle{
	public :
		void input()
		{
			cout << "Nhap chieu dai mot canh cho hinh vuong : ";
			cin >> width;
			height = width;
		}
};



int main()
{
	square s;
	s.input();
	cout << "Dien tich : " << s.getarea();
	return 0;
}
