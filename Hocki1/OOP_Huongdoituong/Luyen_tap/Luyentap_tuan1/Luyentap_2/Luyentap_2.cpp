#include <iostream>
using namespace std;

class phanso {
private:
	int tu;
	int mau;
public:
	phanso(phanso& x)
	{
		this->tu = x->tu;
		this->mau = x->mau;
	}
	void nhap_phanso()
	{
		cout << "Nhap tu:";
		cin >> this->tu;
		cout << "Nhap mau:";
		cin >> this->mau;
		while (mau <= 0)
		{
			cout << "Khong hop le, vui long nhap lai : ";
			cin >> this->mau;
		}
	}

	void xuat()
	{
		cout << this->tu << "/" << this->mau;
	}

	phanso* nhan(phanso* x)
	{
		phanso* kq = new phanso();
		if (x->tu != NULL && x->mau != NULL)
		{
			kq->tu = this->tu * x->tu;
			kq->mau = this->mau * x->mau;
		}
		return kq;
	}
	phanso* nhan(int x)
	{
		phanso* kq = new phanso();
		if (x != NULL)
		{
			kq->tu = this->tu * x;
			kq->mau = this->mau * x;
		}
		return kq;
	}

};


int main()
{
	phanso* a = new phanso(), * b = new phanso(), * c = new phanso();
	a->nhap_phanso();
	b->nhap_phanso();

	c = a->nhan(b);
	cout << "Tich cua 2 phan so a, b la :";
	c->xuat();

	int n;
	cout << "Nhap vao so n muon tinh tich voi phan so a :";
	cin >> n;
	c = a->nhan(n);
	c->xuat();
	return 0;
}