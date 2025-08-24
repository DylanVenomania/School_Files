#include <iostream>
using namespace std;

class CPhanSo {
private:
	int tu;
	int mau;

public:
	CPhanSo()
	{
		this->tu = 0;
		this->mau = 1;
	}

	CPhanSo(int newtu, int newmau)
	{
		this->tu = newtu;
		this->mau = newmau;
	}

	//Ton Hoang Cam
	void chuanHoa()
	{
		if (this->tu == 0)
		{
			this->tu = 0;
			this->mau = 1;
		}
		else
		{
			if (this->mau < 0)
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
		cin >> this->tu;

		cout << "Nhap mau : ";
		cin >> this->mau;
		chuanHoa();
	}


	CPhanSo operator+(const CPhanSo& other)
	{
		int newTu = this->tu * other.mau + other.tu * this->mau;
		int newMau = this->mau * other.mau;
		CPhanSo ketqua(newTu, newMau);
		return ketqua;
	}

	CPhanSo operator++()        //++phanso
	{
		this->tu += this->mau;
		return  *this;
	}

	CPhanSo operator++(int n)        //phanso++
	{
		CPhanSo temp = *this;        // luu lai gia tri cu
		this->tu += this->mau;
		return  temp;
	}

	friend ostream &operator<<(ostream& out, const CPhanSo &ps);

};

ostream &operator<<( ostream &out, const CPhanSo &ps)
{
	out << ps.tu << "/" << ps.mau;
	return out;
}


int main()
{
	CPhanSo phanso1;
	phanso1.nhap();
	
	CPhanSo phanso2;
	phanso2.nhap();
	CPhanSo phanso3 = phanso1 + phanso2;
	

	cout << phanso3 << endl;
	++phanso3;
	cout << phanso3 << endl;
	phanso3++;
	cout << phanso3;


	return 0;
}