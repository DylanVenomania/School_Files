/* Ton Hoang Cam 
   23110186 */
#include <iostream>
using namespace std;

class CPhanSo{
	private:
		int tu;
		int mau;
	
	public:	
		CPhanSo()
		{
			this->tu = 0;
			this->mau = 1;
		}
		
		//Ton Hoang Cam
		void chuanHoa()
		{
			if(this->tu == 0)
			{
				this->tu = 0;
				this->mau = 1;
			}
			else
			{
				if(this->mau < 0)
				{
					this->tu = -(this->tu);
					this->mau = -(this->mau);
				}
			}
		}
		
		
		//Ton Hoang Cam
		void nhap()
		{
			cout << "Nhap tu : ";
			cin>> this->tu;
			
			cout << "Nhap mau : ";
			cin >> this->mau;
			chuanHoa();
		}
		
		//Ton Hoang Cam
		void xuat()
		{
			cout << this->tu << "/" << this->mau;
		}
			
	
		int max_uocchung(CPhanSo other)
		{
			if(other.tu == 0)
				return -1;
				
			int temptu = other.tu;
			if(other.tu < 0)
				temptu = -(other.tu);
				
			int tempmau = other.mau;
			while(temptu != tempmau)
			{
				if(temptu > tempmau)
					temptu = temptu - tempmau;
				else
					tempmau = tempmau - temptu;
			}
			return temptu;
		}
		
		//Ton Hoang Cam
		void rutGon(CPhanSo &other)
		{
			if(max_uocchung(other) == -1)
				return;
			int uocchunglonnhat = max_uocchung(other);
			other.tu = other.tu/uocchunglonnhat;
			other.mau = other.mau/uocchunglonnhat;
		}
		
		//Ton Hoang Cam
		CPhanSo cong(CPhanSo y)
		{
			CPhanSo ketqua;
			if(this->mau == y.mau)
			{
				ketqua.tu = this->tu + y.tu;
				ketqua.mau = this->mau;
				rutGon(ketqua);
			}
			else
			{
				ketqua.tu = ( this->tu * y.mau ) + (this->mau * y.tu );
				ketqua.mau = this->mau * y.mau;
				rutGon(ketqua);
			}
			return ketqua;
		}
		
		
		//Ton Hoang Cam
		CPhanSo nhan(CPhanSo y)
		{
			CPhanSo ketqua;
			
			ketqua.tu = this->tu * y.tu;
			ketqua.mau = this-> mau * y.mau;
			rutGon(ketqua);
			
			return ketqua;
		}
		
		
		//Ton Hoang Cam
		bool soSanhBang(CPhanSo y)
		{
			CPhanSo temp = y;
			if(this->mau == temp.mau && this->tu == temp.tu)
				return true;
			return false;
		}
		
		
		//Ton Hoang Cam
		bool soSanhBe(CPhanSo y)
		{
			float temp1 = this->tu / this->mau;
			float temp2 = y.tu / y.mau;
			
			if(temp1 < temp2)
				return true;
			return false;
		}
		
		
		//Ton Hoang Cam
		CPhanSo &gan(CPhanSo y)
		{
			this->tu = y.tu;
			this->mau = y.mau;
		}
		
		//Ton Hoang Cam
		CPhanSo &gan(int k)
		{
			this->tu = k;
			this->mau = 1;
		}

};



int main()
{
	CPhanSo phanso1;
	CPhanSo phanso2;
	cout << "Nhap vao phan so 1 \n";
	phanso1.nhap();                      //ham chuan hoa duoc dat trong ham nhap()
	cout << "Phan so 1 la :";
	phanso1.xuat();
	cout << endl;
	
	cout << "\nNhap vao phan so 2 \n";
	phanso2.nhap();                      //ham chuan hoa duoc dat trong ham nhap()
	cout << "Phan so 2 la :";
	phanso2.xuat();
	cout << endl;
	
	
	cout << "Menu: \n";
	cout << "1. Tong cua 2 phan so\n";
	cout << "2. Tich cua 2 phan so\n";
	cout << "3. Kiem tra 2 phan so co bang nhau khong\n";
	cout << "4. Kiem tra phan so "; phanso1.xuat(); cout << " co be hon phan so "; phanso2.xuat(); cout << " khong :\n";
	cout << "5. Gan gia tri cua mot phan so bat ki cho phan so 1\n";
	cout << "6. Gan gia tri cua mot so nguyen bat ki cho phan so 1\n";
	int choose;
	cin >> choose;
	while( choose != 0)
	{
		
			switch(choose)
			{
				case(1):
					{
						cout << "\nTong cua 2 phan so la: ";    
						phanso1.cong(phanso2).xuat();                 // ham rutGon() duoc dat trong ham cong()
						cout << endl;
						break;
					}
				case(2):
					{
						cout << "\nTich cua 2 phan so la: ";
						phanso1.nhan(phanso2).xuat();                // ham rutGon() duoc dat trong ham nhan()
						cout << endl;
						break;
					}
				case(3):
					{
						if( phanso1.soSanhBang(phanso2) == true )
							cout << "\n2 phan so bang nhau !\n";
						else
							cout << "\n2 phan so khong bang nhau !\n" << endl;
						break;
					}
				case(4):
					{
						if( phanso1.soSanhBe(phanso2) == true )
							cout << "\nPhan so 1 be hon phan so 2 !\n";
						else
							cout << "\nPhan so 1 khong be hon phan so 2 !\n" << endl;
						break;
					}
				case(5):
					{
						CPhanSo temp;
						cout << "\nNhap phan so ma ban muon gan gia tri cho phan so 1 :\n";
						temp.nhap();
						cout << endl;
						cout << "\nGan gia tri "; temp.xuat(); cout << " cho phan so 1\n";
						phanso1.gan(temp);
						cout << "\nPhan so 1 = ";
						phanso1.xuat();
						cout << endl;
						break;
					}
				case(6):
					{
						int temp;
						cout << "\nNhap mot so nguyen muon gan cho phan so 1 :";
						cin >> temp;
						
						cout << "\n\nGia tri cua phan so 1 sau khi gan gia tri " << temp << " la : ";
						phanso1.gan(temp);
						phanso1.xuat();
						break;
					}
			}
	cout << endl;
	cout << "\nNhap lua chon cua ban, chon 0 de ket thuc :";
	cin >> choose;
	}
	
	return 0;
}

