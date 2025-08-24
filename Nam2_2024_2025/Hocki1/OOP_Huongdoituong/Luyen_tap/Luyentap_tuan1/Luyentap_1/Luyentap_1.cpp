#include <iostream>
using namespace std;

class phanso {
private:
	int tu;
	int mau;
public:
	void nhap()
	{
		cout << "Nhap tu : ";
		cin >> this->tu;
		cout << "Nhap mau : ";
		cin >> this->mau;
	};
	void xuat()
	{
		cout << this->tu << "/" << this->mau;
	}

	phanso* nhan(phanso* x)
	{
		phanso* kq = new phanso();
		kq->tu = this->tu * x->tu;
		kq->mau = this->mau * x->mau;
		return kq;
	}
};

int main()
{
	phanso* a = new phanso();
	a->nhap();
	phanso* b = new phanso();
	b->nhap();
	phanso* c = new phanso();
	c = a->nhan(b);
	c->xuat();
	return 0;
}
