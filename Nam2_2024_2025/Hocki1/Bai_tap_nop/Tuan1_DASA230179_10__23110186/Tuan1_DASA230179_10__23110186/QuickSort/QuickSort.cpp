/*
Ton Hoang Cam
23110186
*/
#include <iostream>
using namespace std;
int n;

void swap(int array[], int a, int b)
{
	int tempt;
	tempt = a;
	a = b;
	b = tempt;
}

void sapxep(int array[], int left, int right)
{
	int i = left, j = right;
	int giatri = array[(left + right) / 2];
	while (i < j)
	{
		while (array[i] < giatri)
			i++;
		while (array[j] > giatri)
			j--;
		if (i <= j)
		{
			swap(array[i], array[j]);
			i++;
			j--;
		}
	}
	if (j > left)
		sapxep(array, left, j);
	if (i < right)
		sapxep(array, i, right);
}

int main()
{
	int array[1000];
	cin >> n;
	for (int i = 0; i < n; i++)
		cin >> array[i];

	int left = 0, right = n - 1;

	sapxep(array, left, right);
	for (int i = 0; i < n; i++)
		cout << array[i] << " ";
	return 0;
}
