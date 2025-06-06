#include <iostream>
#include <vector>
#include <math.h>
using namespace std;

class Shape {
public:
    virtual void input()     //Dung Virtual de su dung da hinh o lop cha 
	{
        
    }
    void output() 
	{
        
    }
    virtual double getArea() 
	{
        return 0;
    }
};

class Rectangle: public Shape {
	protected:
	    double width;
	    double height;
	
	public:
	   
	    virtual void input() 
		{
	        cout << "Enter width of the rectangle: ";
	        cin >> width;
	        cout << "Enter height of the rectangle: ";
	        cin >> height;
	    }
	
	    void output() 
		{
	        cout << "Rectangle: width = " << width << ", height = " << height << endl;
	    }
	    
	    double getArea() 
		{
	        return width * height;
	    }
};
class Square : public Rectangle{
	public:
	    void input() 
		{
	        cout << "Enter side of the square: ";
	        cin >> width;
	        height = width;
	    }
		
};

class Triangle : public Shape{
	protected:
		double a, b, c;
		
	public:
		void input()
		{
	        cout << "Enter a, b, c of the triangle: \n";
	        cout << "a : ";
	        cin >> a;
	       	cout << "b : ";
	        cin >> b;
	        cout << "c : ";
	        cin >> c;
		}
		
		virtual double getArea()
		{
			double herong = ( a + b + c) /2;
			return sqrt( herong * (herong - a) * (herong - b) * (herong - c) );
		}
};

void menu(vector<Shape*> &lst)
{
	cout <<"Menu :\n";
	cout << "1. Chu nhat \n";
	cout << "2. Hinh vuong \n";
	cout << "3. Tam giac \n";
	cout << "4. Exit\n";
	
	int choice;
	cout <<"Chon loai hinh muon them vao danh sach : ";
	cin >> choice ;
	cout << endl;
	
	do
	{
		cout <<"Menu :\n";
		cout << "1. Chu nhat \n";
		cout << "2. Hinh vuong \n";
		cout << "3. Tam giac \n";
		cout << "4. Exit\n";
		switch(choice)
		{
			case 1: 
				lst.push_back( new Rectangle);
				break;
			case 2: 
				lst.push_back( new Square);
				break;
			case 3: 
				lst.push_back( new Triangle);
				break;
			default:
				cout << "Lua chon khong hop le, vui long nhap lai !";
				break;
		}
		
		cout <<"Chon loai hinh muon them vao danh sach : ";
		cin >> choice ;
		cout << endl;
		
	}while(choice != 4);
}

int main()
{
	vector<Shape*> lst;
	
	menu(lst);
	
	double allArea;
	for (int i = 0; i < lst.size(); i++)
	{
		lst[i]->input();
		while(lst[i] -> getArea() <= 0)
		{
			cout << "Gia tri cac canh hinh khong hop le ! Vui long nhap lai !";
			lst[i]->input();
		}
		allArea += lst[i]->getArea();
		cout << endl;
	}
	
	cout << "Tong dien tich cac hinh la :  " << allArea << endl; 
	
	
	
	return 0;
}
