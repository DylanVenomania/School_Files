#include <iostream>
#include <string>
#include <math.h>
using namespace std;

class Khoa{
	public:
		string tenkhoa;
		int namthanhlap;
	
		void nhap()
		{
			cin.ignore();
			cout << "Nhap ten khoa : ";
			getline(cin, tenkhoa);
			cout << "Nhap nam thanh lap : ";
			cin >> namthanhlap;
			cout << endl;
		}
		
		void xuat()
		{
			cout << "Khoa : " << tenkhoa << endl;
			cout << "Nam thanh lap : " << namthanhlap << endl;
			cout << endl;
		}
};

class svChinhquy{
	private :
		int mssv;
		string hoten;
		float dtb;
		float diemkhoaluan;
		Khoa *khoa;
	public :
		void nhap()
		{
			cout <<"Nhap ma so sinh vien ";
			cin >> mssv;
			cout << "Nhap ho ten sinh vien : ";
			cin.ignore();
			getline(cin, hoten);
			cout << "Diem khoa luan : ";
			cin >> diemkhoaluan;
			cout << "Nhap khoa cua sinh vien \n";
			khoa->nhap();
		}
		
		float tinhDiemtotnghiep()
		{
			float result = dtb*0.8 + diemkhoaluan*0.2;
			return result;
		}
		
		void xuat()
		{
			cout << "Ma so sinh vien : "<< mssv << endl;;
			cout << "Ho ten sinh vien : " << hoten << endl;
			cout << "Diem khoa luan : " << diemkhoaluan << endl;
			khoa->xuat();
		}
};

class svVanbang2{
	private :
		int mssv;
		string hoten;
		float dtb;
		float diemlythuyet;
		float diemthuchanh;
		Khoa *khoa;
	public :
		void nhap()
		{
			cout <<"Nhap ma so sinh vien ";
			cin >> mssv;
			cout << "Nhap ho ten sinh vien : ";
			cin.ignore();
			getline(cin, hoten);
			cout << "Diem ly thuyet : ";
			cin >> diemlythuyet;
			cout << "Diem thuc hanh : ";
			cin >> diemthuchanh;
			cout << "Nhap khoa cua sinh vien \n";
			khoa->nhap();
		}
		
		float tinhDiemtotnghiep()
		{
			float result = dtb*0.4 + (diemlythuyet + diemthuchanh)*0.3;
			return result;
		}
		
		void xuat()
		{
			cout << "Ma so sinh vien : "<< mssv << endl;;
			cout << "Ho ten sinh vien : " << hoten << endl;;
			cout << "Diem ly thuyet : " << diemlythuyet << endl;
			cout << "Diem thuc hanh : " << diemthuchanh << endl;
			khoa->xuat();
		}
};


class program{
	
};

int main()
{
	svVanbang2 sv1;
	sv1.nhap();
	sv1.xuat();
	return 0;
}
