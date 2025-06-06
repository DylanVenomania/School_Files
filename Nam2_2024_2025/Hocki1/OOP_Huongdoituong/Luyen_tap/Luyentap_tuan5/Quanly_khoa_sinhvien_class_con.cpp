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
			cout << "Nhap ten khoa : ";
			cin.ignore();
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

class sinhvien{
	
	protected :
		int mssv;
		string hoten;
		float dtb;
		float diemkhoaluan;
		Khoa khoa;
	public :
		void nhap()
		{
			cout <<"Nhap ma so sinh vien ";
			cin >> mssv;
			cout << "Nhap ho ten sinh vien : ";
			cin.ignore();
			getline(cin, hoten);
			cout << "Nhap khoa cua sinh vien \n";
			khoa.nhap();
		}
		
		float tinhDiemtotnghiep();
		
		void xuat()
		{
			cout << "Ma so sinh vien : "<< mssv << endl;;
			cout << "Ho ten sinh vien : " << hoten << endl;
			khoa.xuat();
		}
		
};

class svChinhquy :public sinhvien{
	public :
		void nhap()
		{
			sinhvien::nhap();
			cout << "Diem khoa luan : ";
			cin >> diemkhoaluan;
		}
			
		float tinhDiemtotnghiep()
		{
			float result = dtb*0.8 + diemkhoaluan*0.2;
			return result;
		}
		
		void xuat()
		{
			sinhvien::xuat();
			cout << "Diem khoa luan : " << diemkhoaluan << endl;
		}
};
	

class svVanbang2 : public sinhvien{
	private:
		float diemlythuyet;
		float diemthuchanh;
	
	public :
		void nhap()
		{
			sinhvien::nhap();
			cout << "Diem ly thuyet : ";
			cin >> diemlythuyet;
			cout << "Diem thuc hanh : ";
			cin >> diemthuchanh;
		}
		
		float tinhDiemtotnghiep()
		{
			float result = dtb*0.4 + (diemlythuyet + diemthuchanh)*0.3;
			return result;
		}
		
		void xuat()
		{
			sinhvien::xuat();
			cout << "Diem ly thuyet : " << diemlythuyet << endl;
			cout << "Diem thuc hanh : " << diemthuchanh << endl;

		}
};
	




int main()
{
	svChinhquy sv1;
	sv1.nhap();
	sv1.xuat();
	return 0;
}
