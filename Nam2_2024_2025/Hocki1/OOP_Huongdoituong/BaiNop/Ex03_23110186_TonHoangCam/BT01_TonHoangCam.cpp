/* Ton Hoang Cam 
   23110186 */
#include <iostream>
using namespace std;

class CPhanSo{
	public:
		int tu;
		int mau;
	
		
		int findmax_uoc(int num1, int num2)
		{
			while ( num1!= 0)
			{
				int temp = num1;
				num1 = num2 % num1;
				num2 = temp;
			}
			return num2;
		}
		
		void rutgon()
		{
			int max_uoc = findmax_uoc(tu, mau);
			tu /= max_uoc;
			mau /= max_uoc;
		}
		
		void nhap()
		{
			cout << "Nhap tu:";
			cin >> tu;
			cout << "Nhap mau:";
			cin >> mau;
			cout << endl;
		}
		
		void xuat()
		{
			cout << tu << "/" << mau; 
		}
		
		// Ton Hoang Cam 
		CPhanSo()
		{
			tu = 0;
			mau = 1;
		}
		
		// Ton Hoang Cam
		CPhanSo(int tuso)
		{
			tu = tuso;
			mau = 1;
		}
		
		// Ton Hoang Cam
		CPhanSo(int tuso, int mauso)
		{
			tu = tuso;
			if(mauso != 0)
				mau = mauso;
			else
			{
				cout << "Mau so khong hop le! Tu dong dat mau so bang 1 !\n";
				mau = 1;
			}
		}
		
		// Ton Hoang Cam
		CPhanSo(const CPhanSo &other)
		{
			tu = other.tu;
			mau = other.mau;
		}
		// Ton Hoang Cam
		CPhanSo operator+(const CPhanSo &other)
		{
			CPhanSo sum;
			sum.tu = tu*other.mau + other.tu * mau;
			sum.mau = mau * other.mau;
			sum.rutgon();
			return sum;
		}
		// Ton Hoang Cam
		CPhanSo operator-(const CPhanSo &other)
		{
			CPhanSo hieu;
			hieu.tu = tu*other.mau - other.tu * mau;
			hieu.mau = mau * other.mau;
			hieu.rutgon();
			return hieu;
		}
		// Ton Hoang Cam
		CPhanSo operator*(const CPhanSo &other )
		{
			CPhanSo tich;
			tich.tu = tu * other.tu;
			tich.mau = mau * other.mau;
			tich.rutgon();
			return tich;
		}
		// Ton Hoang Cam
		CPhanSo operator/(const CPhanSo &other)
		{
			CPhanSo thuong;
			thuong.tu = tu * other.mau;
			thuong.mau = mau * other.tu;
			thuong.rutgon();
			return thuong;
		}
		// Ton Hoang Cam
		CPhanSo operator++()
		{
			return *this + CPhanSo(1);
		}
		// Ton Hoang Cam
		CPhanSo operator--()
		{
			return *this - CPhanSo(1);
		}
		// Ton Hoang Cam
		bool operator>(const CPhanSo &other)
		{
			return (tu * other.mau) > (other.tu * mau);
		}
		// Ton Hoang Cam
		bool operator<(const CPhanSo &other)
		{
			return (tu * other.mau) < (other.tu * mau);
		}
		// Ton Hoang Cam
		bool operator>=(const CPhanSo &other)
		{
			return (tu * other.mau) > (other.tu * mau);
		}
		// Ton Hoang Cam
		bool operator<=(const CPhanSo &other)
		{
			return (tu * other.mau) <= (other.tu * mau);
		}
		// Ton Hoang Cam
		bool operator==(const CPhanSo &other)
		{
			return (tu * other.mau) == (other.tu * mau);
		}
		// Ton Hoang Cam
		CPhanSo operator=(const CPhanSo &other)
		{
			if (this != &other)
			{
				tu = other.tu;
				mau = other.mau;
			}
			return *this;
		}
		// Ton Hoang Cam
		CPhanSo operator+=(const CPhanSo &other)
		{
			*this = *this + other;
			return *this;
		}
		// Ton Hoang Cam
		CPhanSo operator-=(const CPhanSo &other)
		{
			*this = *this - other;
			return *this;
		}
		// Ton Hoang Cam
		CPhanSo operator*=(const CPhanSo &other)
		{
			*this = *this * other;
			return *this;
		}
		// Ton Hoang Cam
		CPhanSo operator/=(const CPhanSo &other)
		{
			*this = *this / other;
			return *this;
		}
		// Ton Hoang Cam
		friend istream &operator>>(istream &in, CPhanSo &phanso )
		{
			in >> phanso.tu >> phanso.mau;
			if(phanso.mau == 0)
			{
				cout << "Mau khong hop le! Tu dong dat mau so ve 1\n";
				phanso.mau =1;
			}
			phanso.rutgon();
			return in;
		}
		// Ton Hoang Cam
		friend ostream &operator<<(ostream &out, const CPhanSo &phanso)
		{
			out << phanso.tu << "/" << phanso.mau;
			return out;
		}
};

void menu() {
    cout << "Menu: \n";
    cout << "1. Tong cua 2 phan so\n";
    cout << "2. Hieu cua 2 phan so\n";
    cout << "3. Tich cua 2 phan so\n";
    cout << "4. Thuong cua 2 phan so\n";
    cout << "5. Cong 1 vao phan so 1\n";
    cout << "6. Tru 1 cho phan so 1\n";
    cout << "7. Kiem tra phan so 1 > phan so 2\n";
    cout << "8. Kiem tra phan so 1 < phan so 2\n";
    cout << "9. Kiem tra phan so 1 >= phan so 2\n";
    cout << "10. Kiem tra phan so 1 <= phan so 2\n";
    cout << "11. Kiem tra phan so 1 = phan so 2\n";
    cout << "12. Gan mot phan tu 2 cho phan tu 1\n";
    cout << "13. Cap nhat phan so 1 = tong cua phan so 1 voi mot phan so khac\n";
    cout << "14. Cap nhat phan so 1 = hieu cua phan so 1 voi mot phan so khac\n";
    cout << "15. Cap nhat phan so 1 = tich cua phan so 1 voi mot phan so khac\n";
    cout << "16. Cap nhat phan so 1 = thuong cua phan so 1 voi mot phan so khac\n";
}

int main() {
    CPhanSo phanso1;
    CPhanSo phanso2;
    cout << "Nhap vao gia tri 2 phan so : \n";
    cout << "Nhap vao phan so 1 :\n";
    phanso1.nhap();
    cout << "Nhap vao phan so 2 :\n";
    phanso2.nhap();  

    menu();
    int choice;
   	do {
        cout << "\nLua chon : ";
        cin >> choice;
        if ( choice < 0 || choice > 16)
        	break;
        CPhanSo temp;
        switch (choice) 
		{
            case 1:
                cout << "Tong cua 2 phan so: " << phanso1 + phanso2 << endl;
                break;
            case 2:
                cout << "Hieu cua 2 phan so: " << phanso1 - phanso2 << endl;
                break;
            case 3:
                cout << "Tich cua 2 phan so: " << phanso1 * phanso2 << endl;
                break;
            case 4:
                cout << "Thuong cua 2 phan so: " << phanso1 / phanso2 << endl;
                break;
            case 5:
                cout << "Cong 1 vao phan so 1: " << ++phanso1 << endl;
                break;
            case 6:
                cout << "Tru 1 cho phan so 1: " << --phanso1 << endl;
                break;
            case 7:
                cout << "Kiem tra phan so 1 > phan so 2: " << (phanso1 > phanso2) << endl;
                break;
            case 8:
                cout << "Kiem tra phan so 1 < phan so 2: " << (phanso1 < phanso2) << endl;
                break;
            case 9:
                cout << "Kiem tra phan so 1 >= phan so 2: " << (phanso1 >= phanso2) << endl;
                break;
            case 10:
                cout << "Kiem tra phan so 1 <= phan so 2: " << (phanso1 <= phanso2) << endl;
                break;
            case 11:
                cout << "Kiem tra phan so 1 = phan so 2: " << (phanso1 == phanso2) << endl;
                break;
            case 12:
                temp = phanso1; 
                phanso1 = temp;
                cout << "Phan so 1 sau khi gan: " << phanso1 << endl;
                break;
            case 13:
                phanso1 += phanso2;
                cout << "Phan so 1 sau khi cap nhat bang tong: " << phanso1 << endl;
                break;
            case 14:
                phanso1 -= phanso2;
                cout << "Phan so 1 sau khi cap nhat bang hieu: " << phanso1 << endl;
                break;
            case 15:
                phanso1 *= phanso2;
                cout << "Phan so 1 sau khi cap nhat bang tich: " << phanso1 << endl;
                break;
            case 16:
                phanso1 /= phanso2;
                cout << "Phan so 1 sau khi cap nhat bang thuong: " << phanso1 << endl;
                break;
            case 0:
                cout << "Thoat chuong trinh.\n";
                break;
            default:
                cout << "Lua chon khong hop le. Vui long chon lai.\n";
                break;
        }
    } while (choice != 0);

	return 0;
}

